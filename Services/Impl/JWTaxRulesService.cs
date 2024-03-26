using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SnapObjects.Data;
using DWNet.Data;
using System;
using TaxabilityWebAPI;
using TaxabilityWebAPI.Models;

namespace TaxabilityWebAPI.Services.Impl
{
	/// <summary>
	/// The service needs to be injected into the ConfigureServices method of the Startup class. The sample code is as follows:
	/// services.AddScoped<I<JWTaxRulesService>, JWTaxRulesService>();
	/// </summary>
    public class JWTaxRulesService : IJWTaxRulesService
    {
        private readonly DataContext _dataContext;
        public JWTaxRulesService(MSSDataContext dataContext)
        {
            _dataContext = dataContext;
        }

		public async Task<IDataStore<JWTaxRules>> RetrieveAsync(string s_state_id, CancellationToken cancellationToken)
		{
			var dataStore = new DataStore<JWTaxRules>(_dataContext);

			await dataStore.RetrieveAsync(new object[] { s_state_id }, cancellationToken);

			return dataStore;
		}

        public async Task<int> CreateAsync(JWTaxRules JWTaxRules, CancellationToken cancellationToken)
        {
            var dataStore = new DataStore<JWTaxRules>(_dataContext);

            dataStore.Add(JWTaxRules);

            return await dataStore.UpdateAsync(cancellationToken);
        }

    }
}