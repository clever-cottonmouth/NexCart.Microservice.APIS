using FluentValidation;
using NexCart.Orders.DTO;

namespace NexCart.Orders.Validators
{
    public class OrderItemAddRequestValidator : AbstractValidator<OrderItemAddRequest>
    {
        public OrderItemAddRequestValidator()
        {
            RuleFor(x => x.ProductID).NotEmpty().WithMessage("ProductID is required");

            RuleFor(x => x.UnitPrice).NotEmpty().WithMessage("UnitPrice is required");

            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Quantity is required");
        }
    }
}
