using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RopExample
{
    public interface IRoPStatus
    {
        IEnumerable<string> GetMessages();
        bool GetStatus();
    }
}
