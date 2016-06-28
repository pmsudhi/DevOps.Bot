using DevOpsBot.Authentication;

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

        public virtual void Initialize(DevOpsBotArgs InitArgs, IAuthenticationBase AuthProvider)
        {
            AuthenticationProvider = AuthProvider;
            InitParams = InitArgs;
        }

        public virtual bool CheckIfInitialized()
        {
            if (AuthenticationProvider == null || InitParams == null || InitParams.Count <= 1)
            {
                return false;
            }
            return true;
        }
    }
}