using Aktion.Common.Acumatica.NoCodeChangeTracking.DAC;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PX.Data;
using PX.Data.BQL.Fluent;
using System.Collections;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.Graphs
{
    /// <summary>
    /// No-Code Change Tracking controller
    /// </summary>
    public class NoCodeChangeTrack : PXGraph<NoCodeChangeTrack>
    {
        #region DAC overrides
        
        [PXMergeAttributes(Method = MergeMethod.Append)]
        [PXUIField(DisplayName = PXDBLastModifiedByIDAttribute.DisplayFieldNames.CreatedDateTime, Enabled = false)]
        protected virtual void CSAttribute_CreatedDateTime_CacheAttached(PXCache cache) { }

        [PXMergeAttributes(Method = MergeMethod.Append)]
        [PXUIField(DisplayName = PXDBLastModifiedByIDAttribute.DisplayFieldNames.LastModifiedDateTime, Enabled = false)]
        protected virtual void CSAttribute_LastModifiedDateTime_CacheAttached(PXCache cache) { }
            
        [PXMergeAttributes(Method = MergeMethod.Append)]
        [PXUIField(DisplayName = PXDBLastModifiedByIDAttribute.DisplayFieldNames.CreatedDateTime, Enabled = false)]
        protected virtual void CSAttributeDetail_CreatedDateTime_CacheAttached(PXCache cache) { }

        [PXMergeAttributes(Method = MergeMethod.Append)]
        [PXUIField(DisplayName = PXDBLastModifiedByIDAttribute.DisplayFieldNames.LastModifiedDateTime, Enabled = false)]
        protected virtual void CSAttributeDetail_LastModifiedDateTime_CacheAttached(PXCache cache) { }

        [PXMergeAttributes(Method = MergeMethod.Append)]
        [PXUIField(DisplayName = PXDBLastModifiedByIDAttribute.DisplayFieldNames.CreatedDateTime, Enabled = false)]
        protected virtual void CSAttributeGroup_CreatedDateTime_CacheAttached(PXCache cache) { }

        [PXMergeAttributes(Method = MergeMethod.Append)]
        [PXUIField(DisplayName = PXDBLastModifiedByIDAttribute.DisplayFieldNames.LastModifiedDateTime, Enabled = false)]
        protected virtual void CSAttributeGroup_LastModifiedDateTime_CacheAttached(PXCache cache) { }

        [PXMergeAttributes(Method = MergeMethod.Append)]
        [PXUIField(DisplayName = PXDBLastModifiedByIDAttribute.DisplayFieldNames.CreatedDateTime, Enabled = false)]
        protected virtual void CSScreenAttribute_CreatedDateTime_CacheAttached(PXCache cache) { }

        [PXMergeAttributes(Method = MergeMethod.Append)]
        [PXUIField(DisplayName = PXDBLastModifiedByIDAttribute.DisplayFieldNames.LastModifiedDateTime, Enabled = false)]
        protected virtual void CSScreenAttribute_LastModifiedDateTime_CacheAttached(PXCache cache) { }
        #endregion

        #region Views

        /// <summary>
        /// View of all custom attributes
        /// </summary>
        public SelectFrom<CSAttribute>
            .Where<CSAttribute.attributeID.IsNotNull>
            .OrderBy<CSAttribute.attributeID.Asc>.View Attributes;

        /// <summary>
        /// View of custom attribute options
        /// </summary>
        public SelectFrom<CSAttributeDetail>
            .OrderBy<CSAttributeDetail.attributeID.Asc, CSAttributeDetail.valueID.Asc>.View AttributeDetails;

        /// <summary>
        /// View of attribute groups
        /// </summary>
        public SelectFrom<CSAttributeGroup>
            .OrderBy<CSAttributeGroup.attributeID.Asc, CSAttributeGroup.entityClassID.Asc, CSAttributeGroup.entityType.Asc>.View AttributeGroups;

        /// <summary>
        /// View of screen attributes
        /// </summary>
        public SelectFrom<CSScreenAttribute>
            .OrderBy<CSScreenAttribute.attributeID.Asc, CSScreenAttribute.screenID.Asc, CSScreenAttribute.typeValue.Asc>.View ScreenAttributes;

        /// <summary>
        /// View of custom reports
        /// </summary>
        public SelectFrom<UserReport>
            .OrderBy<UserReport.reportFileName.Asc, UserReport.version.Desc>.View Reports;

        /// <summary>
        /// View of all dashboards
        /// </summary>
        public SelectFrom<Dashboard>
            .OrderBy<Dashboard.name.Asc>.View Dashboards;

        /// <summary>
        /// View of dashboard widgets
        /// </summary>
        public SelectFrom<Widget>
            .OrderBy<Widget.caption.Asc, Widget.type.Asc>.View Widgets;

        /// <summary>
        /// View of dashboard parameters
        /// </summary>
        public SelectFrom<DashboardParameter>
            .OrderBy<DashboardParameter.name.Asc, DashboardParameter.lineNbr.Asc>.View DashboardParameters;

        /// <summary>
        /// View of sitemap entries
        /// </summary>
        public SelectFrom<Sitemap>
            .Where<Sitemap.title.IsNotNull>
            .OrderBy<Sitemap.title.Asc, Sitemap.screenID.Asc>.View Sitemaps;

        /// <summary>
        /// View of webhooks
        /// </summary>
        public SelectFrom<WebHook>
            .OrderBy<WebHook.name.Asc>.View WebHooks;

        /// <summary>
        /// View of business events
        /// </summary>
        public SelectFrom<BPEvent>
            .OrderBy<BPEvent.name.Asc, BPEvent.description.Asc>.View BusinessEvents;

        /// <summary>
        /// View of business event subscribers
        /// </summary>
        public SelectFrom<BPEventSubscriber>
            .OrderBy<BPEventSubscriber.handlerID.Asc, BPEventSubscriber.orderNbr.Asc>.View BusinessEventSubscribers;

        /// <summary>
        /// View of business event trigger conditions
        /// </summary>
        public SelectFrom<BPEventTriggerCondition>
            .OrderBy<BPEventTriggerCondition.orderNbr.Asc, BPEventTriggerCondition.tableName.Asc, BPEventTriggerCondition.fieldName.Asc>.View BusinessEventTriggerConditions;

        /// <summary>
        /// View of business event schedules
        /// </summary>
        public SelectFrom<BPEventSchedule>
            .OrderBy<BPEventSchedule.scheduleID.Asc>.View BusinessEventSchedules;

        /// <summary>
        /// View of business event inquiry parameters
        /// </summary>
        public SelectFrom<BPInquiryParameter>
            .OrderBy<BPInquiryParameter.name.Asc>.View BusinessEventInquiryParameters;

        /// <summary>
        /// View of roles
        /// </summary>
        public SelectFrom<Roles>
            .OrderBy<Roles.rolename.Asc, Roles.applicationName.Asc>.View Roles;

        /// <summary>
        /// View of roles in caches
        /// </summary>
        public SelectFrom<RolesInCache>
            .OrderBy<RolesInCache.rolename.Asc, RolesInCache.applicationName.Asc, RolesInCache.screenID.Asc, RolesInCache.cachetype.Asc>.View RolesInCaches;

        /// <summary>
        /// View of roles in graphs
        /// </summary>
        public SelectFrom<RolesInGraph>
            .OrderBy<RolesInGraph.rolename.Asc, RolesInGraph.applicationName.Asc, RolesInGraph.screenID.Asc>.View RolesInGraphs;

        /// <summary>
        /// View of roles in members
        /// </summary>
        public SelectFrom<RolesInMember>
            .OrderBy<RolesInMember.rolename.Asc, RolesInMember.applicationName.Asc, RolesInMember.screenID.Asc, RolesInMember.cachetype.Asc, RolesInMember.membername.Asc>.View RolesInMembers;

        /// <summary>
        /// View of scenario mappings
        /// </summary>
        public SelectFrom<SYMapping>
            .OrderBy<SYMapping.name.Asc, SYMapping.screenID.Asc, SYMapping.graphName.Asc>.View ScenarioMappings;

        /// <summary>
        /// View of scenario mapping conditions
        /// </summary>
        public SelectFrom<SYMappingCondition>
            .OrderBy<SYMappingCondition.objectName.Asc, SYMappingCondition.fieldName.Asc>.View ScenarioMappingConditions;

        /// <summary>
        /// View of scenario import conditions
        /// </summary>
        public SelectFrom<SYImportCondition>
            .OrderBy<SYImportCondition.objectName.Asc, SYImportCondition.fieldName.Asc>.View ScenarioImportConditions;

        /// <summary>
        /// View of scenario import conditions
        /// </summary>
        public SelectFrom<SYMappingField>
            .OrderBy<SYMappingField.objectName.Asc, SYMappingField.fieldName.Asc>.View ScenarioMappingFields;

        /// <summary>
        /// View of GIs
        /// </summary>
        public SelectFrom<GIDesign>
            .OrderBy<GIDesign.name.Asc>.View GIs;

        /// <summary>
        /// View of GI filters
        /// </summary>
        public SelectFrom<GIFilter>
            .OrderBy<GIFilter.name.Asc, GIFilter.fieldName.Asc>.View GIFilters;

        /// <summary>
        /// View of GI group bys
        /// </summary>
        public SelectFrom<GIGroupBy>
            .OrderBy<GIGroupBy.dataFieldName.Asc>.View GIGroupBys;

        /// <summary>
        /// View of GI relation ons
        /// </summary>
        public SelectFrom<GIOn>
            .OrderBy<GIOn.parentField.Asc, GIOn.condition.Asc, GIOn.childField.Asc>.View GIOns;

        /// <summary>
        /// View of GI relations
        /// </summary>
        public SelectFrom<GIRelation>
            .OrderBy<GIRelation.parentTable.Asc, GIRelation.childTable.Asc>.View GIRelations;

        /// <summary>
        /// View of GI results
        /// </summary>
        public SelectFrom<GIResult>
            .OrderBy<GIResult.objectName.Asc, GIResult.field.Asc, GIResult.schemaField.Asc, GIResult.caption.Asc>.View GIResults;

        /// <summary>
        /// View of GI sorts
        /// </summary>
        public SelectFrom<GISort>
            .OrderBy<GISort.dataFieldName.Asc, GISort.sortOrder.Asc>.View GISorts;

        /// <summary>
        /// View of GI tables
        /// </summary>
        public SelectFrom<GITable>
            .OrderBy<GITable.alias.Asc, GITable.name.Asc>.View GITables;

        /// <summary>
        /// View of GI wheres
        /// </summary>
        public SelectFrom<GIWhere>
            .OrderBy<GIWhere.dataFieldName.Asc, GIWhere.condition.Asc, GIWhere.value1.Asc>.View GIWheres;

        // View of tracked objects that were changed, for every unique key value
        public SelectFrom<AKChangeObject>
            .InnerJoin<AKChangeObjectType>.On<AKChangeObject.changeObjectTypeID.IsEqual<AKChangeObjectType.changeObjectTypeID>>
            .InnerJoin<AKChangeObjectSubType>.On<AKChangeObject.changeObjectSubTypeID.IsEqual<AKChangeObjectSubType.changeObjectSubTypeID>>.View ChangeObjects;

        // Views of individual changes to a tracked object

        public SelectFrom<AttributeVersion>
            .OrderBy<AttributeVersion.changeObjectVersionID.Desc>.View AttributeVersions;

        public SelectFrom<AttributeDetailVersion>
            .OrderBy<AttributeDetailVersion.changeObjectVersionID.Desc>.View AttributeDetailVersions;

        public SelectFrom<AttributeGroupVersion>
            .OrderBy<AttributeGroupVersion.changeObjectVersionID.Desc>.View AttributeGroupVersions;

        public SelectFrom<ScreenAttributeVersion>
            .OrderBy<ScreenAttributeVersion.changeObjectVersionID.Desc>.View ScreenAttributeVersions;

        public SelectFrom<ReportVersion>
            .OrderBy<ReportVersion.changeObjectVersionID.Desc>.View ReportVersions;

        public SelectFrom<DashboardVersion>
            .OrderBy<DashboardVersion.changeObjectVersionID.Desc>.View DashboardVersions;

        public SelectFrom<WidgetVersion>
            .OrderBy<WidgetVersion.changeObjectVersionID.Desc>.View WidgetVersions;

        public SelectFrom<DashboardParameterVersion>
            .OrderBy<DashboardParameterVersion.changeObjectVersionID.Desc>.View DashboardParameterVersions;

        public SelectFrom<SitemapVersion>
            .OrderBy<SitemapVersion.changeObjectVersionID.Desc>.View SitemapVersions;

        public SelectFrom<WebHookVersion>
            .OrderBy<WebHookVersion.changeObjectVersionID.Desc>.View WebHookVersions;

        public SelectFrom<BusinessEventVersion>
            .OrderBy<BusinessEventVersion.changeObjectVersionID.Desc>.View BusinessEventVersions;

        public SelectFrom<BusinessEventSubscriberVersion>
            .OrderBy<BusinessEventSubscriberVersion.changeObjectVersionID.Desc>.View BusinessEventSubscriberVersions;

        public SelectFrom<BusinessEventTriggerConditionVersion>
            .OrderBy<BusinessEventTriggerConditionVersion.changeObjectVersionID.Desc>.View BusinessEventTriggerConditionVersions;

        public SelectFrom<BusinessEventScheduleVersion>
            .OrderBy<BusinessEventScheduleVersion.changeObjectVersionID.Desc>.View BusinessEventScheduleVersions;

        public SelectFrom<BusinessEventInquiryParameterVersion>
            .OrderBy<BusinessEventInquiryParameterVersion.changeObjectVersionID.Desc>.View BusinessEventInquiryParameterVersions;

        public SelectFrom<RoleVersion>
            .OrderBy<RoleVersion.changeObjectVersionID.Desc>.View RoleVersions;

        public SelectFrom<RoleInCacheVersion>
            .OrderBy<RoleInCacheVersion.changeObjectVersionID.Desc>.View RoleInCacheVersions;

        public SelectFrom<RoleInGraphVersion>
            .OrderBy<RoleInGraphVersion.changeObjectVersionID.Desc>.View RoleInGraphVersions;

        public SelectFrom<RoleInMemberVersion>
            .OrderBy<RoleInMemberVersion.changeObjectVersionID.Desc>.View RoleInMemberVersions;

        public SelectFrom<ScenarioMappingVersion>
            .OrderBy<ScenarioMappingVersion.changeObjectVersionID.Desc>.View ScenarioMappingVersions;

        public SelectFrom<ScenarioMappingConditionVersion>
            .OrderBy<ScenarioMappingConditionVersion.changeObjectVersionID.Desc>.View ScenarioMappingConditionVersions;

        public SelectFrom<ScenarioMappingFieldVersion>
            .OrderBy<ScenarioMappingFieldVersion.changeObjectVersionID.Desc>.View ScenarioMappingFieldVersions;

        public SelectFrom<ScenarioImportConditionVersion>
            .OrderBy<ScenarioImportConditionVersion.changeObjectVersionID.Desc>.View ScenarioImportConditionVersions;

        public SelectFrom<GIVersion>
            .OrderBy<GIVersion.changeObjectVersionID.Desc>.View GIVersions;

        public SelectFrom<GIFilterVersion>
            .OrderBy<GIFilterVersion.changeObjectVersionID.Desc>.View GIFilterVersions;

        public SelectFrom<GIGroupByVersion>
            .OrderBy<GIGroupByVersion.changeObjectVersionID.Desc>.View GIGroupByVersions;

        public SelectFrom<GIOnVersion>
            .OrderBy<GIOnVersion.changeObjectVersionID.Desc>.View GIOnVersions;

        public SelectFrom<GIRelationVersion>
            .OrderBy<GIRelationVersion.changeObjectVersionID.Desc>.View GIRelationVersions;

        public SelectFrom<GIResultVersion>
            .OrderBy<GIResultVersion.changeObjectVersionID.Desc>.View GIResultVersions;

        public SelectFrom<GISortVersion>
            .OrderBy<GISortVersion.changeObjectVersionID.Desc>.View GISortVersions;

        public SelectFrom<GITableVersion>
            .OrderBy<GITableVersion.changeObjectVersionID.Desc>.View GITableVersions;

        public SelectFrom<GIWhereVersion>
            .OrderBy<GIWhereVersion.changeObjectVersionID.Desc>.View GIWhereVersions;

        // View of single versions of a tracked object

        public SelectFrom<AttributeVersion>.View AttributeCurrentVersion;

        #endregion

        /// <summary>
        /// No-Code Change Tracking controller constructor.
        /// </summary>
        public NoCodeChangeTrack() 
        {
            // Add Where conditions here because I haven't figured out yet how to do a Required keyword with Fluent syntax

            ChangeObjects.WhereNew<
                Where<AKChangeObjectType.name, Equal<Required<AKChangeObjectType.name>>, 
                    And<AKChangeObjectSubType.name, Equal<Required<AKChangeObjectSubType.name>>>>>();

            AttributeDetails.WhereNew<
                Where<CSAttributeDetail.attributeID, Equal<Current<CSAttribute.attributeID>>>>();

            AttributeGroups.WhereNew<
                Where<CSAttributeGroup.attributeID, Equal<Current<CSAttribute.attributeID>>>>();

            ScreenAttributes.WhereNew<
                Where<CSScreenAttribute.attributeID, Equal<Current<CSAttribute.attributeID>>>>();

            Widgets.WhereNew<
                Where<Widget.dashboardID, Equal<Current<Dashboard.dashboardID>>>>();

            DashboardParameters.WhereNew<
                Where<DashboardParameter.dashboardID, Equal<Current<Dashboard.dashboardID>>>>();

            BusinessEventSubscribers.WhereNew<
                Where<BPEventSubscriber.eventID, Equal<Current<BPEvent.eventID>>>>();

            BusinessEventTriggerConditions.WhereNew<
                Where<BPEventTriggerCondition.eventID, Equal<Current<BPEvent.eventID>>>>();

            BusinessEventSchedules.WhereNew<
                Where<BPEventSchedule.eventID, Equal<Current<BPEvent.eventID>>>>();

            BusinessEventInquiryParameters.WhereNew<
                Where<BPInquiryParameter.eventID, Equal<Current<BPEvent.eventID>>>>();

            RolesInCaches.WhereNew<
                Where<RolesInCache.rolename, Equal<Current<Aktion.Common.Acumatica.NoCodeChangeTracking.DAC.Roles.rolename>>,
                    And<RolesInCache.applicationName, Equal<Current<Aktion.Common.Acumatica.NoCodeChangeTracking.DAC.Roles.applicationName>>>>>();

            RolesInGraphs.WhereNew<
                Where<RolesInGraph.rolename, Equal<Current<Aktion.Common.Acumatica.NoCodeChangeTracking.DAC.Roles.rolename>>,
                    And<RolesInGraph.applicationName, Equal<Current<Aktion.Common.Acumatica.NoCodeChangeTracking.DAC.Roles.applicationName>>>>>();

            RolesInMembers.WhereNew<
                Where<RolesInMember.rolename, Equal<Current<Aktion.Common.Acumatica.NoCodeChangeTracking.DAC.Roles.rolename>>,
                    And<RolesInMember.applicationName, Equal<Current<Aktion.Common.Acumatica.NoCodeChangeTracking.DAC.Roles.applicationName>>>>>();

            ScenarioImportConditions.WhereNew<
                Where<SYImportCondition.mappingID, Equal<Current<SYMapping.mappingID>>>>();

            ScenarioMappingConditions.WhereNew<
                Where<SYMappingCondition.mappingID, Equal<Current<SYMapping.mappingID>>>>();

            ScenarioMappingFields.WhereNew<
                Where<SYMappingField.mappingID, Equal<Current<SYMapping.mappingID>>>>();

            GIFilters.WhereNew<
                Where<GIFilter.designID, Equal<Current<GIDesign.designID>>>>();

            GIGroupBys.WhereNew<
                Where<GIGroupBy.designID, Equal<Current<GIDesign.designID>>>>();

            GIOns.WhereNew<
                Where<GIOn.designID, Equal<Current<GIDesign.designID>>>>();

            GIRelations.WhereNew<
                Where<GIRelation.designID, Equal<Current<GIDesign.designID>>>>();

            GIResults.WhereNew<
                Where<GIResult.designID, Equal<Current<GIDesign.designID>>>>();

            GISorts.WhereNew<
                Where<GISort.designID, Equal<Current<GIDesign.designID>>>>();

            GITables.WhereNew<
                Where<GITable.designID, Equal<Current<GIDesign.designID>>>>();

            GIWheres.WhereNew<
                Where<GIWhere.designID, Equal<Current<GIDesign.designID>>>>();

            AttributeVersions.WhereNew<
                Where<AttributeVersion.changeObjectID, Equal<Required<AttributeVersion.changeObjectID>>>>();

            AttributeDetailVersions.WhereNew<
                Where<AttributeDetailVersion.changeObjectID, Equal<Required<AttributeDetailVersion.changeObjectID>>>>();

            AttributeGroupVersions.WhereNew<
                Where<AttributeGroupVersion.changeObjectID, Equal<Required<AttributeGroupVersion.changeObjectID>>>>();

            ScreenAttributeVersions.WhereNew<
                Where<ScreenAttributeVersion.changeObjectID, Equal<Required<ScreenAttributeVersion.changeObjectID>>>>();

            AttributeCurrentVersion.WhereNew<
                Where<AttributeVersion.changeObjectVersionID, Equal<Required<AttributeVersion.changeObjectVersionID>>>>();

            ReportVersions.WhereNew<
                Where<ReportVersion.changeObjectID, Equal<Required<ReportVersion.changeObjectID>>>>();

            DashboardVersions.WhereNew<
                Where<DashboardVersion.changeObjectID, Equal<Required<DashboardVersion.changeObjectID>>>>();

            WidgetVersions.WhereNew<
                Where<WidgetVersion.changeObjectID, Equal<Required<WidgetVersion.changeObjectID>>>>();

            SitemapVersions.WhereNew<
                Where<SitemapVersion.changeObjectID, Equal<Required<SitemapVersion.changeObjectID>>>>();

            WebHookVersions.WhereNew<
                Where<WebHookVersion.changeObjectID, Equal<Required<WebHookVersion.changeObjectID>>>>();

            BusinessEventVersions.WhereNew<
                Where<BusinessEventVersion.changeObjectID, Equal<Required<BusinessEventVersion.changeObjectID>>>>();

            BusinessEventSubscriberVersions.WhereNew<
                Where<BusinessEventVersion.changeObjectID, Equal<Required<BusinessEventVersion.changeObjectID>>>>();

            BusinessEventTriggerConditionVersions.WhereNew<
                Where<BusinessEventTriggerConditionVersion.changeObjectID, Equal<Required<BusinessEventTriggerConditionVersion.changeObjectID>>>>();

            BusinessEventScheduleVersions.WhereNew<
                Where<BusinessEventScheduleVersion.changeObjectID, Equal<Required<BusinessEventScheduleVersion.changeObjectID>>>>();

            BusinessEventInquiryParameterVersions.WhereNew<
                Where<BusinessEventInquiryParameterVersion.changeObjectID, Equal<Required<BusinessEventInquiryParameterVersion.changeObjectID>>>>();

            RoleVersions.WhereNew<
                Where<RoleVersion.changeObjectID, Equal<Required<RoleVersion.changeObjectID>>>>();

            RoleInCacheVersions.WhereNew<
                Where<RoleInCacheVersion.changeObjectID, Equal<Required<RoleInCacheVersion.changeObjectID>>>>();

            RoleInGraphVersions.WhereNew<
                Where<RoleInGraphVersion.changeObjectID, Equal<Required<RoleInGraphVersion.changeObjectID>>>>();

            RoleInMemberVersions.WhereNew<
                Where<RoleInMemberVersion.changeObjectID, Equal<Required<RoleInMemberVersion.changeObjectID>>>>();

            ScenarioMappingVersions.WhereNew<
                Where<ScenarioMappingVersion.changeObjectID, Equal<Required<ScenarioMappingVersion.changeObjectID>>>>();

            ScenarioMappingConditionVersions.WhereNew<
                Where<ScenarioMappingConditionVersion.changeObjectID, Equal<Required<ScenarioMappingConditionVersion.changeObjectID>>>>();

            ScenarioImportConditionVersions.WhereNew<
                Where<ScenarioImportConditionVersion.changeObjectID, Equal<Required<ScenarioImportConditionVersion.changeObjectID>>>>();

            ScenarioMappingFieldVersions.WhereNew<
                Where<ScenarioMappingFieldVersion.changeObjectID, Equal<Required<ScenarioMappingFieldVersion.changeObjectID>>>>();

            GIVersions.WhereNew<
                Where<GIVersion.changeObjectID, Equal<Required<GIVersion.changeObjectID>>>>();

            GIFilterVersions.WhereNew<
                Where<GIFilterVersion.changeObjectID, Equal<Required<GIFilterVersion.changeObjectID>>>>();

            GIGroupByVersions.WhereNew<
                Where<GIGroupByVersion.changeObjectID, Equal<Required<GIGroupByVersion.changeObjectID>>>>();

            GIOnVersions.WhereNew<
                Where<GIOnVersion.changeObjectID, Equal<Required<GIOnVersion.changeObjectID>>>>();

            GIRelationVersions.WhereNew<
                Where<GIRelationVersion.changeObjectID, Equal<Required<GIRelationVersion.changeObjectID>>>>();

            GIResultVersions.WhereNew<
                Where<GIResultVersion.changeObjectID, Equal<Required<GIResultVersion.changeObjectID>>>>();

            GISortVersions.WhereNew<
                Where<GISortVersion.changeObjectID, Equal<Required<GISortVersion.changeObjectID>>>>();

            GITableVersions.WhereNew<
                Where<GITableVersion.changeObjectID, Equal<Required<GITableVersion.changeObjectID>>>>();

            GIWhereVersions.WhereNew<
                Where<GIWhereVersion.changeObjectID, Equal<Required<GIWhereVersion.changeObjectID>>>>();
        }

        /// <summary>
        /// Fill a change object versions view with all versions of the current change object
        /// </summary>
        /// <typeparam name="TTable">tracked object table type</typeparam>
        /// <typeparam name="TTableVersion">tracked object version table type</typeparam>
        /// <param name="currentObject">current object of a tracked object type</param>
        /// <param name="changeObjectType">change object type to retrieve</param>
        /// <param name="changeObjectSubType">change object subtype to retrieve</param>
        /// <returns>List of version rows</returns>
        protected virtual IEnumerable GetVersions<TTable, TTableVersion>(object currentObject, string changeObjectType, string changeObjectSubType)
            where TTable : ITrackedObject
            where TTableVersion : AKChangeObjectVersion
        {
            if (currentObject == null)
            {
                yield break;
            }

            // Find current object changes
            foreach (AKChangeObject changeObject in ChangeObjects.Select(changeObjectType, changeObjectSubType))
            {
                // Parse json to get object key
                string keyValues = changeObject.KeyValues;

                if (keyValues != null)
                {
                    dynamic key = JsonConvert.DeserializeObject(keyValues);

                    // If object key matches current object, show any object changes
                    if (((TTable)currentObject).IsKeyMatch(key, currentObject))
                    {
                        foreach (var cob in ((TTable)currentObject).GetChangeObjectVersions(changeObject, this))
                        {
                            TTableVersion objectVersion = (TTableVersion)cob;
                            string changeValues = objectVersion.ChangeObject;

                            // Deserialize change object JSON
                            dynamic change = JsonConvert.DeserializeObject(changeValues);

                            // Fill object version row with changed object values
                            if (change != null)
                            {
                                objectVersion.Selected = false;
                                objectVersion.SetChangedValues(change);

                                // Format JSON
                                objectVersion.ChangeObject = JToken.Parse(objectVersion.ChangeObject).ToString(Formatting.Indented);

                                // Convert action type code to name
                                objectVersion.ActionName = objectVersion.ActionType.ToActionName();
                            }

                            yield return cob;
                        }

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Fill AttributeVersions view with all versions of the current Attribute
        /// </summary>
        /// <returns>list of AttributeVersion rows</returns>
        protected virtual IEnumerable attributeVersions()
        {
            return GetVersions<CSAttribute, AttributeVersion>((CSAttribute)Attributes.Current, 
                Enums.ChangeObjectType.Attribute, Enums.ChangeObjectSubType.CSAttribute);
        }

        /// <summary>
        /// Fill AttributeDetailVersions view with all versions of the current Attribute Detail
        /// </summary>
        /// <returns>list of AttributeDetailVersions rows</returns>
        protected virtual IEnumerable attributeDetailVersions()
        {
            return GetVersions<CSAttributeDetail, AttributeDetailVersion>((CSAttributeDetail)AttributeDetails.Current, 
                Enums.ChangeObjectType.Attribute, Enums.ChangeObjectSubType.CSAttributeDetail);
        }

        /// <summary>
        /// Fill AttributeGroupVersions view with all versions of the current Attribute Group
        /// </summary>
        /// <returns>list of AttributeGroupVersions rows</returns>
        protected virtual IEnumerable attributeGroupVersions()
        {
            return GetVersions<CSAttributeGroup, AttributeGroupVersion>((CSAttributeGroup)AttributeGroups.Current, 
                Enums.ChangeObjectType.Attribute, Enums.ChangeObjectSubType.CSAttributeGroup);
        }

        /// <summary>
        /// Fill ScreenAttributeVersions view with all versions of the current Screen Attribute
        /// </summary>
        /// <returns>list of ScreenAttributeVersions rows</returns>
        protected virtual IEnumerable screenAttributeVersions()
        {
            return GetVersions<CSScreenAttribute, ScreenAttributeVersion>((CSScreenAttribute)ScreenAttributes.Current, 
                Enums.ChangeObjectType.Attribute, Enums.ChangeObjectSubType.CSScreenAttribute);
        }

        /// <summary>
        /// Fill AttributeCurrentVersion view with the current Attribute's current version
        /// </summary>
        /// <returns>list of AttributeVersion rows</returns>
        protected virtual IEnumerable attributeCurrentVersion()
        {
            var objectVersion = (AttributeVersion)AttributeVersions.Current;

            if (objectVersion != null)
            {
                yield return objectVersion;
            }
        }

        /// <summary>
        /// Fill ReportVersions view with all versions of the current Report
        /// </summary>
        /// <returns>list of ReportVersions rows</returns>
        protected virtual IEnumerable reportVersions()
        {
            return GetVersions<UserReport, ReportVersion>((UserReport)Reports.Current, 
                Enums.ChangeObjectType.Report, Enums.ChangeObjectSubType.UserReport);
        }

        /// <summary>
        /// Fill DashboardVersions view with all versions of the current Dashboard
        /// </summary>
        /// <returns>list of DashboardVersions rows</returns>
        protected virtual IEnumerable dashboardVersions()
        {
            return GetVersions<Dashboard, DashboardVersion>((Dashboard)Dashboards.Current, 
                Enums.ChangeObjectType.Dashboard, Enums.ChangeObjectSubType.Dashboard);
        }

        /// <summary>
        /// Fill WidgetVersions view with all versions of the current Widget
        /// </summary>
        /// <returns>list of WidgetVersions rows</returns>
        protected virtual IEnumerable widgetVersions()
        {
            return GetVersions<Widget, WidgetVersion>((Widget)Widgets.Current, 
                Enums.ChangeObjectType.Dashboard, Enums.ChangeObjectSubType.Widget);
        }

        /// <summary>
        /// Fill DashboardParameterVersions view with all versions of the current Dashboard Parameter
        /// </summary>
        /// <returns>list of DashboardParameterVersions rows</returns>
        protected virtual IEnumerable dashboardParameterVersions()
        {
            return GetVersions<DashboardParameter, DashboardParameterVersion>((DashboardParameter)DashboardParameters.Current,
                Enums.ChangeObjectType.Dashboard, Enums.ChangeObjectSubType.DashboardParameter);
        }

        /// <summary>
        /// Fill SitemapVersions view with all versions of the current Sitemap
        /// </summary>
        /// <returns>list of SitemapVersions rows</returns>
        protected virtual IEnumerable sitemapVersions()
        {
            return GetVersions<Sitemap, SitemapVersion>((Sitemap)Sitemaps.Current, 
                Enums.ChangeObjectType.Sitemap, Enums.ChangeObjectSubType.Sitemap);
        }

        /// <summary>
        /// Fill WebHookVersions view with all versions of the current WebHook
        /// </summary>
        /// <returns>list of WebHooks rows</returns>
        protected virtual IEnumerable webHookVersions()
        {
            return GetVersions<WebHook, WebHookVersion>((WebHook)WebHooks.Current,
                Enums.ChangeObjectType.WebHook, Enums.ChangeObjectSubType.WebHook);
        }

        /// Fill BusinessEventVersions view with all versions of the current BusinessEvent
        /// </summary>
        /// <returns>list of BusinessEvents rows</returns>
        protected virtual IEnumerable businessEventVersions()
        {
            return GetVersions<BPEvent, BusinessEventVersion>((BPEvent)BusinessEvents.Current,
                Enums.ChangeObjectType.BusinessEvent, Enums.ChangeObjectSubType.BPEvent);
        }

        /// <summary>
        /// Fill BusinessEventSubscriberVersions view with all versions of the current BusinessEventSubscriber
        /// </summary>
        /// <returns>list of BusinessEventSubscriberVersions rows</returns>
        protected virtual IEnumerable businessEventSubscriberVersions()
        {
            return GetVersions<BPEventSubscriber, BusinessEventSubscriberVersion>((BPEventSubscriber)BusinessEventSubscribers.Current,
                Enums.ChangeObjectType.BusinessEvent, Enums.ChangeObjectSubType.BPEventSubscriber);
        }

        /// <summary>
        /// Fill BusinessEventTriggerConditionVersions view with all versions of the current BusinessEventTriggerCondition
        /// </summary>
        /// <returns>list of BusinessEventTriggerConditionVersions rows</returns>
        protected virtual IEnumerable businessEventTriggerConditionVersions()
        {
            return GetVersions<BPEventTriggerCondition, BusinessEventTriggerConditionVersion>((BPEventTriggerCondition)BusinessEventTriggerConditions.Current,
                Enums.ChangeObjectType.BusinessEvent, Enums.ChangeObjectSubType.BPEventTriggerCondition);
        }

        /// <summary>
        /// Fill BusinessEventScheduleVersions view with all versions of the current BusinessEventSchedule
        /// </summary>
        /// <returns>list of BusinessEventScheduleVersions rows</returns>
        protected virtual IEnumerable businessEventScheduleVersions()
        {
            return GetVersions<BPEventSchedule, BusinessEventScheduleVersion>((BPEventSchedule)BusinessEventSchedules.Current,
                Enums.ChangeObjectType.BusinessEvent, Enums.ChangeObjectSubType.BPEventSchedule);
        }

        /// <summary>
        /// Fill BusinessEventInquiryParameterVersions view with all versions of the current BusinessEventInquiryParameter
        /// </summary>
        /// <returns>list of BusinessEventInquiryParameterVersions rows</returns>
        protected virtual IEnumerable businessEventInquiryParameterVersions()
        {
            return GetVersions<BPInquiryParameter, BusinessEventInquiryParameterVersion>((BPInquiryParameter)BusinessEventInquiryParameters.Current,
                Enums.ChangeObjectType.BusinessEvent, Enums.ChangeObjectSubType.BPInquiryParameter);
        }

        /// Fill RoleVersions view with all versions of the current Role
        /// </summary>
        /// <returns>list of RoleVersions rows</returns>
        protected virtual IEnumerable roleVersions()
        {
            return GetVersions<Roles, RoleVersion>((Roles)Roles.Current,
                Enums.ChangeObjectType.Role, Enums.ChangeObjectSubType.Roles);
        }

        /// Fill RoleInCacheVersions view with all versions of the current RoleInCaches
        /// </summary>
        /// <returns>list of RoleInCacheVersions rows</returns>
        protected virtual IEnumerable roleInCacheVersions()
        {
            return GetVersions<RolesInCache, RoleInCacheVersion>((RolesInCache)RolesInCaches.Current,
                Enums.ChangeObjectType.Role, Enums.ChangeObjectSubType.RolesInCache);
        }

        /// Fill RoleInGraphVersions view with all versions of the current RoleInGraphs
        /// </summary>
        /// <returns>list of RoleInGraphVersions rows</returns>
        protected virtual IEnumerable roleInGraphVersions()
        {
            return GetVersions<RolesInGraph, RoleInGraphVersion>((RolesInGraph)RolesInGraphs.Current,
                Enums.ChangeObjectType.Role, Enums.ChangeObjectSubType.RolesInGraph);
        }

        /// Fill RoleInMemberVersions view with all versions of the current RoleInMembers
        /// </summary>
        /// <returns>list of RoleInMemberVersions rows</returns>
        protected virtual IEnumerable roleInMemberVersions()
        {
            return GetVersions<RolesInMember, RoleInMemberVersion>((RolesInMember)RolesInMembers.Current,
                Enums.ChangeObjectType.Role, Enums.ChangeObjectSubType.RolesInMember);
        }

        /// Fill ScenarioMappingVersions view with all versions of the current Scenario
        /// </summary>
        /// <returns>list of ScenarioMappingVersions rows</returns>
        protected virtual IEnumerable scenarioMappingVersions()
        {
            return GetVersions<SYMapping, ScenarioMappingVersion>((SYMapping)ScenarioMappings.Current,
                Enums.ChangeObjectType.Scenario, Enums.ChangeObjectSubType.SYMapping);
        }

        /// Fill ScenarioMappingConditionVersions view with all versions of the current Scenario Condition
        /// </summary>
        /// <returns>list of ScenarioMappingConditionVersions rows</returns>
        protected virtual IEnumerable scenarioMappingConditionVersions()
        {
            return GetVersions<SYMappingCondition, ScenarioMappingConditionVersion>((SYMappingCondition)ScenarioMappingConditions.Current,
                Enums.ChangeObjectType.Scenario, Enums.ChangeObjectSubType.SYMappingCondition);
        }

        /// Fill ScenarioMappingFieldVersions view with all versions of the current Scenario Field
        /// </summary>
        /// <returns>list of ScenarioMappingFieldVersions rows</returns>
        protected virtual IEnumerable scenarioMappingFieldVersions()
        {
            return GetVersions<SYMappingField, ScenarioMappingFieldVersion>((SYMappingField)ScenarioMappingFields.Current,
                Enums.ChangeObjectType.Scenario, Enums.ChangeObjectSubType.SYMappingField);
        }

        /// Fill ScenarioImportConditionVersions view with all versions of the current Scenario Import Condition
        /// </summary>
        /// <returns>list of ScenarioImportConditionVersions rows</returns>
        protected virtual IEnumerable scenarioImportConditionVersions()
        {
            return GetVersions<SYMappingField, ScenarioMappingFieldVersion>((SYMappingField)ScenarioMappingFields.Current,
                Enums.ChangeObjectType.Scenario, Enums.ChangeObjectSubType.SYMappingField);
        }

        /// Fill GIVersions view with all versions of the current GI
        /// </summary>
        /// <returns>list of GIVersions rows</returns>
        protected virtual IEnumerable giVersions()
        {
            return GetVersions<GIDesign, GIVersion>((GIDesign)GIs.Current,
                Enums.ChangeObjectType.GI, Enums.ChangeObjectSubType.GIDesign);
        }

        /// Fill GIFilters view with all versions of the current GI
        /// </summary>
        /// <returns>list of GIFilters rows</returns>
        protected virtual IEnumerable giFilterVersions()
        {
            return GetVersions<GIFilter, GIFilterVersion>((GIFilter)GIFilters.Current,
                Enums.ChangeObjectType.GI, Enums.ChangeObjectSubType.GIFilter);
        }

        /// Fill GIGroupBys view with all versions of the current GI
        /// </summary>
        /// <returns>list of GIGroupBys rows</returns>
        protected virtual IEnumerable giGroupByVersions()
        {
            return GetVersions<GIGroupBy, GIGroupByVersion>((GIGroupBy)GIGroupBys.Current,
                Enums.ChangeObjectType.GI, Enums.ChangeObjectSubType.GIGroupBy);
        }

        /// Fill GIOns view with all versions of the current GI
        /// </summary>
        /// <returns>list of GIOns rows</returns>
        protected virtual IEnumerable giOnVersions()
        {
            return GetVersions<GIOn, GIOnVersion>((GIOn)GIOns.Current,
                Enums.ChangeObjectType.GI, Enums.ChangeObjectSubType.GIOn);
        }

        /// Fill GIRelations view with all versions of the current GI
        /// </summary>
        /// <returns>list of GIRelations rows</returns>
        protected virtual IEnumerable giRelationVersions()
        {
            return GetVersions<GIRelation, GIRelationVersion>((GIRelation)GIRelations.Current,
                Enums.ChangeObjectType.GI, Enums.ChangeObjectSubType.GIRelation);
        }

        /// Fill GIResults view with all versions of the current GI
        /// </summary>
        /// <returns>list of GIResults rows</returns>
        protected virtual IEnumerable giResultVersions()
        {
            return GetVersions<GIResult, GIResultVersion>((GIResult)GIResults.Current,
                Enums.ChangeObjectType.GI, Enums.ChangeObjectSubType.GIResult);
        }

        /// Fill GISorts view with all versions of the current GI
        /// </summary>
        /// <returns>list of GISorts rows</returns>
        protected virtual IEnumerable giSortVersions()
        {
            return GetVersions<GISort, GISortVersion>((GISort)GISorts.Current,
                Enums.ChangeObjectType.GI, Enums.ChangeObjectSubType.GISort);
        }

        /// Fill GITables view with all versions of the current GI
        /// </summary>
        /// <returns>list of GITables rows</returns>
        protected virtual IEnumerable giTableVersions()
        {
            return GetVersions<GITable, GITableVersion>((GITable)GITables.Current,
                Enums.ChangeObjectType.GI, Enums.ChangeObjectSubType.GITable);
        }

        /// Fill GIWheres view with all versions of the current GI
        /// </summary>
        /// <returns>list of GIWheres rows</returns>
        protected virtual IEnumerable giWhereVersions()
        {
            return GetVersions<GIWhere, GIWhereVersion>((GIWhere)GIWheres.Current,
                Enums.ChangeObjectType.GI, Enums.ChangeObjectSubType.GIWhere);
        }
    }

    /// <summary>
    /// Extensions class for the No-Code Change Tracking controller
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Convert action type string to its name
        /// </summary>
        /// <param name="actionType">change tracking action type code (I, U, D)</param>
        /// <returns>corresponding change tracking action name (Insert, Update, Delete)</returns>
        public static string ToActionName(this string actionType)
        {
            string actionName = null;

            // Convert action type code to name
            if (actionType == "I")
            {
                actionName = "Insert";
            }
            else if (actionType == "U")
            {
                actionName = "Update";
            }
            else if (actionType == "D")
            {
                actionName = "Delete";
            }

            return actionName;
        }
    }
}