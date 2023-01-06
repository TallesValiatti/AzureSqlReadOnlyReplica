namespace App.Domain.Category
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(Guid id);
        Task<Category?> GetByNameAsync(string name);
        Task<Category> CreateAsync(Category category);        
    }
}