using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string subject, string body, string to);
    }
}
