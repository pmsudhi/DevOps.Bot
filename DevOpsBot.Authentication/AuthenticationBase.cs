using System.Collections.Generic;
using System.Threading.Tasks;
using DevOpsBot.Util;

namespace DevOpsBot.Authentication
{
    public interface IAuthenticationBase
    {
        bool Authenticated { get; }
        DevOpsBotArgs AuthenticationParam { get; set; }
        Task<bool> Authenticate(DevOpsBotArgs AuthenticationParam);
    }
}