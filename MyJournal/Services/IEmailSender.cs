using System.Threading.Tasks;

namespace MyJournal.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
