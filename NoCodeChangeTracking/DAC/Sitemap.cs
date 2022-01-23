using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Data;
using PX.Data.BQL;

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