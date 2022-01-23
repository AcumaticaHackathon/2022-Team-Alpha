using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// Widget change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("WidgetVersion")]
    public class WidgetVersion : AKChangeObjectVersion
    {
        #region Caption
        [PXDBString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Caption")]
        public virtual string Caption { get; set; }
        public abstract class caption : PX.Data.BQL.BqlString.Field<caption> { }
        #endregion

        #region Type
        [PXDBString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Type")]
        public virtual string Type { get; set; }
        public abstract class type : PX.Data.BQL.BqlString.Field<type> { }
        #endregion

        /// <summary>
        /// Set the changed values of an object
        /// </summary>
        /// <param name="change">dynamic change object</param>
        public override void SetChangedValues(dynamic change)
        {
            this.Caption = change.Caption;
            this.Type = change.Type;
        }
    }
}
