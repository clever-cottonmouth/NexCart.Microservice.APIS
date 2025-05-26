using FluentValidation;
using NexCart.Products.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexCart.Products.Validators
{
    public class ProductAddRequestValidator : AbstractValidator<ProductAddRequest>
    {
        public ProductAddRequestValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Product Name is required");
            RuleFor(x => x.Category).IsInEnum().WithMessage("Category is required");
            RuleFor(x => x.UnitPrice).NotEmpty().WithMessage("Unit Price is required");
            RuleFor(x => x.QuantityInStock).NotEmpty().WithMessage("Quantity In Stock is required");
        }
    }
}
