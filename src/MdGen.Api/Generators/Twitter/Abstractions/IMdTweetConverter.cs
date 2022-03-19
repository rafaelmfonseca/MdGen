using MdGen.Api.Generators.Twitter.Models;

namespace MdGen.Api.Generators.Twitter.Abstractions;

public interface IMdTweetConverter
{
    /// <summary>
    /// Converts any data to a timeline with <see cref="MdTweetModel"/>.
    /// </summary>
    /// <param name="data">The data to convert.</param>
    /// <param name="firstTweetId">The first tweed id.</param>
    /// <returns>Lists of tweets in order.</returns>
    IList<MdTweetModel> Convert(object data, string firstTweetId);
}
