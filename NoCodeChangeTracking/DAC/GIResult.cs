using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Data;
using PX.Data.BQL;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// GIResult table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("GIResult")]
    public class GIResult : IBqlTable, ITrackedObject
    {
        #region DesignID
        [PXDBGuid(IsKey = true)]
        [PXUIField(DisplayName = "Design ID")]
        public virtual Guid? DesignID { get; set; }
        public abstract class designID : PX.Data.BQL.BqlGuid.Field<designID> { }
        #endregion

        #region LineNbr
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Line Nbr")]
        public virtual int? LineNbr { get; set; }
        public abstract class lineNbr : PX.Data.BQL.BqlInt.Field<lineNbr> { }
        #endregion

        #region SortOrder
        [PXDBInt()]
        [PXUIField(DisplayName = "Sort Order")]
        public virtual int? SortOrder { get; set; }
        public abstract class sortOrder : PX.Data.BQL.BqlInt.Field<sortOrder> { }
        #endregion

        #region IsActive
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Active")]
        public virtual bool? IsActive { get; set; }
        public abstract class isActive : PX.Data.BQL.BqlBool.Field<isActive> { }
        #endregion

        #region ObjectName
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Object Name")]
        public virtual string ObjectName { get; set; }
        public abstract class objectName : PX.Data.BQL.BqlString.Field<objectName> { }
        #endregion

        #region Field
        [PXDBString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Field")]
        public virtual string Field { get; set; }
        public abstract class field : PX.Data.BQL.BqlString.Field<field> { }
        #endregion

        #region SchemaField
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Schema Field")]
        public virtual string SchemaField { get; set; }
        public abstract class schemaField : PX.Data.BQL.BqlString.Field<schemaField> { }
        #endregion

        #region Caption
        [PXDBString(128, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Caption")]
        public virtual string Caption { get; set; }
        public abstract class caption : PX.Data.BQL.BqlString.Field<caption> { }
        #endregion

        #region StyleFormula
        [PXDBString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Style Formula")]
        public virtual string StyleFormula { get; set; }
        public abstract class styleFormula : PX.Data.BQL.BqlString.Field<styleFormula> { }
        #endregion

        #region Width
        [PXDBInt()]
        [PXUIField(DisplayName = "Width")]
        public virtual int? Width { get; set; }
        public abstract class width : PX.Data.BQL.BqlInt.Field<width> { }
        #endregion

        #region IsVisible
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Visible")]
        public virtual bool? IsVisible { get; set; }
        public abstract class isVisible : PX.Data.BQL.BqlBool.Field<isVisible> { }
        #endregion

        #region DefaultNav
        [PXDBBool()]
        [PXUIField(DisplayName = "Default Nav")]
        public virtual bool? DefaultNav { get; set; }
        public abstract class defaultNav : PX.Data.BQL.BqlBool.Field<defaultNav> { }
        #endregion

        #region AggregateFunction
        [PXDBString(32, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Aggregate Function")]
        public virtual string AggregateFunction { get; set; }
        public abstract class aggregateFunction : PX.Data.BQL.BqlString.Field<aggregateFunction> { }
        #endregion

        #region TotalAggregateFunction
        [PXDBString(32, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Total Aggregate Function")]
        public virtual string TotalAggregateFunction { get; set; }
        public abstract class totalAggregateFunction : PX.Data.BQL.BqlString.Field<totalAggregateFunction> { }
        #endregion

        #region NavigationNbr
        [PXDBInt()]
        [PXUIField(DisplayName = "Navigation Nbr")]
        public virtual int? NavigationNbr { get; set; }
        public abstract class navigationNbr : PX.Data.BQL.BqlInt.Field<navigationNbr> { }
        #endregion

        #region QuickFilter
        [PXDBBool()]
        [PXUIField(DisplayName = "Quick Filter")]
        public virtual bool? QuickFilter { get; set; }
        public abstract class quickFilter : PX.Data.BQL.BqlBool.Field<quickFilter> { }
        #endregion

        #region FastFilter
        [PXDBBool()]
        [PXUIField(DisplayName = "Fast Filter")]
        public virtual bool? FastFilter { get; set; }
        public abstract class fastFilter : PX.Data.BQL.BqlBool.Field<fastFilter> { }
        #endregion

        #region Rowid
        [PXDBGuid()]
        [PXUIField(DisplayName = "Rowid")]
        public virtual Guid? Rowid { get; set; }
        public abstract class rowid : PX.Data.BQL.BqlGuid.Field<rowid> { }
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
            int? lineNbr = null;
            var giResult = (GIResult)tableRow;

            if (key != null)
            {
                designID = (Guid)(key.DesignID);
                lineNbr = (int)(key.LineNbr);
            }

            return (designID.HasValue && giResult.DesignID == designID.Value
                && lineNbr.HasValue && giResult.LineNbr == lineNbr.Value);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<GIResultVersion,
                Where<GIResultVersion.changeObjectID, Equal<Required<GIResultVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<GIResultVersion>().ToList<object>();
        }
    }
}