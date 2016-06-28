using DevOpsBot.Authentication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static GitLabProvider.GitLabUtil;

namespace GitLabProvider
{
    public class GitLabAuthenticationProvider : IAuthenticationBase
    {
        public AccessTokenTypeEnum AccessTokenTye;
        public string PrivateKey;
        protected bool isAuthenticated;
        protected Dictionary<string, string> AuthentParam;

        public GitLabAuthenticationProvider(Dictionary<string, string> AuthenticationParam)
        {
            AuthentParam = AuthenticationParam;
            Task.Run(async () => { await MainAsync(AuthentParam); }).Wait();
        }

        public GitLabAuthenticationProvider()
        {
        }

        private async Task MainAsync(Dictionary<string, string> AuthenticationParam)
        {
            var result = await Authenticate(AuthenticationParam);
        }

        public async Task<bool> Authenticate(Dictionary<string, string> AuthenticationParam)
        {
            bool AuthenticationResult = false;
            if (AuthenticationParam.ContainsKey(GitLabUtil.AuthenticationParam_AccessTokenType))
            {
                AccessTokenTye = (AccessTokenTypeEnum)Enum.Parse(typeof(AccessTokenTypeEnum), AuthenticationParam[GitLabUtil.AuthenticationParam_AccessTokenType]);
                switch (AccessTokenTye)
                {
                    case AccessTokenTypeEnum.Private_Token:

                        if (AuthenticationParam.ContainsKey(GitLabUtil.AuthenticationParam_Private_Token))
                        {
                            PrivateKey = AuthenticationParam[GitLabUtil.AuthenticationParam_Private_Token];
                            isAuthenticated = true;
                        }
                        else
                        {
                            throw new ArgumentNullException("Private_Token", "You must pass a parameter with key AuthenticationParam_Private_Token and value");
                        }
                        AuthenticationResult = true;
                        break;
                }
            }
            else
            {
                throw new ArgumentNullException("AccessTokenType", "You must pass a parameter with key AuthenticationParam_AccessTokenType and AccessTokenTypeEnum as value");
            }
            isAuthenticated = AuthenticationResult;
            return AuthenticationResult;
        }

        public bool Authenticated
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}