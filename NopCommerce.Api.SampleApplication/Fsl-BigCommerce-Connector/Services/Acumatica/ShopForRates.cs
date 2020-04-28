using System.Runtime.Serialization;

namespace Fsl.BigCommerce.Api.Connector.Services.Acumatica
{
	[DataContract]
	public class ShopForRates : Entity
	{
		[DataMember(Name = "IsManualPackage", EmitDefaultValue = false)]
		public BooleanValue IsManualPackage { get; set; }

		[DataMember(Name = "OrderWeight", EmitDefaultValue = false)]
		public DecimalValue OrderWeight { get; set; }

		[DataMember(Name = "PackageWeight", EmitDefaultValue = false)]
		public DecimalValue PackageWeight { get; set; }
	}
}