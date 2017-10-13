using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        // GET: api/RealEstateProperty
        [HttpGet]
        public IEnumerable<IRealEstateProperty> Get()
        {
            return _service.GetAll();
        }

        // GET: api/RealEstateProperty/5
        [HttpGet("{id}")]
        public IRealEstateProperty Get(int id)
        {
            return _service.Get(id);
        }

        // POST: api/RealEstateProperty
        [HttpPost]
        public IActionResult Post([FromBody]RealEstateProperty value)
        {
            var result = _service.Create(value);
            return Ok();
        }

        // PUT: api/RealEstateProperty/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]RealEstateProperty value)
        {
            var result = _service.Update(value);
            return Ok(); ;
        }

        // DELETE: api/RealEstateProperty/5
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
    }
}
