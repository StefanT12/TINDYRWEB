using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces
{
    public interface IAppUser
    {
        bool IsAuthenticated { get; }

        int UserID { get; }
    }
}
