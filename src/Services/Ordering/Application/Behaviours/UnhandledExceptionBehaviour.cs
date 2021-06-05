using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Behaviours {
    public class UnhandledExceptionBehaviour<Req, Res> : IPipelineBehavior<Req, Res> {
        public async Task<Res> Handle(Req request, CancellationToken cancellationToken, RequestHandlerDelegate<Res> next) {
            try {
                return await next();
            }
            catch (Exception e) {
                Console.WriteLine("[ERROR_REQ_UN]" + e.Message);
                throw;
            }

        }
    }
}
