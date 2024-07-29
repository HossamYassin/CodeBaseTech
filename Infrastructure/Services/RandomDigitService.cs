using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class RandomDigitService : IRandomDigitService
    {
        public async Task<int> GenerateAsync()
        {
            Random random = new Random();
            return await Task.FromResult(random.Next(100000, 1000000));
        }
    }
}
