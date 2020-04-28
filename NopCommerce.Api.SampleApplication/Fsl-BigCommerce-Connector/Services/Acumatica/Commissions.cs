using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Fsl.BigCommerce.Api.Connector.Services.Acumatica
{
	[DataContract]
	public class Commissions : Entity
	{

		[DataMember(Name = "DefaultSalesperson", EmitDefaultValue = false)]
		public StringValue DefaultSalesperson { get; set; }

		[DataMember(Name = "SalesPersons", EmitDefaultValue = false)]
		public List<SalesPersonDetail> SalesPersons { get; set; }

	}
}