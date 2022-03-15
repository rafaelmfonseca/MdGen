using MdGen.Core.Modules.Twitter.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Web;

namespace MdGen.Core.Modules.Twitter;

public class TwitterClient : ITwitterClient
{
    private readonly HttpClient _httpClient;

    public TwitterClient()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri("https://api.twitter.com/2/") };
    }

    public async Task<TweetsModel?> GetTweetAsync(string idTweet)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);
        query["id"] = idTweet;
        query["expansions"] = "author_id,in_reply_to_user_id,referenced_tweets.id";

        var request = new HttpRequestMessage(HttpMethod.Get, "/tweets/search/recent" + query.ToString());
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        string content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<TweetsModel>(content);
    }

    public async Task<TweetsModel?> GetConversationAsync(string idConversation, string? idAuthor, string? nextToken)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);
        query["query"] = $"conversation_id:{idConversation} from:{idAuthor}";
        query["expansions"] = "author_id,referenced_tweets.id,attachments.media_keys";
        query["next_token"] = nextToken;

        var request = new HttpRequestMessage(HttpMethod.Get, "/tweets/search/recent" + query.ToString());
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "");

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        string content = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject<TweetsModel>(content);
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }

}
