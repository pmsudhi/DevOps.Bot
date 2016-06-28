using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevOpsBot.Authentication
{
    public interface IAuthenticationBase
    {
        Task<bool> Authenticate(Dictionary<string, string> AuthenticationParam);

        bool Authenticated { get; }
    }
}