using System;
using System.Collections.Generic;
using System.Linq;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    [Serializable]
    [PXCacheName("BPInquiryParameter")]
    public class BPInquiryParameter : IBqlTable, ITrackedObject
    {
        #region EventID
        [PXDBGuid(IsKey = true)]
        [PXUIField(DisplayName = "Event ID")]
        public virtual Guid? EventID { get; set; }
        public abstract class eventID : PX.Data.BQL.BqlGuid.Field<eventID> { }
        #endregion

        #region Name
        [PXDBString(64, IsKey = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Name")]
        public virtual string Name { get; set; }
        public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
        #endregion

        #region FieldType
        [PXDBInt()]
        [PXUIField(DisplayName = "Field Type")]
        public virtual int? FieldType { get; set; }
        public abstract class fieldType : PX.Data.BQL.BqlInt.Field<fieldType> { }
        #endregion

        #region Value
        [PXDBString(256, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Value")]
        public virtual string Value { get; set; }
        public abstract class value : PX.Data.BQL.BqlString.Field<value> { }
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
            string name = null;

            var bpEventInquiryParameter = (BPInquiryParameter)tableRow;

            if (key != null)
            {
                eventID = (Guid)key.EventID;
                name = Convert.ToString(key.Name);
            }

            return (eventID != null && bpEventInquiryParameter.EventID == eventID
                && name != null && bpEventInquiryParameter.Name == name);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<BusinessEventInquiryParameterVersion,
                Where<AKChangeObjectVersion.changeObjectID, Equal<Required<AKChangeObjectVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<BusinessEventTriggerConditionVersion>().ToList<object>();
        }
    }
}