namespace CurrencyExchangeRate.Interfaces
{
    using CurrencyExchangeRate.Entities;
    using CurrencyExchangeRate.Model;
    using System;
    using System.Threading.Tasks;

    public interface IExchangeRateCreateService
    {
        /// <summary>
        /// Заполнение таблицы Курс валют.
        /// </summary>
        ResultModel<ExchangeRate> FillExchangeRate(DateTime dateTime);
    }
}
