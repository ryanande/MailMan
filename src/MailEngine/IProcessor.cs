using MailTemplates.Messages;

namespace MailEngine
{
    public interface IProcessor
    {
        /// <summary>
        /// Sends the specified data. Tempalte is configured off of the 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">Message Model <see cref="BaseMailMessage"/></param>
        void Send<T>(T data) where T : BaseMailMessage;
    }
}
