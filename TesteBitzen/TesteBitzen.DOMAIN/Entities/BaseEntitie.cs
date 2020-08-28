using System;

namespace TesteBitzen.DOMAIN.Entities
{
    public abstract class BaseEntitie
    {
        protected BaseEntitie()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
