using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeekyMoney.Data;
using GeekyMoney.Model;

namespace GeekyMoney.Angular.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RealEstatePropertyController : Controller
    {
        private GeekyMoneyContext _context;

        public RealEstatePropertyController(GeekyMoneyContext context)
        {
            _context = context;
        }


        // GET: api/RealEstate
        [HttpGet]
        public IEnumerable<RealEstateProperty> Get()
        {
            var result = new List<RealEstateProperty>();

            result.Add(new RealEstateProperty
            {
                PropertyPrice = 100000,
                MarketValue = 100000,
                ListingDate = DateTime.Now.AddMonths(-6),
                SquareFeet = 1000

            });
            result.Add(new RealEstateProperty
            {
                PropertyPrice = 200000,
                MarketValue = 200000,
                ListingDate = DateTime.Now.AddMonths(-9),
                SquareFeet = 2000

            });
            return result;
        }

        // GET: api/RealEstate/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RealEstate
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RealEstate/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
