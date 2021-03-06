using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Data;
using PX.Data.BQL;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// GIOn table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("GIOn")]
    public class GIOn : IBqlTable, ITrackedObject
    {
        #region DesignID
        [PXDBGuid(IsKey = true)]
        [PXUIField(DisplayName = "Design ID")]
        public virtual Guid? DesignID { get; set; }
        public abstract class designID : PX.Data.BQL.BqlGuid.Field<designID> { }
        #endregion

        #region RelationNbr
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Relation Nbr")]
        public virtual int? RelationNbr { get; set; }
        public abstract class relationNbr : PX.Data.BQL.BqlInt.Field<relationNbr> { }
        #endregion

        #region LineNbr
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Line Nbr")]
        public virtual int? LineNbr { get; set; }
        public abstract class lineNbr : PX.Data.BQL.BqlInt.Field<lineNbr> { }
        #endregion

        #region OpenBrackets
        [PXDBString(9, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Open Brackets")]
        public virtual string OpenBrackets { get; set; }
        public abstract class openBrackets : PX.Data.BQL.BqlString.Field<openBrackets> { }
        #endregion

        #region ParentField
        [PXDBString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Parent Field")]
        public virtual string ParentField { get; set; }
        public abstract class parentField : PX.Data.BQL.BqlString.Field<parentField> { }
        #endregion

        #region Condition
        [PXDBString(2, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Condition")]
        public virtual string Condition { get; set; }
        public abstract class condition : PX.Data.BQL.BqlString.Field<condition> { }
        #endregion

        #region ChildField
        [PXDBString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Child Field")]
        public virtual string ChildField { get; set; }
        public abstract class childField : PX.Data.BQL.BqlString.Field<childField> { }
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
            int? relationNbr = null;
            int? lineNbr = null;
            var giOn = (GIOn)tableRow;

            if (key != null)
            {
                designID = (Guid)(key.DesignID);
                relationNbr = (int)(key.RelationNbr);
                lineNbr = (int)(key.LineNbr);
            }

            return (designID.HasValue && giOn.DesignID == designID.Value
                && relationNbr.HasValue && giOn.RelationNbr == relationNbr.Value
                && lineNbr.HasValue && giOn.LineNbr == lineNbr.Value);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<GIOnVersion,
                Where<GIOnVersion.changeObjectID, Equal<Required<GIOnVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<GIOnVersion>().ToList<object>();
        }
    }
}