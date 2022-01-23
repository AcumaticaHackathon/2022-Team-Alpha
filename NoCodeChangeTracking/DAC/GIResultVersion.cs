using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// GIResult change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("GIResultVersion")]
    public class GIResultVersion : AKChangeObjectVersion
    {
        #region ObjectName
        [PXString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Object Name")]
        public virtual string ObjectName { get; set; }
        public abstract class objectName : PX.Data.BQL.BqlString.Field<objectName> { }
        #endregion

        #region Field
        [PXString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Field")]
        public virtual string Field { get; set; }
        public abstract class field : PX.Data.BQL.BqlString.Field<field> { }
        #endregion

        #region SchemaField
        [PXString(255, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Schema Field")]
        public virtual string SchemaField { get; set; }
        public abstract class schemaField : PX.Data.BQL.BqlString.Field<schemaField> { }
        #endregion

        #region Caption
        [PXString(128, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Caption")]
        public virtual string Caption { get; set; }
        public abstract class caption : PX.Data.BQL.BqlString.Field<caption> { }
        #endregion

        public override void SetChangedValues(dynamic change)
        {
            this.ObjectName = change.ObjectName;
            this.Field = change.Field;
            this.SchemaField = change.SchemaField;
            this.Caption = change.Caption;
        }
    }
}
