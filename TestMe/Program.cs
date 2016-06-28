using GitLabProvider;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GitLabAuthenticationProvider gp = new GitLabAuthenticationProvider();
            Dictionary<string, string> objparam = new Dictionary<string, string>();
            objparam.Add(GitLabUtil.AuthenticationParam_AccessTokenType, GitLabUtil.AccessTokenTypeEnum.Private_Token.ToString());
            objparam.Add(GitLabUtil.AuthenticationParam_Private_Token, "rUVXQigQAU6h8YfzvhHg");
            objparam.Add(GitLabUtil.AuthenticationParam_BaseProjectURL, "http://waspsource/");
            Task.Run(async () => { await MainAsync(gp, objparam); }).Wait();
            GitLabBot gb = new GitLabBot();
        }

        private static async Task MainAsync(GitLabAuthenticationProvider gp, Dictionary<string, string> objparam)
        {
            var result = await gp.Authenticate(objparam);
        }
    }
}