using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Data;
using PX.Data.BQL;

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