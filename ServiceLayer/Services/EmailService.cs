using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    [ExcludeFromCodeCoverage]
    public class EmailService: IEmailService
    {
        private readonly IConfig _config;
        private readonly IMessageFormatter _messageFormatter;
        private readonly IMessageSender _messageSender;
        
        public EmailService(IConfig config, IMessageFormatter messageFormatter, IMessageSender messageSender)
        {
            _config = config;
            _messageFormatter = messageFormatter;
            _messageSender = messageSender;
        }

        /// <summary>
        /// method to configure the html and email for registration email
        /// </summary>
        /// <param name="fullname"></param>
        /// <param name="storename"></param>
        /// <param name="email"></param>
        /// <param name="toAddress"></param>
        public void SendRegistrationEmail(string fullname, string email, string toAddress)
        {
            var mailMessage = _messageFormatter.BuildRegistrationMessage(fullname, email);
            _messageSender.SendAsync(_config.FromAddress, toAddress, "Welcome to Smartdata", mailMessage, _config.CC_RegistrationEmail, _config.BCC_RegistrationEmail);
        }
        public bool SendForgotPasswordEmail(string fullname, string email, string toAddress,string body)
        {
            try
            {
                _messageSender.Send(_config.FromAddress, toAddress, "Reset Password", body);                
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

      
    }
}
