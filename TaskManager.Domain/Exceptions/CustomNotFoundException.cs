using TaskManager.Domain.Exceptions.BaseExceptions;

namespace TaskManager.Domain.Exceptions;

public class CustomNotFoundException : NotFoundException
{
    public CustomNotFoundException(string message) : base(message)
    {
    }
}