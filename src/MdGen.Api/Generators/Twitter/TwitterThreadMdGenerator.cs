using Tweetinvi;
using Tweetinvi.Models.V2;
using Tweetinvi.Parameters.V2;
using MdGen.Api.Generators.Twitter.Exceptions;
using MdGen.Api.Generators.Twitter.Abstractions;
using MdGen.Api.Generators.Markdown.Abstractions;

namespace MdGen.Api.Generators.Twitter;

public class TwitterThreadMdGenerator : ITwitterThreadMdGenerator
{
    private readonly ITwitterClient _twitterClient;
    private readonly ITweetIdExtractor _tweetIdExtractor;
    private readonly IMdTweetConverter _mdTweetConverter;
    private readonly IMarkdownParser _markdownParser;

    public TwitterThreadMdGenerator(
        ITwitterClient twitterClient,
        ITweetIdExtractor tweetIdExtractor,
        IMdTweetConverter mdTweetConverter,
        IMarkdownParser markdownParser)
    {
        _twitterClient = twitterClient;
        _tweetIdExtractor = tweetIdExtractor;
        _mdTweetConverter = mdTweetConverter;
        _markdownParser = markdownParser;
    }

    /// <inheritdoc />
    async Task<string> ITwitterThreadMdGenerator.Generate(string tweetUrl)
    {
        var tweetId = _tweetIdExtractor.ExtractId(tweetUrl);

        var tweet = await _twitterClient.TweetsV2.GetTweetAsync(tweetId);

        if (tweet is { Tweet: null })
        {
            throw new TweetNotFoundException("Tweet not found.");
        }

        var author = await _twitterClient.UsersV2.GetUserByIdAsync(tweet.Tweet.AuthorId);

        if (author is { User: null })
        {
            throw new TweetAuthorNotFoundException("Author of the tweet not found.");
        }

        string query = $"from:{author.User.Username} to:{author.User.Username} conversation_id:{tweet.Tweet.Id}";

        var searchIterator = _twitterClient.SearchV2.GetSearchTweetsV2Iterator(new SearchTweetsV2Parameters(query));

        var tweets = new List<TweetV2>() { tweet.Tweet };

        while (!searchIterator.Completed)
        {
            var searchPage = await searchIterator.NextPageAsync();
            var searchResponse = searchPage.Content;

            tweets.AddRange(searchResponse.Tweets);
        }

        var mdTweets = _mdTweetConverter.Convert(tweets, tweetId);

        var markdown = _markdownParser.Parse(mdTweets);

        return markdown.ToString();
    }
}
