using Fsl.NopCommerce.Api.Connector.DTOs;
using Fsl.NopCommerce.Api.Connector.Services;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Repositories
{
    public sealed class CustomerRepository
    {
        private readonly NopCommerceApiService _api;

        public CustomerRepository(NopCommerceApiService api)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
        }

        public Task<int> Create(CustomerApi entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomersRootObject> GetAll()
        {
            string jsonUrl = $"/api/customers?fields=id,first_name,last_name";
            var (statuCode, data) = await _api.Get<CustomersRootObject>(jsonUrl);


            return data;
        }

        public Task<CustomerApi> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(int id, CustomerApi updated)
        {
            string jsonUrl = $"/api/customers/{id}";

            // we use anonymous type as we want to update only the last_name of the customer
            // also the customer shoud be the cutomer property of a holder object as explained in the documentation
            // https://github.com/SevenSpikes/api-plugin-for-nopcommerce/blob/nopcommerce-3.80/Customers.md#update-details-for-a-customer
            // i.e: { customer : { last_name: "" } }
            var customerToUpdate = new { customer = new { last_name = updated?.LastName } };
            string customerJson = JsonConvert.SerializeObject(customerToUpdate);

            var (statusCode, data) = await _api.Put(jsonUrl, customerJson);

            return data != null;
        }
    }
}
