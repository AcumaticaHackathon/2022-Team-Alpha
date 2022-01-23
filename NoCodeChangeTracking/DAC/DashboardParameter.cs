using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Data;
using PX.Data.BQL;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// DashboardParameter table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("DashboardParameter")]
    public class DashboardParameter : IBqlTable, ITrackedObject
    {
        #region DashboardID
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Dashboard ID")]
        public virtual int? DashboardID { get; set; }
        public abstract class dashboardID : PX.Data.BQL.BqlInt.Field<dashboardID> { }
        #endregion

        #region LineNbr
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Line Nbr")]
        public virtual int? LineNbr { get; set; }
        public abstract class lineNbr : PX.Data.BQL.BqlInt.Field<lineNbr> { }
        #endregion

        #region Name
        [PXDBString(256, IsKey = true, InputMask = "")]
        [PXUIField(DisplayName = "Name")]
        public virtual string Name { get; set; }
        public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
        #endregion

        #region IsActive
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Active")]
        public virtual bool? IsActive { get; set; }
        public abstract class isActive : PX.Data.BQL.BqlBool.Field<isActive> { }
        #endregion

        #region Required
        [PXDBBool()]
        [PXUIField(DisplayName = "Required")]
        public virtual bool? Required { get; set; }
        public abstract class required : PX.Data.BQL.BqlBool.Field<required> { }
        #endregion

        #region ObjectName
        [PXDBString(512, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Object Name")]
        public virtual string ObjectName { get; set; }
        public abstract class objectName : PX.Data.BQL.BqlString.Field<objectName> { }
        #endregion

        #region FieldName
        [PXDBString(512, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Field Name")]
        public virtual string FieldName { get; set; }
        public abstract class fieldName : PX.Data.BQL.BqlString.Field<fieldName> { }
        #endregion

        #region DisplayName
        [PXDBString(512, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Display Name")]
        public virtual string DisplayName { get; set; }
        public abstract class displayName : PX.Data.BQL.BqlString.Field<displayName> { }
        #endregion

        #region IsExpression
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Expression")]
        public virtual bool? IsExpression { get; set; }
        public abstract class isExpression : PX.Data.BQL.BqlBool.Field<isExpression> { }
        #endregion

        #region DefaultValue
        [PXDBString(512, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Default Value")]
        public virtual string DefaultValue { get; set; }
        public abstract class defaultValue : PX.Data.BQL.BqlString.Field<defaultValue> { }
        #endregion

        #region Size
        [PXDBString(3, InputMask = "")]
        [PXUIField(DisplayName = "Size")]
        public virtual string Size { get; set; }
        public abstract class size : PX.Data.BQL.BqlString.Field<size> { }
        #endregion

        #region LabelSize
        [PXDBString(3, InputMask = "")]
        [PXUIField(DisplayName = "Label Size")]
        public virtual string LabelSize { get; set; }
        public abstract class labelSize : PX.Data.BQL.BqlString.Field<labelSize> { }
        #endregion

        #region ColSpan
        [PXDBInt()]
        [PXUIField(DisplayName = "Col Span")]
        public virtual int? ColSpan { get; set; }
        public abstract class colSpan : PX.Data.BQL.BqlInt.Field<colSpan> { }
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

        #region ITrackedObject

        /// <summary>
        /// Whether a dynamic object key matches a table row object
        /// </summary>
        /// <param name="key">dynamic object holding key fields</param>
        /// <param name="tableRow">table row object</param>
        /// <returns>whether the key matches</returns>
        public bool IsKeyMatch(dynamic key, object tableRow)
        {
            int? dashboardID = null;
            int? lineNbr = null;
            var dashboardParameter = (DashboardParameter)tableRow;

            if (key != null)
            {
                dashboardID = Convert.ToInt32(key.DashboardID);
                lineNbr = Convert.ToInt32(key.LineNbr);
            }

            return (dashboardID.HasValue && dashboardParameter.DashboardID == dashboardID.Value
                && lineNbr.HasValue && dashboardParameter.LineNbr == lineNbr.Value);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<DashboardParameterVersion,
                Where<DashboardParameterVersion.changeObjectID, Equal<Required<DashboardParameterVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<DashboardParameterVersion>().ToList<object>();
        }

        #endregion
    }
}