using StreamAndDeferDemo.Database;
using StreamAndDeferDemo.Models;

namespace StreamAndDeferDemo.GraphQL;

public class Query
{
    [UsePaging(IncludeTotalCount = true)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Book> Books([Service] BooksContext context)
    {
        return context.Books;
    }
}