using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace robotium_client
{
    [DataContract]
    public class CommandRequest
    {
        private string command;
        private string[] parameters;

        public CommandRequest(string command, string[] parameters)
        {
            this.command = command;
            this.parameters = parameters;
        }

        [DataMember(Name = "command")]
        public string Command
        {
            get { return command; }
            set { command = value; }
        }

        [DataMember(Name = "params")]
        public string[] Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }
    }
}
