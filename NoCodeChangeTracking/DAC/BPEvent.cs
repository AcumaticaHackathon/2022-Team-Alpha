using System;
using System.Collections.Generic;
using System.Linq;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// BPEvent table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("BPEvent")]
    public class BPEvent : IBqlTable, ITrackedObject
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

        #region Description
        [PXDBString(256, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Description")]
        public virtual string Description { get; set; }
        public abstract class description : PX.Data.BQL.BqlString.Field<description> { }
        #endregion

        #region ScreenID
        [PXDBString(8, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Screen ID")]
        public virtual string ScreenID { get; set; }
        public abstract class screenID : PX.Data.BQL.BqlString.Field<screenID> { }
        #endregion

        #region ViewName
        [PXDBString(256, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "View Name")]
        public virtual string ViewName { get; set; }
        public abstract class viewName : PX.Data.BQL.BqlString.Field<viewName> { }
        #endregion

        #region ActionName
        [PXDBString(64, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Action Name")]
        public virtual string ActionName { get; set; }
        public abstract class actionName : PX.Data.BQL.BqlString.Field<actionName> { }
        #endregion

        #region Active
        [PXDBBool()]
        [PXUIField(DisplayName = "Active")]
        public virtual bool? Active { get; set; }
        public abstract class active : PX.Data.BQL.BqlBool.Field<active> { }
        #endregion

        #region FilterID
        [PXDBGuid()]
        [PXUIField(DisplayName = "Filter ID")]
        public virtual Guid? FilterID { get; set; }
        public abstract class filterID : PX.Data.BQL.BqlGuid.Field<filterID> { }
        #endregion

        #region GroupingField
        [PXDBString(256, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Grouping Field")]
        public virtual string GroupingField { get; set; }
        public abstract class groupingField : PX.Data.BQL.BqlString.Field<groupingField> { }
        #endregion

        #region GroupingTable
        [PXDBString(256, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Grouping Table")]
        public virtual string GroupingTable { get; set; }
        public abstract class groupingTable : PX.Data.BQL.BqlString.Field<groupingTable> { }
        #endregion

        #region IsGroupByNew
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Group By New")]
        public virtual bool? IsGroupByNew { get; set; }
        public abstract class isGroupByNew : PX.Data.BQL.BqlBool.Field<isGroupByNew> { }
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
            Guid? eventID = null;
            var bpEvent = (BPEvent)tableRow;

            if (key != null)
            {
                eventID = (Guid)key.EventID;
            }

            return (eventID != null && bpEvent.EventID == eventID);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<BusinessEventVersion,
                Where<AKChangeObjectVersion.changeObjectID, Equal<Required<AKChangeObjectVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<BusinessEventVersion>().ToList<object>();
        }
    }
}