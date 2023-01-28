using System.ComponentModel.DataAnnotations;
using MediatR;

namespace App.Application.Commands
{
    public class CreateBookCommand : IRequest<CreateBookCommandResponse>
    {
        public string? Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int NumberOfPages { get; set; }
        public IEnumerable<Guid> Categories { get; set; } = new List<Guid>();
    }
}