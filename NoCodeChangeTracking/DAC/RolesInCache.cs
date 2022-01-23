using System;
using System.Collections.Generic;
using System.Linq;
using PX.Data;
using PX.Data.BQL;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// RolesInCache table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("RolesInCache")]
    public class RolesInCache : IBqlTable, ITrackedObject
    {
        #region ScreenID
        [PXDBString(8, IsKey = true, InputMask = "")]
        [PXUIField(DisplayName = "Screen ID")]
        public virtual string ScreenID { get; set; }
        public abstract class screenID : PX.Data.BQL.BqlString.Field<screenID> { }
        #endregion

        #region Cachetype
        [PXDBString(255, IsKey = true, InputMask = "")]
        [PXUIField(DisplayName = "Cachetype")]
        public virtual string Cachetype { get; set; }
        public abstract class cachetype : PX.Data.BQL.BqlString.Field<cachetype> { }
        #endregion

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

        #region Accessrights
        [PXDBShort()]
        [PXUIField(DisplayName = "Accessrights")]
        public virtual short? Accessrights { get; set; }
        public abstract class accessrights : PX.Data.BQL.BqlShort.Field<accessrights> { }
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
            string screenID = null;
            string cacheType = null;
            var roleInCache = (RolesInCache)tableRow;

            if (key != null)
            {
                roleName = Convert.ToString(key.RoleName);
                applicationName = Convert.ToString(key.ApplicationName);
                screenID = Convert.ToString(key.ScreenID);
                cacheType = Convert.ToString(key.CacheType);
            }

            return ((!string.IsNullOrEmpty(roleName)) && roleInCache.Rolename == roleName
                && (!string.IsNullOrEmpty(applicationName)) && roleInCache.ApplicationName == applicationName
                && (!string.IsNullOrEmpty(screenID)) && roleInCache.ScreenID == screenID
                && (!string.IsNullOrEmpty(cacheType)) && roleInCache.Cachetype == cacheType);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<RoleInCacheVersion,
                Where<RoleInCacheVersion.changeObjectID, Equal<Required<RoleInCacheVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<RoleInCacheVersion>().ToList<object>();
        }
    }
}