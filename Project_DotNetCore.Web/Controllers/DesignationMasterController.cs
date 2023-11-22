using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_DotNetCore.Base.Modules.AdminUsers.Models.DTOs;
using Project_DotNetCore.Base.Modules.AdminUsers.Services;
using Project_DotNetCore.Base.Modules.Core;

namespace Project_DotNetCore.Web.Controllers
{
    public class DesignationMasterController : Controller
    {
        private readonly IDesignationMasterService _designationMasterService;
        public DesignationMasterController(IDesignationMasterService designationMasterService)
        {
            _designationMasterService = designationMasterService;
        }

        [HttpGet]
        public IActionResult Index()
        {


            var dto = new DesignationMasterFilterDto();

            var result = _designationMasterService.List(dto);
            if (result != null)
            {
                return View(result.Data);
            }

            return View(result);
        }

        [HttpGet]
        //[AuthorizeAdminUser(permissions: new[] { DesignationMasterPermission.Create, DesignationMasterPermission.Edit })]
        public IActionResult Manage(int id = 0)
        {


            var dto = new DesignationMasterManageDto();

            if (id > 0)
            {
                dto = _designationMasterService.ById(id);
            }
            return View(dto);
        }

        [HttpPost]
        //[AuthorizeAdminUser(permissions: new[] { DesignationMasterPermission.Create, DesignationMasterPermission.Edit })]
        public IActionResult Manage(DesignationMasterManageDto dto)
        {
            var result = new Result();

            if (dto != null)
            {
                if (dto.Id > 0)
                {
                    //dto.UpdatedBy = loginUserInfo.Id;
                    result = _designationMasterService.Edit(dto.Id, dto);
                }
                else
                {
                    //dto.CreatedBy = loginUserInfo.Id;
                    result = _designationMasterService.Create(dto);
                }

                if (result.Success)
                {
                    return Json(new { result = "Success", value = "Designation saved successfully", TempProjectId = result.Id });
                }
                return Json(new { result = "Error", value = string.Join(" <br/> ", result.Errors.Select(x => x.Value)) });
            }
            return Json(new { result = "Error", value = "Designation is not saved." });


        }

        [HttpGet]
        //[AuthorizeAdminUser(permissions: new[] { DesignationMasterPermission.Delete })]
        public async Task<IActionResult> Delete(int Id, bool isActive)
        {
            try
            {
                var entity = Content(Convert.ToString(await _designationMasterService.Delete(Id, isActive)));
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction("Index");
        }


        //Datatable
        [HttpPost]
        public IActionResult GetDesignationMasterList(string filterdata = null)
        {
            int recordsFiltered = 0;
            int recordsTotal = 0;
            var dto = new DesignationMasterFilterDto();
            if (filterdata != null)
            {
                dto = JsonConvert.DeserializeObject<DesignationMasterFilterDto>(filterdata);
            }
            var draw = Request.Form["draw"].FirstOrDefault();

            try
            {
                dto.SortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                dto.SortType = Request.Form["order[0][dir]"].FirstOrDefault();
                dto.Page = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
                dto.Size = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");

                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                if (searchValue.IsNotNullOrEmpty())
                {
                    dto.GeneralSearch = searchValue;
                }

                var result = _designationMasterService.List(dto);
                if (result != null)
                {
                    recordsFiltered = result.Paging.Total;
                    recordsTotal = result.Paging.Total;

                    return new JsonResult(new { draw, recordsFiltered, recordsTotal, data = result.Data });
                }
                return new JsonResult(new { draw, recordsFiltered, recordsTotal, data = new object[] { } });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { draw, recordsFiltered, recordsTotal, data = new object[] { } });
            }
        }
    }
}