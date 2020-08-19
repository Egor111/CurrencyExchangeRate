namespace CurrencyExchangeRate.Repository
{
    using CurrencyExchangeRate.Context;
    using CurrencyExchangeRate.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CurrencyCodesReferenceRepository : Repository<CurrencyCodesReference>
    {
        public CurrencyCodesReferenceRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
