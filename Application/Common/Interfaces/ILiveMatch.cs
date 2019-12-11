using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ILiveMatch
    {
        Task<string> Like(string fromUser, string toUser);
        Task<string> Unlike(string fromUser, string toUser);
    }
}
