using MdGen.Api.Generators.Markdown.Abstractions;
using MdGen.Api.Generators.Twitter.Models;

namespace MdGen.Api.Generators.Markdown;

public class MarkdownParser : IMarkdownParser
{
    /// <inheritdoc />
    IMarkdownGenerator IMarkdownParser.Parse(IList<MdTweetModel> models)
    {

    }
}
