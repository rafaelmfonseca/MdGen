using MdGen.Core.Modules.Twitter.Models;

namespace MdGen.Core.Modules.Twitter;

public interface ITwitterClient : IDisposable
{
    Task<TweetsModel?> GetTweetAsync(string idTweet);
    Task<TweetsModel?> GetConversationAsync(string idConversation, string? idAuthor, string? nextToken);
}
