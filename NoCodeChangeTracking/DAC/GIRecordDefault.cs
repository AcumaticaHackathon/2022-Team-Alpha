using System;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
  [Serializable]
  [PXCacheName("GIRecordDefault")]
  public class GIRecordDefault : IBqlTable
  {
    #region DesignID
    [PXDBGuid(IsKey = true)]
    [PXUIField(DisplayName = "Design ID")]
    public virtual Guid? DesignID { get; set; }
    public abstract class designID : PX.Data.BQL.BqlGuid.Field<designID> { }
    #endregion

    #region Recdefid
    [PXDBInt(IsKey = true)]
    [PXUIField(DisplayName = "Recdefid")]
    public virtual int? Recdefid { get; set; }
    public abstract class recdefid : PX.Data.BQL.BqlInt.Field<recdefid> { }
    #endregion

    #region CompanyRecDefID
    [PXDBIdentity]
    public virtual int? CompanyRecDefID { get; set; }
    public abstract class companyRecDefID : PX.Data.BQL.BqlInt.Field<companyRecDefID> { }
    #endregion

    #region FieldName
    [PXDBString(256, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Field Name")]
    public virtual string FieldName { get; set; }
    public abstract class fieldName : PX.Data.BQL.BqlString.Field<fieldName> { }
    #endregion

    #region Value
    [PXDBString(512, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Value")]
    public virtual string Value { get; set; }
    public abstract class value : PX.Data.BQL.BqlString.Field<value> { }
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