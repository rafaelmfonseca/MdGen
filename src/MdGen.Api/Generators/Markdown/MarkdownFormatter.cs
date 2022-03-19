using MdGen.Api.Generators.Markdown.Abstractions;
using MdGen.Api.Generators.Markdown.Models;

namespace MdGen.Api.Generators.Markdown;

public class MarkdownFormatter : IMarkdownFormatter
{
    /// <inheritdoc />
    string IMarkdownFormatter.Heading(HeadingLevel level, string title)
        => $"{new string('#', (int) level)} {title}";

    /// <inheritdoc />
    string IMarkdownFormatter.NewLine()
        => "<br />";

    /// <inheritdoc />
    string IMarkdownFormatter.Text(string content)
        => content;

    /// <inheritdoc />
    string IMarkdownFormatter.Link(string text, string url)
        => $"[{text}]({url})";
}
