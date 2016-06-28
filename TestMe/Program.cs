using GitLabProvider;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevOpsBot.Util;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GitLabAuthenticationProvider gp = new GitLabAuthenticationProvider();
            DevOpsBotArgs objparam = new DevOpsBotArgs();
            objparam.Add(GitLabUtil.AuthenticationParam_AccessTokenType, GitLabUtil.AccessTokenTypeEnum.Private_Token.ToString());
            objparam.Add(GitLabUtil.AuthenticationParam_Private_Token, "rUVXQigQAU6h8YfzvhHg");
            objparam.Add(GitLabUtil.AuthenticationParam_BaseProjectURL, "http://waspsource/");
            Task.Run(async () => { await MainAsync(gp, objparam); }).Wait();
            GitLabBot gb = new GitLabBot();
            gb.Initialize(objparam, gp);
        }

        private static async Task MainAsync(GitLabAuthenticationProvider gp, DevOpsBotArgs objparam)
        {
            var result = await gp.Authenticate(objparam);
        }
    }
}