using System;
using System.Collections.Generic;
using OCTM.Domain.Core.Events;

namespace OCTM.Infra.Data.Repository.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}