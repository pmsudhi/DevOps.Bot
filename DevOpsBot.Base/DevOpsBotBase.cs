using DevOpsBot.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devops.Bot
{
    public abstract class DevOpsBotBase
    {
        protected IAuthenticationBase AuthenticationProvider;
        protected DevOpsBotArgs InitParams;
        public abstract string List(DevOpsBotArgs args);
        public abstract string Get(DevOpsBotArgs args);
        public abstract string Add(DevOpsBotArgs args);
        public abstract string Edit(DevOpsBotArgs args);
        public abstract string Delete(DevOpsBotArgs args);

        public virtual void Initilize(DevOpsBotArgs InitArgs, IAuthenticationBase AuthProvider)
        {
            AuthenticationProvider = AuthProvider;
            InitParams = InitArgs;
        }
        

    }
}
