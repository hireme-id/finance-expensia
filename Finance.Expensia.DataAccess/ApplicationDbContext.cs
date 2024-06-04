﻿using Finance.Expensia.DataAccess.Bases;
using Finance.Expensia.Shared.Objects;
using Microsoft.EntityFrameworkCore;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.DataAccess.Builders;

namespace Finance.Expensia.DataAccess
{
    public class ApplicationDbContext(DbContextOptions options, CurrentUserAccessor currentUserAccessor) : DbContextBase(options, currentUserAccessor)
    {
        #region UserManagement
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        #endregion

        #region MasterData
        public virtual DbSet<BankAlias> BankAliases { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<ChartOfAccount> ChartOfAccounts { get; set; }
        public virtual DbSet<CostCenter> CostCenters { get; set; }
        public virtual DbSet<TransactionType> TransactionTypes { get; set; }
        public virtual DbSet<DocNumberConfig> DocNumberConfigs { get; set; }
        public virtual DbSet<AppConfig> AppConfigs { get; set; }
        #endregion

        #region Transaction
        public virtual DbSet<OutgoingPayment> OutgoingPayments { get; set; }
        public virtual DbSet<OutgoingPaymentDetail> OutgoingPaymentDetails { get; set; }
        public virtual DbSet<OutgoingPaymentDetailAttachment> OutgoingPaymentDetailAttachments { get; set; }
        #endregion

        #region Workflow Approval
        public virtual DbSet<ApprovalRule> ApprovalRules { get; set; }
        public virtual DbSet<ApprovalInbox> ApprovalInboxes { get; set; }
        public virtual DbSet<ApprovalHistory> ApprovalHistories { get; set; }
        public virtual DbSet<EmailHistory> EmailHistories { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region UserManagement
            new UserEntityBuilder().Configure(modelBuilder.Entity<User>());
            new RoleEntityBuilder().Configure(modelBuilder.Entity<Role>());
            new UserRoleEntityBuilder().Configure(modelBuilder.Entity<UserRole>());
            new PermissionEntityBuilder().Configure(modelBuilder.Entity<Permission>());
            new RolePermissionEntityBuilder().Configure(modelBuilder.Entity<RolePermission>());
            #endregion

            #region MasterData
            new BankAliasEntityBuilder().Configure(modelBuilder.Entity<BankAlias>());
            new CompanyEntityBuilder().Configure(modelBuilder.Entity<Company>());
            new PartnerEntityBuilder().Configure(modelBuilder.Entity<Partner>());
            new ChartOfAccountEntityBuilder().Configure(modelBuilder.Entity<ChartOfAccount>());
            new CostCenterEntityBuilder().Configure(modelBuilder.Entity<CostCenter>());
            new TransactionTypeEntityBuilder().Configure(modelBuilder.Entity<TransactionType>());
            new DocNumberConfigEntityBuilder().Configure(modelBuilder.Entity<DocNumberConfig>());
            new AppConfigEntityBuilder().Configure(modelBuilder.Entity<AppConfig>());
            #endregion

            #region Transaction
            new OutgoingPaymentEntityBuilder().Configure(modelBuilder.Entity<OutgoingPayment>());
            new OutgoingPaymentDetailEntityBuilder().Configure(modelBuilder.Entity<OutgoingPaymentDetail>());
            new OutgoingPaymentDetailAttachmentEntityBuilder().Configure(modelBuilder.Entity<OutgoingPaymentDetailAttachment>());
            #endregion

            #region Workflow Approval
            new ApprovalRuleEntityBuilder().Configure(modelBuilder.Entity<ApprovalRule>());
            new ApprovalInboxEntityBuilder().Configure(modelBuilder.Entity<ApprovalInbox>());
            new ApprovalHistoryEntityBuilder().Configure(modelBuilder.Entity<ApprovalHistory>());
            new EmailHistoryEntityBuilder().Configure(modelBuilder.Entity<EmailHistory>());
            #endregion
        }
    }
}
