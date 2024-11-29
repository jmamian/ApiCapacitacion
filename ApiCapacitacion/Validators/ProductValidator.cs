using FluentValidation;
using ApiCapacitacion.Models;
namespace ApiCapacitacion.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name).NotEmpty().WithMessage("El nombre del producto es requerido");
            RuleFor(product => product.Price).GreaterThan(0).WithMessage("El precio debe ser mayor a 0");
        }
    }
}
