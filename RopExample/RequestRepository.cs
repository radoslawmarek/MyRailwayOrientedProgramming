using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RopExample
{
    public static class RequestRepository
    {
        private static IList<SampleRequest> requestStore = new List<SampleRequest>();

        public static void AddToStore(SampleRequest request)
        {
            requestStore.Add(request);
        }

        public static bool CheckIfExist(SampleRequest request)
        {
            return requestStore.Any(r => r.Id == request.Id);
        }
    }
}
