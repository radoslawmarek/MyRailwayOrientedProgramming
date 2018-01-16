using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RopExample
{
    public class MailService
    {
        public static bool CanSend(SampleRequest request)
        {
            if(request.EmailAddress.Contains("blocked"))
            {
                return false;
            }

            return true;
        }

        public static void Send(SampleRequest request)
        {

        }
    }
}
