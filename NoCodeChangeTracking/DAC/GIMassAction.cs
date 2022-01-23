using System;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
  [Serializable]
  [PXCacheName("GIMassAction")]
  public class GIMassAction : IBqlTable
  {
    #region DesignID
    [PXDBGuid(IsKey = true)]
    [PXUIField(DisplayName = "Design ID")]
    public virtual Guid? DesignID { get; set; }
    public abstract class designID : PX.Data.BQL.BqlGuid.Field<designID> { }
    #endregion

    #region MassActionID
    [PXDBInt(IsKey = true)]
    [PXUIField(DisplayName = "Mass Action ID")]
    public virtual int? MassActionID { get; set; }
    public abstract class massActionID : PX.Data.BQL.BqlInt.Field<massActionID> { }
    #endregion

    #region CompanyMassActionID
    [PXDBIdentity]
    public virtual int? CompanyMassActionID { get; set; }
    public abstract class companyMassActionID : PX.Data.BQL.BqlInt.Field<companyMassActionID> { }
    #endregion

    #region ActionName
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Action Name")]
    public virtual string ActionName { get; set; }
    public abstract class actionName : PX.Data.BQL.BqlString.Field<actionName> { }
    #endregion

    #region IsActive
    [PXDBBool()]
    [PXUIField(DisplayName = "Is Active")]
    public virtual bool? IsActive { get; set; }
    public abstract class isActive : PX.Data.BQL.BqlBool.Field<isActive> { }
    #endregion
  }
}