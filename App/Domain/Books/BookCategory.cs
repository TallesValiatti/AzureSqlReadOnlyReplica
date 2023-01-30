using App.Domain.Shared;

namespace App.Domain.Books
{
    public class BookCategory : BaseEntity
    {
        public Guid BookId { get; private set; }
        public Book Book { get; private set; } = null!;
        public Guid CategoryId { get; private set; }

        // EF
        protected BookCategory() : base()
        {}

        protected BookCategory(Guid id, Book book, Guid categoryId) : base(id)
        {
            Book = book;
            BookId = book.Id;
            CategoryId = categoryId;
        }

        public static BookCategory Create(Book book, Guid categoryId)
        {
            return new BookCategory(Guid.NewGuid(), book, categoryId);
        }
    }
}