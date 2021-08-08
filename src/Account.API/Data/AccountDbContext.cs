using Account.API.EntityConfigurations;
using Account.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.DataEncryption;
using Microsoft.EntityFrameworkCore.DataEncryption.Providers;

namespace Account.API.Data
{
  public class AccountDbContext : DbContext
  {
    private readonly IEncryptionProvider _provider;
    private readonly byte[] _encryptionKey;
    private readonly byte[] _encryptionIV;
    public AccountDbContext(DbContextOptions<AccountDbContext> options)
      : base(options)
    {
      _provider = new AesProvider(_encryptionKey, _encryptionIV);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.UseEncryption(_provider);
      builder.ApplyConfiguration(new AccountEntityTypeConfiguration());
    }

    public DbSet<AccountEntity> Accounts { get; set; }

  }
}
