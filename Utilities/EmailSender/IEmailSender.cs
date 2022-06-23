namespace Utilities.EmailSender
{
    using Utilities.EmailSender.Models;
    using System.Threading.Tasks;

    public interface IEmailSender
    {
        Task SendEmailAsync(EmailRequestModel model);
    }
}
