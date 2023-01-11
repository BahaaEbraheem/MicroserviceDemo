using AutoMapper;
using RemittanceManagement.Remittances;
using MsDemo.Shared.Dtos;
using RemittanceManagement.Status;
using RemittanceManagement.Status.Dtos;
using static RemittanceManagement.Web.Pages.RemittanceManagement.CreateModel;

namespace RemittanceManagement.Web;

public class RemittanceManagementWebAutoMapperProfile : Profile
{
    public RemittanceManagementWebAutoMapperProfile()
    {
        CreateMap<RemittanceStatus, RemittanceStatusDto>();
        CreateMap<CreateUpdateRemittanceStatusDto, RemittanceStatus>()
            .ForMember(model => model.IsDeleted, option => option.Ignore())
            .ForMember(model => model.DeleterId, option => option.Ignore())
            .ForMember(model => model.DeletionTime, option => option.Ignore())
            .ForMember(model => model.Id, option => option.Ignore())
                .ForMember(model => model.LastModifierId, option => option.Ignore())
               .ForMember(model => model.CreatorId, option => option.Ignore())
               .ForMember(model => model.CreationTime, option => option.Ignore())
               .ForMember(model => model.LastModificationTime, option => option.Ignore());


        CreateMap<RemittanceCreateViewModel, CreateRemittanceDto>()
             .ForMember(model => model.SerialNumber, option => option.Ignore())
              .ForMember(model => model.ApprovedBy, option => option.Ignore())
               .ForMember(model => model.ApprovedDate, option => option.Ignore())
               .ForMember(model => model.ReleasedBy, option => option.Ignore())
               .ForMember(model => model.ReleasedDate, option => option.Ignore())
               .ForMember(model => model.SenderName, option => option.Ignore())
               .ForMember(model => model.ReceiverBy, option => option.Ignore())
               .ForMember(model => model.ReceiverName, option => option.Ignore())
               .ForMember(model => model.CurrencyName, option => option.Ignore())
               .ForMember(model => model.State, option => option.Ignore())

            ;

        CreateMap<CreateUpdateRemittanceStatusDto, RemittanceStatusDto>()
            .ForMember(model => model.Id, option => option.Ignore())
                .ForMember(model => model.LastModifierId, option => option.Ignore())
               .ForMember(model => model.CreatorId, option => option.Ignore())
               .ForMember(model => model.CreationTime, option => option.Ignore())
               .ForMember(model => model.LastModificationTime, option => option.Ignore());

        CreateMap<GetRemittanceListPagedAndSortedResultRequestDto, Remittance>()
              .ForMember(model => model.ExtraProperties, option => option.Ignore())
               .ForMember(model => model.ConcurrencyStamp, option => option.Ignore())
               .ForMember(model => model.Status, option => option.Ignore());
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
