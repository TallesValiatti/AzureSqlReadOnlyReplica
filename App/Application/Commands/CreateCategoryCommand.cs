using System.ComponentModel.DataAnnotations;
using MediatR;

namespace App.Application.Commands
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string? Name { get; set; }
    }
}