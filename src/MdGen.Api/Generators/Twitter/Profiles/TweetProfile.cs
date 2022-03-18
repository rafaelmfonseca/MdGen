using AutoMapper;
using Tweetinvi.Models.V2;
using MdGen.Api.Generators.Twitter.Models;

namespace MdGen.Api.Generators.Twitter.Profiles;

public class TweetProfile : Profile
{
    public TweetProfile()
    {
        CreateMap<TweetV2, MdTweetModel>()
            .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text));
    }
}
