using GraphQL.Types;
using GraphQLNet.Models;

namespace GraphQLNet.QLTypes;

public sealed class BookType : ObjectGraphType<Book>
{
    public BookType()
    {
        Field(x => x.Id).Description("The id of the book");
        Field(x => x.Title).Description("The title of the book");
        Field(x => x.Author).Description("The author of the book");
        Field(x => x.Details, typeof(ListGraphType<BookDetailType>)).Description("The details of the book");;
    }
}