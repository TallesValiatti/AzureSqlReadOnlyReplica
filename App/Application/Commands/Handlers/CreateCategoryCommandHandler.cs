using App.Domain.Category;
using App.Domain.Shared;
using App.Infrastructure.Data;
using MediatR;

namespace App.Application.Commands.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = Category.Create(command.Name);

            if(await _unitOfWork.CategoryRepository.GetByNameAsync(category.Name) is not null)
                throw new BusinessException($"Already exists a category with name '{category.Name}'");
            
            category = await _unitOfWork.CategoryRepository.CreateAsync(category);

            await _unitOfWork.CompleteAsync();

            return new CreateCategoryCommandResponse { Id = category.Id };
        }
    }
}