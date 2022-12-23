using Exchange_rates.Models;
using Exchange_rates.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Exchange_rates.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExchangeRatesController : Controller
    {
        private Cache _cache;
        private IRequests _requests;
        public ExchangeRatesController()
        {
            _cache = new Cache("Rates.json");
            _requests = new RequestProxy(_cache.Rates);
        }
        // GET: ExchangeRatesController
        [HttpGet("concrete/{currencyType}&{startPeriod}&{endPeriod}")]
        public async Task<ActionResult<List<Rates>>> GetConcreteDate(string currencyType, string startPeriod, string endPeriod)
        {
            List<Rates> currentRate = _requests.GetRateOnConcretePeriod(currencyType, startPeriod, endPeriod);
            _cache.TakeData(currentRate);
            return currentRate;
        }

        [HttpGet("floating/{currencyType}&{startPeriod}")]
        public async Task<ActionResult<List<Rates>>> GetFromStart(string currencyType, string startPeriod)
        {
            List<Rates> currentRate = _requests.GetRateOnConcretePeriod(currencyType, startPeriod, "");
            _cache.TakeData(currentRate);
            return currentRate;
        }
    }
}