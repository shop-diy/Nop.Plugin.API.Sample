using System.Runtime.Serialization;

namespace Fsl.NopCommerce.Api.Connector.Model.HubSpot
{
    [DataContract]
    public enum DiscountDisplayStyle
    {
        [EnumMember(Value = "fixed")]
        Fixed,
        [EnumMember(Value = "percentage")]
        Percentage
    }
}
