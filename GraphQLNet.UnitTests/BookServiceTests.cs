using GraphQLNet.Services;

namespace GraphQLNet.UnitTests;

public class BookServiceTests
{
    private readonly BookService _bookService = new();

    [Fact]
    public void GetBooks_ShouldReturnAllBooks()
    {
        // Act
        var books = _bookService.GetBooks();

        // Assert
        Assert.Equal(2, books.Count);
    }

    [Fact]
    public void GetBookById_ShouldReturnCorrectBook()
    {
        // Arrange
        var bookId = _bookService.GetBooks().First().Id;

        // Act
        var book = _bookService.GetBookById(bookId);

        // Assert
        Assert.NotNull(book);
        Assert.Equal(bookId, book.Id);
    }

    [Fact]
    public void GetBookByTitle_ShouldReturnCorrectBook()
    {
        // Arrange
        var bookTitle = "1984";

        // Act
        var book = _bookService.GetBookByTitle(bookTitle);

        // Assert
        Assert.NotNull(book);
        Assert.Contains(bookTitle, book.Title, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void GetBookDetailsById_ShouldReturnBookDetails()
    {
        // Arrange
        var bookId = _bookService.GetBooks().First().Id;

        // Act
        var bookDetails = _bookService.GetBookDetailsById(bookId);

        // Assert
        Assert.NotNull(bookDetails);
        Assert.Equal(2, bookDetails.Count);
    }
}