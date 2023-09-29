namespace TaskManager.Domain.Exceptions.BaseExceptions;

public abstract class NotFoundException : Exception
{
    protected NotFoundException(string message) : base(message) { }
}
