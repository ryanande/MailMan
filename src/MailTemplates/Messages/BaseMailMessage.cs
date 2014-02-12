
namespace MailTemplates.Messages
{
    public abstract class BaseMailMessage
    {
        public abstract string ToAddress { get; set; }
        public abstract string FromName { get; }
        public abstract string FromAddress { get; }
        public abstract string Subject { get; }
        public abstract string TemplateFilePath { get;  }
    }
}
