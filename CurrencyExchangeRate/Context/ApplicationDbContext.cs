namespace CurrencyExchangeRate.Context
{
    using CurrencyExchangeRate.Entities;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<CurrencyCodesReference> CurrencyCodesReference { get; set; }
        public DbSet<ExchangeRate> ExchangeRate { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
    }
}
