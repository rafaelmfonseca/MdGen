namespace MdGen.Api.Generators.Twitter.Exceptions;

public class TweetAuthorNotFoundException : Exception
{
    public TweetAuthorNotFoundException(string message) : base(message) { }
}
