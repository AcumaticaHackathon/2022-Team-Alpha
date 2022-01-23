using System;
using System.Collections.Generic;
using System.Linq;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    [Serializable]
    [PXCacheName("BPEventSubscriber")]
    public class BPEventSubscriber : IBqlTable, ITrackedObject
    {
        #region EventID
        [PXDBGuid(IsKey = true)]
        [PXUIField(DisplayName = "Event ID")]
        public virtual Guid? EventID { get; set; }
        public abstract class eventID : PX.Data.BQL.BqlGuid.Field<eventID> { }
        #endregion

        #region HandlerID
        [PXDBGuid(IsKey = true)]
        [PXUIField(DisplayName = "Handler ID")]
        public virtual Guid? HandlerID { get; set; }
        public abstract class handlerID : PX.Data.BQL.BqlGuid.Field<handlerID> { }
        #endregion

        #region Active
        [PXDBBool()]
        [PXUIField(DisplayName = "Active")]
        public virtual bool? Active { get; set; }
        public abstract class active : PX.Data.BQL.BqlBool.Field<active> { }
        #endregion

        #region OrderNbr
        [PXDBShort()]
        [PXUIField(DisplayName = "Order Nbr")]
        public virtual short? OrderNbr { get; set; }
        public abstract class orderNbr : PX.Data.BQL.BqlShort.Field<orderNbr> { }
        #endregion

        #region Type
        [PXDBString(4, IsFixed = true, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Type")]
        public virtual string Type { get; set; }
        public abstract class type : PX.Data.BQL.BqlString.Field<type> { }
        #endregion

        #region StopOnError
        [PXDBBool()]
        [PXUIField(DisplayName = "Stop On Error")]
        public virtual bool? StopOnError { get; set; }
        public abstract class stopOnError : PX.Data.BQL.BqlBool.Field<stopOnError> { }
        #endregion

        #region IsProcessSingleLine
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Process Single Line")]
        public virtual bool? IsProcessSingleLine { get; set; }
        public abstract class isProcessSingleLine : PX.Data.BQL.BqlBool.Field<isProcessSingleLine> { }
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
            Guid? handlerID = null;
            var bpEventSubscriber = (BPEventSubscriber)tableRow;

            if (key != null)
            {
                eventID = (Guid)key.EventID;
                handlerID = (Guid)key.HandlerID;
            }

            return (eventID != null && bpEventSubscriber.EventID == eventID
                && handlerID != null && bpEventSubscriber.HandlerID == handlerID);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<BusinessEventSubscriberVersion,
                Where<AKChangeObjectVersion.changeObjectID, Equal<Required<AKChangeObjectVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<BusinessEventSubscriberVersion>().ToList<object>();
        }
    }
}