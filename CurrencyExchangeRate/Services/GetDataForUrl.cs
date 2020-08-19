namespace CurrencyExchangeRate.Services
{
    using CurrencyExchangeRate.Interfaces;
    using CurrencyExchangeRate.Utils;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    /// <summary>
    /// Получение данных по url.
    /// </summary>
    public class GetDataForUrl :  IGetDataForUrl
    {
        private readonly HttpClient _client;

        public GetDataForUrl(
            HttpClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Получение json по Url.
        /// </summary>
        public string GetJsonAsync(string url)
        {
            var response = _client.GetAsync(url).Result;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            if (!response.IsSuccessStatusCode)
            {
                throw new ValidationException("Ошибка запроса с сервера");
            }

            var xmlStream = response.Content.ReadAsStreamAsync().Result;

            var xDocument = XDocument.Load(xmlStream);
            var xmlDocument = xDocument.ToXmlDocument();

            var json = JsonConvert.SerializeXmlNode(xmlDocument);

            return json;
        }
    }
}
