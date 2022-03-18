namespace MdGen.Api.Generators.Twitter.Exceptions;

public class NotValidTweetDataException : Exception
{
    public NotValidTweetDataException(string message) : base(message) { }
}
