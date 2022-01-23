using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// GIRelation change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("GIRelationVersion")]
    public class GIRelationVersion : AKChangeObjectVersion
    {
        #region ParentTable
        [PXString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Parent Table")]
        public virtual string ParentTable { get; set; }
        public abstract class parentTable : PX.Data.BQL.BqlString.Field<parentTable> { }
        #endregion

        #region ChildTable
        [PXString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Child Table")]
        public virtual string ChildTable { get; set; }
        public abstract class childTable : PX.Data.BQL.BqlString.Field<childTable> { }
        #endregion

        public override void SetChangedValues(dynamic change)
        {
            this.ParentTable = change.ParentTable;
            this.ChildTable = change.ChildTable;
        }
    }
}
