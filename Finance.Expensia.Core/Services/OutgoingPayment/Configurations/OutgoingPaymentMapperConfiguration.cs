using AutoMapper;
using Finance.Expensia.Core.Services.OutgoingPayment.Dtos;
using Finance.Expensia.Core.Services.OutgoingPayment.Inputs;
using Finance.Expensia.DataAccess.Models;

namespace Finance.Expensia.Core.Services.OutgoingPayment.Configurations
{
	public class OutgoingPaymentMapperConfiguration : Profile
    {
        public OutgoingPaymentMapperConfiguration()
        {
            CreateMap<DataAccess.Models.OutgoingPayment, ListOutgoingPaymentDto>()
                .ForMember(dest => dest.OutgoingPaymentId, opt => opt.MapFrom(src => src.Id));

            CreateMap<CreateOutgoingPaymentInput, DataAccess.Models.OutgoingPayment>()
                .ForMember(dest => dest.OutgoingPaymentDetails, opt => opt.Ignore());

			CreateMap<CreateOutgoingPaymentDetailInput, OutgoingPaymentDetail>()
				.ForMember(dest => dest.OutgoingPaymentDetailAttachments, opt => opt.Ignore())
                .ForMember(dest => dest.OutgoingPayment, opt => opt.Ignore());

			CreateMap<CreateOutgoingPaymentDetailAttachmentInput, OutgoingPaymentDetailAttachment>()
                .ForMember(dest => dest.OutgoingPaymentDetail, opt => opt.Ignore());
		}
    }
}
