using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// WebHook change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("WebHookVersion")]
    public class WebHookVersion : AKChangeObjectVersion
    {
        #region Name
        [PXString]
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
