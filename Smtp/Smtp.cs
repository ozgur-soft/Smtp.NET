using System.Net;
using System.Net.Mail;

namespace Smtp {
    public interface ISmtp {
        void SetHost(string host);
        void SetPort(int port);
        void SetUsername(string username);
        void SetPassword(string password);
        void Mail(MailAddress from, MailAddress to, string subject, string message);
    }
    public class Smtp : ISmtp {
        private string Host { get; set; }
        private int Port { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        public Smtp() { }
        public void SetHost(string host) {
            Host = host;
        }
        public void SetPort(int port) {
            Port = port;
        }
        public void SetUsername(string username) {
            Username = username;
        }
        public void SetPassword(string password) {
            Password = password;
        }
        public void Mail(MailAddress from, MailAddress to, string subject, string message) {
            try {
                var smtp = new SmtpClient {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(Username, Password),
                    Host = Host,
                    Port = Port
                };
                var mail = new MailMessage(from, to) {
                    IsBodyHtml = true,
                    Subject = subject,
                    Body = message
                };
                smtp.Send(mail);
            } catch (Exception err) {
                if (err.InnerException != null) {
                    Console.WriteLine(err.InnerException.Message);
                } else {
                    Console.WriteLine(err.Message);
                }
            }
        }
    }
}