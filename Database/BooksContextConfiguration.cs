using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StreamAndDeferDemo.Models;

namespace StreamAndDeferDemo.Database;

public class BooksContextConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        var books = new List<Book>();
        for (int i = 1; i <= 1000; i++)
        {
            books.Add(new Book
            {
                Id = i,
                Title = $"Sample Book {i}"
            });
        }

        builder.HasData(books);
    }
}