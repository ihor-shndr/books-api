namespace StreamAndDeferDemo.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    public List<Review> Reviews { get; set; }
}