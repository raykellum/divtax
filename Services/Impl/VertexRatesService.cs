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
	/// services.AddScoped<I<VertexRatesService>, VertexRatesService>();
	/// </summary>
    public class VertexRatesService : IVertexRatesService
    {
        private readonly DataContext _dataContext;
        public VertexRatesService(MSSDataContext dataContext)
        {
            _dataContext = dataContext;
        }

		public async Task<IEnumerable<VertexRates>> RetrieveAsync(string s_state_id,string s_zip_code, CancellationToken cancellationToken)
		{
			var dataStore = new DataStore<VertexRates>(_dataContext);

			await dataStore.RetrieveAsync(new object[] { s_state_id, s_zip_code }, cancellationToken);

			return dataStore;
		}

        public async Task<int> CreateAsync(VertexRates VertexRates, CancellationToken cancellationToken)
        {
            var dataStore = new DataStore<VertexRates>(_dataContext);

            dataStore.Add(VertexRates);

            return await dataStore.UpdateAsync(cancellationToken);

        }

    }
}