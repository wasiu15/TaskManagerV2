using TaskManager.Domain.Exceptions.BaseExceptions;

namespace TaskManager.Domain.Exceptions;
public class CustomDuplicateRequestException : DuplicateRequestException
{
    public CustomDuplicateRequestException(string message) : base(message)
    {

    }
}