using App.Application.Queries.Dtos;
using App.Infrastructure.ReadOnlyData;
using Dapper;
using MediatR;

namespace App.Application.Queries.Handlers
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, QueryResponse>
    {
        private readonly IReadOnlyContext _readOnlyContext;
        public GetAllCategoriesQueryHandler(IReadOnlyContext readOnlyContext)
        {
            _readOnlyContext = readOnlyContext;
        }
        public async Task<QueryResponse> Handle(GetAllCategoriesQuery query, CancellationToken cancellationToken)
        {
            var data = await _readOnlyContext.Connection.QueryAsync<CategoryDto>(
            @"
                SELECT 
                    *,
                    ISNULL(
                        (SELECT 
                            COUNT(*)
                        FROM 
                            BookCategories
                        WHERE 
                            BookCategories.CategoryId = Categories.Id
                        GROUP BY    
                            BookCategories.CategoryId),
                        0) AS 'BookCount'
                FROM 
                    Categories
                ORDER BY 
                    Categories.Name ASC
            ");

            return new QueryResponse { Data = data };
        }
    }
}