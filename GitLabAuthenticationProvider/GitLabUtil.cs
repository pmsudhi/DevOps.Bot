using Devops.Bot;
using System;
using System.Net;
using DevOpsBot.Util;

namespace GitLabProvider
{
    public static class GitLabUtil
    {
        public static string AuthenticationParam_AccessTokenType = "AccessTokenType";

        public static string AuthenticationParam_BaseProjectURL = "Base_Project_URL";

        public static string AuthenticationParam_Private_Token = "Private_Token";

        public enum AccessTokenTypeEnum
        {
            Private_Token = 0,
            OAuth_2_Token = 1,
            Personal_Access_Token = 2
        }

        public static WebRequest createListProjectRequest(DevOpsBotArgs args, GitLabAuthenticationProvider AuthProvider)
        {
            WebRequest wr = null;

            Uri baseuri = new Uri(args[GitLabUtil.AuthenticationParam_BaseProjectURL].ToString());
            wr = WebRequest.Create(new Uri(baseuri, "projects"));
            addHeaders(ref wr, ref AuthProvider);

            return wr;
        }

        private static void addHeaders(ref WebRequest wr, ref GitLabAuthenticationProvider AuthProvider)
        {
            switch (AuthProvider.AccessTokenTye)
            {
                case AccessTokenTypeEnum.Private_Token:
                    wr.Headers["PRIVATE-TOKEN"] = AuthProvider.PrivateKey;
                    break;
            }
        }
    }
}