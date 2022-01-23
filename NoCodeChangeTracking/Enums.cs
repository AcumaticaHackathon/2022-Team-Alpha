using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking
{
    public static class Enums
    {
        public static class ChangeObjectType
        {
            public const string Attribute = "Attribute";
            public const string Report = "Report";
            public const string Dashboard = "Dashboard";
            public const string Sitemap = "Sitemap";
            public const string WebHook = "WebHook";
            public const string BusinessEvent = "BusinessEvent";
            public const string Role = "Role";
            public const string Scenario = "Scenario";
            public const string GI = "GI";
        }

        public static class ChangeObjectSubType
        {
            public const string CSAttribute = "CSAttribute";
            public const string CSAttributeGroup = "CSAttributeGroup";
            public const string CSScreenAttribute = "CSScreenAttribute";
            public const string CSAttributeDetail = "CSAttributeDetail";
            public const string UserReport = "UserReport";
            public const string Dashboard = "Dashboard";
            public const string Widget = "Widget";
            public const string DashboardParameter = "DashboardParameter";
            public const string Sitemap = "Sitemap";
            public const string WebHook = "WebHook";
            public const string BPEvent = "BPEvent";
            public const string BPEventSubscriber = "BPEventSubscriber";
            public const string BPEventTriggerCondition = "BPEventTriggerCondition";
            public const string BPEventSchedule = "BPEventSchedule";
            public const string BPInquiryParameter = "BPInquiryParameter";
            public const string Roles = "Roles";
            public const string RolesInCache = "RolesInCache";
            public const string RolesInGraph = "RolesInGraph";
            public const string RolesInMember = "RolesInMember";
            public const string SYMapping = "SYMapping";
            public const string SYMappingCondition = "SYMappingCondition";
            public const string SYMappingField = "SYMappingField";
            public const string SYImportCondition = "SYImportCondition";
            public const string GIDesign = "GIDesign";
            public const string GIFilter = "GIFilter";
            public const string GIGroupBy = "GIGroupBy";
            public const string GIMassAction = "GIMassAction";
            public const string GIMassUpdateField = "GIMassUpdateField";
            public const string GINavigationCondition = "GINavigationCondition";
            public const string GINavigationParameter = "GINavigationParameter";
            public const string GINavigationScreen = "GINavigationScreen";
            public const string GIOn = "GIOn";
            public const string GIRecordDefault = "GIRecordDefault";
            public const string GIRelation = "GIRelation";
            public const string GIResult = "GIResult";
            public const string GISort = "GISort";
            public const string GITable = "GITable";
            public const string GIWhere = "GIWhere";
        }
    }
}
