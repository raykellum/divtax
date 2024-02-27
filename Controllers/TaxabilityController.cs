using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Collections.Generic;
using TaxabilityWebAPI.Services;
using System.Threading.Tasks;
using System.Threading;
using TaxabilityWebAPI.Models;
using System.Transactions;

namespace TaxabilityWebAPI.Controllers
{
    //[Route("api/[controller]/[action]")]
    [Route("api/[controller]")]
	[ApiController]
	public class TaxabilityController : ControllerBase
    {
        private readonly ITaxabilityService _iTaxabilityservice;

        public TaxabilityController(ITaxabilityService iTaxabilityservice)
        {
            _iTaxabilityservice = iTaxabilityservice;
        }
        
        //GET api/Taxability/Retrieve/{s_state}/{s_order_rule_def}/{s_item_rule_def}
        [HttpGet("{s_state}/{s_order_rule_def}/{s_item_rule_def}")]
        [ProducesResponseType(typeof(IEnumerable<Taxability>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<Taxability>>> RetrieveAsync(string s_state, string s_order_rule_def, string s_item_rule_def)
        {
            try
            {
                var result = await _iTaxabilityservice.RetrieveAsync(s_state, s_order_rule_def, s_item_rule_def, default);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //POST api/Taxability/Create
        //[HttpPost]
        //[ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<int>> CreateAsync([FromBody] Taxability Taxability)
        //{
        //    try
        //    {
        //        var result = await _iTaxabilityservice.CreateAsync(Taxability, default);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

    }
}