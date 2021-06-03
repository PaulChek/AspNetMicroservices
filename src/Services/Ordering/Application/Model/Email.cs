using Application.Contracts_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Model {
    public class Email : IEmail {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
