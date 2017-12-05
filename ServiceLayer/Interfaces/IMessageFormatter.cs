using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IMessageFormatter
    {
        /// <summary>
        /// build html for registration email
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="storeName"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        string BuildRegistrationMessage(string fullName, string email);
    }
}
