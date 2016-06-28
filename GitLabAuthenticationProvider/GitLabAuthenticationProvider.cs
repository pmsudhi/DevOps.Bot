using DevOpsBot.Authentication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static GitLabProvider.GitLabUtil;
using DevOpsBot.Util;

namespace GitLabProvider
{
    public class GitLabAuthenticationProvider : IAuthenticationBase
    {
        public AccessTokenTypeEnum AccessTokenTye;
        public string PrivateKey;
        DevOpsBotArgs AuthenticationParam;
        protected bool isAuthenticated;

        public GitLabAuthenticationProvider(DevOpsBotArgs AuthParam)
        {
            AuthenticationParam = AuthParam;
            
            Task.Run(async () => { await MainAsync(AuthParam); }).Wait();
        }

        public GitLabAuthenticationProvider()
        {
        }

        public bool Authenticated
        {
            get
            {
                throw new NotImplementedException();
            }
        }
         DevOpsBotArgs IAuthenticationBase.AuthenticationParam
        {
            get
            {
                return AuthenticationParam;
            }

            set
            {
                AuthenticationParam = value; ;
            }
        }

        public async Task<bool> Authenticate(DevOpsBotArgs AuthenticationParam)
        {
            bool AuthenticationResult = false;
            if (AuthenticationParam.ContainsKey(GitLabUtil.AuthenticationParam_AccessTokenType))
            {
                AccessTokenTye = (AccessTokenTypeEnum)Enum.Parse(typeof(AccessTokenTypeEnum), AuthenticationParam[GitLabUtil.AuthenticationParam_AccessTokenType].ToString());
                switch (AccessTokenTye)
                {
                    case AccessTokenTypeEnum.Private_Token:

                        if (AuthenticationParam.ContainsKey(GitLabUtil.AuthenticationParam_Private_Token))
                        {
                            PrivateKey = AuthenticationParam[GitLabUtil.AuthenticationParam_Private_Token].ToString();
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

        private async Task MainAsync(DevOpsBotArgs AuthenticationParam)
        {
            var result = await Authenticate(AuthenticationParam);
        }
    }
}