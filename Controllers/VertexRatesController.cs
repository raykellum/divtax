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
    [Route("api/[controller]")]
	[ApiController]
	public class VertexRatesController : ControllerBase
    {
        private readonly IVertexRatesService _ivertexratesservice;

        public VertexRatesController(IVertexRatesService ivertexratesservice)
        {
            _ivertexratesservice = ivertexratesservice;
        }
    
        //GET api/VertexRates/Retrieve/{s_state_id}/{s_zip_code}
        [HttpGet("{s_state_id}/{s_zip_code}")]
        [ProducesResponseType(typeof(IEnumerable<VertexRates>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<VertexRates>>> RetrieveAsync(string s_state_id, string s_zip_code)
        {
            try
            {
                var result = await _ivertexratesservice.RetrieveAsync(s_state_id, s_zip_code, default);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}