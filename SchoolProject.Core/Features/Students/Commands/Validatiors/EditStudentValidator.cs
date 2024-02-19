using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _localizer;
        #endregion

        #region Constructors
        public EditStudentValidator(IStudentService studentService, IStringLocalizer<SharedResources> localizer)
        {
            _localizer = localizer;
            _studentService = studentService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            /*  RuleFor(x => x.Name).NotEmpty().WithMessage("Name Must Not be Empty")
                                  .NotNull().WithMessage("Name Must Not be Null")
                                  .MaximumLength(10).WithMessage("max Length is 10");*/
            RuleFor(x => x.NameAr)
                  .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                  .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                  .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            /*    RuleFor(x => x.Address).NotEmpty().WithMessage("{PropertyName} Must Not be Empty")
                                       .NotNull().WithMessage("{PropertyValue} Must Not be Null")
                                       .MaximumLength(10).WithMessage("{PropertyName} Length is 10");*/

            RuleFor(x => x.Address)
                              .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                              .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                              .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.NameAr)
                .MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(Key, model.Id))
                    .WithMessage("Name Is Exist");
        }

        #endregion
    }
}
