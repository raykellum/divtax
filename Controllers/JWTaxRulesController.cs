using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Collections.Generic;
using DWNet.Data;
using TaxabilityWebAPI.Services;
using System.Threading.Tasks;
using System.Threading;
using TaxabilityWebAPI.Models;

namespace TaxabilityWebAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class JWTaxRulesController : ControllerBase
    {
        private readonly IJWTaxRulesService _ijwtaxrulesservice;

        public JWTaxRulesController(IJWTaxRulesService ijwtaxrulesservice)
        {
            _ijwtaxrulesservice = ijwtaxrulesservice;
        }
    
        //GET api/JWTaxRules/Retrieve/{s_state_id}
        [HttpGet("{s_state_id}")]
        [ProducesResponseType(typeof(IDataStore<JWTaxRules>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IDataStore<JWTaxRules>>> RetrieveAsync(string s_state_id)
        {
            try
            {
                var result = await _ijwtaxrulesservice.RetrieveAsync(s_state_id, default);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        ////POST api/JWTaxRules/Create
        //[HttpPost]
        //[ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<int>> CreateAsync([FromBody] JWTaxRules JWTaxRules)
        //{
        //    try
        //    {
        //        var result = await _ijwtaxrulesservice.CreateAsync(JWTaxRules, default);
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}

    }
}