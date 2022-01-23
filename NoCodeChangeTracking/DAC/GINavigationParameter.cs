using System;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
  [Serializable]
  [PXCacheName("GINavigationParameter")]
  public class GINavigationParameter : IBqlTable
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

    #region FieldName
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field Name")]
    public virtual string FieldName { get; set; }
    public abstract class fieldName : PX.Data.BQL.BqlString.Field<fieldName> { }
    #endregion

    #region ParameterName
    [PXDBString(IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Parameter Name")]
    public virtual string ParameterName { get; set; }
    public abstract class parameterName : PX.Data.BQL.BqlString.Field<parameterName> { }
    #endregion

    #region IsExpression
    [PXDBBool()]
    [PXUIField(DisplayName = "Is Expression")]
    public virtual bool? IsExpression { get; set; }
    public abstract class isExpression : PX.Data.BQL.BqlBool.Field<isExpression> { }
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