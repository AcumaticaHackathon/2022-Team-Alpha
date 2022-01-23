using System;
using System.Collections.Generic;
using System.Linq;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    [Serializable]
    [PXCacheName("BPEventTriggerCondition")]
    public class BPEventTriggerCondition : IBqlTable, ITrackedObject
    {
        #region EventID
        [PXDBGuid(IsKey = true)]
        [PXUIField(DisplayName = "Event ID")]
        public virtual Guid? EventID { get; set; }
        public abstract class eventID : PX.Data.BQL.BqlGuid.Field<eventID> { }
        #endregion

        #region OrderNbr
        [PXDBShort(IsKey = true)]
        [PXUIField(DisplayName = "Order Nbr")]
        public virtual short? OrderNbr { get; set; }
        public abstract class orderNbr : PX.Data.BQL.BqlShort.Field<orderNbr> { }
        #endregion

        #region TableName
        [PXDBString(256, InputMask = "")]
        [PXUIField(DisplayName = "Table Name")]
        public virtual string TableName { get; set; }
        public abstract class tableName : PX.Data.BQL.BqlString.Field<tableName> { }
        #endregion

        #region Active
        [PXDBBool()]
        [PXUIField(DisplayName = "Active")]
        public virtual bool? Active { get; set; }
        public abstract class active : PX.Data.BQL.BqlBool.Field<active> { }
        #endregion

        #region OpenBrackets
        [PXDBInt()]
        [PXUIField(DisplayName = "Open Brackets")]
        public virtual int? OpenBrackets { get; set; }
        public abstract class openBrackets : PX.Data.BQL.BqlInt.Field<openBrackets> { }
        #endregion

        #region FieldName
        [PXDBString(256, InputMask = "")]
        [PXUIField(DisplayName = "Field Name")]
        public virtual string FieldName { get; set; }
        public abstract class fieldName : PX.Data.BQL.BqlString.Field<fieldName> { }
        #endregion

        #region Value
        [PXDBString(256, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Value")]
        public virtual string Value { get; set; }
        public abstract class value : PX.Data.BQL.BqlString.Field<value> { }
        #endregion

        #region Value2
        [PXDBString(256, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Value2")]
        public virtual string Value2 { get; set; }
        public abstract class value2 : PX.Data.BQL.BqlString.Field<value2> { }
        #endregion

        #region CloseBrackets
        [PXDBInt()]
        [PXUIField(DisplayName = "Close Brackets")]
        public virtual int? CloseBrackets { get; set; }
        public abstract class closeBrackets : PX.Data.BQL.BqlInt.Field<closeBrackets> { }
        #endregion

        #region Operator
        [PXDBInt()]
        [PXUIField(DisplayName = "Operator")]
        public virtual int? Operator { get; set; }
        public abstract class @operator : PX.Data.BQL.BqlInt.Field<@operator> { }
        #endregion

        #region DataType
        [PXDBInt()]
        [PXUIField(DisplayName = "Data Type")]
        public virtual int? DataType { get; set; }
        public abstract class dataType : PX.Data.BQL.BqlInt.Field<dataType> { }
        #endregion

        /// <summary>
        /// Whether a dynamic object key matches a table row object
        /// </summary>
        /// <param name="key">dynamic object holding key fields</param>
        /// <param name="tableRow">table row object</param>
        /// <returns>whether the key matches</returns>
        public bool IsKeyMatch(dynamic key, object tableRow)
        {
            Guid? eventID = null;
            short? orderNbr = null;

            var bpEventTriggerCondition = (BPEventTriggerCondition)tableRow;

            if (key != null)
            {
                eventID = (Guid)key.EventID;
                orderNbr = (short)key.OrderNbr;
            }

            return (eventID != null && bpEventTriggerCondition.EventID == eventID
                && orderNbr != null && bpEventTriggerCondition.OrderNbr == orderNbr);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<BusinessEventTriggerConditionVersion,
                Where<AKChangeObjectVersion.changeObjectID, Equal<Required<AKChangeObjectVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<BusinessEventTriggerConditionVersion>().ToList<object>();
        }
    }
}