using System;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
  [Serializable]
  [PXCacheName("GIMassUpdateField")]
  public class GIMassUpdateField : IBqlTable
  {
    #region DesignID
    [PXDBGuid(IsKey = true)]
    [PXUIField(DisplayName = "Design ID")]
    public virtual Guid? DesignID { get; set; }
    public abstract class designID : PX.Data.BQL.BqlGuid.Field<designID> { }
    #endregion

    #region FieldID
    [PXDBInt(IsKey = true)]
    [PXUIField(DisplayName = "Field ID")]
    public virtual int? FieldID { get; set; }
    public abstract class fieldID : PX.Data.BQL.BqlInt.Field<fieldID> { }
    #endregion

    #region CompanyFieldID
    [PXDBIdentity]
    public virtual int? CompanyFieldID { get; set; }
    public abstract class companyFieldID : PX.Data.BQL.BqlInt.Field<companyFieldID> { }
    #endregion

    #region FieldName
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field Name")]
    public virtual string FieldName { get; set; }
    public abstract class fieldName : PX.Data.BQL.BqlString.Field<fieldName> { }
    #endregion

    #region IsActive
    [PXDBBool()]
    [PXUIField(DisplayName = "Is Active")]
    public virtual bool? IsActive { get; set; }
    public abstract class isActive : PX.Data.BQL.BqlBool.Field<isActive> { }
    #endregion
  }
}