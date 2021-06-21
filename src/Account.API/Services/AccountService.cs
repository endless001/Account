using Account.API.Data;
using Account.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly AccountDbContext _accountDbContext;


        public AccountService(AccountDbContext accountDbContext)
        {
            _accountDbContext = accountDbContext;
        }

        public async Task<AccountEntity> CheckOrCreateAsync(string phone)
        {

            var account = await _accountDbContext.Accounts.FirstOrDefaultAsync(a => a.Phone == phone);
            
            if (account == null)
            {
                account = new AccountEntity()
                {
                    Phone = phone,
                };
                _accountDbContext.Add(account);
                await _accountDbContext.SaveChangesAsync();
            }

            return account;

        }
        public async Task<AccountEntity> SearchAsync(string phone)
        {
            var account = await _accountDbContext.Accounts.FirstOrDefaultAsync(u => u.Phone == phone);
            return account;
        }

        public async Task<bool> RegisterEmailAsync(AccountEntity accountEntity)
        {
            var account = await _accountDbContext.Accounts.FirstOrDefaultAsync(a => a.Email == accountEntity.Email);

            if (account != null)
            {
                return false;
            }

            account = new AccountEntity()
            {
                Email = accountEntity.Email,
                AccountName = accountEntity.AccountName,
                Password = accountEntity.Password
            };

            _accountDbContext.Add(account);
            await _accountDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RegisterPhoneAsync(AccountEntity accountEntity)
        {
            var account = await _accountDbContext.Accounts.FirstOrDefaultAsync(a => a.Phone == accountEntity.Phone);
            
            if (account != null)
            {
                return false;
            }

            account = new AccountEntity()
            {
                Phone = accountEntity.Phone,
                AccountName = accountEntity.AccountName,
                Password = accountEntity.Password
            };

            _accountDbContext.Add(account);
            await _accountDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<AccountEntity> PasswordSignInAsync(string accountName, string password)
        {
            var account = await _accountDbContext.Accounts.FirstOrDefaultAsync(a => a.AccountName == accountName && a.Password == password);
            return account;
        }
    }
}
