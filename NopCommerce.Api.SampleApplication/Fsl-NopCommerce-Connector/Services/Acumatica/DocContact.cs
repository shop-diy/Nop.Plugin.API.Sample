using System.Runtime.Serialization;

namespace Fsl.NopCommerce.Api.Connector.Services.Acumatica
{
	[DataContract]
	public class DocContact : Entity
	{

		[DataMember(Name = "Attention", EmitDefaultValue = false)]
		public StringValue Attention { get; set; }

		[DataMember(Name = "BusinessName", EmitDefaultValue = false)]
		public StringValue BusinessName { get; set; }

		[DataMember(Name = "Email", EmitDefaultValue = false)]
		public StringValue Email { get; set; }

		[DataMember(Name = "Phone1", EmitDefaultValue = false)]
		public StringValue Phone1 { get; set; }

	}
}