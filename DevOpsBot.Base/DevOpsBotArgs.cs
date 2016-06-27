using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devops.Bot
{
    public class DevOpsBotArgs:EventArgs
    {
        private Dictionary<string, object> arguments;

        public DevOpsBotArgs()
        {
            arguments = new Dictionary<string, object>();
        }

        public void Add(string key,string value)
        {
            arguments.Add(key, value);
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
    }
}
