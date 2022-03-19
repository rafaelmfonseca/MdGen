namespace MdGen.Api.Generators.Markdown.Abstractions;

public interface IMarkdownGenerator
{
    void HeadingL1(string title);
    void HeadingL2(string title);
    void HeadingL3(string title);
    void HeadingL4(string title);
    void HeadingL5(string title);
    void HeadingL6(string title);
    void Text(string content);
    void NewLine();
}
