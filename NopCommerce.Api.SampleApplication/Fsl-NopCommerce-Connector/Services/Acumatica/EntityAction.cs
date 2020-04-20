using System.IO;
using System.Runtime.Serialization;

namespace Fsl.NopCommerce.Api.Connector.Services.Acumatica
{
    [DataContract]
    public abstract class EntityAction<EntityType>
        where EntityType : Entity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Action" /> class.
        /// </summary>
        /// <param name="entity">entity (required).</param>
        public EntityAction(EntityType entity)
        {
            // to ensure "entity" is required (not null)
            if (entity == null)
            {
                throw new InvalidDataException("entity is a required property for Action and cannot be null");
            }
            else
            {
                Entity = entity;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Action" /> class.
        /// </summary>
        public EntityAction()
        {
        }

        [DataMember(Name = "entity", EmitDefaultValue = false)]
        public EntityType Entity
        {
            get;
            set;
        }
    }
}