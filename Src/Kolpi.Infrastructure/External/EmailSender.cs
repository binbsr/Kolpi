using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace Kolpi.Infrastructure.External
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // TODO: Wire this up to actual email sending logic via SendGrid, local SMTP, etc.
            return Task.CompletedTask;
        }
    }
}
