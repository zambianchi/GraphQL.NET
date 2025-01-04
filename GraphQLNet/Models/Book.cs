namespace GraphQLNet.Models;

public record Book(string Id, string Title, string Author)
{
    public List<BookDetails> Details { get; private set; } = [];
    
    public void SetDetails(List<BookDetails> details)
    {
        Details = details;
    }
}