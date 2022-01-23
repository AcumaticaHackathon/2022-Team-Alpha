using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Data;

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