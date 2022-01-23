using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// GIResult table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("GISort")]
    public class GISort : IBqlTable, ITrackedObject
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

        #region DataFieldName
        [PXDBString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Data Field Name")]
        public virtual string DataFieldName { get; set; }
        public abstract class dataFieldName : PX.Data.BQL.BqlString.Field<dataFieldName> { }
        #endregion

        #region SortOrder
        [PXDBString(1, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Sort Order")]
        public virtual string SortOrder { get; set; }
        public abstract class sortOrder : PX.Data.BQL.BqlString.Field<sortOrder> { }
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
            var giSort = (GISort)tableRow;

            if (key != null)
            {
                designID = (Guid)(key.DesignID);
                lineNbr = (int)(key.LineNbr);
            }

            return (designID.HasValue && giSort.DesignID == designID.Value
                && lineNbr.HasValue && giSort.LineNbr == lineNbr.Value);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<GISortVersion,
                Where<GISortVersion.changeObjectID, Equal<Required<GISortVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<GISortVersion>().ToList<object>();
        }
    }
}