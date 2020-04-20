using System.Runtime.Serialization;

namespace Fsl.NopCommerce.Api.Connector.Services.Acumatica
{
	[DataContract]
	public class BusinessAccountPaymentInstructionDetail : Entity
	{
		[DataMember(Name = "Description", EmitDefaultValue = false)]
		public StringValue Description { get; set; }

		[DataMember(Name = "LocationID", EmitDefaultValue = false)]
		public IntValue LocationID { get; set; }

		[DataMember(Name = "PaymentInstructionsID", EmitDefaultValue = false)]
		public StringValue PaymentInstructionsID { get; set; }

		[DataMember(Name = "PaymentMethod", EmitDefaultValue = false)]
		public StringValue PaymentMethod { get; set; }

		[DataMember(Name = "Value", EmitDefaultValue = false)]
		public StringValue Value { get; set; }
	}
}
