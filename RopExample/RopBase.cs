using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RopExample
{
    public class RoPBase<T> : IRoPStatus
    {
        protected T RoPObject { get; private set; }
        protected bool Status { get; set; }
        public IList<string> Messages { get; set; }

        public RoPBase(T ropObject)
        {
            RoPObject = ropObject;
            Messages = new List<string>();
            Status = true;
        }

        public IEnumerable<string> GetMessages()
        {
            return Messages;
        }

        public bool GetStatus()
        {
            return Status;
        }

        protected void SetStatusFalsWithMessage(string message)
        {
            Status = false;
            Messages.Add(message);
        }
    }
}
