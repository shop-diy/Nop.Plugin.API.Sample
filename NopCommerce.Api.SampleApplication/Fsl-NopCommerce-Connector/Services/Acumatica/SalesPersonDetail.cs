﻿using System.Runtime.Serialization;

namespace Fsl.NopCommerce.Api.Connector.Services.Acumatica
{
	[DataContract]
	public class SalesPersonDetail : Entity
	{

		[DataMember(Name = "CommissionableAmount", EmitDefaultValue = false)]
		public DecimalValue CommissionableAmount { get; set; }

		[DataMember(Name = "CommissionAmount", EmitDefaultValue = false)]
		public DecimalValue CommissionAmount { get; set; }

		[DataMember(Name = "CommissionPercent", EmitDefaultValue = false)]
		public DecimalValue CommissionPercent { get; set; }

		[DataMember(Name = "SalespersonID", EmitDefaultValue = false)]
		public StringValue SalespersonID { get; set; }
	}
}