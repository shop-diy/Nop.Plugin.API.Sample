using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot.Model
{
    public class HubSpotEntity
    {
        /// <summary>
        /// The unique identifier for this item.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of this item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The date/time this item was created.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// The date/time this item was last updated.
        /// </summary>
        public DateTime UpdatedDate { get; set; }

        /// <summary>
        /// Whether or not this item has been archived.
        /// </summary>
        public bool IsArchived { get; set; }
    }
}
