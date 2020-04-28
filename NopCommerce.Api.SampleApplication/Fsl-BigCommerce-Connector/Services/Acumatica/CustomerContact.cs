using System.Runtime.Serialization;

namespace Fsl.BigCommerce.Api.Connector.Services.Acumatica
{
	[DataContract]
	public class CustomerContact : Entity
	{
		[DataMember(Name = "Contact", EmitDefaultValue = false)]
		public Contact Contact { get; set; }

		[DataMember(Name = "ContactID", EmitDefaultValue = false)]
		public IntValue ContactID { get; set; }
	}
}
