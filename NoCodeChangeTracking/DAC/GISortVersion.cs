using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// GISort change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("GISortVersion")]
    public class GISortVersion : AKChangeObjectVersion
    {
        #region DataFieldName
        [PXString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Data Field Name")]
        public virtual string DataFieldName { get; set; }
        public abstract class dataFieldName : PX.Data.BQL.BqlString.Field<dataFieldName> { }
        #endregion

        #region SortOrder
        [PXString(1, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Sort Order")]
        public virtual string SortOrder { get; set; }
        public abstract class sortOrder : PX.Data.BQL.BqlString.Field<sortOrder> { }
        #endregion

        public override void SetChangedValues(dynamic change)
        {
            this.DataFieldName = change.DataFieldName;
            this.SortOrder = change.SortOrder;
        }
    }
}
