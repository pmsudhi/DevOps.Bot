using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devops.Bot;
using DevOpsBot.Authentication;

namespace GitLabProvider
{
    public class GitLabBot : DevOpsBotBase
    {
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

        public override void Initilize(DevOpsBotArgs InitArgs, IAuthenticationBase AuthProvider)
        {
            base.Initilize(InitArgs, AuthProvider);
        }

        public override string List(DevOpsBotArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
