using FluentEmail;
using MailEngine.Properties;
using MailTemplates.Messages;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;

namespace MailEngine
{
    public class Processor : IProcessor
    {
        /// <summary>
        /// Sends the specified data. Tempalte is configured off of the
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">Message Model <see cref="BaseMailMessage" /></param>
        public void Send<T>(T data) where T : BaseMailMessage
        {
            string body = GetTemplateString(data.TemplateFilePath);

            Email.From(data.FromName, data.FromAddress)
                .To(data.ToAddress)
                .Subject(data.Subject)
                .UsingTemplate(body, data)
                .UseSSL()
                .UsingClient(new SmtpClient
                {
                    Credentials = new NetworkCredential
                    {
                        Password = Settings.Default.Password,
                        UserName = Settings.Default.UserName
                    },
                    Host = Settings.Default.MailHost,
                    Port = Settings.Default.MailPort,
                    EnableSsl = Settings.Default.UseSSL
                }).Send();
        }

        private static string GetTemplateString(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(fileName))
            {
                if (stream == null)
                    return string.Empty;

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
