using System;
using System.Collections.Generic;
using System.Linq;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// SYImportCondition table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("SYImportCondition")]
    public class SYImportCondition : IBqlTable, ITrackedObject
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
        [PXDBCreatedByID()]
        public virtual Guid? CreatedByID { get; set; }
        public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
        #endregion

        #region CreatedByScreenID
        [PXDBCreatedByScreenID()]
        public virtual string CreatedByScreenID { get; set; }
        public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
        #endregion

        #region LastModifiedByID
        [PXDBLastModifiedByID()]
        public virtual Guid? LastModifiedByID { get; set; }
        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
        #endregion

        #region LastModifiedByScreenID
        [PXDBLastModifiedByScreenID()]
        public virtual string LastModifiedByScreenID { get; set; }
        public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
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
            var importCondition = (SYImportCondition)tableRow;

            if (key != null)
            {
                mappingID = (Guid)key.MappingID;
                lineNbr = (short)key.LineNbr;
            }

            return (mappingID.HasValue && importCondition.MappingID == mappingID.Value
                && lineNbr.HasValue && importCondition.LineNbr == lineNbr.Value);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<ScenarioImportConditionVersion,
                Where<ScenarioImportConditionVersion.changeObjectID, Equal<Required<ScenarioImportConditionVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<ScenarioImportConditionVersion>().ToList<object>();
        }
    }
}