using ServiceLayer.Emails.Templates;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Emails
{
    public class HtmlMessageFormatter : IMessageFormatter
    {
        private readonly IConfig _config;

        public HtmlMessageFormatter(IConfig config)
        {
            _config = config;
        }



        /// <summary>
        /// build html for registration email
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="storeName"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public string BuildRegistrationMessage(string fullName, string email)
        {
            var template = new Registration();
            template.Session = new Dictionary<string, object>();
            template.Session.Add("HostDomain", _config.SiteUrl);
            template.Session.Add("FullName", fullName);
            template.Session.Add("Email", email);
            template.Initialize();
            return template.TransformText();
        }

        public string BuildRegistrationMessage(string FullName, string Email, string Title, string Description, string TemplateName)
        {
            throw new NotImplementedException();
        }
    }
}
