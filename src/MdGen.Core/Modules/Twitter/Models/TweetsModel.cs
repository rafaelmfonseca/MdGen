using Newtonsoft.Json;

namespace MdGen.Core.Modules.Twitter.Models;

[Serializable]
public class TweetsModel
{
    [JsonProperty("data")]
    public TweetModel[]? Data { get; set; }
}
