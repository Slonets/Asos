using Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISmtpEmailService
    {
        void Send(Message message);
        void DownloadMessages();
        void SuccessfulLogin(string userName, string email);
    }
}
