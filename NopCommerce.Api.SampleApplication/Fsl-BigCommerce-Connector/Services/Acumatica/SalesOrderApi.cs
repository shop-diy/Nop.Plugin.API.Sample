using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsl.BigCommerce.Api.Connector.Services.Acumatica
{
	public sealed class SalesOrderApi : EntityAPI<SalesOrder>
	{
		public SalesOrderApi(Configuration configuration) : base(configuration)
		{ }
	}
}
