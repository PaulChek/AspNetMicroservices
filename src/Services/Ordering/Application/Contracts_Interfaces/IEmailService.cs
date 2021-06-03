using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts_Interfaces {
    public interface IEmailService {
        Task<bool> SendMail(IEmail email);
    }

    public interface IEmail {
        string To { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
    }
}
