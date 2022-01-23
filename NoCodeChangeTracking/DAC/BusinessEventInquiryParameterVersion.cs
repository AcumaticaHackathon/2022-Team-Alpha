using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// Business Event Inquiry Parameter change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("BusinessEventInquiryParameterVersion")]
    public class BusinessEventInquiryParameterVersion : AKChangeObjectVersion
    {
        #region Name
        [PXString(64, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Name")]
        public virtual string Name { get; set; }
        public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
        #endregion

        /// <summary>
        /// Set the changed values of an object
        /// </summary>
        /// <param name="change">dynamic change object</param>
        public override void SetChangedValues(dynamic change)
        {
            this.Name = change.Name;
        }
    }
}
