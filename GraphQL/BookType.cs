using StreamAndDeferDemo.Models;

namespace StreamAndDeferDemo.GraphQL;

public class BookType : ObjectType<Book>
{
    public BookType() { }
    
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        base.Configure(descriptor);
        
        descriptor
            .Field("image")
            .ResolveWith<Resolvers>(r => r.GetImageUrl() );
    }

    private class Resolvers
    {
        public async Task<string?> GetImageUrl()
        {
            await Task.Delay(2000);
            return $"https://picsum.photos/200/100?random={new Random().Next(1, 1001)}";
        }
    }
}