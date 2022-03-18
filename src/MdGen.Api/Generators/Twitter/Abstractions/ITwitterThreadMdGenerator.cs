namespace MdGen.Api.Generators.Twitter.Abstractions;

public interface ITwitterThreadMdGenerator
{
    /// <summary>
    /// Generates a markdown file from some tweet.
    /// </summary>
    /// <param name="tweetUrl">The tweet url.</param>
    /// <returns>The markdown content</returns>
    Task<string> Generate(string tweetUrl);
}
