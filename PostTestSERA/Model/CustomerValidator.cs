using FluentValidation;

namespace PostTestSERA.Model
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.customerName)
                .NotEmpty().WithMessage("customerName is required.");

            RuleFor(x => x.customerCode)
                .NotEmpty().WithMessage("customerCode is required.");

            RuleFor(x => x.createdAt)
                .NotEmpty().WithMessage("createdAt is required.");

            RuleFor(x => x.createdBy)
                .NotEmpty().WithMessage("createdBy is required.");
                
        }
    }
}
