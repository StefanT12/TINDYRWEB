using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tindyr.CQRS.CMMD
{
    public class ProcessVar : IRequest<string>//IRequest is the return
    {
        public object Var { get; }

        public ProcessVar(object var)
        {
            Var = var;
        }
    }
}
