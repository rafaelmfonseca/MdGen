using MdGen.Api.Generators.Twitter.Models;

namespace MdGen.Api.Generators.Markdown.Abstractions;

public interface IMarkdownParser
{
    /// <summary>
    /// Parses a list of <see cref="MdTweetModel"/> and converts to <see cref="IMarkdownGenerator"/>.
    /// </summary>
    /// <param name="models">All tweets.</param>
    /// <returns>The markdown content parsed.</returns>
    IMarkdownGenerator Parse(IList<MdTweetModel> models);
}
