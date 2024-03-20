using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaxabilityWebAPI;
using TaxabilityWebAPI.Models;

namespace TaxabilityWebAPI.Services
{
    public interface ITaxRulesService
    {

		Task<IEnumerable<TaxRules>> RetrieveAsync(string s_state_id, CancellationToken cancellationToken);

        Task<int> CreateAsync(TaxRules TaxRules, CancellationToken cancellationToken);

    }
}