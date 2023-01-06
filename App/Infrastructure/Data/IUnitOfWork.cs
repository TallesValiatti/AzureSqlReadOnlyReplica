using App.Domain.Books;
using App.Domain.Category;

namespace App.Infrastructure.Data
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository {get;}
        ICategoryRepository CategoryRepository {get;}
        Task CompleteAsync();
    }
}