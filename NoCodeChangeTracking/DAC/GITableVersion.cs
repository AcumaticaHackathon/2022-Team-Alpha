using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// GITable change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("GITableVersion")]
    public class GITableVersion : AKChangeObjectVersion
    {
        #region Alias
        [PXString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Alias")]
        public virtual string Alias { get; set; }
        public abstract class alias : PX.Data.BQL.BqlString.Field<alias> { }
        #endregion

        #region Name
        [PXString(255, InputMask = "")]
        [PXUIField(DisplayName = "Name")]
        public virtual string Name { get; set; }
        public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
        #endregion

        public override void SetChangedValues(dynamic change)
        {
            this.Alias = change.Aias;
            this.Name = change.Name;
        }
    }
}
