using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Yummmy.Api.Entities;

namespace Yummmy.Api.ValidationRules
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı boş olamaz");
            RuleFor(x => x.ProductName).MaximumLength(30).WithMessage("Ürün adı boş olamaz");
            RuleFor(x => x.ProductDescription).MinimumLength(10).WithMessage("Ürün açıklaması en az 10 karakter olmalıdır");
            RuleFor(x => x.Price)
    .GreaterThanOrEqualTo(0).WithMessage("Ürün fiyatı 0'dan küçük olamaz");

        }
    }
}