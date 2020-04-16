using System.Collections.Generic;

namespace Fsl.NopCommerce.Api.Connector.Services.HubSpot
{
    public partial class HubSpotProperties
    {
        public static class Common
        {
            internal static readonly Dictionary<string, string> _propertyKeyMap = new Dictionary<string, string>
            {
                { nameof(CreatedByUserId), "hs_created_by_user_id" },
                { nameof(CreatedDate), "hs_createdate" },
                { nameof(LastModifiedDate), "hs_lastmodifieddate" },
                { nameof(MergedObjectIds), "hs_merged_object_ids" },
                { nameof(Id), "hs_object_id" },
                { nameof(UpdatedByUserId), "hs_updated_by_user_id" },
                { nameof(OwnerId), "hubspot_owner_id" },
                { nameof(OwnerAssignedDate), "hubspot_owner_assigneddate" },
                { nameof(AssociatedDealCount), "hs_num_associated_deals" },
                { nameof(TimeZone), "hs_timezone" },
                { nameof(LastEmailRepliedDate), "hs_sales_email_last_replied" },
                { nameof(NotesLastContactedDate), "notes_last_contacted" },
                { nameof(NotesLastUpdatedDate), "notes_last_updated" },
                { nameof(NotesNextActivityDate), "notes_next_activity_date" },
                { nameof(NotesTimesContacted), "num_contacted_notes" },
                { nameof(NotesActivityCount), "num_notes" },
                { nameof(TeamId), "hubspot_team_id" },
                { nameof(AllOwnerIds), "hs_all_owner_ids" },
                { nameof(AllTeamIds), "hs_all_team_ids" },
                { nameof(AllAccessibleTeamIds), "hs_all_accessible_team_ids" },
            };

            /// <summary>
            /// The ID of the user that created this object.
            /// </summary>
            public static string CreatedByUserId => _propertyKeyMap[nameof(CreatedByUserId)];

            /// <summary>
            /// The date this object was created.
            /// </summary>
            public static string CreatedDate => _propertyKeyMap[nameof(CreatedDate)];

            /// <summary>
            /// The date and time any property on this object was modified.
            /// </summary>
            public static string LastModifiedDate => _propertyKeyMap[nameof(LastModifiedDate)];

            /// <summary>
            /// The list of object IDs that have been merged into this object.
            /// </summary>
            public static string MergedObjectIds => _propertyKeyMap[nameof(MergedObjectIds)];

            /// <summary>
            /// The unique ID for this object.
            /// </summary>
            public static string Id => _propertyKeyMap[nameof(Id)];

            /// <summary>
            /// The ID of the user that last updated this object.
            /// </summary>
            public static string UpdatedByUserId => _propertyKeyMap[nameof(UpdatedByUserId)];

            /// <summary>
            /// The date an owner was assigned to the quote.
            /// </summary>
            public static string OwnerAssignedDate => _propertyKeyMap[nameof(OwnerAssignedDate)];

            /// <summary>
            /// The last time a tracked sales email was replied to for this quote
            /// </summary>
            public static string LastEmailRepliedDate => _propertyKeyMap[nameof(LastEmailRepliedDate)];

            /// <summary>
            /// The owner of this object.
            /// </summary>
            public static string OwnerId => _propertyKeyMap[nameof(OwnerId)];

            /// <summary>
            /// The last timestamp when a call, email or meeting was logged for this quote.
            /// </summary>
            public static string NotesLastContactedDate => _propertyKeyMap[nameof(NotesLastContactedDate)];

            /// <summary>
            /// The last time a note, call, email, meeting, or task was logged for a quote. This is set automatically by HubSpot based on user actions in the quote record.
            /// </summary>
            public static string NotesLastUpdatedDate => _propertyKeyMap[nameof(NotesLastUpdatedDate)];

            /// <summary>
            /// The date of the next upcoming activity for this quote.
            /// </summary>
            public static string NotesNextActivityDate => _propertyKeyMap[nameof(NotesNextActivityDate)];

            /// <summary>
            /// The number of times a call, email or meeting was logged for this quote.
            /// </summary>
            public static string NotesTimesContacted => _propertyKeyMap[nameof(NotesTimesContacted)];

            /// <summary>
            /// Number of sales activities for this quote.
            /// </summary>
            public static string NotesActivityCount => _propertyKeyMap[nameof(NotesActivityCount)];

            /// <summary>
            /// The name of the team associated with the owner of the quote.
            /// </summary>
            public static string TeamId => _propertyKeyMap[nameof(TeamId)];

            /// <summary>
            /// The value of all owner referencing properties for this object, both default and custom.
            /// </summary>
            public static string AllOwnerIds => _propertyKeyMap[nameof(AllOwnerIds)];

            /// <summary>
            /// Timezone for displaying dates on the quote.
            /// </summary>
            public static string TimeZone => _propertyKeyMap[nameof(TimeZone)];

            /// <summary>
            /// The team ids corresponding to all owner referencing properties for this object, both default and custom.
            /// </summary>
            public static string AllTeamIds => _propertyKeyMap[nameof(AllTeamIds)];

            /// <summary>
            /// The team ids, including up the team hierarchy, corresponding to all owner referencing properties for this object, both default and custom.
            /// </summary>
            public static string AllAccessibleTeamIds => _propertyKeyMap[nameof(AllAccessibleTeamIds)];

            /// <summary>
            /// The number of deals associated with this quote.
            /// </summary>
            public static string AssociatedDealCount => _propertyKeyMap[nameof(AssociatedDealCount)];
        }
    }
}
