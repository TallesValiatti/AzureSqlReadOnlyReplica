namespace App.Domain.Shared
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }

        // EF
        protected BaseEntity()
        {}

        public BaseEntity(Guid id)
        {
            Id = id;
        }
    }
}