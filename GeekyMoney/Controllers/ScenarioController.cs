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
    public class ScenarioController : Controller
    {
        RealEstateScenarioService _service;

        public ScenarioController(GeekyMoneyContext context, IMapper mapper)
        {
            _service = new RealEstateScenarioService(context, mapper);
        }
        // GET: api/Scenarios
        [HttpGet]
        public IEnumerable<IScenario> Get()
        {
            return _service.GetAll();
        }

        // GET: api/Scenario/5
        [HttpGet("{id}")]
        public IScenario Get(int id)
        {
            return _service.Get(id);
        }
        
        // POST: api/Scenario
        [HttpPost]
        public IActionResult Post([FromBody]Scenario value)
        {
            _service.Create(value);
            return Ok();
        }
        
        // PUT: api/Scenario/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Scenario value)
        {
            _service.Update(value);
            return Ok();
        }
        
        // DELETE: api/Scenario/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }


        //// GET: api/Scenarios/PercentOfOptions/0
        //[HttpGet("[action]/{id}")]
        //public IEnumerable<PercentOfOption> PercentOfOptions(int id)
        //{
        //    return _service.PercentOfOptions(id);
        //}
    }
}
