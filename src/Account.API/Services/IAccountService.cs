using Account.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.API.Services
{
    public interface IAccountService
    {
        Task<AccountEntity> CheckOrCreateAsync(string phone);
        Task<AccountEntity> SearchAsync(string phone);
        Task<AccountEntity> PasswordSignInAsync(string accountName,string password);
        Task<bool> RegisterPhoneAsync(AccountEntity accountEntity);
        Task<bool> RegisterEmailAsync(AccountEntity accountEntity);
    }
}
