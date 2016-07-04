using Devops.Bot;
using DevOpsBot.Authentication;
using DevOpsBot.Util;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Reflection;

namespace GitLabProvider
{
    public class GitLabBot : DevOpsBotBase
    {
        private ProcessorObjects objProcessors;

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
            if (InitArgs.ContainsKey(GitLabUtil.Gitlab_ProcessorJSON))
            {
                objProcessors = new ProcessorObjects();
                objProcessors = JsonConvert.DeserializeObject<ProcessorObjects>(InitArgs[GitLabUtil.Gitlab_ProcessorJSON].ToString());
                base.Initialize(InitArgs, AuthProvider);
            }
            else
            {
                throw new ArgumentException("Processor_JSON", "You need to pass a Json string contating processors with key Processor_JSON");
            }
        }

        public override string List(DevOpsBotArgs args)
        {
            string response = "";
            if (CheckIfInitialized())
            {
                if (AuthenticationProvider.Authenticated)
                {
                    if (args.ContainsKey(GitLabUtil.Gitlab_ProcessorType))
                    {
                        string processortype = args[GitLabUtil.Gitlab_ProcessorType].ToString();
                        Processor prs = objProcessors.processor.Where(x => x.key == processortype).SingleOrDefault();
                        if (prs != null)
                        {
                            Assembly processorAssembly = Assembly.LoadFrom(prs.path);
                            Type AssemblyType = processorAssembly.GetType(prs.classname);
                            DevOpsBotBase objActivity =(DevOpsBotBase) Activator.CreateInstance(AssemblyType);
                            objActivity.Initialize(InitParams, AuthenticationProvider);
                            response= objActivity.List(args);
                        }
                        else
                        {
                            throw new ArgumentException("Processor_Type", "Processor_Type " + processortype + "is not defined in Processores.json please cross check the details");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Processor_Type", "You need to specify Processor_Type as key and GitlabResourceType as value in arguments in order to execute this method");
                    }
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
            return response;
        }

    }
}