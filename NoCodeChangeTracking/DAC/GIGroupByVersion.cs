using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// GIGroupBy change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("GIGroupByVersion")]
    public class GIGroupByVersion : AKChangeObjectVersion
    {
        #region DataFieldName
        [PXString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Data Field Name")]
        public virtual string DataFieldName { get; set; }
        public abstract class dataFieldName : PX.Data.BQL.BqlString.Field<dataFieldName> { }
        #endregion

        public override void SetChangedValues(dynamic change)
        {
            this.DataFieldName = change.DataFieldName;
        }
    }
}
