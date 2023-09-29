using TaskManager.Domain.Exceptions.BaseExceptions;

namespace TaskManager.Domain.Exceptions;
public class CustomNoContentException : NoContentException
{
    public CustomNoContentException(string message) : base(message)
    {

    }
}