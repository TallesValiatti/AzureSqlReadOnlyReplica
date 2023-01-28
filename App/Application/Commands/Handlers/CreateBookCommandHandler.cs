using App.Domain.Books;
using App.Domain.Shared;
using App.Infrastructure.Data;
using MediatR;

namespace App.Application.Commands.Handlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreateBookCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public CreateBookCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateBookCommandResponse> Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            var book = Book.Create(command.Name, command.NumberOfPages, command.ReleaseDate);

            if(await _unitOfWork.BookRepository.GetByNameAsync(book.Name) is not null)
                throw new BusinessException($"Already exists a book with name '{book.Name}'");

            foreach (var categoryId in command.Categories)
                if(await _unitOfWork.CategoryRepository.GetByIdAsync(categoryId) is null)
                    throw new BusinessException($"Does not exist a category with Id '{categoryId}'");
                else
                    book.AddCategory(categoryId);

            book = await _unitOfWork.BookRepository.CreateAsync(book);

            await _unitOfWork.CompleteAsync();

            return new CreateBookCommandResponse { Id = book.Id };
        }
    }
}