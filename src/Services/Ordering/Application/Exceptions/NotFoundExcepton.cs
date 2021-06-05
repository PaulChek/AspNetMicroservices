using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions {
    public class NotFoundException : ApplicationException {
        public NotFoundException(string name, object key) : base($"[ERROR_DB]'{name}' ({key}) was not found") {
        }
    }
}
