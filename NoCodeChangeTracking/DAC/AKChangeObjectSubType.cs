using System;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
  [Serializable]
  [PXCacheName("AKChangeObjectSubType")]
  public class AKChangeObjectSubType : IBqlTable
  {
    #region ChangeObjectSubTypeID
    [PXDBIdentity(IsKey = true)]
    public virtual int? ChangeObjectSubTypeID { get; set; }
    public abstract class changeObjectSubTypeID : PX.Data.BQL.BqlInt.Field<changeObjectSubTypeID> { }
    #endregion

    #region Name
    [PXDBString(50, IsKey = true, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Name")]
    public virtual string Name { get; set; }
    public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
    #endregion

    #region Description
    [PXDBString(255, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Description")]
    public virtual string Description { get; set; }
    public abstract class description : PX.Data.BQL.BqlString.Field<description> { }
    #endregion
  }
}