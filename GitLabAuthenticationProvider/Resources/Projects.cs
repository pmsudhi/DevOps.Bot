using Devops.Bot;
using DevOpsBot.Authentication;
using System;
using System.Net;
using System.Threading.Tasks;

namespace GitLabProvider.Resources
{
    public class Projects : DevOpsBotBase
    {
        private DevOpsBotArgs InitParams;

        public override string Add(DevOpsBotArgs args)
        {
            throw new NotImplementedException();
        }

        public override string Delete(DevOpsBotArgs args)
        {
            throw new NotImplementedException();
        }

        public override string Edit(DevOpsBotArgs args)
        {
            throw new NotImplementedException();
        }

        public override string Get(DevOpsBotArgs args)
        {
            throw new NotImplementedException();
        }

        public override void Initialize(DevOpsBotArgs InitArgs, IAuthenticationBase AuthProvider)
        {
            if (!InitArgs.ContainsKey(GitLabUtil.AuthenticationParam_BaseProjectURL))
            {
                throw new ArgumentNullException("Base_Project_URL", "Dictionary should contain an entry with key AuthenticationParam_BaseProjectURL and value");
            }
            InitParams = InitArgs;
        }

        public override string List(DevOpsBotArgs args)
        {
            GitLabAuthenticationProvider gla = (GitLabAuthenticationProvider)AuthenticationProvider;
            WebRequest wr = GitLabUtil.createListProjectRequest(InitParams, gla);
            return null;
        }

        public async Task<string> ListProjects()
        {
            string returnval = string.Empty;
            if (InitParams == null || InitParams.Count < 1)
            {
                throw new InvalidOperationException("You Need to call Initialize method before calling this method");
            }

            return returnval;
        }
    }
}