using Olp.Core.ProcessingDomain.Entities;


namespace Olp.Repositories.ProcessingAbstractions;

public interface IRepositoryBase<TId, TEntity>
    where TEntity : EntityBase<TId>
    where TId : struct
{
    #region Get

    /// <summary>
    /// Получить сущность по Id.
    /// </summary>
    /// <param name="id">Id сущности.</param>
    /// <param name="asNoTracking">Не отслеживать изменения.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Cущность.</returns>
    Task<TEntity?> GetAsync(TId id, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить сущности с укзанными иднтификаторами.
    /// </summary>
    /// <param name="ids">Идентификаторы сущностей.</param>
    /// <param name="asNoTracking">Не отслеживать изменения.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Найденные сущности.</returns>
    Task<IList<TEntity>> GetAsync(IList<TId> ids, bool asNoTracking = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Запросить все сущности.
    /// </summary>
    /// <param name="asNoTracking">Не отслеживать изменения.</param>
    /// <returns>Провайдер сущностей.</returns>
    IQueryable<TEntity> GetAll(bool asNoTracking = false);

    /// <summary>
    /// Запросить все сущности.
    /// </summary>
    /// <param name="asNoTracking">Не отслеживать изменения.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Провайдер сущностей.</returns>
    Task<IList<TEntity>> GetAllAsync(bool asNoTracking = false, CancellationToken cancellationToken = default);

    #endregion

    #region Create

    /// <summary>
    /// Добавить в базу одну сущность.
    /// </summary>
    /// <param name="entity">Сущность для добавления.</param>
    /// <returns>Добавленная сущность.</returns>
    Task<TEntity> AddAsync(TEntity entity);

    #endregion

    #region Update

    /// <summary>
    /// Зпланировать обновление сущности при сохранении изменений.
    /// </summary>
    /// <param name="entity">Сущность для изменения.</param>
    void Update(TEntity entity);

    #endregion

    #region Delete

    /// <summary>
    /// Удалить сущность.
    /// </summary>
    /// <param name="id">Идентификатор удаляемой сущности.</param>
    /// <returns>Была ли сущность удалена.</returns>
    Task<bool> DeleteAsync(TId id);

    /// <summary>
    /// Удалить сущность.
    /// </summary>
    /// <param name="entity">Сущность для удаления.</param>
    /// <returns>Была ли сущность удалена.</returns>
    bool Delete(TEntity entity);

    /// <summary>
    /// Удалить сущности.
    /// </summary>
    /// <param name="entities">Сущности для удаления.</param>
    /// <returns>Была ли операция удаления завершена успешно.</returns>
    bool DeleteRange(ICollection<TEntity> entities);

    #endregion

    #region SaveChanges

    /// <summary>
    /// Сохранить изменения.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Задача, представляющая асинхронную операцию сохранения изменений.</returns>
    Task SaveChangesAsync(CancellationToken cancellationToken = default);

    #endregion
}
