namespace App.Application.Queries.Dtos
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int BookCount { get; set; }
    }
}