﻿using domain;
using entityframework;
using Microsoft.EntityFrameworkCore;
using repository.AppRepositories.Base;
using repository.contract.IAppRepositories;

namespace repository.AppRepositories
{
    public class AccountRepository : AppGenericDefaultKeyRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Account> GetAccountByUserName(string userName)
        {
            var account = await Entities.FirstOrDefaultAsync(a => a.Username == userName);
            return account;
        }
    }
}
