using System.Text;

namespace MdGen.Api.Generators.Markdown;

public class MarkdownGenerator
{
    private readonly StringBuilder _stringBuilder;

    public MarkdownGenerator()
    {
        _stringBuilder = new StringBuilder();
    }
}
