namespace WebHost.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeRateApiController : Controller
    {
        [HttpGet("{date_req}")]
        public void Get(DateTime date_req)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
               "http://free.ipwhois.io/json/" + date_req);
        }

        [HttpGet()]
        public void Get()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(
               "http://www.cbr.ru/scripts/XML_valFull.asp");
        }
    }
}