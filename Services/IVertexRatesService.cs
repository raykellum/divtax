using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaxabilityWebAPI;
using TaxabilityWebAPI.Models;

namespace TaxabilityWebAPI.Services
{
    public interface IVertexRatesService
    {

		Task<IEnumerable<VertexRates>> RetrieveAsync(string s_state_id,string s_zip_code, CancellationToken cancellationToken);

        Task<int> CreateAsync(VertexRates VertexRates, CancellationToken cancellationToken);

    }
}