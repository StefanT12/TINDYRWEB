using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tindyr.CQRS.CMMD
{
    public class ProcessVarHandler : IRequestHandler<ProcessVar, string>
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<string> Handle(ProcessVar request, CancellationToken cancellationToken)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var obj = request.Var;

            var objToInt = 0;
            var canCast = int.TryParse((string)obj, out objToInt);

            if (canCast)
            {
                return "Its a number";
            }

            return "A string or something else";
        }
    }
}
