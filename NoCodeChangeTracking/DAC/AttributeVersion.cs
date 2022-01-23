using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// Attribute change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("AttributeVersion")]
    public class AttributeVersion : AKChangeObjectVersion
    {
        #region Description
        [PXString]
        [PXUIField(DisplayName = "Description")]
        public virtual string Description { get; set; }
        public abstract class description : PX.Data.BQL.BqlString.Field<description> { }
        #endregion

        #region ControlType
        [PXString]
        [PXUIField(DisplayName = "Control Type")]
        public virtual string ControlType { get; set; }
        public abstract class controlType : PX.Data.BQL.BqlString.Field<controlType> { }
        #endregion

        /// <summary>
        /// Set the changed values of an object
        /// </summary>
        /// <param name="change">dynamic change object</param>
        public override void SetChangedValues(dynamic change)
        {
            this.Description = change.Description;

            // Convert control type number to name
            if (Convert.ToInt32(change.ControlType) == CSAttribute.Text)
            {
                this.ControlType = nameof(CSAttribute.Text);
            }
            else if (Convert.ToInt32(change.ControlType) == CSAttribute.Combo)
            {
                this.ControlType = nameof(CSAttribute.Combo);
            }
            else if (Convert.ToInt32(change.ControlType) == CSAttribute.CheckBox)
            {
                this.ControlType = nameof(CSAttribute.CheckBox);
            }
            else if (Convert.ToInt32(change.ControlType) == CSAttribute.Datetime)
            {
                this.ControlType = nameof(CSAttribute.Datetime);
            }
            else if (Convert.ToInt32(change.ControlType) == CSAttribute.MultiSelectCombo)
            {
                this.ControlType = nameof(CSAttribute.MultiSelectCombo);
            }
            else if (Convert.ToInt32(change.ControlType) == CSAttribute.GISelector)
            {
                this.ControlType = nameof(CSAttribute.GISelector);
            }
        }
    }
}
