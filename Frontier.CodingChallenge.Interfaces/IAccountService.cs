using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Frontier.CodingChallenge.Models;

namespace Frontier.CodingChallenge.Interfaces
{
    public interface IAccountService
    {
        Task<List<Account>> GetAccounts();
    }
}
