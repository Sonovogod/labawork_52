using FluentValidation;
using LabaWork.Models.Abstract;
using LabaWork.Services.Abstract;

namespace LabaWork.Validators;

public class SectionValidator : AbstractValidator<ISection>
{
    public SectionValidator(ISectionService<ISection> sectionService)
    {
        RuleFor(section => section.Name)
            .NotNull().WithMessage("Поле не должно быть пустым")
            .MinimumLength(1).WithMessage("Поле не должно быть меньше 1 символа")
            .MaximumLength(20).WithMessage("Поле не должно быть больше 20 символов")
            .Must(name =>
            {
                if (sectionService.IsExist(name.Normalize()))
                    return false;
                return true;
            });
    }
    
}