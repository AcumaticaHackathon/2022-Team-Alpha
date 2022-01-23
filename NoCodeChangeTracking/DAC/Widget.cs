using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// Widget table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("Widget")]
    public class Widget : IBqlTable, ITrackedObject
    {
        #region DashboardID
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Dashboard ID")]
        public virtual int? DashboardID { get; set; }
        public abstract class dashboardID : PX.Data.BQL.BqlInt.Field<dashboardID> { }
        #endregion

        #region WidgetID
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Widget ID")]
        public virtual int? WidgetID { get; set; }
        public abstract class widgetID : PX.Data.BQL.BqlInt.Field<widgetID> { }
        #endregion

        #region CompanyWidgetID
        [PXDBIdentity]
        public virtual int? CompanyWidgetID { get; set; }
        public abstract class companyWidgetID : PX.Data.BQL.BqlInt.Field<companyWidgetID> { }
        #endregion

        #region OwnerName
        [PXDBString(64, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Owner Name")]
        public virtual string OwnerName { get; set; }
        public abstract class ownerName : PX.Data.BQL.BqlString.Field<ownerName> { }
        #endregion

        #region Caption
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Caption")]
        public virtual string Caption { get; set; }
        public abstract class caption : PX.Data.BQL.BqlString.Field<caption> { }
        #endregion

        #region Column
        [PXDBInt()]
        [PXUIField(DisplayName = "Column")]
        public virtual int? Column { get; set; }
        public abstract class column : PX.Data.BQL.BqlInt.Field<column> { }
        #endregion

        #region Row
        [PXDBInt()]
        [PXUIField(DisplayName = "Row")]
        public virtual int? Row { get; set; }
        public abstract class row : PX.Data.BQL.BqlInt.Field<row> { }
        #endregion

        #region Workspace
        [PXDBInt()]
        [PXUIField(DisplayName = "Workspace")]
        public virtual int? Workspace { get; set; }
        public abstract class workspace : PX.Data.BQL.BqlInt.Field<workspace> { }
        #endregion

        #region Width
        [PXDBInt()]
        [PXUIField(DisplayName = "Width")]
        public virtual int? Width { get; set; }
        public abstract class width : PX.Data.BQL.BqlInt.Field<width> { }
        #endregion

        #region Height
        [PXDBInt()]
        [PXUIField(DisplayName = "Height")]
        public virtual int? Height { get; set; }
        public abstract class height : PX.Data.BQL.BqlInt.Field<height> { }
        #endregion

        #region Type
        [PXDBString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Type")]
        public virtual string Type { get; set; }
        public abstract class type : PX.Data.BQL.BqlString.Field<type> { }
        #endregion

        #region Settings
        [PXDBString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Settings")]
        public virtual string Settings { get; set; }
        public abstract class settings : PX.Data.BQL.BqlString.Field<settings> { }
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
            int? dashboardID = null;
            int? widgetID = null;
            var widget = (Widget)tableRow;

            if (key != null)
            {
                dashboardID = Convert.ToString(key.DashboardID);
                widgetID = Convert.ToString(key.WidgetID);
            }

            return (dashboardID != null && widget.DashboardID == dashboardID
                && widgetID != null && widget.WidgetID == widgetID);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<WidgetVersion,
                Where<WidgetVersion.changeObjectID, Equal<Required<WidgetVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<WidgetVersion>().ToList<object>();
        }
    }
}