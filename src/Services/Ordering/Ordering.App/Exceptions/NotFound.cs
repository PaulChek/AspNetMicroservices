using System;

namespace Ordering.App.Exceptions {
    public class NotFound : ApplicationException {
        public NotFound(string name, object key) : base($"Entity {name}>>{key} was not found!") { }
    }
}
