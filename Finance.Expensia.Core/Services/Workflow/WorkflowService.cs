using AutoMapper;
using Finance.Expensia.Core.Services.Workflow.Dtos;
using Finance.Expensia.DataAccess;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Helpers;
using Finance.Expensia.Shared.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace Finance.Expensia.Core.Services.Workflow
{
	public class WorkflowService(ApplicationDbContext dbContext, IMapper mapper, ILogger<WorkflowService> logger) : BaseService<WorkflowService>(dbContext, mapper, logger)
	{
		public async Task<(bool, string)> CreateApprovalWorkflow(DataAccess.Models.OutgoingPayment input, CurrentUserAccessor currentUserAccessor)
		{
			var dataRoleCodes = await _dbContext.UserCompanyRoles
												.Include(ucr => ucr.UserCompany)
												.Include(ucr => ucr.Role)
												.Where(d => d.UserCompany.UserId.Equals(currentUserAccessor.Id))
												.Select(d => d.Role.RoleCode)
												.ToListAsync();

			var workflowRule = await _dbContext.ApprovalRules
											   .FirstOrDefaultAsync(x =>
													x.MinAmount <= input.TotalAmount
													&& input.TotalAmount <= x.MaxAmount
													&& x.Level == 1);

			if (workflowRule == null)
				return (false, string.Empty);

			var firstRoleApprover = await _dbContext.ApprovalRules
													.FirstOrDefaultAsync(x => 
														x.TransactionTypeCode == input.TransactionTypeCode 
														&& x.MinAmount == workflowRule.MinAmount 
														&& x.MaxAmount == workflowRule.MaxAmount 
														&& x.Level == 2);

			if (firstRoleApprover == null)
				return (false, string.Empty);

			var dataInbox = new ApprovalInbox
			{
				ApprovalLevel = 2,
				ApprovalRoleCode = firstRoleApprover.RoleCode,
				ApprovalStatus = ApprovalStatus.WaitingApproval,
				TransactionTypeCode = input.TransactionTypeCode,
				TransactionNo = input.TransactionNo,
				MinAmount = workflowRule.MinAmount,
				MaxAmount = workflowRule.MaxAmount
			};

			await _dbContext.ApprovalInboxes.AddAsync(dataInbox);

			var dataHistory = new ApprovalHistory
			{
				ApprovalLevel = 1,
				ExecutorName = input.Requestor,
				ExecutorRoleCode = string.Empty,
				ExecutorRoleDesc = string.Empty,
				ApprovalStatus = ApprovalStatus.Submitted,
				ApprovalUserId = currentUserAccessor.Id,
				TransactionNo = input.TransactionNo,
				MinAmount = workflowRule.MinAmount,
				MaxAmount = workflowRule.MaxAmount
			};

			await _dbContext.ApprovalHistories.AddAsync(dataHistory);
			await _dbContext.SaveChangesAsync();

			return (true, firstRoleApprover.RoleCode);
		}

		public async Task<bool> CancelApprovalWorkflow(DataAccess.Models.OutgoingPayment input, string remark, CurrentUserAccessor currentUserAccessor)
		{
			var dataInbox = await _dbContext.ApprovalInboxes.FirstOrDefaultAsync(x => x.TransactionNo == input.TransactionNo);

			if (dataInbox == null)
				return false;

			var dataRole = await _dbContext.UserCompanyRoles
										   .Include(x => x.Role)
                                           .Include(x => x.UserCompany)
                                           .AsNoTracking()
										   .FirstOrDefaultAsync(x => x.UserCompany.UserId == currentUserAccessor.Id);

			if (dataRole == null)
				return false;

			dataInbox.ApprovalStatus = ApprovalStatus.Cancelled;
			dataInbox.ApprovalRoleCode = string.Empty;

			_dbContext.Update(dataInbox);


			var dataHistory = new ApprovalHistory
			{
				ApprovalLevel = dataInbox.ApprovalLevel,
				ExecutorName = input.Requestor,
				ExecutorRoleCode = dataRole.Role.RoleCode,
				ExecutorRoleDesc = dataRole.Role.RoleDescription,
				ApprovalStatus = ApprovalStatus.Cancelled,
				ApprovalUserId = currentUserAccessor.Id,
				TransactionNo = input.TransactionNo,
				MinAmount = dataInbox.MinAmount,
				MaxAmount = dataInbox.MaxAmount,
				Remark = remark
			};

			await _dbContext.ApprovalHistories.AddAsync(dataHistory);

			return true;
		}

		public async Task SendEmailToApprover(SendEmailDto input, ApprovalStatus status)
		{
			var dataUsers = await _dbContext.UserCompanyRoles
											.Include(x => x.UserCompany)
												.ThenInclude(x => x.User)
											.Include(x => x.Role)
											.Where(x => x.Role.RoleCode == input.RoleCodeReceiver)
											.ToListAsync();

			if (dataUsers == null) 
				return;

			var dataEmailConfigs = await _dbContext.AppConfigs
												   .Where(x => x.Modul.Equals("EmailNotification"))
												   .ToListAsync();

			var generalConfig = await _dbContext.AppConfigs
												.Where(x => x.Modul.Equals("General"))
												.ToListAsync();

			if (dataEmailConfigs == null || generalConfig == null) 
				return;

			var emailDataInput = new EmailData();

			try
			{
				var fromEmail = dataEmailConfigs.First(x => x.Key.Equals("FromEmail")).Value;
				var fromEmailDisplay = dataEmailConfigs.First(x => x.Key.Equals("FromEmailDisplay")).Value;
				var emailPass = dataEmailConfigs.First(x => x.Key.Equals("FromEmailPassword")).Value;
				var templateBody = dataEmailConfigs.First(x => x.Key.Equals("BodyTemplate")).Value;

				var baseUrl = generalConfig.First(x => x.Key.Equals("BaseUrl")).Value;
				string linkDocument = $"{baseUrl}Core/Mailbox/Approval/{input.DocumentId}";

				var body = templateBody
						.Replace("{{toName}}", input.RoleCodeReceiver)
						.Replace("{{linkDocument}}", linkDocument)
						.Replace("{{documentNo}}", input.TransactionNo)
						.Replace("{{action}}", status.ToString())
						.Replace("{{executorName}}", input.ExecutorName);

				if (!string.IsNullOrEmpty(input.Remark))
					body = body.Replace("{{remark}}", $"untuk <strong>{input.Remark}</strong>");
				else
					body = body.Replace("{{remark}}", $"");

				if (input.ScheduleDate != null)
					body = body.Replace("{{scheduledate}}", $"Transaksi perlu dilakukan pada tanggal : <strong>{input.ScheduleDate.Value:dd-MMM-yyyy}</strong>");
				else
					body = body.Replace("{{scheduledate}}", $"");

				emailDataInput = new EmailData
				{
					BodyEmail = body,
					FromDisplayName = fromEmailDisplay,
					FromEmail = fromEmail,
					PasswordEmail = emailPass,
					SubjectEmail = "Outgoing Payment Notification",
					MultiRecievers = []
				};

				foreach (var user in dataUsers)
				{
					emailDataInput.MultiRecievers.Add(new MailAddress(user.UserCompany.User.Email, user.UserCompany.User.FullName));
				}
                emailDataInput.MultiRecievers = emailDataInput.MultiRecievers.Distinct().ToList();

				EmailHelper.SendEmailMultiReceiver(emailDataInput);

				await _dbContext.EmailHistories.AddAsync(new EmailHistory
				{
					Sender = emailDataInput.FromEmail,
					Receiver = string.Join("; ", emailDataInput.MultiRecievers.Select(x => x.Address)),
					Subject = emailDataInput.SubjectEmail,
					Content = emailDataInput.BodyEmail,
					Error = string.Empty,
					Status = EmailStatus.Sended
				});
			}
			catch (Exception ex)
			{
				await _dbContext.EmailHistories.AddAsync(new EmailHistory
				{
					Sender = emailDataInput.FromEmail,
					Receiver = string.Join("; ", emailDataInput.MultiRecievers.Select(x => x.Address)),
					Subject = emailDataInput.SubjectEmail,
					Content = emailDataInput.BodyEmail,
					Error = ex.Message,
					Status = EmailStatus.Failed
				});
			}
			finally
			{
				await _dbContext.SaveChangesAsync();
			}
		}

		// Send email to requestor get email config with key = "EmailForRequestor"
		public async Task SendEmailToRequestor(SendEmailDto input, ApprovalStatus status, string requestorId)
		{
			var dataUser = await _dbContext.Users.FirstOrDefaultAsync(d => d.Id.Equals(new Guid(requestorId)));

            if (dataUser == null)
                return;

            var dataEmailConfigs = await _dbContext.AppConfigs
                                                   .Where(x => x.Modul.Equals("EmailNotification"))
                                                   .ToListAsync();

            var generalConfig = await _dbContext.AppConfigs
                                                .Where(x => x.Modul.Equals("General"))
                                                .ToListAsync();

            if (dataEmailConfigs == null || generalConfig == null)
                return;

            var emailDataInput = new EmailData();

            try
            {
                var fromEmail = dataEmailConfigs.First(x => x.Key.Equals("FromEmail")).Value;
                var fromEmailDisplay = dataEmailConfigs.First(x => x.Key.Equals("FromEmailDisplay")).Value;
                var emailPass = dataEmailConfigs.First(x => x.Key.Equals("FromEmailPassword")).Value;
                var templateBody = dataEmailConfigs.First(x => x.Key.Equals("EmailForRequestor")).Value;

                var baseUrl = generalConfig.First(x => x.Key.Equals("BaseUrl")).Value;
                string linkDocument = $"{baseUrl}Core/OutgoingPayment/Detail/{input.DocumentId}";

                var body = templateBody
                        .Replace("{{toName}}", input.RequestorName)
                        .Replace("{{linkDocument}}", linkDocument)
                        .Replace("{{documentNo}}", input.TransactionNo)
                        .Replace("{{action}}", status.ToString())
                        .Replace("{{executorName}}", input.ExecutorName);

                if (!string.IsNullOrEmpty(input.Remark))
                    body = body.Replace("{{remark}}", $"untuk <strong>{input.Remark}</strong>");
                else
                    body = body.Replace("{{remark}}", $"");

                if (!string.IsNullOrEmpty(input.RejectReason))
                    body = body.Replace("{{rejectReason}}", $"Alasan penolakan : <strong>{input.RejectReason}</strong>");
                else
                    body = body.Replace("{{rejectReason}}", $"");

                emailDataInput = new EmailData
                {
                    BodyEmail = body,
                    FromDisplayName = fromEmailDisplay,
                    FromEmail = fromEmail,
                    PasswordEmail = emailPass,
                    SubjectEmail = "Outgoing Payment Notification",
                    MultiRecievers = [new MailAddress(dataUser.Email, dataUser.FullName)]
                };
                emailDataInput.MultiRecievers = emailDataInput.MultiRecievers.Distinct().ToList();

                EmailHelper.SendEmailMultiReceiver(emailDataInput);

                await _dbContext.EmailHistories.AddAsync(new EmailHistory
                {
                    Sender = emailDataInput.FromEmail,
                    Receiver = string.Join("; ", emailDataInput.MultiRecievers.Select(x => x.Address)),
                    Subject = emailDataInput.SubjectEmail,
                    Content = emailDataInput.BodyEmail,
                    Error = string.Empty,
                    Status = EmailStatus.Sended
                });
            }
            catch (Exception ex)
            {
                await _dbContext.EmailHistories.AddAsync(new EmailHistory
                {
                    Sender = emailDataInput.FromEmail,
                    Receiver = string.Join("; ", emailDataInput.MultiRecievers.Select(x => x.Address)),
                    Subject = emailDataInput.SubjectEmail,
                    Content = emailDataInput.BodyEmail,
                    Error = ex.Message,
                    Status = EmailStatus.Failed
                });
            }
            finally
            {
                await _dbContext.SaveChangesAsync();
            }
        }

		// Fungsi untuk mmendapatkan current role yang sedang di assign sebagai approval dari dokumen OutgoingPayment
		public async Task<string> GetCurrentRoleApproval(string transactionNo)
		{
			// Query dari tabel ApprovalInbox untuk mendapatkan data role yang sedang di assign sebagai approval dari dokumen OutgoingPayment
			var dataInbox = await _dbContext.ApprovalInboxes
                                            .Where(x => x.TransactionNo == transactionNo)
                                            .FirstOrDefaultAsync();

			if (dataInbox == null)
                return string.Empty;

			return dataInbox.ApprovalRoleCode;
		}
    }
}
