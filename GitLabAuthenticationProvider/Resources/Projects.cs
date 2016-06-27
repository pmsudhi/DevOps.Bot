using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabProvider.Resources
{
    public class Projects
    {
        Dictionary<string, string> InitParams;
        public void Initialize(Dictionary<string, string> InitilizationParam)
        {
            if(!InitilizationParam.ContainsKey(GitLabAuthenticationProvider.AuthenticationParam_BaseProjectURL))
            {
                throw new ArgumentNullException("Base_Project_URL", "Dictionary should contain an entry with key AuthenticationParam_BaseProjectURL and value");
            }
            InitParams = InitilizationParam;
        }
        public async Task<string> ListProjects()
        {
            string returnval = string.Empty;
            if(InitParams == null || InitParams.Count<1)
            {
                throw new InvalidOperationException("You Need to call Initialize method before calling this method");
            }

            return returnval;
        }
    }
}
