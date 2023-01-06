namespace App.Application.Queries.Dtos
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int NumberOfPages { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Categories { get; set; }
    }
}