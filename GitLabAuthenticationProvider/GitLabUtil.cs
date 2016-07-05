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


    public class GitlabProject
    {
        public Project[] Property1 { get; set; }
    }

    public class Project
    {
        public int id { get; set; }
        public string description { get; set; }
        public string default_branch { get; set; }
        public object[] tag_list { get; set; }
        public bool _public { get; set; }
        public bool archived { get; set; }
        public int visibility_level { get; set; }
        public string ssh_url_to_repo { get; set; }
        public string http_url_to_repo { get; set; }
        public string web_url { get; set; }
        public string name { get; set; }
        public string name_with_namespace { get; set; }
        public string path { get; set; }
        public string path_with_namespace { get; set; }
        public bool issues_enabled { get; set; }
        public bool merge_requests_enabled { get; set; }
        public bool wiki_enabled { get; set; }
        public bool builds_enabled { get; set; }
        public bool snippets_enabled { get; set; }
        public object container_registry_enabled { get; set; }
        public DateTime created_at { get; set; }
        public DateTime last_activity_at { get; set; }
        public bool shared_runners_enabled { get; set; }
        public int creator_id { get; set; }
        public Namespace _namespace { get; set; }
        public string avatar_url { get; set; }
        public int star_count { get; set; }
        public int forks_count { get; set; }
        public int open_issues_count { get; set; }
        public bool public_builds { get; set; }
        public Permissions permissions { get; set; }
        public Owner owner { get; set; }
    }

    public class Namespace
    {
        public int id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public int? owner_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string description { get; set; }
        public Avatar avatar { get; set; }
        public bool share_with_group_lock { get; set; }
        public int visibility_level { get; set; }
    }

    public class Avatar
    {
        public object url { get; set; }
    }

    public class Permissions
    {
        public Project_Access project_access { get; set; }
        public Group_Access group_access { get; set; }
    }

    public class Project_Access
    {
        public int access_level { get; set; }
        public int notification_level { get; set; }
    }

    public class Group_Access
    {
        public int access_level { get; set; }
        public int notification_level { get; set; }
    }

    public class Owner
    {
        public string name { get; set; }
        public string username { get; set; }
        public int id { get; set; }
        public string state { get; set; }
        public string avatar_url { get; set; }
        public string web_url { get; set; }
    }

}