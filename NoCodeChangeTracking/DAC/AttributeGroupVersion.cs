using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// Attribute Group change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("AttributeGroupVersion")]
    public class AttributeGroupVersion : AKChangeObjectVersion
    {
        /// <summary>
        /// Set the changed values of an object
        /// </summary>
        /// <param name="change">dynamic change object</param>
        public override void SetChangedValues(dynamic change)
        {
        }
    }
}
