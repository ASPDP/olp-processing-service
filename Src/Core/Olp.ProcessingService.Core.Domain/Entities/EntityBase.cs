using Olp.ProcessingService.Core.Domain.Interfaces;

namespace Olp.ProcessingService.Core.Domain.Entities
{
    public class EntityBase<TId> : IEntity<TId>
    {
        #region IEntity<TId> implementation

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public TId? Id { get; set; } = default;

        #endregion 
    }
}
