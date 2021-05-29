using Ordering.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.App.Contracts.Infrastructure {
    public interface IEmailService {
        Task<bool> SendEmail(Email mail);
    }
}
