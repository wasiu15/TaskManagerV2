using TaskManager.Domain.Exceptions.BaseExceptions;

namespace TaskManager.Domain.Exceptions;

public sealed class CustomNotAuthorizedException : NotAuthorizedException
{
    public CustomNotAuthorizedException(string message) : base(message)
    {
    }
}