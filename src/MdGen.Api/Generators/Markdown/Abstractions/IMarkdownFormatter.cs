using MdGen.Api.Generators.Markdown.Models;

namespace MdGen.Api.Generators.Markdown.Abstractions;

public interface IMarkdownFormatter
{
    /// <summary>
    /// Creates a markdown heading.
    /// </summary>
    /// <param name="level">The heading level.</param>
    /// <param name="title">The heading text.</param>
    /// <returns>The heading content.</returns>
    string Heading(HeadingLevel level, string title);

    /// <summary>
    /// Creates a markdown text.
    /// </summary>
    /// <param name="content">The text.</param>
    /// <returns>The text content.</returns>
    string Text(string content);

    /// <summary>
    /// Creates a markdown new line.
    /// </summary>
    /// <returns>The new line.</returns>
    string NewLine();

    /// <summary>
    /// Creates a markdown link.
    /// </summary>
    /// <param name="text">The link text.</param>
    /// <param name="url">The link url.</param>
    /// <returns>The link.</returns>
    string Link(string text, string url);
}
