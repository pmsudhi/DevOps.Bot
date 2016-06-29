using System;
using System.Collections.Generic;

namespace DevOpsBot.Util
{
    public class DevOpsBotArgs : EventArgs
    {
        private Dictionary<string, object> arguments;

        public DevOpsBotArgs()
        {
            arguments = new Dictionary<string, object>();
        }

        public int Count
        {
            get
            {
                return arguments.Count;
            }
        }

        public object this[string key]
        {
            get
            {
                return arguments[key];
            }
            set
            {
                arguments[key] = value;
            }
        }

        public void Add(string key, string value)
        {
            arguments.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return arguments.ContainsKey(key);
        }
    }
}