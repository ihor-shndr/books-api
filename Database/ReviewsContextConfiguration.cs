using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StreamAndDeferDemo.Models;

namespace StreamAndDeferDemo.Database;

public class ReviewsContextConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        var reviews = new List<Review>();
        for (int i = 1; i <= 1000; i++)
        {
            reviews.Add(new Review
            {
                Id = i,
                Content = $"Review for Book {i}",
                BookId = i
            });
        }

        builder.HasData(reviews);
    }
}