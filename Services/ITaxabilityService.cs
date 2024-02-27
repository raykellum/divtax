using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaxabilityWebAPI;
using TaxabilityWebAPI.Models;

namespace TaxabilityWebAPI.Services
{
    public interface ITaxabilityService
    {

		Task<IEnumerable<Taxability>> RetrieveAsync(string s_state,string s_order_rule_def,string s_item_rule_def, CancellationToken cancellationToken);

        Task<int> CreateAsync(Taxability GetTaxability, CancellationToken cancellationToken);

    }
}