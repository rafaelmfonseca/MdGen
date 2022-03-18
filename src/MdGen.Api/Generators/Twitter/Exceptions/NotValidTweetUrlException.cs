namespace MdGen.Api.Generators.Twitter.Exceptions;

public class NotValidTweetUrlException : Exception
{
    public NotValidTweetUrlException(string message) : base(message) { }
}
