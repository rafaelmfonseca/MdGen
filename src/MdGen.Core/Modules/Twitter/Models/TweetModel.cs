using Newtonsoft.Json;

namespace MdGen.Core.Modules.Twitter.Models;

[Serializable]
public class TweetModel
{
    [JsonProperty("id")]
    public string? Id { get; set; }

    [JsonProperty("text")]
    public string? Text { get; set; }

    [JsonProperty("author_id")]
    public string? AuthorId { get; set; }

    [JsonProperty("referenced_tweets")]
    public TweetModel[]? ReferencedTweets { get; set; }
}
