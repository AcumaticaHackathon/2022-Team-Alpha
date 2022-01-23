using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    [Serializable]
    public class ChangeObjectVersionFilter : IBqlTable
    {
        #region ChangeObjectID
        // TODO: PXDBIdentity attribute is only valid for 'int' column data type
        [PXLong(IsKey = true)]
        [PXUIField(DisplayName = "Change Object ID")]
        public virtual long? ChangeObjectID { get; set; }
        public abstract class changeObjectID : PX.Data.BQL.BqlLong.Field<changeObjectID> { }
        #endregion
    }
}
