using DevOpsBot.Util;
using System;
using System.Net;

namespace GitLabProvider
{
    public static class GitLabUtil
    {
        public static string AuthenticationParam_AccessTokenType = "AccessTokenType";

        public static string AuthenticationParam_BaseProjectURL = "Base_Project_URL";

        public static string AuthenticationParam_Private_Token = "Private_Token";

        public static string Gitlab_ProcessorJSON = "Processor_JSON";
        public static string Gitlab_ProcessorType = "Processor_Type";

        public enum AccessTokenTypeEnum
        {
            Private_Token = 0,
            OAuth_2_Token = 1,
            Personal_Access_Token = 2
        }

        public enum GitlabResourceType
        {
            Branches = 0,
            Builds = 1,
            Build_triggers = 2,
            Build_Variables = 3,
            Commits = 4,
            Deploy_Keys = 5,
            Groups = 6,
            Issues = 7,
            Keys = 8,
            Labels = 9,
            Merge_Requests = 10,
            Milestones = 11,
            Notes = 12,
            Projects = 13,
            Project_Snippets = 14,
            Repositories = 15,
            Repository_Files = 16,
            Runners = 17,
            Services = 18,
            Session = 19,
            Settings = 20,
            Tags = 21,
            Users = 22
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

    public class Processor
    {
        public string classname { get; set; }
        public string key { get; set; }
        public string path { get; set; }
    }

    public class ProcessorObjects
    {
        public Processor[] processor { get; set; }
    }
}