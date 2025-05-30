using FluentValidation;
using NexCart.Orders.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexCart.Orders.Validators
{
    public class OrderAddRequestValidator : AbstractValidator<OrderAddRequest>
    {
        public OrderAddRequestValidator()
        {
            RuleFor(x => x.UserID).NotEmpty().WithMessage("UserID is required");

            RuleFor(x => x.OrderDate).NotEmpty().WithMessage("OrderDate is required");

            RuleFor(x => x.OrderItems).NotEmpty().WithMessage("OrderItems is required");
        }

    }
}
