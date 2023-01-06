using App.Domain.Books;
using App.Domain.Category;
using App.Infrastructure.Data.Repositories;

namespace App.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        private IBookRepository _bookRepository = null!;
        private ICategoryRepository _categoryRepository = null!;

        public UnitOfWork(Context context)
        {
            _context = context;
        }

        public IBookRepository BookRepository 
        {
            get 
            {
                if(_bookRepository is null)
                    _bookRepository = new BookRepository(_context);

                return _bookRepository;
            }
        }

        public ICategoryRepository CategoryRepository 
        {
            get 
            {
                if(_categoryRepository is null)
                    _categoryRepository = new CategoryRepository(_context);

                return _categoryRepository;
            }
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}