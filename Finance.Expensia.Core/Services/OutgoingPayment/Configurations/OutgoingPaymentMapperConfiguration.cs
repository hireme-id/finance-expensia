using AutoMapper;
using Finance.Expensia.Core.Services.OutgoingPayment.Dtos;
using Finance.Expensia.Core.Services.OutgoingPayment.Inputs;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Helpers;

namespace Finance.Expensia.Core.Services.OutgoingPayment.Configurations
{
	public class OutgoingPaymentMapperConfiguration : Profile
    {
        public OutgoingPaymentMapperConfiguration()
        {
            CreateMap<DataAccess.Models.OutgoingPayment, ListOutgoingPaymentDto>()
                .ForMember(dest => dest.OutgoingPaymentId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.FromBankAlias, opt => opt.MapFrom(src => src.FromBankAliasName))
                .ForMember(dest => dest.ToBankAlias, opt => opt.MapFrom(src => src.ToBankAliasName));

            CreateMap<DataAccess.Models.OutgoingPayment, OutgoingPaymentDto>()
                .ForMember(dest => dest.OutgoingPaymentId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ApprovalStatus, opt => opt.MapFrom(src => src.ApprovalStatus.GetDescription()))
                .ForMember(dest => dest.ExpectedTransfer, opt => opt.MapFrom(src => src.ExpectedTransfer.ToString()))
                .ForMember(dest => dest.IsCancelable, opt => opt.MapFrom(src => src.ApprovalStatus != Shared.Enums.ApprovalStatus.WaitingApproval));

			CreateMap<DataAccess.Models.OutgoingPayment, DownloadOutgoingPaymentDto>()
				.ForMember(dest => dest.OutgoingPaymentId, opt => opt.MapFrom(src => src.Id));

			CreateMap<OutgoingPaymentDetail, OutgoingPaymentDetailDto>();

			CreateMap<OutgoingPaymentDetail, DownloadOutgoingPaymentDetailDto>();

            CreateMap<OutgoingPaymentTagging, OutgoingPaymentTaggingDto>();

            CreateMap<OutgoingPaymentDetailAttachment, OutgoingPaymentDetailAttachmentDto>();

            CreateMap<CreateOutgoingPaymentInput, DataAccess.Models.OutgoingPayment>()
                .ForMember(dest => dest.OutgoingPaymentDetails, opt => opt.Ignore());

			CreateMap<CreateOutgoingPaymentDetailInput, OutgoingPaymentDetail>()
				.ForMember(dest => dest.OutgoingPaymentDetailAttachments, opt => opt.Ignore())
                .ForMember(dest => dest.OutgoingPayment, opt => opt.Ignore());

			CreateMap<CreateOutgoingPaymentDetailAttachmentInput, OutgoingPaymentDetailAttachment>()
                .ForMember(dest => dest.OutgoingPaymentDetail, opt => opt.Ignore());

			CreateMap<CreateOutgoingPaymentTaggingInput, OutgoingPaymentTagging>()
				.ForMember(dest => dest.OutgoingPayment, opt => opt.Ignore());

			CreateMap<EditOutgoingPaymentInput, DataAccess.Models.OutgoingPayment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TransactionNo, opt => opt.Ignore())
                .ForMember(dest => dest.Requestor, opt => opt.Ignore())
                .ForMember(dest => dest.RequestDate, opt => opt.Ignore())
                .ForMember(dest => dest.OutgoingPaymentDetails, opt => opt.Ignore());

            CreateMap<EditOutgoingPaymentDetailInput, OutgoingPaymentDetail>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.OutgoingPaymentId, opt => opt.Ignore())
                .ForMember(dest => dest.OutgoingPaymentDetailAttachments, opt => opt.Ignore())
                .ForMember(dest => dest.OutgoingPayment, opt => opt.Ignore());

            CreateMap<EditOutgoingPaymentDetailAttachmentInput, OutgoingPaymentDetailAttachment>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.OutgoingPaymentDetailId, opt => opt.Ignore())
                .ForMember(dest => dest.OutgoingPaymentDetail, opt => opt.Ignore());

			CreateMap<EditOutgoingPaymentDetailTaggingInput, OutgoingPaymentTagging>()
				.ForMember(dest => dest.Id, opt => opt.Ignore())
				.ForMember(dest => dest.OutgoingPaymentId, opt => opt.Ignore())
				.ForMember(dest => dest.OutgoingPayment, opt => opt.Ignore());

            CreateMap<CreateOutgoingPaymentDetailInput, BaseOutgoingPaymentDetailInput>();
            CreateMap<EditOutgoingPaymentDetailInput, BaseOutgoingPaymentDetailInput>();
        }
    }
}
