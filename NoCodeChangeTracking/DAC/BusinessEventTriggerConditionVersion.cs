using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// Business Event Trigger Condition change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("BusinessEventTriggerConditionVersion")]
    public class BusinessEventTriggerConditionVersion : AKChangeObjectVersion
    {
        #region OrderNbr
        [PXShort]
        [PXUIField(DisplayName = "Order Nbr")]
        public virtual short? OrderNbr { get; set; }
        public abstract class orderNbr : PX.Data.BQL.BqlShort.Field<orderNbr> { }
        #endregion

        #region TableName
        [PXString(256, InputMask = "")]
        [PXUIField(DisplayName = "Table Name")]
        public virtual string TableName { get; set; }
        public abstract class tableName : PX.Data.BQL.BqlString.Field<tableName> { }
        #endregion

        #region FieldName
        [PXString(256, InputMask = "")]
        [PXUIField(DisplayName = "Field Name")]
        public virtual string FieldName { get; set; }
        public abstract class fieldName : PX.Data.BQL.BqlString.Field<fieldName> { }
        #endregion

        /// <summary>
        /// Set the changed values of an object
        /// </summary>
        /// <param name="change">dynamic change object</param>
        public override void SetChangedValues(dynamic change)
        {
            this.OrderNbr = change.OrderNbr;
            this.TableName = change.TableName;
            this.FieldName = change.FieldName;
        }
    }
}
