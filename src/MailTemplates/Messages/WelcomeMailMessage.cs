
namespace MailTemplates.Messages
{
    public class WelcomeMailMessage : BaseMailMessage
    {
        public override string ToAddress { get; set; }

        public override string FromName { get { return "John Smith"; } }
        public override string FromAddress { get { return "noreply@somesite.com"; } }
        public override string Subject { get { return "Welcome to MailMan!"; } }
        public override string TemplateFilePath { get { return "MailTemplates.Templates.welcome.html"; } }


        // Cusotm message properties go here =>

        public string FullName { get; set; }
    }
}
