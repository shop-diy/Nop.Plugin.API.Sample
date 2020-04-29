using Fsl.NopCommerce.Api.Connector.Model.HubSpot;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public interface IHubSpotRepository<TEntity> : IHubSpotReadOnlyRepository<TEntity> where TEntity : HubSpotEntity
    {
        public Task AddNew(TEntity entity);

        public Task Update(string entityId, TEntity updatedEntity);

        public Task Delete(string entityId);
    }
}
