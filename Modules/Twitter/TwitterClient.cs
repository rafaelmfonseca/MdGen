using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Web;

namespace ContentPacker.Modules.Twitter;

public class TwitterClient : ITwitterClient
{
    private readonly HttpClient _httpClient;

    public TwitterClient()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri("https://api.twitter.com/2/") };
    }


    public async Task<string> GetThread(string idConversation, string idAuthor, string? nextToken)
    {
        try
        {
            var query = HttpUtility.ParseQueryString(string.Empty);
            query["query"] = $"conversation_id:{idConversation} from:{idAuthor}";
            query["expansions"] = "author_id,referenced_tweets.id,attachments.media_keys";
            query["next_token"] = nextToken;

            var request = new HttpRequestMessage(HttpMethod.Get, "/tweets/search/recent" + query.ToString());
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "");

            var response = await _httpClient.SendAsync(request);

        }
        catch (Exception e)
        {

        }
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }

}
