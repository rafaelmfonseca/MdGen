using MdGen.Api.Generators.Twitter.Abstractions;
using MdGen.Api.Generators.Twitter.Exceptions;
using MdGen.Api.Generators.Twitter.Extensions;
using MdGen.Api.Generators.Twitter.Models;
using Tweetinvi.Models.V2;
using AutoMapper;

namespace MdGen.Api.Generators.Twitter;

public class MdTweetConverter : IMdTweetConverter
{
    private readonly IMapper _mapper;

    public MdTweetConverter(IMapper mapper)
    {
        _mapper = mapper;
    }

    /// <inheritdoc />
    IList<MdTweetModel> IMdTweetConverter.Convert(object data, string firstTweetId)
    {
        if (data is IList<TweetV2> tweets)
        {
            var firstTweet = tweets.FirstOrDefault(t => t.Id == firstTweetId);

            if (firstTweet == null)
            {
                throw new NotValidTweetDataException($"The first tweet could not be found.");
            }

            var tweetsOrdered = new List<TweetV2>();

            tweetsOrdered.Add(firstTweet);

            TweetV2 nextTweet = null;

            while ((nextTweet = FindNextReply(tweets, nextTweet ?? firstTweet)) != null)
            {
                tweetsOrdered.Add(nextTweet);
            }

            return _mapper.Map<List<MdTweetModel>>(tweetsOrdered);
        }

        throw new NotValidTweetDataException($"The data cannot be converted to TweetV2.");
    }

    private TweetV2 FindNextReply(IList<TweetV2> tweets, TweetV2 lastTweet)
        => tweets.FirstOrDefault(t => t.IsReplyTo(lastTweet));
}
