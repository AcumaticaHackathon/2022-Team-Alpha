using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    [Serializable]
    public class ChangeObjectFilter : IBqlTable
    {
        #region ChangeObjectID
        // TODO: PXDBIdentity attribute is only valid for 'int' column data type
        [PXLong(IsKey = true)]
        [PXUIField(DisplayName = "Change Object ID")]
        public virtual long? ChangeObjectID { get; set; }
        public abstract class changeObjectID : PX.Data.BQL.BqlLong.Field<changeObjectID> { }
        #endregion

        #region TypeName
        [PXString(50, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Type Name")]
        public virtual string TypeName { get; set; }
        public abstract class typeName : PX.Data.BQL.BqlString.Field<typeName> { }
        #endregion

        #region SubTypeName
        [PXString(50, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "SubType Name")]
        public virtual string SubTypeName { get; set; }
        public abstract class subTypeName : PX.Data.BQL.BqlString.Field<subTypeName> { }
        #endregion
    }
}
