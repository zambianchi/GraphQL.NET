using GraphQLNet.Models;

namespace GraphQLNet.Services;

public class BookService : IBookService
{
    private readonly List<Book> _books =
    [
        new(Guid.NewGuid().ToString(), "The Catcher in the Rye", "J.D. Salinger"),
        new(Guid.NewGuid().ToString(), "1984", "George Orwell")
    ];

    public List<Book> GetBooks()
    {
        return _books;
    }

    public Book GetBookById(string id)
    {
        return _books.First(b => b.Id == id);
    }

    public Book GetBookByTitle(string title)
    {
        return _books.First(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
    }

    public List<BookDetails> GetBookDetailsById(string id)
    {
        return
        [
            new BookDetails(Guid.NewGuid().ToString(), $"Published by ABC Publisher, ISBN: {Guid.NewGuid():N}"),
            new BookDetails(Guid.NewGuid().ToString(), $"Published by XYZ Publisher, ISBN: {Guid.NewGuid():N}"),
        ];
    }
}