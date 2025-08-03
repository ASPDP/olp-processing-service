namespace Olp.Core.ProcessingDomain.Interfaces;

/// <summary>
/// Интерфейс сущности с идентификатором.
/// </summary>
/// <typeparam name="TId"> Тип идентификатора.</typeparam>
public interface IEntity<TId>
    where TId : struct
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    TId? Id { get; set; }
}
