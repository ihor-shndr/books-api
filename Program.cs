
using HotChocolate.Types.Pagination;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StreamAndDeferDemo.Database;
using StreamAndDeferDemo.GraphQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BooksContext>(opt =>
{
    opt.UseInMemoryDatabase("BooksDb");
});



builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<BookType>()
    .AddFiltering()
    .AddSorting()
    .AddProjections()                
    .SetPagingOptions(new PagingOptions
    {
        IncludeTotalCount = true,
        DefaultPageSize = 1000,
        MaxPageSize = 1000
    })
    .AddDirectiveType<StreamDirectiveType>() 
    .AddDirectiveType<DeferDirectiveType>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCorsPolicy", builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BooksContext>();
    await dbContext.Database.EnsureCreatedAsync();
}

app.MapGet("/hello", () => "Hello World!");

app.UseCors("DevCorsPolicy");

app.MapGraphQL();
app.Run();