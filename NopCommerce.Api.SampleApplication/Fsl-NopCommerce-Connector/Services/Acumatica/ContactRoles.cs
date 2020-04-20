using System.Runtime.Serialization;

namespace Fsl.NopCommerce.Api.Connector.Services.Acumatica
{
	[DataContract]
	public class ContactRoles : Entity
	{
		[DataMember(Name = "RoleDescription", EmitDefaultValue = false)]
		public StringValue RoleDescription { get; set; }

		[DataMember(Name = "RoleName", EmitDefaultValue = false)]
		public StringValue RoleName { get; set; }

		[DataMember(Name = "Selected", EmitDefaultValue = false)]
		public BooleanValue Selected { get; set; }

		[DataMember(Name = "UserType", EmitDefaultValue = false)]
		public IntValue UserType { get; set; }
	}
}