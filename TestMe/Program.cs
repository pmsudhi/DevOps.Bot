using GitLabProvider;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            GitLabAuthenticationProvider gp = new GitLabAuthenticationProvider();
            Dictionary<string, string> objparam = new Dictionary<string, string>();
            objparam.Add(GitLabAuthenticationProvider.AuthenticationParam_AccessTokenType, AccessTokenTypeEnum.Private_Token.ToString());
            objparam.Add(GitLabAuthenticationProvider.AuthenticationParam_Private_Token, "rUVXQigQAU6h8YfzvhHg");
            objparam.Add(GitLabAuthenticationProvider.AuthenticationParam_BaseProjectURL, "http://waspsource/");
            Task.Run(async () => { await MainAsync(gp,objparam); }).Wait();
            GitLabBot gb = new GitLabBot();
            
        }
        static async Task MainAsync(GitLabAuthenticationProvider gp, Dictionary<string, string> objparam)
        {
           var result=await gp.Authenticate(objparam);
        }
    }
}
