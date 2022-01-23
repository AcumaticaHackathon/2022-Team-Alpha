using System;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
  [Serializable]
  [PXCacheName("GINavigationScreen")]
  public class GINavigationScreen : IBqlTable
  {
    #region DesignID
    [PXDBGuid(IsKey = true)]
    [PXUIField(DisplayName = "Design ID")]
    public virtual Guid? DesignID { get; set; }
    public abstract class designID : PX.Data.BQL.BqlGuid.Field<designID> { }
    #endregion

    #region Link
    [PXDBString(2048, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Link")]
    public virtual string Link { get; set; }
    public abstract class link : PX.Data.BQL.BqlString.Field<link> { }
    #endregion

    #region LineNbr
    [PXDBInt(IsKey = true)]
    [PXUIField(DisplayName = "Line Nbr")]
    public virtual int? LineNbr { get; set; }
    public abstract class lineNbr : PX.Data.BQL.BqlInt.Field<lineNbr> { }
    #endregion

    #region SortOrder
    [PXDBInt()]
    [PXUIField(DisplayName = "Sort Order")]
    public virtual int? SortOrder { get; set; }
    public abstract class sortOrder : PX.Data.BQL.BqlInt.Field<sortOrder> { }
    #endregion

    #region WindowMode
    [PXDBString(1, InputMask = "")]
    [PXUIField(DisplayName = "Window Mode")]
    public virtual string WindowMode { get; set; }
    public abstract class windowMode : PX.Data.BQL.BqlString.Field<windowMode> { }
    #endregion

    #region IsActive
    [PXDBBool()]
    [PXUIField(DisplayName = "Is Active")]
    public virtual bool? IsActive { get; set; }
    public abstract class isActive : PX.Data.BQL.BqlBool.Field<isActive> { }
    #endregion

    #region Icon
    [PXDBString(255, IsUnicode = true, InputMask = "")]
    [PXUIField(DisplayName = "Icon")]
    public virtual string Icon { get; set; }
    public abstract class icon : PX.Data.BQL.BqlString.Field<icon> { }
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