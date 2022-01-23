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
    /// Business Event Subscriber change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("BusinessEventSubscriberVersion")]
    public class BusinessEventSubscriberVersion : AKChangeObjectVersion
    {
        #region HandlerID
        [PXGuid]
        [PXUIField(DisplayName = "Handler ID")]
        public virtual Guid? HandlerID { get; set; }
        public abstract class handlerID : PX.Data.BQL.BqlGuid.Field<handlerID> { }
        #endregion

        #region OrderNbr
        [PXShort()]
        [PXUIField(DisplayName = "Order Nbr")]
        public virtual short? OrderNbr { get; set; }
        public abstract class orderNbr : PX.Data.BQL.BqlShort.Field<orderNbr> { }
        #endregion

        /// <summary>
        /// Set the changed values of an object
        /// </summary>
        /// <param name="change">dynamic change object</param>
        public override void SetChangedValues(dynamic change)
        {
            this.HandlerID = change.HandlerID;
            this.OrderNbr = change.OrderNbr;
        }
    }
}
