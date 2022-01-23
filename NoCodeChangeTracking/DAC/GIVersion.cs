using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// GIDesign change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("GIVersion")]
    public class GIVersion : AKChangeObjectVersion
    {
        #region Name
        [PXString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Name")]
        public virtual string Name { get; set; }
        public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
        #endregion

        public override void SetChangedValues(dynamic change)
        {
            this.Name = change.Name;
        }
    }
}
