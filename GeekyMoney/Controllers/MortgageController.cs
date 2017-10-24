using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GeekyMoney.Model;
using GeekyMoney.Services;
using GeekyMoney.Data;
using AutoMapper;

namespace GeekyMoney.Angular.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MortgageController : Controller
    {
        MortgageService _service;

        public MortgageController(GeekyMoneyContext context, IMapper mapper)
        {
            _service = new MortgageService(context, mapper);
        }
        // GET: api/Mortgage
        [HttpGet]
        public IEnumerable<IMortgage> Get()
        {
            return _service.GetAll();
        }

        // GET: api/Mortgage/5
        [HttpGet("{id}")]
        public IMortgage Get(int id)
        {
            return _service.Get(id);
        }
        
        // POST: api/Mortgage
        [HttpPost]
        public IActionResult Post([FromBody]Mortgage value)
        {
            _service.Create(value);
            return Ok();
        }
        
        // PUT: api/Mortgage/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Mortgage value)
        {
            _service.Update(value);
            return Ok();
        }
        
        // DELETE: api/Mortgage/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
