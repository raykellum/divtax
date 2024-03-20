using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Collections.Generic;
using TaxabilityWebAPI.Services;
using System.Threading.Tasks;
using System.Threading;
using TaxabilityWebAPI.Models;

namespace TaxabilityWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
	[ApiController]
	public class TaxRulesController : ControllerBase
    {
        private readonly ITaxRulesService _itaxrulesservice;

        public TaxRulesController(ITaxRulesService itaxrulesservice)
        {
            _itaxrulesservice = itaxrulesservice;
        }
    
        //GET api/TaxRules/Retrieve/{s_state_id}
        [HttpGet("{s_state_id}")]
        [ProducesResponseType(typeof(IEnumerable<TaxRules>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<TaxRules>>> RetrieveAsync(string s_state_id)
        {
            try
            {
                var result = await _itaxrulesservice.RetrieveAsync(s_state_id, default);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //POST api/TaxRules/Create
        [HttpPost]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> CreateAsync([FromBody] TaxRules TaxRules)
        {
            try
            {
                var result = await _itaxrulesservice.CreateAsync(TaxRules, default);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}