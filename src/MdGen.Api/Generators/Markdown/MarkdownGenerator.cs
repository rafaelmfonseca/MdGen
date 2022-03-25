using System.Text;
using MdGen.Api.Generators.Markdown.Abstractions;
using MdGen.Api.Generators.Markdown.Models;

namespace MdGen.Api.Generators.Markdown;

/// <summary>
/// Used to generate markdown content.
/// </summary>
public class MarkdownGenerator : IMarkdownGenerator
{
    private readonly StringBuilder _stringBuilder;
    private readonly IMarkdownFormatter _markdownFormatter;

    /// <summary>
    /// Creates a new instance of <see cref="MarkdownGenerator"/>.
    /// </summary>
    public MarkdownGenerator(IMarkdownFormatter markdownFormatter)
    {
        _stringBuilder = new StringBuilder();
        _markdownFormatter = markdownFormatter;
    }

    /// <inheritdoc />
    void IMarkdownGenerator.HeadingL1(string title)
        =>_stringBuilder.Append(_markdownFormatter.Heading(HeadingLevel.Level1, title));

    /// <inheritdoc />
    void IMarkdownGenerator.HeadingL2(string title)
        =>_stringBuilder.Append(_markdownFormatter.Heading(HeadingLevel.Level2, title));

    /// <inheritdoc />
    void IMarkdownGenerator.HeadingL3(string title)
        =>_stringBuilder.Append(_markdownFormatter.Heading(HeadingLevel.Level3, title));

    /// <inheritdoc />
    void IMarkdownGenerator.HeadingL4(string title)
        =>_stringBuilder.Append(_markdownFormatter.Heading(HeadingLevel.Level4, title));

    /// <inheritdoc />
    void IMarkdownGenerator.HeadingL5(string title)
        =>_stringBuilder.Append(_markdownFormatter.Heading(HeadingLevel.Level5, title));

    /// <inheritdoc />
    void IMarkdownGenerator.HeadingL6(string title)
        =>_stringBuilder.Append(_markdownFormatter.Heading(HeadingLevel.Level6, title));

    /// <inheritdoc />
    void IMarkdownGenerator.NewLine()
        => _stringBuilder.Append(_markdownFormatter.NewLine());

    /// <inheritdoc />
    void IMarkdownGenerator.Text(string content)
        => _stringBuilder.Append(_markdownFormatter.Text(content));

    /// <inheritdoc />
    public override string ToString()
        => _stringBuilder.ToString();
}
