using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class SMSService : ISMSService
    {
        public Task<bool> SendAsync(string to, string message)
        {
            // integrate with sms provider
            
            return Task.FromResult(true);
        }
    }
}
