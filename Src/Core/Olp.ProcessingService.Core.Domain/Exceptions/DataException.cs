namespace Olp.ProcessingService.Core.Domain.Exceptions;

/// <summary>
/// Класс исключения из-за неправильных данных.
/// </summary>
public class DataException : Exception
{
    public DataException() { }

    public DataException(string message) : base(message)
    {
    }

    public DataException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
