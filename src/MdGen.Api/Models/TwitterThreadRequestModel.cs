using System.Text.Json.Serialization;

namespace MdGen.Api.Models;

public class TwitterThreadRequestModel
{
    [JsonPropertyName("tweet_url")]
    public string TweetUrl { get; set; }
}
