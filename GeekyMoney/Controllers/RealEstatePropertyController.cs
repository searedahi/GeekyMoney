using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GeekyMoney.Data;
using GeekyMoney.Model;
using GeekyMoney.Services;
using AutoMapper;

namespace GeekyMoney.Angular.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RealEstatePropertyController : Controller
    {
        RealEstatePropertyService _service;
        public RealEstatePropertyController(GeekyMoneyContext context, IMapper mapper)
        {
            _service = new RealEstatePropertyService(context, mapper);
        }

        // GET: api/RealEstateProperties
        [HttpGet]
        public IEnumerable<IRealEstateProperty> Get()
        {
            return _service.GetAll();
        }

        // GET: api/RealEstateProperties/5
        [HttpGet("{id}")]
        public IRealEstateProperty Get(int id)
        {
            return _service.Get(id);
        }

        // POST: api/RealEstateProperties
        [HttpPost]
        public IActionResult Post([FromBody]RealEstateProperty value)
        {
            var result = _service.Create(value);
            return Ok();
        }

        // PUT: api/RealEstateProperties/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]RealEstateProperty value)
        {
            var result = _service.Update(value);
            return Ok(); ;
        }

        // DELETE: api/RealEstateProperties/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
        
        // GET: api/RealEstateProperties/PercentOfOptions/0
        [HttpGet("[action]/{id}")]
        public IEnumerable<PercentOfOption> PercentOfOptions(int id)
        {
            return _service.PercentOfOptions(id);
        }
    }
}
