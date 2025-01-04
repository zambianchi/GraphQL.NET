using GraphQL.Types;
using GraphQLNet.QLQuery;

namespace GraphQLNet.QLSchema;

public class BookSchema : Schema
{
    public BookSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetRequiredService<BookQuery>();
    }
}