using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// GIWhere change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("GIWhereVersion")]
    public class GIWhereVersion : AKChangeObjectVersion
    {
        #region DataFieldName
        [PXString(512, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Data Field Name")]
        public virtual string DataFieldName { get; set; }
        public abstract class dataFieldName : PX.Data.BQL.BqlString.Field<dataFieldName> { }
        #endregion

        #region Condition
        [PXString(2, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Condition")]
        public virtual string Condition { get; set; }
        public abstract class condition : PX.Data.BQL.BqlString.Field<condition> { }
        #endregion

        #region Value1
        [PXString(IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Value1")]
        public virtual string Value1 { get; set; }
        public abstract class value1 : PX.Data.BQL.BqlString.Field<value1> { }
        #endregion

        public override void SetChangedValues(dynamic change)
        {
            this.DataFieldName = change.DataFieldName;
            this.Condition = change.Condition;
            this.Value1 = change.Value1;
        }
    }
}
