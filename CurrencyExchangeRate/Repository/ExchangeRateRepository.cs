namespace CurrencyExchangeRate.Repository
{
    using CurrencyExchangeRate.Context;
    using CurrencyExchangeRate.Entities;

    public class ExchangeRateRepository : Repository<ExchangeRate>
    {
        public ExchangeRateRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
