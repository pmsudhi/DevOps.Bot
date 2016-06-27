using DevOpsBot.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitLabProvider
{
    public class GitLabAuthenticationProvider: IAuthenticationBase
    {
        public AccessTokenTypeEnum AccessTokenTye;
        private string PrivateKey;
     
        public async Task<bool> Authenticate(Dictionary<string, string> AuthenticationParam)
        {
            bool AuthenticationResult=false;
            if(AuthenticationParam.ContainsKey(AuthenticationParam_AccessTokenType))
            {
                AccessTokenTypeEnum _AccessTokenTye = (AccessTokenTypeEnum)Enum.Parse(typeof(AccessTokenTypeEnum), AuthenticationParam[AuthenticationParam_AccessTokenType]);
                switch (AccessTokenTye)
                {
                    case AccessTokenTypeEnum.Private_Token:
                        
                        if(AuthenticationParam.ContainsKey(AuthenticationParam_Private_Token))
                        {
                            PrivateKey = AuthenticationParam[AuthenticationParam_Private_Token];
                            Authenticated = true;
                        }
                        else
                        {
                            throw new ArgumentNullException("Private_Token", "You must pass a parameter with key AuthenticationParam_Private_Token and value");
                        }
                        AuthenticationResult= true;
                        break;
                }
            }
            else
            {
                throw new ArgumentNullException("AccessTokenType", "You must pass a parameter with key AuthenticationParam_AccessTokenType and AccessTokenTypeEnum as value");
            }
            return AuthenticationResult;
        }
        public const string AuthenticationParam_AccessTokenType="AccessTokenType";
        public const string AuthenticationParam_Private_Token = "Private_Token";
        public const string AuthenticationParam_BaseProjectURL = "Base_Project_URL";

        public bool Authenticated
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
    public enum AccessTokenTypeEnum
    {
        Private_Token = 0,
        OAuth_2_Token = 1,
        Personal_Access_Token = 2

    }
}
