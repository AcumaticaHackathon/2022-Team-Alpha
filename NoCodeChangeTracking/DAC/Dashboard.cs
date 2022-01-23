using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Data;
using PX.Data.BQL;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// Dashboard table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("Dashboard")]
    public class Dashboard : IBqlTable, ITrackedObject
    {
        #region DashboardID
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Dashboard ID")]
        public virtual int? DashboardID { get; set; }
        public abstract class dashboardID : PX.Data.BQL.BqlInt.Field<dashboardID> { }
        #endregion

        #region CompanyDashboardID
        [PXDBIdentity]
        public virtual int? CompanyDashboardID { get; set; }
        public abstract class companyDashboardID : PX.Data.BQL.BqlInt.Field<companyDashboardID> { }
        #endregion

        #region Name
        [PXDBString(255, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Name")]
        public virtual string Name { get; set; }
        public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
        #endregion

        #region DefaultOwnerRole
        [PXDBString(64, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Default Owner Role")]
        public virtual string DefaultOwnerRole { get; set; }
        public abstract class defaultOwnerRole : PX.Data.BQL.BqlString.Field<defaultOwnerRole> { }
        #endregion

        #region ScreenID
        [PXDBString(8, InputMask = "")]
        [PXUIField(DisplayName = "Screen ID")]
        public virtual string ScreenID { get; set; }
        public abstract class screenID : PX.Data.BQL.BqlString.Field<screenID> { }
        #endregion

        #region AllowCopy
        [PXDBBool()]
        [PXUIField(DisplayName = "Allow Copy")]
        public virtual bool? AllowCopy { get; set; }
        public abstract class allowCopy : PX.Data.BQL.BqlBool.Field<allowCopy> { }
        #endregion

        #region Workspace1Size
        [PXDBInt()]
        [PXUIField(DisplayName = "Workspace1 Size")]
        public virtual int? Workspace1Size { get; set; }
        public abstract class workspace1Size : PX.Data.BQL.BqlInt.Field<workspace1Size> { }
        #endregion

        #region Workspace2Size
        [PXDBInt()]
        [PXUIField(DisplayName = "Workspace2 Size")]
        public virtual int? Workspace2Size { get; set; }
        public abstract class workspace2Size : PX.Data.BQL.BqlInt.Field<workspace2Size> { }
        #endregion

        #region IsPortal
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Portal")]
        public virtual bool? IsPortal { get; set; }
        public abstract class isPortal : PX.Data.BQL.BqlBool.Field<isPortal> { }
        #endregion

        #region ExposeViaMobile
        [PXDBBool()]
        [PXUIField(DisplayName = "Expose Via Mobile")]
        public virtual bool? ExposeViaMobile { get; set; }
        public abstract class exposeViaMobile : PX.Data.BQL.BqlBool.Field<exposeViaMobile> { }
        #endregion

        #region Noteid
        [PXNote()]
        public virtual Guid? Noteid { get; set; }
        public abstract class noteid : PX.Data.BQL.BqlGuid.Field<noteid> { }
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
            int? dashboardID = null;
            var dashboard = (Dashboard)tableRow;

            if (key != null)
            {
                dashboardID = Convert.ToInt32(key.DashboardID);
            }

            return (dashboardID.HasValue && dashboard.DashboardID == dashboardID.Value);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<DashboardVersion,
                Where<DashboardVersion.changeObjectID, Equal<Required<DashboardVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<DashboardVersion>().ToList<object>();
        }
    }
}