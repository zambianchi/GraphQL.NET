using GraphQL;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Types;
using GraphQLNet.QLQuery;
using GraphQLNet.QLSchema;
using GraphQLNet.QLTypes;
using GraphQLNet.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IBookService, BookService>();

builder.Services.AddSingleton<BookType>();
builder.Services.AddSingleton<BookDetailType>();

builder.Services.AddSingleton<BookQuery>();
builder.Services.AddSingleton<ISchema, BookSchema>();

builder.Services.AddLogging();
builder.Logging.AddConsole();

builder.Services.AddGraphQL(qlBuilder =>
    qlBuilder
        .AddSystemTextJson()
        .AddDataLoader()
        .AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = true));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();

app.UseWebSockets();

// Configure the graphql endpoint at "/graphql"
app.UseGraphQL();

// Configure GraphiQL at "/"
app.UseGraphQLGraphiQL(
    "/",
    new GraphiQLOptions
    {
        GraphQLEndPoint = "/graphql",
        SubscriptionsEndPoint = "/graphql"
    });

app.UseHttpsRedirection();

await app.RunAsync();