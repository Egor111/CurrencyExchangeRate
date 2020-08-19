namespace CurrencyExchangeRate.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// Получение данных по url.
    /// </summary>
    public interface IGetDataForUrl
    {
        /// <summary>
        /// Получение json по Url.
        /// </summary>
        string GetJsonAsync(string url);
    }
}
