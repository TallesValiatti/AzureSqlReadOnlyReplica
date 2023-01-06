using System.Collections.ObjectModel;
using App.Domain.Shared;

namespace App.Domain.Books
{
    public class Book : BaseEntity
    {   
        public string Name { get; private set; } = null!;
        public int NumberOfPages { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public ICollection<BookCategory> BookCategories { get; private set; } = new Collection<BookCategory>();
        
        // EF
        protected Book() : base()
        {}

        protected Book(
            Guid id, 
            string name, 
            int numberOfPages,
            DateTime releaseDate) : base(id)
        {
            Name = name;
            NumberOfPages = numberOfPages;
            ReleaseDate = releaseDate;
        }

        public static Book Create(
            string name, 
            int numberOfPages,
            DateTime releaseDate)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new BusinessException("Book Name property can not be null");

            if(numberOfPages <= 0)
                throw new BusinessException("Book NumberOfPages property should be greater than or equals to 0");

            if(releaseDate >= DateTime.Now)
                throw new BusinessException("Book ReleaseDate property should be lower than now");

            return new Book(
                Guid.NewGuid(),
                name.Trim(),
                numberOfPages,
                releaseDate);
        }

        public bool HasCategory(Guid categoryId) => BookCategories.Any(x => x.CategoryId.Equals(categoryId));

        public void AddCategory(Guid categoryId)
        {
            if(this.HasCategory(categoryId)) 
                return;

            BookCategories.Add(BookCategory.Create(this, categoryId));
        }
    }
}