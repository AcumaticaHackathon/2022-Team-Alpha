using System;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
  [Serializable]
  [PXCacheName("AKChangeVersion")]
  public class AKChangeVersion : IBqlTable
  {
    #region ChangeVersionID
    // TODO: PXDBIdentity attribute is only valid for 'int' column data type
    [PXDBLong(IsKey = true)]
    [PXUIField(DisplayName = "Change Version ID")]
    public virtual long? ChangeVersionID { get; set; }
    public abstract class changeVersionID : PX.Data.BQL.BqlLong.Field<changeVersionID> { }
    #endregion

    #region ChangeObjectID
    [PXDBLong(IsKey = true)]
    [PXUIField(DisplayName = "Change Object ID")]
    public virtual long? ChangeObjectID { get; set; }
    public abstract class changeObjectID : PX.Data.BQL.BqlLong.Field<changeObjectID> { }
    #endregion

    #region LastVersion
    [PXDBLong()]
    [PXUIField(DisplayName = "Last Version")]
    public virtual long? LastVersion { get; set; }
    public abstract class lastVersion : PX.Data.BQL.BqlLong.Field<lastVersion> { }
    #endregion

    #region CreatedDateTime
    [PXDBCreatedDateTime()]
    public virtual DateTime? CreatedDateTime { get; set; }
    public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
    #endregion

    #region LastModifiedDateTime
    [PXDBLastModifiedDateTime]
    public virtual DateTime? LastModifiedDateTime { get; set; }
    public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
    #endregion
  }
}