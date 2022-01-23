using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// GIFilter table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("GIFilter")]
    public class GIFilter : IBqlTable, ITrackedObject
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

        #region IsActive
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Active")]
        public virtual bool? IsActive { get; set; }
        public abstract class isActive : PX.Data.BQL.BqlBool.Field<isActive> { }
        #endregion

        #region Name
        [PXDBString(255, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Name")]
        public virtual string Name { get; set; }
        public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
        #endregion

        #region FieldName
        [PXDBString(512, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Field Name")]
        public virtual string FieldName { get; set; }
        public abstract class fieldName : PX.Data.BQL.BqlString.Field<fieldName> { }
        #endregion

        #region DataType
        [PXDBString(50, InputMask = "")]
        [PXUIField(DisplayName = "Data Type")]
        public virtual string DataType { get; set; }
        public abstract class dataType : PX.Data.BQL.BqlString.Field<dataType> { }
        #endregion

        #region DisplayName
        [PXDBString(512, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Display Name")]
        public virtual string DisplayName { get; set; }
        public abstract class displayName : PX.Data.BQL.BqlString.Field<displayName> { }
        #endregion

        #region AvailableValues
        [PXDBString(1024, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Available Values")]
        public virtual string AvailableValues { get; set; }
        public abstract class availableValues : PX.Data.BQL.BqlString.Field<availableValues> { }
        #endregion

        #region IsExpression
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Expression")]
        public virtual bool? IsExpression { get; set; }
        public abstract class isExpression : PX.Data.BQL.BqlBool.Field<isExpression> { }
        #endregion

        #region DefaultValue
        [PXDBString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Default Value")]
        public virtual string DefaultValue { get; set; }
        public abstract class defaultValue : PX.Data.BQL.BqlString.Field<defaultValue> { }
        #endregion

        #region ColSpan
        [PXDBInt()]
        [PXUIField(DisplayName = "Col Span")]
        public virtual int? ColSpan { get; set; }
        public abstract class colSpan : PX.Data.BQL.BqlInt.Field<colSpan> { }
        #endregion

        #region Required
        [PXDBBool()]
        [PXUIField(DisplayName = "Required")]
        public virtual bool? Required { get; set; }
        public abstract class required : PX.Data.BQL.BqlBool.Field<required> { }
        #endregion

        #region Hidden
        [PXDBBool()]
        [PXUIField(DisplayName = "Hidden")]
        public virtual bool? Hidden { get; set; }
        public abstract class hidden : PX.Data.BQL.BqlBool.Field<hidden> { }
        #endregion

        #region Size
        [PXDBString(3, InputMask = "")]
        [PXUIField(DisplayName = "Size")]
        public virtual string Size { get; set; }
        public abstract class size : PX.Data.BQL.BqlString.Field<size> { }
        #endregion

        #region LabelSize
        [PXDBString(3, InputMask = "")]
        [PXUIField(DisplayName = "Label Size")]
        public virtual string LabelSize { get; set; }
        public abstract class labelSize : PX.Data.BQL.BqlString.Field<labelSize> { }
        #endregion

        #region CreatedByID
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
        #endregion

        #region CreatedByScreenID
        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
        #endregion

        #region LastModifiedByID
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
        #endregion

        #region LastModifiedByScreenID
        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
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
            var giFilter = (GIFilter)tableRow;

            if (key != null)
            {
                designID = (Guid)(key.DesignID);
                lineNbr = (int)(key.LineNbr);
            }

            return (designID.HasValue && giFilter.DesignID == designID.Value
                && lineNbr.HasValue && giFilter.LineNbr == lineNbr.Value);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<GIFilterVersion,
                Where<GIFilterVersion.changeObjectID, Equal<Required<GIFilterVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<GIFilterVersion>().ToList<object>();
        }
    }
}