using FluentValidation.Results;
using System;

namespace Swiks.Domain.Entities.Base
{
    public abstract class Entity
    {
        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public int Id { get; set; }
        public Guid UniqueKey { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
