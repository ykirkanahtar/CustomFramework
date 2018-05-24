using System.Collections.Generic;

namespace CustomFramework.EmailProvider
{
    public interface IEmailManager
    {
        void SendEmail(string sender, IList<string> receiverList, string subject, string message);
    }
}