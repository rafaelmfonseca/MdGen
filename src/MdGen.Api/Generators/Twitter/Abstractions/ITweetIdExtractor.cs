namespace MdGen.Api.Generators.Twitter.Abstractions;

public interface ITweetIdExtractor
{
    /// <summary>
    /// Extracts the tweet id from some data.
    /// </summary>
    /// <param name="data">The data to analyze.</param>
    /// <returns>The tweet id.</returns>
    string ExtractId(object data);
}
