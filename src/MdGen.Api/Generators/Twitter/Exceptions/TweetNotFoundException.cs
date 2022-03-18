namespace MdGen.Api.Generators.Twitter.Exceptions;

public class TweetNotFoundException : Exception
{
    public TweetNotFoundException(string message) : base(message) { }
}
