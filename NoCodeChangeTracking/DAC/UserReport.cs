using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Data;
using Newtonsoft.Json;
using PX.Data.BQL;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// UserReport table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("UserReport")]
    public class UserReport : IBqlTable, ITrackedObject
    {
        #region ReportFileName
        [PXDBString(50, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Report File Name")]
        public virtual string ReportFileName { get; set; }
        public abstract class reportFileName : PX.Data.BQL.BqlString.Field<reportFileName> { }
        #endregion

        #region Version
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Report Version")]
        public virtual int? Version { get; set; }
        public abstract class version : PX.Data.BQL.BqlInt.Field<version> { }
        #endregion

        #region Description
        [PXDBString(50, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Description")]
        public virtual string Description { get; set; }
        public abstract class description : PX.Data.BQL.BqlString.Field<description> { }
        #endregion

        #region DateCreated
        [PXDBDate()]
        [PXUIField(DisplayName = "Date Created")]
        public virtual DateTime? DateCreated { get; set; }
        public abstract class dateCreated : PX.Data.BQL.BqlDateTime.Field<dateCreated> { }
        #endregion

        #region IsActive
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Active")]
        public virtual bool? IsActive { get; set; }
        public abstract class isActive : PX.Data.BQL.BqlBool.Field<isActive> { }
        #endregion

        #region Xml
        [PXDBString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Xml")]
        public virtual string Xml { get; set; }
        public abstract class xml : PX.Data.BQL.BqlString.Field<xml> { }
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
            string reportFileName = null;
            int? version = null;
            var report = (UserReport)tableRow;

            if (key != null)
            {
                reportFileName = Convert.ToString(key.ReportFileName);
                version = Convert.ToInt32(key.Version);
            }

            return (reportFileName != null && report.ReportFileName == reportFileName &&
                version.HasValue && report.Version == version.Value);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<ReportVersion,
                Where<AKChangeObjectVersion.changeObjectID, Equal<Required<AKChangeObjectVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<ReportVersion>().ToList<object>();
        }
    }
}