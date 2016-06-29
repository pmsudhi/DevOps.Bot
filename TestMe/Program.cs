using DevOpsBot.Util;
using GitLabProvider;
using System.IO;
using System.Threading.Tasks;

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
            objparam.Add(GitLabUtil.AuthenticationParam_BaseProjectURL, "http://waspsource/api/v3/projects");
            string ProcessorJson;
            using (TextReader reader = File.OpenText(@"G:\DevOps.Bot\Devops.Bot\GitLabAuthenticationProvider\Processores.json"))
            {
                ProcessorJson = reader.ReadToEnd();
            }
            objparam.Add(GitLabUtil.Gitlab_ProcessorJSON, ProcessorJson);
            Task.Run(async () => { await MainAsync(gp, objparam); }).Wait();
            GitLabBot gb = new GitLabBot();
            gb.Initialize(objparam, gp);
            DevOpsBotArgs Processorargs = new DevOpsBotArgs();
            Processorargs.Add(GitLabUtil.Gitlab_ProcessorType, GitLabUtil.GitlabResourceType.Projects.ToString());
            string str = gb.List(Processorargs);
        }

        private static async Task MainAsync(GitLabAuthenticationProvider gp, DevOpsBotArgs objparam)
        {
            var result = await gp.Authenticate(objparam);
        }
    }
}