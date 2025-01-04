using GraphQL;
using GraphQL.Types;
using GraphQLNet.Models;
using GraphQLNet.QLTypes;
using GraphQLNet.Services;

namespace GraphQLNet.QLQuery;

public sealed class BookQuery : ObjectGraphType
{
    private readonly IBookService _bookService;

    public BookQuery(IBookService bookService)
    {
        _bookService = bookService;

        Field<ListGraphType<BookType>>("books")
            .Resolve(context =>
            {
                var books = _bookService.GetBooks();
                AddDetailsIfRequested(books, context);
                return books;
            });

        Field<BookType>("book")
            .Arguments(new QueryArguments(
                new QueryArgument<StringGraphType> { Name = "id" },
                new QueryArgument<StringGraphType> { Name = "title" }
            ))
            .Resolve(context =>
            {
                var id = context.GetArgument<string>("id");
                var title = context.GetArgument<string>("title");

                if (string.IsNullOrEmpty(id) && string.IsNullOrEmpty(title))
                {
                    context.Errors.Add(new ExecutionError("No parameters present"));
                    return null;
                }

                var book = GetBook(id, title);
                if (book == null) return null;

                AddDetailsIfRequested(book, context);
                return book;
            });
    }

    /// <summary>
    ///     Retrieves a book based on the provided ID or title.
    /// </summary>
    /// <param name="id">The unique identifier of the book.</param>
    /// <param name="title">The title of the book.</param>
    /// <returns>The <see cref="Book" /> object that matches the given ID or title, or null if both parameters are empty.</returns>
    private Book? GetBook(string id, string title)
    {
        if (!string.IsNullOrEmpty(id))
            return _bookService.GetBookById(id);

        if (!string.IsNullOrEmpty(title))
            return _bookService.GetBookByTitle(title);

        return null;
    }

    /// <summary>
    ///     Adds detailed information to each book in the provided list if requested in the query.
    /// </summary>
    /// <param name="books">The list of books to which details will be added.</param>
    /// <param name="context">The context of the GraphQL field resolution.</param>
    private void AddDetailsIfRequested(List<Book> books, IResolveFieldContext context)
    {
        foreach (var book in books)
            AddDetailsIfRequested(book, context);
    }

    /// <summary>
    ///     Adds detailed information to the book if requested in the query.
    /// </summary>
    /// <param name="book">The book to which details will be added.</param>
    /// <param name="context">The context of the GraphQL field resolution.</param>
    private void AddDetailsIfRequested(Book book, IResolveFieldContext context)
    {
        if (context.SubFields == null) return;

        if (context.SubFields.Any(field => field.Key.Equals(nameof(Book.Details), StringComparison.OrdinalIgnoreCase)))
            book.SetDetails(_bookService.GetBookDetailsById(book.Id));
    }
}