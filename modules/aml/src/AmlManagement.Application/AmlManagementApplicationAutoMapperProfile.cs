using AmlManagement.Aml_Remittance;
using AutoMapper;
using MsDemo.Shared.Dtos;
using MsDemo.Shared.Etos;
using RemittanceManagement.Remittances;

namespace AmlManagement
{
    public class AmlManagementApplicationAutoMapperProfile : Profile
    {
        public AmlManagementApplicationAutoMapperProfile()
        {
            CreateMap<RemittanceEto, AmlRemittance>()
           .ForMember(dest => dest.RemittanceId, opt => opt.MapFrom(src => src.RemittanceId))
           .ForMember(model => model.IsDeleted, option => option.Ignore())
           .ForMember(model => model.DeleterId, option => option.Ignore())
           .ForMember(model => model.DeletionTime, option => option.Ignore())
           .ForMember(model => model.ExtraProperties, option => option.Ignore())
           .ForMember(model => model.ConcurrencyStamp, option => option.Ignore());

            CreateMap<AmlRemittance, RemittanceEto>();


        }
    }
}