using System.Runtime.Serialization;

namespace Fsl.NopCommerce.Api.Connector.Model.HubSpot
{
    [DataContract]
    public enum CompanyType
    {
        [EnumMember(Value = "PROSPECT")]
        Prospect,
        [EnumMember(Value = "PARTNER")]
        Partner,
        [EnumMember(Value = "RESELLER")]
        Reseller,
        [EnumMember(Value = "VENDOR")]
        Vendor,
        [EnumMember(Value = "OTHER")]
        Other,
    }
}