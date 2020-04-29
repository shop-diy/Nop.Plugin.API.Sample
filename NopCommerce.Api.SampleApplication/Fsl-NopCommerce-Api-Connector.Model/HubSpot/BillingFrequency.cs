using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Fsl.NopCommerce.Api.Connector.Model.HubSpot
{
    // "one_time", "monthly", "quarterly", "per_six_months", "annually", "per_two_years", "per_three_years"
    [DataContract]
    public enum BillingFrequency
    {
        [EnumMember(Value = "")]
        OneTime,

        [EnumMember(Value = "monthly")]
        Monthly,

        [EnumMember(Value = "quarterly")]
        Quarterly,

        [EnumMember(Value = "per_six_months")]
        SemiAnnually,

        [EnumMember(Value = "annually")]
        Annually,

        [EnumMember(Value = "per_two_years")]
        EveryTwoYears,

        [EnumMember(Value = "per_three_years")]
        EveryThreeYears,
    }
}
