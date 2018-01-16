using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RopExample
{
    public class SampleRequestHandler : RoPBase<SampleRequest>
    {
        public SampleRequestHandler(SampleRequest request): base(request)
        {
        }

        public SampleRequestHandler Validate()
        {
            if (string.IsNullOrEmpty(RoPObject.FirstName))
            {
                Status = false;
                Messages.Add("Imię nie może być puste");
            }

            if (string.IsNullOrEmpty(RoPObject.LastName))
            {
                Status = false;
                Messages.Add("Nazwisko nie może być puste");
            }

            if (string.IsNullOrEmpty(RoPObject.EmailAddress))
            {
                SetStatusFalsWithMessage("Adres e-mail nie może być pusty");
            }
            return this;
        }
        public SampleRequestHandler Persist()
        {
            if (!Status)
            {
                return this;
            }

            if (RequestRepository.CheckIfExist(RoPObject))
            {
                Status = false;
                Messages.Add($"Element o id={RoPObject.Id} już istnieje. Nie można zapisać kolejnego!");

                return this;
            }

            RequestRepository.AddToStore(RoPObject);

            return this;
        }      
        public IRoPStatus SendEmail()
        {
            if (!Status)
            {
                return this;
            }

            if (!MailService.CanSend(RoPObject))
            {
                Status = false;
                Messages.Add("Adres jest blokowany, nie można wysłać maila!");

                return this;
            }

            return this;
        }
    }
}
