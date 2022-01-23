using System;
using PX.Data;
using Newtonsoft.Json;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    [Serializable]
    [PXCacheName("AKChangeObject")]
    public class AKChangeObject : IBqlTable
    {
        #region ChangeObjectID
        // TODO: PXDBIdentity attribute is only valid for 'int' column data type
        [PXDBLong(IsKey = true)]
        [PXUIField(DisplayName = "Change Object ID")]
        public virtual long? ChangeObjectID { get; set; }
        public abstract class changeObjectID : PX.Data.BQL.BqlLong.Field<changeObjectID> { }
        #endregion

        #region KeyValues
        [PXDBString(1000, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Key Values")]
        public virtual string KeyValues { get; set; }
        public abstract class keyValues : PX.Data.BQL.BqlString.Field<keyValues> { }
        #endregion

        #region ChangeObjectTypeID
        [PXDBInt()]
        [PXUIField(DisplayName = "Change Object Type ID")]
        public virtual int? ChangeObjectTypeID { get; set; }
        public abstract class changeObjectTypeID : PX.Data.BQL.BqlInt.Field<changeObjectTypeID> { }
        #endregion

        #region ChangeObjectSubTypeID
        [PXDBInt()]
        [PXUIField(DisplayName = "Change Object Sub Type ID")]
        public virtual int? ChangeObjectSubTypeID { get; set; }
        public abstract class changeObjectSubTypeID : PX.Data.BQL.BqlInt.Field<changeObjectSubTypeID> { }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime()]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
        #endregion
    }
}