namespace CurrencyExchangeRate.Interfaces
{
    using CurrencyExchangeRate.Entities;
    using CurrencyExchangeRate.Model;

    public interface ICurrencyExchangeRateCreateService
    {
        /// <summary>
        /// Заполнение таблицы Справочник по кодам валют.
        /// </summary>
        ResultModel<CurrencyCodesReference> FillCurrencyCodesReference();
    }
}
