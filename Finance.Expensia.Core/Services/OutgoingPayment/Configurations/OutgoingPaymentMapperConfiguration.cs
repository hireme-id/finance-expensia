using AutoMapper;
using Finance.Expensia.Core.Services.OutgoingPayment.Dtos;
using Finance.Expensia.DataAccess.Models;

namespace Finance.Expensia.Core.Services.OutgoingPayment.Configurations
{
    public class OutgoingPaymentMapperConfiguration : Profile
    {
        public OutgoingPaymentMapperConfiguration()
        {
            CreateMap<DataAccess.Models.OutgoingPayment, ListOutgoingPaymentDto>()
                .ForMember(dest => dest.OutgoingPaymentId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
