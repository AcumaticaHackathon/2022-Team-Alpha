using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// GIFilter change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("GIFilterVersion")]
    public class GIFilterVersion : AKChangeObjectVersion
    {
        #region Name
        [PXString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Name")]
        public virtual string Name { get; set; }
        public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
        #endregion

        #region FieldName
        [PXString(512, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Field Name")]
        public virtual string FieldName { get; set; }
        public abstract class fieldName : PX.Data.BQL.BqlString.Field<fieldName> { }
        #endregion

        public override void SetChangedValues(dynamic change)
        {
            this.Name = change.Name;
            this.FieldName = change.FieldName;
        }
    }
}
