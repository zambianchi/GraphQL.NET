using GraphQLNet.Models;

namespace GraphQLNet.Services;

public interface IBookService
{
    /// <summary>
    /// Retrieves a list of all books available.
    /// </summary>
    /// <returns>A list of <see cref="Book"/> object.</returns>
    List<Book> GetBooks();
    
    /// <summary>
    /// Retrieves a book based on its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the book.</param>
    /// <returns>The <see cref="Book"/> object that matches the given ID.</returns>
    Book GetBookById(string id);
    
    /// <summary>
    /// Retrieves a book based on its title.
    /// </summary>
    /// <param name="title">The title of the book.</param>
    /// <returns>The <see cref="Book"/> object that matches the given title.</returns>
    Book GetBookByTitle(string title);
    
    /// <summary>
    /// Retrieves detailed information about a book based on its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the book.</param>
    /// <returns>A list of <see cref="BookDetails"/> objects containing detailed information about the book.</returns>
    List<BookDetails> GetBookDetailsById(string id);
}