using App.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly Context _context;

        public BookRepository(Context context)
        {
            _context = context;
        }
        public async Task<Book> CreateAsync (Book book)
        {
            return (await _context.Books.AddAsync(book)).Entity;
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            return await _context.Books
                .Include(x => x.BookCategories)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Book?> GetByNameAsync(string name)
        {
            return await _context.Books
                .Include(x => x.BookCategories)
                .FirstOrDefaultAsync(x => x.Name.Equals(name));
        }
    }
}