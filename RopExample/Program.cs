using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RopExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // --- First Request
            var firstRequest = new SampleRequest()
            {
                Id = 1,
                FirstName = "abcd",
                LastName = "azxsdf",
                EmailAddress = "aaa@rr.org.pl"
            };

            var firstRequestStatus = new SampleRequestHandler(firstRequest)
                .Validate()
                .Persist()
                .SendEmail();

            PrintStatus(firstRequestStatus);

            // --- Second request
            var secondRequest = new SampleRequest()
            {
                Id = 2,
                FirstName = "abrakadabra",
                EmailAddress = "aaa@rr.org.pl"
            };

            var secondRequestStatus = new SampleRequestHandler(secondRequest)
                .Validate()
                .Persist()
                .SendEmail();

            PrintStatus(secondRequestStatus);

            // --- Third request
            var thirdRequest = new SampleRequest()
            {
                Id = 3,
                EmailAddress = "aaa@rr.org.pl"
            };
            var thirdRequestStatus = new SampleRequestHandler(thirdRequest)
                .Validate()
                .Persist()
                .SendEmail();

            PrintStatus(thirdRequestStatus);

            // --- Fourth request
            var fourthRequest = new SampleRequest()
            {
                Id = 1,
                FirstName = "qqqqqq",
                LastName = "aaaaaaa",
                EmailAddress = "aaa@rr.org.pl"
            };
            var fourthRequestStatus = new SampleRequestHandler(fourthRequest)
                .Validate()
                .Persist()
                .SendEmail();

            PrintStatus(fourthRequestStatus);
            

            // --- Fifth request
            var fifthRequest = new SampleRequest()
            {
                Id = 5,
                FirstName = "qqqqqq",
                LastName = "aaaaaaa",
                EmailAddress = "aaa@blocked.org.pl"
            };

            var fifthRequestStatus = new SampleRequestHandler(fifthRequest)
                .Validate()
                .Persist()
                .SendEmail();

            PrintStatus(fifthRequestStatus);

            Console.WriteLine("Finished... Press a key.");
            Console.ReadKey();
        }

        private static void PrintStatus(IRoPStatus status)
        {
            Console.WriteLine($"Request status... {status.GetStatus()}");
            foreach (var message in status.GetMessages())
            {
                Console.WriteLine($"\tMessage: {message}");
            }
            Console.WriteLine();
        }
    }
}
