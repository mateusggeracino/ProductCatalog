
using FluentValidation;
using Swiks.Domain.Entities.Base;

namespace Swiks.Domain.Entities
{
    public class Product : Entity
    {
        public Product(string name, string description, double price, int categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            CategoryID = categoryId;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        public int CategoryID { get; private set; }
        public virtual Category Category { get; private set; }
    }

    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Description)
                .MaximumLength(500);

            RuleFor(x => x.Price)
                .GreaterThan(0);
        }
    }
}
