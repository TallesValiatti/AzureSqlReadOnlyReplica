using App.Domain.Category;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }
        public async Task<Category> CreateAsync (Category category)
        {
            return (await _context.Categories.AddAsync(category)).Entity;
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Name.Equals(name));
        }
    }
}