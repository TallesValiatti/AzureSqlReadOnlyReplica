using App.Domain.Shared;

namespace App.Domain.Category
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; } = null!;

        // EF
        protected Category() : base() 
        {}

        protected Category(Guid id, string name) : base(id)
        {
            Name = name;
        }

        public static Category Create(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new BusinessException("Category Name property can not be null");

            return new Category(Guid.NewGuid(), name);            
        }
    }
}