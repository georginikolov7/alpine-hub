using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlpineHub.Core.Contracts
{
    public interface ICountersService
    {
        Task<int> GetNumberOfOpenLiftsAsync();
        Task<int> GetTotalNumberOfLiftsAsync();
        Task<int> GetNumberOfOpenSlopesAsync();
        Task<int> GetTotalNumberOfSlopesAsync();
    }
}
