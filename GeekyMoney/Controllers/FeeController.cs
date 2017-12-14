using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GeekyMoney.Model;
using AutoMapper;
using GeekyMoney.Data;
using GeekyMoney.Services;

namespace GeekyMoney.Angular.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FeeController : Controller
    {
        FeeService _service;
        public FeeController(GeekyMoneyContext context, IMapper mapper)
        {
            _service = new FeeService(context, mapper);
        }

        // GET: api/Fee
        [HttpGet()]
        public IEnumerable<IFee> Get()
        {
            return _service.GetAll();
        }

        // GET: api/Fee/ByType/1
        [HttpGet("[action]/{feeTypeId}")]
        public IEnumerable<IFee> ByType(int feeTypeId)
        {
            return _service.GetAllByType(feeTypeId);
        }

        // GET: api/Fee/Templates
        [HttpGet("[action]")]
        public IEnumerable<IFee> Templates()
        {
            return _service.GetTemplates();
        }

        // GET: api/Fee/Templates/ByType/1
        [HttpGet("/Templates/ByType/{feeTypeId}")]
        public IEnumerable<IFee> TemplatesByType(int feeTypeId)
        {
            return _service.GetTemplates();
        }

        // GET: api/Fee/5
        [HttpGet("{id}")]
        public IFee Get(int id)
        {
            return _service.Get(id);
        }

        // POST: api/Fee
        [HttpPost]
        public IFee Post([FromBody]Fee value)
        {
            var result = _service.Create(value);
            return result;
        }

        // PUT: api/Fee/5
        [HttpPut("{id}")]
        public IFee Put(int id, [FromBody]Fee value)
        {
            var result = _service.Update(value);
            return result;
        }

        // DELETE: api/Fee/5
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