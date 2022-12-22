using Exchange_rates.Models;
using Exchange_rates.Models.JsonWork;
using Exchange_rates.Models.Requests;
using Microsoft.AspNetCore.Http;
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
        [HttpGet("concrete/{id}&{startPeriod}&{endPeriod}")]
        public async Task<ActionResult<List<Rates>>> GetConcreteDate(int id, string startPeriod, string endPeriod)
        {
            List<Rates> currentRate = _requests.GetRateOnConcretePeriod(id,startPeriod, endPeriod);
            _cache.TakeData(currentRate);
            return currentRate;
        }

        [HttpGet("floating/{id}&{startPeriod}")]
        public async Task<ActionResult<List<Rates>>> GetFromStart(int id, string startPeriod)
        {
            List<Rates> currentRate = _requests.GetRateOnConcretePeriod(id, startPeriod, "");
            _cache.TakeData(currentRate);
            return currentRate;
        }
    }
}
