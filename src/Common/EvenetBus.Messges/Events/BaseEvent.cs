using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenetBus.Messges.Events {
    public class BaseEvent {
        public BaseEvent(Guid? id, DateTime? createdDate) {
            Id = id ?? Guid.NewGuid();
            CreatedDate = createdDate ?? DateTime.UtcNow;
        }

        public Guid Id { get; }
        public DateTime CreatedDate { get; }
    }
}
