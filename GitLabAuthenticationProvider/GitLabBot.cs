using Devops.Bot;
using DevOpsBot.Authentication;
using System;

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

        public override void Initialize(DevOpsBotArgs InitArgs, IAuthenticationBase AuthProvider)
        {
            base.Initialize(InitArgs, AuthProvider);
        }

        public override string List(DevOpsBotArgs args)
        {
            if (CheckIfInitialized())
            {
                if (AuthenticationProvider.Authenticated)
                {
                }
                else
                {
                    throw new MethodAccessException("You need to call Authenticate method of gitLabAuthentication provider with right parameters or call overloaded constructor");
                }
            }
            else
            {
                throw new MethodAccessException("Class not Initilized. You need to call Initialize method before calling any other method");
            }
            return string.Empty;
        }
    }
}