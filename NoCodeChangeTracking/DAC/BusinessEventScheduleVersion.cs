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
    /// Business Event Schedule change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("BusinessEventScheduleVersion")]
    public class BusinessEventScheduleVersion : AKChangeObjectVersion
    {
        #region ScheduleID
        [PXInt]
        [PXUIField(DisplayName = "Schedule ID")]
        public virtual int? ScheduleID { get; set; }
        public abstract class scheduleID : PX.Data.BQL.BqlInt.Field<scheduleID> { }
        #endregion

        /// <summary>
        /// Set the changed values of an object
        /// </summary>
        /// <param name="change">dynamic change object</param>
        public override void SetChangedValues(dynamic change)
        {
            this.ScheduleID = change.ScheduleID;
        }
    }
}
