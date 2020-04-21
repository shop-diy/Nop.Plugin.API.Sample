using Fsl.NopCommerce.Api.Connector.Model.HubSpot;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public interface IHubSpotReadOnlyRepository<TEntity> where TEntity: HubSpotEntity
    {
        Task<IEnumerable<TEntity>> GetAll(EntityOptions options = null);
        Task<IEnumerable<TEntity>> GetBatch(params string[] ids);
        Task<TEntity> GetById(string id, EntityOptions options = null);
    }
}