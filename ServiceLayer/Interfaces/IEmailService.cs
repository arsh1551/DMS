using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IEmailService
    {
        void SendRegistrationEmail(string fullname, string email, string toAddress);
        bool SendForgotPasswordEmail(string fullname, string email, string toAddress, string body);
    }
}
