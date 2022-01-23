using System;
using System.Collections.Generic;
using System.Linq;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// BPEventSchedule table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("BPEventSchedule")]
    public class BPEventSchedule : IBqlTable, ITrackedObject
    {
        #region EventID
        [PXDBGuid(IsKey = true)]
        [PXUIField(DisplayName = "Event ID")]
        public virtual Guid? EventID { get; set; }
        public abstract class eventID : PX.Data.BQL.BqlGuid.Field<eventID> { }
        #endregion

        #region ScheduleID
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Schedule ID")]
        public virtual int? ScheduleID { get; set; }
        public abstract class scheduleID : PX.Data.BQL.BqlInt.Field<scheduleID> { }
        #endregion

        #region Active
        [PXDBBool()]
        [PXUIField(DisplayName = "Active")]
        public virtual bool? Active { get; set; }
        public abstract class active : PX.Data.BQL.BqlBool.Field<active> { }
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
            int? scheduleID = null;
            var bpEventSchedule = (BPEventSchedule)tableRow;

            if (key != null)
            {
                eventID = (Guid)key.EventID;
                scheduleID = (int)key.ScheduleID;
            }

            return (eventID != null && bpEventSchedule.EventID == eventID
                && scheduleID != null && bpEventSchedule.ScheduleID == scheduleID);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<BusinessEventScheduleVersion,
                Where<AKChangeObjectVersion.changeObjectID, Equal<Required<AKChangeObjectVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<BusinessEventScheduleVersion>().ToList<object>();
        }
    }
}