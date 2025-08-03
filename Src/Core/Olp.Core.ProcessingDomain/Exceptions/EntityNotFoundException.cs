namespace Olp.Core.ProcessingDomain.Exceptions;

/// <summary>
/// Класс исключения из-за отсутствия искомой сущности.
/// </summary>
public class EntityNotFoundException : DataException
{
    public static string DataEntityIdKey = "entityId";

    public EntityNotFoundException() { }

    public EntityNotFoundException(string message) : base(message)
    {
    }

    public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
