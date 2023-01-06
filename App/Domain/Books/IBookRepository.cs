namespace App.Domain.Books
{
    public interface IBookRepository
    {
        Task<Book?> GetByNameAsync(string name);
        Task<Book?> GetByIdAsync(Guid id);
        Task<Book> CreateAsync(Book book);
    }
}