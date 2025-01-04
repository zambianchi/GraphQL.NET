using GraphQL.Types;
using GraphQLNet.Models;

namespace GraphQLNet.QLTypes;

public sealed class BookDetailType : ObjectGraphType<BookDetails>
{
    public BookDetailType()
    {
        Field(x => x.Id).Description("The id of the book detail");
        Field(x => x.Info).Description("The info of the book detail");
    }
}