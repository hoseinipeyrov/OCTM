using System;
using OCTM.Domain.Commands;
using FluentValidation;

namespace OCTM.Domain.Validations
{
    public abstract class ContainerShipValidation<T> : AbstractValidator<T> where T : ContainerShipCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateCapacity()
        {
            RuleFor(c => c.Capacity)
                .NotEmpty()
                .WithMessage("The Container Ship must have Capacity");
        }

        protected void ValidateColor()
        {
            RuleFor(c => c.Color)
                .NotEmpty();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}