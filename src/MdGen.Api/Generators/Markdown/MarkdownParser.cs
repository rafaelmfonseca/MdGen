using MdGen.Api.Generators.Markdown.Abstractions;
using MdGen.Api.Generators.Twitter.Models;

namespace MdGen.Api.Generators.Markdown;

public class MarkdownParser : IMarkdownParser
{
    private readonly IMarkdownGenerator _markdownGenerator;

    public MarkdownParser(IMarkdownGenerator markdownGenerator)
    {
        _markdownGenerator = markdownGenerator;
    }

    /// <inheritdoc />
    IMarkdownGenerator IMarkdownParser.Parse(IList<MdTweetModel> models)
    {
        foreach (MdTweetModel model in models)
        {
            string[] lines = model.Text.Split(Environment.NewLine);

            foreach (string line in lines)
            {
                _markdownGenerator.Text(line);
                _markdownGenerator.NewLine();
            }
        }

        return _markdownGenerator;
    }
}
