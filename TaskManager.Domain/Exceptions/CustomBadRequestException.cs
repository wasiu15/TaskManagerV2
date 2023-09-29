using TaskManager.Domain.Exceptions.BaseExceptions;

namespace TaskManager.Domain.Exceptions;

public sealed class CustomBadRequestException : BadRequestException
{
    public CustomBadRequestException(string message) : base(message)
    {
    }
}