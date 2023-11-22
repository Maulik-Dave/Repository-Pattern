using AutoMapper;
using Project_DotNetCore.Base.Modules.AdminUsers.Models.DTOs;

namespace Project_DotNetCore.Base.Modules.AdminUsers.Models.Mappers
{
    public class DesignationMasterMappingProfile : Profile
    {
        public DesignationMasterMappingProfile()
        {
            CreateMap<DesignationMasterManageDto, DesignationMaster>().ReverseMap();
        }
    }
}