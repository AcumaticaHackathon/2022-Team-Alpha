using System;
using System.Collections.Generic;
using System.Linq;
using PX.Data;
using PX.Data.BQL;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// SYMapping table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("SYMapping")]
    public class SYMapping : IBqlTable, ITrackedObject
    {
        #region MappingID
        [PXDBGuid(IsKey = true)]
        [PXUIField(DisplayName = "Mapping ID")]
        public virtual Guid? MappingID { get; set; }
        public abstract class mappingID : PX.Data.BQL.BqlGuid.Field<mappingID> { }
        #endregion

        #region InverseMappingID
        [PXDBGuid()]
        [PXUIField(DisplayName = "Inverse Mapping ID")]
        public virtual Guid? InverseMappingID { get; set; }
        public abstract class inverseMappingID : PX.Data.BQL.BqlGuid.Field<inverseMappingID> { }
        #endregion

        #region Name
        [PXDBString(128, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Name")]
        public virtual string Name { get; set; }
        public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
        #endregion

        #region IsActive
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Active")]
        public virtual bool? IsActive { get; set; }
        public abstract class isActive : PX.Data.BQL.BqlBool.Field<isActive> { }
        #endregion

        #region ScreenID
        [PXDBString(8, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Screen ID")]
        public virtual string ScreenID { get; set; }
        public abstract class screenID : PX.Data.BQL.BqlString.Field<screenID> { }
        #endregion

        #region MappingType
        [PXDBString(1, IsKey = true, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Mapping Type")]
        public virtual string MappingType { get; set; }
        public abstract class mappingType : PX.Data.BQL.BqlString.Field<mappingType> { }
        #endregion

        #region GraphName
        [PXDBString(128, InputMask = "")]
        [PXUIField(DisplayName = "Graph Name")]
        public virtual string GraphName { get; set; }
        public abstract class graphName : PX.Data.BQL.BqlString.Field<graphName> { }
        #endregion

        #region ViewName
        [PXDBString(128, InputMask = "")]
        [PXUIField(DisplayName = "View Name")]
        public virtual string ViewName { get; set; }
        public abstract class viewName : PX.Data.BQL.BqlString.Field<viewName> { }
        #endregion

        #region GridViewName
        [PXDBString(128, InputMask = "")]
        [PXUIField(DisplayName = "Grid View Name")]
        public virtual string GridViewName { get; set; }
        public abstract class gridViewName : PX.Data.BQL.BqlString.Field<gridViewName> { }
        #endregion

        #region ProviderID
        [PXDBGuid()]
        [PXUIField(DisplayName = "Provider ID")]
        public virtual Guid? ProviderID { get; set; }
        public abstract class providerID : PX.Data.BQL.BqlGuid.Field<providerID> { }
        #endregion

        #region ProviderObject
        [PXDBString(128, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Provider Object")]
        public virtual string ProviderObject { get; set; }
        public abstract class providerObject : PX.Data.BQL.BqlString.Field<providerObject> { }
        #endregion

        #region SyncType
        [PXDBString(1, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Sync Type")]
        public virtual string SyncType { get; set; }
        public abstract class syncType : PX.Data.BQL.BqlString.Field<syncType> { }
        #endregion

        #region Status
        [PXDBString(1, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Status")]
        public virtual string Status { get; set; }
        public abstract class status : PX.Data.BQL.BqlString.Field<status> { }
        #endregion

        #region FieldCntr
        [PXDBShort()]
        [PXUIField(DisplayName = "Field Cntr")]
        public virtual short? FieldCntr { get; set; }
        public abstract class fieldCntr : PX.Data.BQL.BqlShort.Field<fieldCntr> { }
        #endregion

        #region FieldOrderCntr
        [PXDBShort()]
        [PXUIField(DisplayName = "Field Order Cntr")]
        public virtual short? FieldOrderCntr { get; set; }
        public abstract class fieldOrderCntr : PX.Data.BQL.BqlShort.Field<fieldOrderCntr> { }
        #endregion

        #region ImportConditionCntr
        [PXDBShort()]
        [PXUIField(DisplayName = "Import Condition Cntr")]
        public virtual short? ImportConditionCntr { get; set; }
        public abstract class importConditionCntr : PX.Data.BQL.BqlShort.Field<importConditionCntr> { }
        #endregion

        #region ConditionCntr
        [PXDBShort()]
        [PXUIField(DisplayName = "Condition Cntr")]
        public virtual short? ConditionCntr { get; set; }
        public abstract class conditionCntr : PX.Data.BQL.BqlShort.Field<conditionCntr> { }
        #endregion

        #region DataCntr
        [PXDBInt()]
        [PXUIField(DisplayName = "Data Cntr")]
        public virtual int? DataCntr { get; set; }
        public abstract class dataCntr : PX.Data.BQL.BqlInt.Field<dataCntr> { }
        #endregion

        #region NbrRecords
        [PXDBInt()]
        [PXUIField(DisplayName = "Nbr Records")]
        public virtual int? NbrRecords { get; set; }
        public abstract class nbrRecords : PX.Data.BQL.BqlInt.Field<nbrRecords> { }
        #endregion

        #region PreparedOn
        [PXDBDate()]
        [PXUIField(DisplayName = "Prepared On")]
        public virtual DateTime? PreparedOn { get; set; }
        public abstract class preparedOn : PX.Data.BQL.BqlDateTime.Field<preparedOn> { }
        #endregion

        #region CompletedOn
        [PXDBDate()]
        [PXUIField(DisplayName = "Completed On")]
        public virtual DateTime? CompletedOn { get; set; }
        public abstract class completedOn : PX.Data.BQL.BqlDateTime.Field<completedOn> { }
        #endregion

        #region ImportTimeStamp
        [PXDBString(4000, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Import Time Stamp")]
        public virtual string ImportTimeStamp { get; set; }
        public abstract class importTimeStamp : PX.Data.BQL.BqlString.Field<importTimeStamp> { }
        #endregion

        #region ExportTimeStamp
        [PXDBDate()]
        [PXUIField(DisplayName = "Export Time Stamp")]
        public virtual DateTime? ExportTimeStamp { get; set; }
        public abstract class exportTimeStamp : PX.Data.BQL.BqlDateTime.Field<exportTimeStamp> { }
        #endregion

        #region ExportTimeStampUtc
        [PXDBDate()]
        [PXUIField(DisplayName = "Export Time Stamp Utc")]
        public virtual DateTime? ExportTimeStampUtc { get; set; }
        public abstract class exportTimeStampUtc : PX.Data.BQL.BqlDateTime.Field<exportTimeStampUtc> { }
        #endregion

        #region FormatLocale
        [PXDBString(6, InputMask = "")]
        [PXUIField(DisplayName = "Format Locale")]
        public virtual string FormatLocale { get; set; }
        public abstract class formatLocale : PX.Data.BQL.BqlString.Field<formatLocale> { }
        #endregion

        #region CreatedByID
        public abstract class createdByID : BqlGuid.Field<createdByID> { }
        [PXDBCreatedByID]
        [PXUIField(DisplayName = PXDBLastModifiedByIDAttribute.DisplayFieldNames.CreatedByID, Enabled = false)]
        public virtual Guid? CreatedByID { get; set; }
        #endregion

        #region CreatedByScreenID
        public abstract class createdByScreenID : BqlString.Field<createdByScreenID> { }
        [PXDBCreatedByScreenID]
        public virtual string CreatedByScreenID { get; set; }
        #endregion

        #region CreatedDateTime
        public abstract class createdDateTime : BqlDateTime.Field<createdDateTime> { }
        [PXDBCreatedDateTime]
        [PXUIField(DisplayName = PXDBLastModifiedByIDAttribute.DisplayFieldNames.CreatedDateTime, Enabled = false)]
        public virtual DateTime? CreatedDateTime { get; set; }
        #endregion

        #region LastModifiedByID
        public abstract class lastModifiedByID : BqlGuid.Field<lastModifiedByID> { }
        [PXDBLastModifiedByID]
        [PXUIField(DisplayName = PXDBLastModifiedByIDAttribute.DisplayFieldNames.LastModifiedByID, Enabled = false)]
        public virtual Guid? LastModifiedByID { get; set; }
        #endregion

        #region LastModifiedByScreenID
        public abstract class lastModifiedByScreenID : BqlString.Field<lastModifiedByScreenID> { }
        [PXDBLastModifiedByScreenID]
        public virtual string LastModifiedByScreenID { get; set; }
        #endregion

        #region LastModifiedDateTime
        public abstract class lastModifiedDateTime : BqlDateTime.Field<lastModifiedDateTime> { }
        [PXDBLastModifiedDateTime]
        [PXUIField(DisplayName = PXDBLastModifiedByIDAttribute.DisplayFieldNames.LastModifiedDateTime, Enabled = false)]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        #endregion

        #region Tstamp
        [PXDBTimestamp()]
        [PXUIField(DisplayName = "Tstamp")]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
        #endregion

        #region SitemapID
        [PXDBGuid()]
        [PXUIField(DisplayName = "Sitemap ID")]
        public virtual Guid? SitemapID { get; set; }
        public abstract class sitemapID : PX.Data.BQL.BqlGuid.Field<sitemapID> { }
        #endregion

        #region IsSimpleMapping
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Simple Mapping")]
        public virtual bool? IsSimpleMapping { get; set; }
        public abstract class isSimpleMapping : PX.Data.BQL.BqlBool.Field<isSimpleMapping> { }
        #endregion

        #region DiscardResult
        [PXDBBool()]
        [PXUIField(DisplayName = "Discard Result")]
        public virtual bool? DiscardResult { get; set; }
        public abstract class discardResult : PX.Data.BQL.BqlBool.Field<discardResult> { }
        #endregion

        #region Noteid
        [PXNote()]
        public virtual Guid? Noteid { get; set; }
        public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }
        #endregion

        #region IsExportOnlyMappingFields
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Export Only Mapping Fields")]
        public virtual bool? IsExportOnlyMappingFields { get; set; }
        public abstract class isExportOnlyMappingFields : PX.Data.BQL.BqlBool.Field<isExportOnlyMappingFields> { }
        #endregion

        #region ProcessInParallel
        [PXDBBool()]
        [PXUIField(DisplayName = "Process In Parallel")]
        public virtual bool? ProcessInParallel { get; set; }
        public abstract class processInParallel : PX.Data.BQL.BqlBool.Field<processInParallel> { }
        #endregion

        #region BreakOnError
        [PXDBBool()]
        [PXUIField(DisplayName = "Break On Error")]
        public virtual bool? BreakOnError { get; set; }
        public abstract class breakOnError : PX.Data.BQL.BqlBool.Field<breakOnError> { }
        #endregion

        #region BreakOnTarget
        [PXDBBool()]
        [PXUIField(DisplayName = "Break On Target")]
        public virtual bool? BreakOnTarget { get; set; }
        public abstract class breakOnTarget : PX.Data.BQL.BqlBool.Field<breakOnTarget> { }
        #endregion

        #region SkipHeaders
        [PXDBBool()]
        [PXUIField(DisplayName = "Skip Headers")]
        public virtual bool? SkipHeaders { get; set; }
        public abstract class skipHeaders : PX.Data.BQL.BqlBool.Field<skipHeaders> { }
        #endregion

        /// <summary>
        /// Whether a dynamic object key matches a table row object
        /// </summary>
        /// <param name="key">dynamic object holding key fields</param>
        /// <param name="tableRow">table row object</param>
        /// <returns>whether the key matches</returns>
        public bool IsKeyMatch(dynamic key, object tableRow)
        {
            Guid? mappingID = null;
            var mapping = (SYMapping)tableRow;

            if (key != null)
            {
                mappingID = (Guid)key.MappingID;
            }

            return (mappingID.HasValue && mapping.MappingID == mappingID.Value);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<ScenarioMappingVersion,
                Where<ScenarioMappingVersion.changeObjectID, Equal<Required<ScenarioMappingVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<ScenarioMappingVersion>().ToList<object>();
        }
    }
}