using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// Sitemap table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("Sitemap")]
    public class Sitemap : IBqlTable, ITrackedObject
    {
        #region Title
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Title")]
        public virtual string Title { get; set; }
        public abstract class title : PX.Data.BQL.BqlString.Field<title> { }
        #endregion

        #region Description
        [PXDBString(512, InputMask = "")]
        [PXUIField(DisplayName = "Description")]
        public virtual string Description { get; set; }
        public abstract class description : PX.Data.BQL.BqlString.Field<description> { }
        #endregion

        #region Url
        [PXDBString(512, InputMask = "")]
        [PXUIField(DisplayName = "Url")]
        public virtual string Url { get; set; }
        public abstract class url : PX.Data.BQL.BqlString.Field<url> { }
        #endregion

        #region ScreenID
        [PXDBString(8, InputMask = "")]
        [PXUIField(DisplayName = "Screen ID")]
        public virtual string ScreenID { get; set; }
        public abstract class screenID : PX.Data.BQL.BqlString.Field<screenID> { }
        #endregion

        #region Nodeid
        [PXDBGuid(IsKey = true)]
        [PXUIField(DisplayName = "Nodeid")]
        public virtual Guid? Nodeid { get; set; }
        public abstract class nodeid : PX.Data.BQL.BqlGuid.Field<nodeid> { }
        #endregion

        #region ParentID
        [PXDBGuid()]
        [PXUIField(DisplayName = "Parent ID")]
        public virtual Guid? ParentID { get; set; }
        public abstract class parentID : PX.Data.BQL.BqlGuid.Field<parentID> { }
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

        #region RecordSourceID
        [PXDBShort()]
        [PXUIField(DisplayName = "Record Source ID")]
        public virtual short? RecordSourceID { get; set; }
        public abstract class recordSourceID : PX.Data.BQL.BqlShort.Field<recordSourceID> { }
        #endregion

        /// <summary>
        /// Whether a dynamic object key matches a table row object
        /// </summary>
        /// <param name="key">dynamic object holding key fields</param>
        /// <param name="tableRow">table row object</param>
        /// <returns>whether the key matches</returns>
        public bool IsKeyMatch(dynamic key, object tableRow)
        {
            Guid? nodeID = null;
            var sitemap = (Sitemap)tableRow;

            if (key != null)
            {
                nodeID = (Guid)key.NodeID;
            }

            return (nodeID.HasValue && sitemap.Nodeid == nodeID.Value);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<SitemapVersion,
                Where<SitemapVersion.changeObjectID, Equal<Required<SitemapVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<SitemapVersion>().ToList<object>();
        }
    }
}