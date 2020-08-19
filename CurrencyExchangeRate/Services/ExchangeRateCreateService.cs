namespace CurrencyExchangeRate.Services
{
    using Base.EF.Interfaces;
    using CurrencyExchangeRate.Entities;
    using CurrencyExchangeRate.Interfaces;
    using CurrencyExchangeRate.Model;
    using CurrencyExchangeRate.Serializations;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExchangeRateCreateService : IExchangeRateCreateService
    {
        private readonly IGetDataForUrl _getDataForUrl;
        private readonly IRepository<ExchangeRate> _repository;

        public ExchangeRateCreateService(
            IGetDataForUrl getDataForUrl,
            IRepository<ExchangeRate> repository)
        {
            _getDataForUrl = getDataForUrl;
            _repository = repository;
        }

        /// <summary>
        /// Заполнение таблицы Курс валют.
        /// </summary>
        public ResultModel<ExchangeRate> FillExchangeRate(DateTime dateTime)
        {
            var resultModel = new ResultModel<ExchangeRate>();

            try
            {
                var model = GetData(dateTime);
                var urlModel = GetUrlData(dateTime);

                var saveModel = ProcessorData(model, urlModel);

                Save(saveModel);
            }
            catch (Exception ex)
            {
                resultModel.ErrorMessages = new List<string> { ex.Message };
                resultModel.Result = false;
                return resultModel;
            }

            resultModel.Result = true;

            return resultModel;
        }

        /// <summary>
        /// 
        /// </summary>
        private List<ExchangeRate> GetData(DateTime dateTime)
        {
            var data = _repository.GetAll()
                .Where(x => x.Date == dateTime)
                .ToList();

            return data;
        }

        /// <summary>
        /// Получение данных с портала ЦБ.
        /// </summary>
        private CashModel GetUrlData(DateTime dateTime)
        {
            var jsonResult = _getDataForUrl.GetJsonAsync("http://www.cbr.ru/scripts/XML_daily.asp?date_req=12.08.2019");

            var start = 10;
            var end = start + 1;
            var data = jsonResult.Substring(start, jsonResult.Length - end);

            var cashModel = JsonConvert.DeserializeObject<CashModel>(data);

            return cashModel;
        }

        /// <summary>
        /// Подготовка данных для сохранения.
        /// </summary>
        private List<ExchangeRate> ProcessorData(List<ExchangeRate> models, CashModel urlModel)
        {
            var saveModel = new List<ExchangeRate>();
            var ExchangeRateUrlModels = urlModel.Item.ToList();

            foreach (var ExchangeRateUrlModel in ExchangeRateUrlModels)
            {
                //if (!models.Any(x => x.IsoNumCode == currencyCodesReferenceUrlModel.ISO_Num_Code))
                //{
                //    saveModel.Add(new ExchangeRate
                //    {
                //        Name = currencyCodesReferenceUrlModel.Name,
                //        EngName = currencyCodesReferenceUrlModel.EngName,
                //        ParentCode = currencyCodesReferenceUrlModel.ParentCode,
                //        IsoNumCode = currencyCodesReferenceUrlModel.ISO_Num_Code,
                //        IsoCharCode = currencyCodesReferenceUrlModel.ISO_Char_Code
                //    });
                //}
            }

            return saveModel;
        }

        /// <summary>
        /// Сохранение
        /// </summary>
        private void Save(List<ExchangeRate> saveModels)
        {
            //_repository.Create(saveModels);
        }

        /// <summary>
        /// Кэш модель.
        /// </summary>
        private class CashModel
        {
            /// <summary>
            /// 
            /// </summary>
            public string name { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public ExchangeRateSerialization[] Item { get; set; }
        }
    }
}
