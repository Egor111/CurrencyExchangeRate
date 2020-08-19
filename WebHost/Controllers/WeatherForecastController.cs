using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CurrencyExchangeRate.Serializations;
using System.Text.Json;
using System.Xml.Linq;
using Newtonsoft.Json;
using CurrencyExchangeRate.Utils;
using CurrencyExchangeRate.Interfaces;

namespace WebHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        //private readonly ICurrencyExchangeRateCreateService _currencyExchangeRateCreateService;
        private readonly IExchangeRateCreateService _exchangeRateCreateService;

        public WeatherForecastController(
            IExchangeRateCreateService exchangeRateCreateService)
        {
           // _currencyExchangeRateCreateService = currencyExchangeRateCreateService;
            _exchangeRateCreateService = exchangeRateCreateService;
        }

        ///// <summary>
        ///// Заполнение таблицы Справочник по кодам валют.
        ///// </summary>
        //[HttpGet]
        //public JsonResult FillCurrencyExchangeRate()
        //{
        //    var result = _currencyExchangeRateCreateService.FillCurrencyCodesReference();

        //    if (!result.Result)
        //    {
        //        return Json(result.ErrorMessages);
        //    }

        //    return Json("Добавлены записи в таблицу Справочник по кодам валют");
        //}

        ///// <summary>
        /////  Заполнение таблицы Курс валют.
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public JsonResult FillExchangeRate()
        //{
        //    var result = _exchangeRateCreateService.FillExchangeRate(DateTime.Now);

        //    if (!result.Result)
        //    {
        //        return Json(result.ErrorMessages);
        //    }

        //    return Json("Добавлены записи в таблицу Курс валют");
        //}


        ///// <summary>
        /////  Заполнение таблицы Курс валют на отперделенный день
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //public JsonResult FillExchangeRate(DateTime dateTime)
        //{
        //    var result = _exchangeRateCreateService.FillExchangeRate(DateTime.Now);

        //    if (!result.Result)
        //    {
        //        return Json(result.ErrorMessages);
        //    }

        //    return Json("Добавлены записи в таблицу Курс валют");
        //}


        //[HttpGet]
        //public JsonResult Get(string charCode, DateTime dateTime)
        //{

        //}

        //[HttpGet]
        //public JsonResult Get(int NumCode, DateTime dateTime)
        //{

        //}

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var aa = new List<string>();
            var rng = new Random();

            return aa;
        }
    }
}
