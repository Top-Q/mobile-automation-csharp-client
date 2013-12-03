using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace robotium_client
{
    [DataContract]
    public class CommandResponse
    {
        private string originalCommand;
        private string[] parameters;
        private string response;
        private bool isSucceeded;

        /**
         * inits the command response with default values
         */
        public CommandResponse()
        {
            this.originalCommand = null;
            this.parameters = null;
            this.response = null;
            this.isSucceeded = false;
        }

        [DataMember(Name = "originalCommand")]
        public string OriginalCommand
        {
            set { originalCommand = value; }
            get { return originalCommand; }
        }

        [DataMember(Name = "params")]
        public string[] Parameters
        {
            set { parameters = value; }
            get { return parameters; }
        }

        [DataMember(Name = "response")]
        public string Response
        {
            set { response = value; }
            get { return response; }
        }

        [DataMember(Name = "succeeded")]
        public bool IsSucceeded
        {
            get { return isSucceeded; }
            set { isSucceeded = value; }
        }

    }

 	



}
