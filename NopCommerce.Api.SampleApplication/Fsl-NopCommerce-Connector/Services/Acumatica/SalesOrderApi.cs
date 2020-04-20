using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services.Acumatica
{
	public sealed class SalesOrderApi : EntityAPI<SalesOrder>
	{
		public SalesOrderApi(Configuration configuration) : base(configuration)
		{ }
	}
}
