using Project_DotNetCore.Base.Modules.AdminUsers.Models;
using Project_DotNetCore.Base.Modules.AdminUsers.Models.DTOs;
using FluentValidation;

namespace Project_DotNetCore.Base.Modules.AdminUsers.Validators
{
    public class DesignationMasterValidator : AbstractValidator<DesignationMasterManageDto>
    {
        public DesignationMasterValidator()
        {
            RuleFor(v => v.Designation)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().MaximumLength(150);
        }
    }
}