using System.Runtime.Serialization;

namespace Fsl.NopCommerce.Api.Connector.Model.HubSpot
{
    // "DRAFT", "PENDING_APPROVAL", "REJECTED", "APPROVED", "APPROVAL_NOT_NEEDED"
    [DataContract]
    public enum ApprovalStatus
    {
        [EnumMember(Value = "REJECTED")]
        Rejected = -1,
        None,
        [EnumMember(Value = "DRAFT")]
        Draft,
        [EnumMember(Value = "APPROVAL_NOT_NEEDED")]
        ApprovalNotNeeded,
        [EnumMember(Value = "PENDING_APPROVAL")]
        PendingApproval,
        [EnumMember(Value = "APPROVED")]
        Approved,
    }
}
