using Tweetinvi.Models.V2;

namespace MdGen.Api.Generators.Twitter.Extensions;

public static class TweetV2Extensions
{
    /// <summary>
    /// Verifies if a <see cref="TweetV2"/> is a reply to another <see cref="TweetV2"/>.
    /// </summary>
    /// <param name="tweet">The tweet to compare.</param>
    /// <param name="parentTweet">The parent tweet.</param>
    /// <returns>True if its a response.</returns>
    public static bool IsReplyTo(this TweetV2 tweet, TweetV2 parentTweet)
    {
        if (tweet == null || tweet.ReferencedTweets == null)
        {
            return false;
        }

        return tweet.ReferencedTweets.Any(x => x.Id == parentTweet.Id && x.Type == "replied_to");
    }
}
