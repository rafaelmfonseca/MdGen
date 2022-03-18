using MdGen.Api.Generators.Twitter.Exceptions;
using MdGen.Api.Generators.Twitter.Abstractions;

namespace MdGen.Api.Generators.Twitter;

public class TweetUrlIdExtractor : ITweetIdExtractor
{
    /// <inheritdoc />
    string ITweetIdExtractor.ExtractId(object data)
    {
        if (data is string tweetUrl)
        {
            var tweetUrlParts = tweetUrl.Split("/");

            if (tweetUrlParts.Length < 3)
            {
                throw new NotValidTweetUrlException($"The tweet url is not valid.");
            }

            var tweetId = tweetUrlParts.LastOrDefault();

            if (string.IsNullOrEmpty(tweetId))
            {
                throw new NotValidTweetUrlException($"The tweet url need to have at least one id.");
            }

            if (tweetId.Contains('?'))
            {
                tweetId = tweetId.Split("?")[0];
            }

            return tweetId;
        }

        throw new NotValidTweetUrlException($"The tweet url is not a string.");
    }
}
