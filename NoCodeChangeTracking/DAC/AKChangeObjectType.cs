using System;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
  [Serializable]
  [PXCacheName("AKChangeObjectType")]
  public class AKChangeObjectType : IBqlTable
  {
    #region ChangeObjectTypeID
    [PXDBIdentity(IsKey = true)]
    public virtual int? ChangeObjectTypeID { get; set; }
    public abstract class changeObjectTypeID : PX.Data.BQL.BqlInt.Field<changeObjectTypeID> { }
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