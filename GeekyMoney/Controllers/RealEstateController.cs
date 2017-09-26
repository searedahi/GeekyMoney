using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeekyMoney.Data;

namespace GeekyMoney.Angular.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RealEstateController : Controller
    {
        private GeekyMoneyContext _context;

        public RealEstateController(GeekyMoneyContext context) {
            _context = context;
        }


        // GET: api/RealEstate
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
