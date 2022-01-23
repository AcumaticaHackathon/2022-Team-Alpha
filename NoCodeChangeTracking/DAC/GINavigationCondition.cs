using System;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
  [Serializable]
  [PXCacheName("GINavigationCondition")]
  public class GINavigationCondition : IBqlTable
  {
    #region DesignID
    [PXDBGuid(IsKey = true)]
    [PXUIField(DisplayName = "Design ID")]
    public virtual Guid? DesignID { get; set; }
    public abstract class designID : PX.Data.BQL.BqlGuid.Field<designID> { }
    #endregion

    #region NavigationScreenLineNbr
    [PXDBInt(IsKey = true)]
    [PXUIField(DisplayName = "Navigation Screen Line Nbr")]
    public virtual int? NavigationScreenLineNbr { get; set; }
    public abstract class navigationScreenLineNbr : PX.Data.BQL.BqlInt.Field<navigationScreenLineNbr> { }
    #endregion

    #region LineNbr
    [PXDBInt(IsKey = true)]
    [PXUIField(DisplayName = "Line Nbr")]
    public virtual int? LineNbr { get; set; }
    public abstract class lineNbr : PX.Data.BQL.BqlInt.Field<lineNbr> { }
    #endregion

    #region IsActive
    [PXDBBool()]
    [PXUIField(DisplayName = "Is Active")]
    public virtual bool? IsActive { get; set; }
    public abstract class isActive : PX.Data.BQL.BqlBool.Field<isActive> { }
    #endregion

    #region DataField
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Data Field")]
    public virtual string DataField { get; set; }
    public abstract class dataField : PX.Data.BQL.BqlString.Field<dataField> { }
    #endregion

    #region OpenBrackets
    [PXDBInt()]
    [PXUIField(DisplayName = "Open Brackets")]
    public virtual int? OpenBrackets { get; set; }
    public abstract class openBrackets : PX.Data.BQL.BqlInt.Field<openBrackets> { }
    #endregion

    #region CloseBrackets
    [PXDBInt()]
    [PXUIField(DisplayName = "Close Brackets")]
    public virtual int? CloseBrackets { get; set; }
    public abstract class closeBrackets : PX.Data.BQL.BqlInt.Field<closeBrackets> { }
    #endregion

    #region IsExpression
    [PXDBBool()]
    [PXUIField(DisplayName = "Is Expression")]
    public virtual bool? IsExpression { get; set; }
    public abstract class isExpression : PX.Data.BQL.BqlBool.Field<isExpression> { }
    #endregion

    #region ValueSt
    [PXDBString(IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Value St")]
    public virtual string ValueSt { get; set; }
    public abstract class valueSt : PX.Data.BQL.BqlString.Field<valueSt> { }
    #endregion

    #region ValueSt2
    [PXDBString(IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Value St2")]
    public virtual string ValueSt2 { get; set; }
    public abstract class valueSt2 : PX.Data.BQL.BqlString.Field<valueSt2> { }
    #endregion

    #region Condition
    [PXDBString(2, IsFixed = true, InputMask = "")]
    [PXUIField(DisplayName = "Condition")]
    public virtual string Condition { get; set; }
    public abstract class condition : PX.Data.BQL.BqlString.Field<condition> { }
    #endregion

    #region Operator
    [PXDBString(1, IsFixed = true, InputMask = "")]
    [PXUIField(DisplayName = "Operator")]
    public virtual string Operator { get; set; }
    public abstract class @operator : PX.Data.BQL.BqlString.Field<@operator> { }
    #endregion

    #region CreatedByID
    [PXDBCreatedByID()]
    public virtual Guid? CreatedByID { get; set; }
    public abstract class createdByID : PX.Data.BQL.BqlGuid.Field<createdByID> { }
    #endregion

    #region CreatedDateTime
    [PXDBCreatedDateTime()]
    public virtual DateTime? CreatedDateTime { get; set; }
    public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
    #endregion

    #region CreatedByScreenID
    [PXDBCreatedByScreenID()]
    public virtual string CreatedByScreenID { get; set; }
    public abstract class createdByScreenID : PX.Data.BQL.BqlString.Field<createdByScreenID> { }
    #endregion

    #region LastModifiedByID
    [PXDBLastModifiedByID()]
    public virtual Guid? LastModifiedByID { get; set; }
    public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
    #endregion

    #region LastModifiedDateTime
    [PXDBLastModifiedDateTime()]
    public virtual DateTime? LastModifiedDateTime { get; set; }
    public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
    #endregion

    #region LastModifiedByScreenID
    [PXDBLastModifiedByScreenID()]
    public virtual string LastModifiedByScreenID { get; set; }
    public abstract class lastModifiedByScreenID : PX.Data.BQL.BqlString.Field<lastModifiedByScreenID> { }
    #endregion
  }
}