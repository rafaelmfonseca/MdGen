using Tweetinvi;
using Tweetinvi.Models;
using MdGen.Api.Filters;
using MdGen.Api.Generators.Markdown;
using MdGen.Api.Generators.Markdown.Abstractions;
using MdGen.Api.Generators.Twitter;
using MdGen.Api.Generators.Twitter.Abstractions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ITwitterClient>((serviceProvider) =>
{
    var section = builder.Configuration.GetSection("TwitterClient");

    var appCredentials = new ConsumerOnlyCredentials
    {
        ConsumerKey = section.GetValue<string>("ConsumerKey"),
        ConsumerSecret = section.GetValue<string>("ConsumerSecret"),
        BearerToken = section.GetValue<string>("BearerToken")
    };

    var appClient = new TwitterClient(appCredentials);
    appClient.Auth.InitializeClientBearerTokenAsync().Wait();
    return appClient;
});
builder.Services.AddScoped<ITwitterThreadMdGenerator, TwitterThreadMdGenerator>();
builder.Services.AddScoped<ITweetIdExtractor, TweetUrlIdExtractor>();
builder.Services.AddScoped<IMdTweetConverter, MdTweetConverter>();
builder.Services.AddScoped<IMarkdownGenerator, MarkdownGenerator>();
builder.Services.AddScoped<IMarkdownFormatter, MarkdownFormatter>();
builder.Services.AddTransient<IMarkdownParser, MarkdownParser>();
builder.Services.AddControllers(options => options.Filters.Add(typeof(ApiExceptionFilterAttribute)));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(name: "default", pattern: "api/{controller}/{action=Index}/{id?}");

app.Run();