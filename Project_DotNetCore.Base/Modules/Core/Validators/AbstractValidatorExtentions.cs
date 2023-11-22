using System.Threading.Tasks;
using FluentValidation;

namespace Project_DotNetCore.Base.Modules.Core.Validators
{
    public static class AbstractValidatorExtension
    {
        public static Result ValidateResult<TInstance>(this AbstractValidator<TInstance> validator, TInstance instance)
        {
            if (instance == null)
                return new Result().SetError("Please ensure a model was supplied.");
            
            var results = validator.Validate(instance);

            if (results.IsValid) return new Result().SetSuccess();

            //var result = new Result { Success = false };
            var result = new Result().SetError("Marked red fields are mandatory.");

            foreach (var validationFailure in results.Errors)
                if (!result.Errors.ContainsKey(validationFailure.PropertyName))
                    result.Errors.Add(validationFailure.PropertyName, validationFailure.ErrorMessage);

            return result;
        }

        public static async Task<Result> ValidateResultAsync<TInstance>(this AbstractValidator<TInstance> validator, TInstance instance)
        {
            if (instance == null)
                return new Result().SetError("Please ensure a model was supplied.");
            
            var results = await validator.ValidateAsync(instance);

            if (results.IsValid) return new Result().SetSuccess();

            //var result = new Result { Success = false };
            var result = new Result().SetError("Marked red fields are mandatory.");

            foreach (var validationFailure in results.Errors)
                if (!result.Errors.ContainsKey(validationFailure.PropertyName))
                    result.Errors.Add(validationFailure.PropertyName, validationFailure.ErrorMessage);

            return result;
        }
    }
}