using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// GIOn change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("GIOnVersion")]
    public class GIOnVersion : AKChangeObjectVersion
    {
        #region ParentField
        [PXString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Parent Field")]
        public virtual string ParentField { get; set; }
        public abstract class parentField : PX.Data.BQL.BqlString.Field<parentField> { }
        #endregion

        #region Condition
        [PXString(2, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Condition")]
        public virtual string Condition { get; set; }
        public abstract class condition : PX.Data.BQL.BqlString.Field<condition> { }
        #endregion

        #region ChildField
        [PXString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Child Field")]
        public virtual string ChildField { get; set; }
        public abstract class childField : PX.Data.BQL.BqlString.Field<childField> { }
        #endregion

        public override void SetChangedValues(dynamic change)
        {
            this.ParentField = change.ParentField;
            this.Condition = change.Condition;
            this.ChildField = change.ChildField;
        }
    }
}
