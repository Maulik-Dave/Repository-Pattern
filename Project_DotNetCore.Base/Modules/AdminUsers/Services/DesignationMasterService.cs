using AutoMapper;
using Project_DotNetCore.Base.Modules.AdminUsers.CacheManagers;
using Project_DotNetCore.Base.Modules.AdminUsers.Data.Repositories;
using Project_DotNetCore.Base.Modules.AdminUsers.Filters;
using Project_DotNetCore.Base.Modules.AdminUsers.ListOrders;
using Project_DotNetCore.Base.Modules.AdminUsers.Models;
using Project_DotNetCore.Base.Modules.AdminUsers.Models.DTOs;
using Project_DotNetCore.Base.Modules.AdminUsers.Validators;
using Project_DotNetCore.Base.Modules.Core;
using Project_DotNetCore.Base.Modules.Core.Content;
using Project_DotNetCore.Base.Modules.Core.Data;
using Project_DotNetCore.Base.Modules.Core.DTOs;
using Project_DotNetCore.Base.Modules.Core.Validators;

namespace Project_DotNetCore.Base.Modules.AdminUsers.Services
{
    public interface IDesignationMasterService
    {
        Result List(DesignationMasterFilterDto dto);
        DesignationMasterManageDto ById(int id);
        Result Create(DesignationMasterManageDto dto);
        Result Edit(int id, DesignationMasterManageDto dto);
        Task<bool> Delete(int Id, bool isActive);
        IList<IdNameDto> GetDesignations();
    }

    public class DesignationMasterService : IDesignationMasterService
    {
        private readonly IDesignationMasterRepository _designationMasterRepository;
        private readonly DesignationMasterValidator _designationMasterValidator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DesignationMasterService(IDesignationMasterRepository designationMasterRepository, DesignationMasterValidator designationMasterValidator, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _designationMasterRepository = designationMasterRepository;
            _designationMasterValidator = designationMasterValidator;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Result List(DesignationMasterFilterDto dto)
        {
            var filter = dto ?? new DesignationMasterFilterDto();
            var query = _designationMasterRepository.AsNoTracking;

            query = new DesignationMasterFilter(query, filter).FilteredQuery();
            query = new DesignationMasterListOrder(query, filter).OrderByQuery();
            var result = new Result().SetPaging(filter, query.Count());

            result.Data = query.Select(s => new DesignationMasterListDto
            {
                Id = s.Id,
                Designation = s.Designation,
                IsActive = s.IsActive,
                Level = s.Level,
                CreatedAt = s.CreatedAt
            }).ToList();

            return result;
        }

        public DesignationMasterManageDto ById(int id)
        {
            var entity = _designationMasterRepository.AsNoTracking.FirstOrDefault(x => x.Id == id);
            return _mapper.Map<DesignationMasterManageDto>(entity);
        }

        public Result Create(DesignationMasterManageDto dto)
        {
            var result = _designationMasterValidator.ValidateResult(dto);
            if (!result.Success) return result;

            var entity = _mapper.Map<DesignationMaster>(dto);
            entity.IsActive = true;
            _designationMasterRepository.Insert(entity);

            _unitOfWork.Commit();
            DesignationMasterCacheManager.ClearCache();
            result.Id = entity.Id;
            _unitOfWork.Commit();
            return result.SetSuccess(Messages.RecordSaved);
        }

        public Result Edit(int id, DesignationMasterManageDto dto)
        {

            dto.Id = id;

            var result = _designationMasterValidator.ValidateResult(dto);
            if (!result.Success) return result;

            var entity = _designationMasterRepository.AsNoTracking.FirstOrDefault(x => x.Id == id);

            if (entity == null)
                return null;

            _mapper.Map(dto, entity);

            _designationMasterRepository.Update(entity);
            _unitOfWork.Commit();
            DesignationMasterCacheManager.ClearCache();
            _unitOfWork.Commit();
            return result.SetSuccess(Messages.RecordSaved);
        }

        public async Task<bool> Delete(int Id, bool isActive)
        {
            var result = false;

            var entity = _designationMasterRepository.AsNoTracking.Where(x => x.Id == Id).FirstOrDefault();
            if (entity == null)
            {
                return result;
            }
            entity.IsActive = isActive;
            _designationMasterRepository.Update(entity);
            await _unitOfWork.CommitAsync();
            result = true;
            var resultMsg = new Result();
            resultMsg = isActive ? resultMsg.SetSuccess(Messages.RecordActivate, 1) : resultMsg.SetSuccess(Messages.RecordInactivate, 1);
            _unitOfWork.Commit();
            return result;
        }

        public IList<IdNameDto> GetDesignations()
        {
            return _designationMasterRepository.GetDesignations();
        }
    }
}