using System.Runtime.Serialization;

namespace Fsl.BigCommerce.Api.Connector.Services.Acumatica
{
	[DataContract]
	public class CampaignDetail : Entity
	{
		[DataMember(Name = "CampaignID", EmitDefaultValue = false)]
		public StringValue CampaignID { get; set; }

		[DataMember(Name = "CampaignName", EmitDefaultValue = false)]
		public StringValue CampaignName { get; set; }

		[DataMember(Name = "ContactID", EmitDefaultValue = false)]
		public IntValue ContactID { get; set; }

		[DataMember(Name = "Stage", EmitDefaultValue = false)]
		public StringValue Stage { get; set; }
	}
}