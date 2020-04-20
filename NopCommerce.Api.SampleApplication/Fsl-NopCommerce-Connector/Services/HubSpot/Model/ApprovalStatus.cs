using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot.Model
{
    // "DRAFT", "PENDING_APPROVAL", "REJECTED", "APPROVED", "APPROVAL_NOT_NEEDED"
    public enum ApprovalStatus
    {
        Rejected = -1,
        None,
        Draft,
        Approval_Not_Needed,
        Pending_Approval,
        Approved,
    }
}
