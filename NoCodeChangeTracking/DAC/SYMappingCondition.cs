using System;
using System.Collections.Generic;
using System.Linq;
using PX.Data;
using PX.Data.BQL;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// SYMappingCondition table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("SYMappingCondition")]
    public class SYMappingCondition : IBqlTable, ITrackedObject
    {
        #region MappingID
        [PXDBGuid(IsKey = true)]
        [PXUIField(DisplayName = "Mapping ID")]
        public virtual Guid? MappingID { get; set; }
        public abstract class mappingID : PX.Data.BQL.BqlGuid.Field<mappingID> { }
        #endregion

        #region LineNbr
        [PXDBShort(IsKey = true)]
        [PXUIField(DisplayName = "Line Nbr")]
        public virtual short? LineNbr { get; set; }
        public abstract class lineNbr : PX.Data.BQL.BqlShort.Field<lineNbr> { }
        #endregion

        #region IsActive
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Active")]
        public virtual bool? IsActive { get; set; }
        public abstract class isActive : PX.Data.BQL.BqlBool.Field<isActive> { }
        #endregion

        #region OpenBrackets
        [PXDBInt()]
        [PXUIField(DisplayName = "Open Brackets")]
        public virtual int? OpenBrackets { get; set; }
        public abstract class openBrackets : PX.Data.BQL.BqlInt.Field<openBrackets> { }
        #endregion

        #region ObjectName
        [PXDBString(128, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Object Name")]
        public virtual string ObjectName { get; set; }
        public abstract class objectName : PX.Data.BQL.BqlString.Field<objectName> { }
        #endregion

        #region FieldName
        [PXDBString(128, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Field Name")]
        public virtual string FieldName { get; set; }
        public abstract class fieldName : PX.Data.BQL.BqlString.Field<fieldName> { }
        #endregion

        #region Condition
        [PXDBInt()]
        [PXUIField(DisplayName = "Condition")]
        public virtual int? Condition { get; set; }
        public abstract class condition : PX.Data.BQL.BqlInt.Field<condition> { }
        #endregion

        #region IsRelative
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Relative")]
        public virtual bool? IsRelative { get; set; }
        public abstract class isRelative : PX.Data.BQL.BqlBool.Field<isRelative> { }
        #endregion

        #region Value
        [PXDBString(128, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Value")]
        public virtual string Value { get; set; }
        public abstract class value : PX.Data.BQL.BqlString.Field<value> { }
        #endregion

        #region Value2
        [PXDBString(128, IsUnicode = true, InputMask = "")]
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

        #region Tstamp
        [PXDBTimestamp()]
        [PXUIField(DisplayName = "Tstamp")]
        public virtual byte[] Tstamp { get; set; }
        public abstract class tstamp : PX.Data.BQL.BqlByteArray.Field<tstamp> { }
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
            Guid? mappingID = null;
            short? lineNbr = null;
            var mappingCondition = (SYMappingCondition)tableRow;

            if (key != null)
            {
                mappingID = (Guid)key.MappingID;
                lineNbr = (short)key.LineNbr;
            }

            return (mappingID.HasValue && mappingCondition.MappingID == mappingID.Value
                && lineNbr.HasValue && mappingCondition.LineNbr == lineNbr.Value);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<ScenarioMappingConditionVersion,
                Where<ScenarioMappingConditionVersion.changeObjectID, Equal<Required<ScenarioMappingConditionVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<ScenarioMappingConditionVersion>().ToList<object>();
        }
    }
}