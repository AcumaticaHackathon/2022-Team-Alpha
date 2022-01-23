using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Data;
using PX.Data.BQL;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// GIDesign table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("GIDesign")]
    public class GIDesign : IBqlTable, ITrackedObject
    {
        #region DesignID
        [PXDBGuid(IsKey = true)]
        [PXUIField(DisplayName = "Design ID")]
        public virtual Guid? DesignID { get; set; }
        public abstract class designID : PX.Data.BQL.BqlGuid.Field<designID> { }
        #endregion

        #region Name
        [PXDBString(255, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Name")]
        public virtual string Name { get; set; }
        public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
        #endregion

        #region FilterCaption
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Filter Caption")]
        public virtual string FilterCaption { get; set; }
        public abstract class filterCaption : PX.Data.BQL.BqlString.Field<filterCaption> { }
        #endregion

        #region ResultsCaption
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Results Caption")]
        public virtual string ResultsCaption { get; set; }
        public abstract class resultsCaption : PX.Data.BQL.BqlString.Field<resultsCaption> { }
        #endregion

        #region SelectTop
        [PXDBInt()]
        [PXUIField(DisplayName = "Select Top")]
        public virtual int? SelectTop { get; set; }
        public abstract class selectTop : PX.Data.BQL.BqlInt.Field<selectTop> { }
        #endregion

        #region FilterColCount
        [PXDBInt()]
        [PXUIField(DisplayName = "Filter Col Count")]
        public virtual int? FilterColCount { get; set; }
        public abstract class filterColCount : PX.Data.BQL.BqlInt.Field<filterColCount> { }
        #endregion

        #region PageSize
        [PXDBInt()]
        [PXUIField(DisplayName = "Page Size")]
        public virtual int? PageSize { get; set; }
        public abstract class pageSize : PX.Data.BQL.BqlInt.Field<pageSize> { }
        #endregion

        #region ExportTop
        [PXDBInt()]
        [PXUIField(DisplayName = "Export Top")]
        public virtual int? ExportTop { get; set; }
        public abstract class exportTop : PX.Data.BQL.BqlInt.Field<exportTop> { }
        #endregion

        #region PrimaryScreenIDNew
        [PXDBString(8, InputMask = "")]
        [PXUIField(DisplayName = "Primary Screen IDNew")]
        public virtual string PrimaryScreenIDNew { get; set; }
        public abstract class primaryScreenIDNew : PX.Data.BQL.BqlString.Field<primaryScreenIDNew> { }
        #endregion

        #region NewRecordCreationEnabled
        [PXDBBool()]
        [PXUIField(DisplayName = "New Record Creation Enabled")]
        public virtual bool? NewRecordCreationEnabled { get; set; }
        public abstract class newRecordCreationEnabled : PX.Data.BQL.BqlBool.Field<newRecordCreationEnabled> { }
        #endregion

        #region MassDeleteEnabled
        [PXDBBool()]
        [PXUIField(DisplayName = "Mass Delete Enabled")]
        public virtual bool? MassDeleteEnabled { get; set; }
        public abstract class massDeleteEnabled : PX.Data.BQL.BqlBool.Field<massDeleteEnabled> { }
        #endregion

        #region AutoConfirmDelete
        [PXDBBool()]
        [PXUIField(DisplayName = "Auto Confirm Delete")]
        public virtual bool? AutoConfirmDelete { get; set; }
        public abstract class autoConfirmDelete : PX.Data.BQL.BqlBool.Field<autoConfirmDelete> { }
        #endregion

        #region MassRecordsUpdateEnabled
        [PXDBBool()]
        [PXUIField(DisplayName = "Mass Records Update Enabled")]
        public virtual bool? MassRecordsUpdateEnabled { get; set; }
        public abstract class massRecordsUpdateEnabled : PX.Data.BQL.BqlBool.Field<massRecordsUpdateEnabled> { }
        #endregion

        #region MassActionsOnRecordsEnabled
        [PXDBBool()]
        [PXUIField(DisplayName = "Mass Actions On Records Enabled")]
        public virtual bool? MassActionsOnRecordsEnabled { get; set; }
        public abstract class massActionsOnRecordsEnabled : PX.Data.BQL.BqlBool.Field<massActionsOnRecordsEnabled> { }
        #endregion

        #region ExposeViaOData
        [PXDBBool()]
        [PXUIField(DisplayName = "Expose Via OData")]
        public virtual bool? ExposeViaOData { get; set; }
        public abstract class exposeViaOData : PX.Data.BQL.BqlBool.Field<exposeViaOData> { }
        #endregion

        #region ExposeViaMobile
        [PXDBBool()]
        [PXUIField(DisplayName = "Expose Via Mobile")]
        public virtual bool? ExposeViaMobile { get; set; }
        public abstract class exposeViaMobile : PX.Data.BQL.BqlBool.Field<exposeViaMobile> { }
        #endregion

        #region RowStyleFormula
        [PXDBString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Row Style Formula")]
        public virtual string RowStyleFormula { get; set; }
        public abstract class rowStyleFormula : PX.Data.BQL.BqlString.Field<rowStyleFormula> { }
        #endregion

        #region ShowDeletedRecords
        [PXDBBool()]
        [PXUIField(DisplayName = "Show Deleted Records")]
        public virtual bool? ShowDeletedRecords { get; set; }
        public abstract class showDeletedRecords : PX.Data.BQL.BqlBool.Field<showDeletedRecords> { }
        #endregion

        #region NotesAndFilesTable
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Notes And Files Table")]
        public virtual string NotesAndFilesTable { get; set; }
        public abstract class notesAndFilesTable : PX.Data.BQL.BqlString.Field<notesAndFilesTable> { }
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

        #region Noteid
        [PXNote()]
        public virtual Guid? Noteid { get; set; }
        public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }
        #endregion

        /// <summary>
        /// Whether a dynamic object key matches a table row object
        /// </summary>
        /// <param name="key">dynamic object holding key fields</param>
        /// <param name="tableRow">table row object</param>
        /// <returns>whether the key matches</returns>
        public bool IsKeyMatch(dynamic key, object tableRow)
        {
            Guid? designID = null;
            var giDesign = (GIDesign)tableRow;

            if (key != null)
            {
                designID = (Guid)(key.DesignID);
            }

            return (designID.HasValue && giDesign.DesignID == designID.Value);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<GIVersion,
                Where<GIVersion.changeObjectID, Equal<Required<GIVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<GIVersion>().ToList<object>();
        }
    }
}