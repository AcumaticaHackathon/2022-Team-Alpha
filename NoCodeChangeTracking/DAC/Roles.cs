using System;
using System.Collections.Generic;
using System.Linq;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// Roles table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("Roles")]
    public class Roles : IBqlTable, ITrackedObject
    {
        #region Rolename
        [PXDBString(64, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Rolename")]
        public virtual string Rolename { get; set; }
        public abstract class rolename : PX.Data.BQL.BqlString.Field<rolename> { }
        #endregion

        #region ApplicationName
        [PXDBString(32, IsKey = true, InputMask = "")]
        [PXUIField(DisplayName = "Application Name")]
        public virtual string ApplicationName { get; set; }
        public abstract class applicationName : PX.Data.BQL.BqlString.Field<applicationName> { }
        #endregion

        #region Descr
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Descr")]
        public virtual string Descr { get; set; }
        public abstract class descr : PX.Data.BQL.BqlString.Field<descr> { }
        #endregion

        #region Guest
        [PXDBBool()]
        [PXUIField(DisplayName = "Guest")]
        public virtual bool? Guest { get; set; }
        public abstract class guest : PX.Data.BQL.BqlBool.Field<guest> { }
        #endregion

        #region CreatedByID
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
        #endregion

        #region CreatedByScreenID
        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
        #endregion

        #region LastModifiedByID
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
        #endregion

        #region LastModifiedByScreenID
        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
        #endregion

        /// <summary>
        /// Whether a dynamic object key matches a table row object
        /// </summary>
        /// <param name="key">dynamic object holding key fields</param>
        /// <param name="tableRow">table row object</param>
        /// <returns>whether the key matches</returns>
        public bool IsKeyMatch(dynamic key, object tableRow)
        {
            string roleName = null;
            string applicationName = null;
            var role = (Roles)tableRow;

            if (key != null)
            {
                roleName = Convert.ToString(key.RoleName);
                applicationName = Convert.ToString(key.ApplicationName);
            }

            return ((!string.IsNullOrEmpty(roleName)) && role.Rolename == roleName
                && (!string.IsNullOrEmpty(applicationName)) && role.ApplicationName == applicationName);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<RoleVersion,
                Where<RoleVersion.changeObjectID, Equal<Required<RoleVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<RoleVersion>().ToList<object>();
        }
    }
}