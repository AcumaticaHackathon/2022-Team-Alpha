using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// GITable table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("GITable")]
    public class GITable : IBqlTable, ITrackedObject
    {
        #region DesignID
        [PXDBGuid(IsKey = true)]
        [PXUIField(DisplayName = "Design ID")]
        public virtual Guid? DesignID { get; set; }
        public abstract class designID : PX.Data.BQL.BqlGuid.Field<designID> { }
        #endregion

        #region Alias
        [PXDBString(255, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Alias")]
        public virtual string Alias { get; set; }
        public abstract class alias : PX.Data.BQL.BqlString.Field<alias> { }
        #endregion

        #region Name
        [PXDBString(255, InputMask = "")]
        [PXUIField(DisplayName = "Name")]
        public virtual string Name { get; set; }
        public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
        #endregion

        #region Number
        [PXDBInt()]
        [PXUIField(DisplayName = "Number")]
        public virtual int? Number { get; set; }
        public abstract class number : PX.Data.BQL.BqlInt.Field<number> { }
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
            string alias = null;
            var giTable = (GITable)tableRow;

            if (key != null)
            {
                designID = (Guid)(key.DesignID);
                alias = Convert.ToString(key.Alias);
            }

            return (designID.HasValue && giTable.DesignID == designID.Value
                && (!string.IsNullOrEmpty(alias)) && giTable.Alias == alias);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<GITableVersion,
                Where<GITableVersion.changeObjectID, Equal<Required<GITableVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<GITableVersion>().ToList<object>();
        }
    }
}