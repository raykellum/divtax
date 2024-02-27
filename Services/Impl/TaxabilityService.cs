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
	/// services.AddScoped<I<TaxabilityService>, TaxabilityService>();
	/// </summary>
    public class TaxabilityService : ITaxabilityService
    {
        private readonly DataContext _dataContext;
        public TaxabilityService(MSSDataContext dataContext)
        {
            _dataContext = dataContext;
        }

		public async Task<IEnumerable<Taxability>> RetrieveAsync(string s_state,string s_order_rule_def,string s_item_rule_def, CancellationToken cancellationToken)
		{
			var dataStore = new DataStore<Taxability>(_dataContext);

			await dataStore.RetrieveAsync(new object[] { s_state, s_order_rule_def, s_item_rule_def }, cancellationToken);

			return dataStore;
		}

        public async Task<int> CreateAsync(Taxability Taxability, CancellationToken cancellationToken)
        {
            var dataStore = new DataStore<Taxability>(_dataContext);

            dataStore.Add(Taxability);

            return await dataStore.UpdateAsync(cancellationToken);

        }

    }
}