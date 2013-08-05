using System;

namespace MoqDemo
{
    public interface IEmailSender
    {
        void Send(string mail, string content);
    }

    public class EmailSender : IEmailSender
    {
        public void Send(string mail, string content)
        {
            throw new NotImplementedException();
        }
    }
}