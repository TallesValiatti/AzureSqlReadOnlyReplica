using App.Application.Queries.Dtos;
using App.Infrastructure.ReadOnlyData;
using Dapper;
using MediatR;

namespace App.Application.Queries.Handlers
{
    public class GetAllBookQueryHandler : IRequestHandler<GetAllBooksQuery, QueryResponse>
    {
        private readonly IReadOnlyContext _readOnlyContext;
        public GetAllBookQueryHandler(IReadOnlyContext readOnlyContext)
        {
            _readOnlyContext = readOnlyContext;
        }
        public async Task<QueryResponse> Handle(GetAllBooksQuery query, CancellationToken cancellationToken)
        {
            var data = await _readOnlyContext.Connection.QueryAsync<BookDto>(
            @"
                SELECT 
                    *,
                    (SELECT 
                        STRING_AGG( Categories.Name, ',') 
                    FROM 
                        BookCategories 
                    JOIN 
                        Categories ON BookCategories.CategoryId = Categories.Id
                    WHERE 
                        BookCategories.BookId = Books.Id) AS 'Categories'
                FROM 
                    Books
                ORDER BY 
                    Books.Name ASC
            ");

            return new QueryResponse { Data = data };
        }
    }
}