namespace CurrencyExchangeRate.Serializations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExchangeRateSerialization
    {
        /// <summary>
        /// Номинал.
        /// </summary>
        public int Nominal { get; set; }

        /// <summary>
        /// Значение курса.
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Дата курса.
        /// </summary>
        public DateTime Date { get; set; }
    }
}
