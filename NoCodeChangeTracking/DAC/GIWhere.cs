using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Data;
using PX.Data.BQL;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// GIWhere table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("GIWhere")]
    public class GIWhere : IBqlTable, ITrackedObject
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

        #region OpenBrackets
        [PXDBString(9, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Open Brackets")]
        public virtual string OpenBrackets { get; set; }
        public abstract class openBrackets : PX.Data.BQL.BqlString.Field<openBrackets> { }
        #endregion

        #region DataFieldName
        [PXDBString(512, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Data Field Name")]
        public virtual string DataFieldName { get; set; }
        public abstract class dataFieldName : PX.Data.BQL.BqlString.Field<dataFieldName> { }
        #endregion

        #region Condition
        [PXDBString(2, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Condition")]
        public virtual string Condition { get; set; }
        public abstract class condition : PX.Data.BQL.BqlString.Field<condition> { }
        #endregion

        #region IsExpression
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Expression")]
        public virtual bool? IsExpression { get; set; }
        public abstract class isExpression : PX.Data.BQL.BqlBool.Field<isExpression> { }
        #endregion

        #region Value1
        [PXDBString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Value1")]
        public virtual string Value1 { get; set; }
        public abstract class value1 : PX.Data.BQL.BqlString.Field<value1> { }
        #endregion

        #region Value2
        [PXDBString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Value2")]
        public virtual string Value2 { get; set; }
        public abstract class value2 : PX.Data.BQL.BqlString.Field<value2> { }
        #endregion

        #region CloseBrackets
        [PXDBString(9, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Close Brackets")]
        public virtual string CloseBrackets { get; set; }
        public abstract class closeBrackets : PX.Data.BQL.BqlString.Field<closeBrackets> { }
        #endregion

        #region Operation
        [PXDBString(1, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Operation")]
        public virtual string Operation { get; set; }
        public abstract class operation : PX.Data.BQL.BqlString.Field<operation> { }
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
            var giWhere = (GIWhere)tableRow;

            if (key != null)
            {
                designID = (Guid)(key.DesignID);
                lineNbr = (int)(key.LineNbr);
            }

            return (designID.HasValue && giWhere.DesignID == designID.Value
                && lineNbr.HasValue && giWhere.LineNbr == lineNbr.Value);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<GIWhereVersion,
                Where<GIWhereVersion.changeObjectID, Equal<Required<GIWhereVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<GIWhereVersion>().ToList<object>();
        }
    }
}