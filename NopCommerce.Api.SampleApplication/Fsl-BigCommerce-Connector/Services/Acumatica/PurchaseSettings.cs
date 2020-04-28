using System.Runtime.Serialization;

namespace Fsl.BigCommerce.Api.Connector.Services.Acumatica
{
	[DataContract]
	public class PurchaseSettings : Entity
	{

		[DataMember(Name = "POSiteID", EmitDefaultValue = false)]
		public StringValue POSiteID { get; set; }

		[DataMember(Name = "POSource", EmitDefaultValue = false)]
		public StringValue POSource { get; set; }

		[DataMember(Name = "VendorID", EmitDefaultValue = false)]
		public StringValue VendorID { get; set; }

	}
}