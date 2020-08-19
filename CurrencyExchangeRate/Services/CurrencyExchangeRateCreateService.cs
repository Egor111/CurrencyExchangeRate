namespace CurrencyExchangeRate.Services
{
    using Base.EF.Interfaces;
    using CurrencyExchangeRate.Entities;
    using CurrencyExchangeRate.Interfaces;
    using CurrencyExchangeRate.Model;
    using CurrencyExchangeRate.Serializations;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class CurrencyExchangeRateCreateService //: ICurrencyExchangeRateCreateService
    {
        private readonly IGetDataForUrl _getDataForUrl;
        private readonly IRepository<CurrencyCodesReference> _repository;

        public CurrencyExchangeRateCreateService(
            IGetDataForUrl getDataForUrl,
            IRepository<CurrencyCodesReference> repository)
        {
            _getDataForUrl = getDataForUrl;
            _repository = repository;
        }

        /// <summary>
        /// Заполнение таблицы Справочник по кодам валют.
        /// </summary>
        public ResultModel<CurrencyCodesReference> FillCurrencyCodesReference()
        {
            var resultModel = new ResultModel<CurrencyCodesReference>();

            try
            {
                var model = GetData();
                var urlModel = GetUrlData();

                var saveModel = ProcessorData(model, urlModel);

                Save(saveModel);
            }
            catch (ValidationException ex)
            {
                resultModel.ErrorMessages = new List<string> { ex.Message };
                resultModel.Result = false;
            }

            resultModel.Result = true;

            return resultModel;
        }

        /// <summary>
        /// 
        /// </summary>
        private List<CurrencyCodesReference> GetData()
        {
            var data = _repository.GetAll().ToList();

            return data;
        }

        /// <summary>
        /// Получение данных с портала ЦБ.
        /// </summary>
        private CashModel GetUrlData()
        {
            var jsonResult = _getDataForUrl.GetJsonAsync("http://www.cbr.ru/scripts/XML_valFull.asp");

            var start = 10;
            var end = start + 1;
            var data = jsonResult.Substring(start, jsonResult.Length - end);

            var cashModel = JsonConvert.DeserializeObject<CashModel>(data);

            return cashModel;
        }

        /// <summary>
        /// Подготовка данных для сохранения.
        /// </summary>
        private List<CurrencyCodesReference> ProcessorData(List<CurrencyCodesReference> models, CashModel urlModel)
        {
            var saveModel = new List<CurrencyCodesReference>();
            var currencyCodesReferenceUrlModels = urlModel.Item.ToList();

            foreach (var currencyCodesReferenceUrlModel in currencyCodesReferenceUrlModels)
            {
                if (!models.Any(x => x.IsoNumCode == currencyCodesReferenceUrlModel.ISO_Num_Code))
                {
                    saveModel.Add(new CurrencyCodesReference
                    {
                        Name = currencyCodesReferenceUrlModel.Name,
                        EngName = currencyCodesReferenceUrlModel.EngName,
                        ParentCode = currencyCodesReferenceUrlModel.ParentCode,
                        IsoNumCode = currencyCodesReferenceUrlModel.ISO_Num_Code,
                        IsoCharCode = currencyCodesReferenceUrlModel.ISO_Char_Code
                    });
                }
            }

            return saveModel;
        }

        /// <summary>
        /// Сохранение
        /// </summary>
        private void Save(List<CurrencyCodesReference> saveModels)
        {
            _repository.Create(saveModels);
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
            public CurrencyCodesReferenceSerialization[] Item { get; set; }
        }
    }
}
