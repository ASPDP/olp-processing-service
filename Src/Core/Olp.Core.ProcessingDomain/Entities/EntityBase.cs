using Olp.Core.ProcessingDomain.Interfaces;


namespace Olp.Core.ProcessingDomain.Entities
{
    public class EntityBase<TId> : IEntity<TId>
        where TId : struct
    {
        #region IEntity<TId> implementation

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public TId? Id { get; set; } = default;

        #endregion 
    }
}
