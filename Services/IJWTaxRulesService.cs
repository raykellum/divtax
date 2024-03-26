using System.Threading;
using System.Threading.Tasks;
using DWNet.Data;
using System;
using TaxabilityWebAPI;
using TaxabilityWebAPI.Models;

namespace TaxabilityWebAPI.Services
{
    public interface IJWTaxRulesService
    {

		Task<IDataStore<JWTaxRules>> RetrieveAsync(string s_state_id,  CancellationToken cancellationToken);

        Task<int> CreateAsync(JWTaxRules JWTaxRules, CancellationToken cancellationToken);

    }
}