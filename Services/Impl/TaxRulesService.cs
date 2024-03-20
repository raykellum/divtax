using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SnapObjects.Data;
using DWNet.Data;
using TaxabilityWebAPI;
using TaxabilityWebAPI.Models;

namespace TaxabilityWebAPI.Services.Impl
{
	/// <summary>
	/// The service needs to be injected into the ConfigureServices method of the Startup class. The sample code is as follows:
	/// services.AddScoped<I<TaxRulesService>, TaxRulesService>();
	/// </summary>
    public class TaxRulesService : ITaxRulesService
    {
        private readonly DataContext _dataContext;
        public TaxRulesService(MSSDataContext dataContext)
        {
            _dataContext = dataContext;
        }

		public async Task<IEnumerable<TaxRules>> RetrieveAsync(string s_state_id, CancellationToken cancellationToken)
		{
			var dataStore = new DataStore<TaxRules>(_dataContext);

			await dataStore.RetrieveAsync(new object[] { s_state_id }, cancellationToken);

			return dataStore;
		}

        public async Task<int> CreateAsync(TaxRules TaxRules, CancellationToken cancellationToken)
        {
            var dataStore = new DataStore<TaxRules>(_dataContext);

            dataStore.Add(TaxRules);

            return await dataStore.UpdateAsync(cancellationToken);

        }

    }
}