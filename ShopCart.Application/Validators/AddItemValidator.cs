using FluentValidation;
using ShopCart.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.Application.Validators
{
    public class AddItemValidator : AbstractValidator<AddItemCommand>
    {
        private IEnumerable<string> AvailableProducts { get; set; } = new List<string>() { "10001", "10002", "20001", "20110" };
        public AddItemValidator()
        {
            RuleFor(item => item.ProductId).NotNull().NotEmpty().Must(id => AvailableProducts.Contains(id)).WithMessage("The ProductId is empty or not exist.");
            RuleFor(item => item.Quantity).NotNull().GreaterThan(0).WithMessage("The Quantity must be greater than 0!");
        }
    }
}
