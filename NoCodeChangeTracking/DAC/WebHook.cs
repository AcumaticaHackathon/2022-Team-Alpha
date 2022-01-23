using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    [Serializable]
    [PXCacheName("WebHook")]
    public class WebHook : IBqlTable, ITrackedObject
    {
        #region WebHookID
        [PXDBGuid(IsKey = true)]
        [PXUIField(DisplayName = "Web Hook ID")]
        public virtual Guid? WebHookID { get; set; }
        public abstract class webHookID : PX.Data.BQL.BqlGuid.Field<webHookID> { }
        #endregion

        #region Name
        [PXDBString(128, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Name")]
        public virtual string Name { get; set; }
        public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
        #endregion

        #region Handler
        [PXDBString(128, InputMask = "")]
        [PXUIField(DisplayName = "Handler")]
        public virtual string Handler { get; set; }
        public abstract class handler : PX.Data.BQL.BqlString.Field<handler> { }
        #endregion

        #region IsActive
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Active")]
        public virtual bool? IsActive { get; set; }
        public abstract class isActive : PX.Data.BQL.BqlBool.Field<isActive> { }
        #endregion

        #region IsSystem
        [PXDBBool()]
        [PXUIField(DisplayName = "Is System")]
        public virtual bool? IsSystem { get; set; }
        public abstract class isSystem : PX.Data.BQL.BqlBool.Field<isSystem> { }
        #endregion

        #region RequestRetainCount
        [PXDBShort()]
        [PXUIField(DisplayName = "Request Retain Count")]
        public virtual short? RequestRetainCount { get; set; }
        public abstract class requestRetainCount : PX.Data.BQL.BqlShort.Field<requestRetainCount> { }
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

        #region Tstamp
        [PXDBTimestamp()]
        [PXUIField(DisplayName = "Tstamp")]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
        #endregion

        #region Noteid
        [PXNote()]
        public virtual Guid? Noteid { get; set; }
        public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }
        #endregion

        #region ITrackedObject

        /// <summary>
        /// Whether a dynamic object key matches a table row object
        /// </summary>
        /// <param name="key">dynamic object holding key fields</param>
        /// <param name="tableRow">table row object</param>
        /// <returns>whether the key matches</returns>
        public bool IsKeyMatch(dynamic key, object tableRow)
        {
            Guid? webHookID = null;
            var webHook = (WebHook)tableRow;

            if (key != null)
            {
                webHookID = Convert.ToInt32(key.WebHookID);
            }

            return (webHookID.HasValue && webHook.WebHookID == webHookID.Value);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<WebHookVersion,
                Where<WebHookVersion.changeObjectID, Equal<Required<WebHookVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<WebHookVersion>().ToList<object>();
        }

        #endregion
    }
}