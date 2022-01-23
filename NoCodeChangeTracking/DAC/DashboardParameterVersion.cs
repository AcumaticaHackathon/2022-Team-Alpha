using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// DashboardParameterVersion change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("DashboardParameterVersion")]
    public class DashboardParameterVersion : AKChangeObjectVersion
    {
        #region Name
        [PXDBString(256, IsKey = true, InputMask = "")]
        [PXUIField(DisplayName = "Name")]
        public virtual string Name { get; set; }
        public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
        #endregion

        #region LineNbr
        [PXDBInt(IsKey = true)]
        [PXUIField(DisplayName = "Line Nbr")]
        public virtual int? LineNbr { get; set; }
        public abstract class lineNbr : PX.Data.BQL.BqlInt.Field<lineNbr> { }
        #endregion

        /// <summary>
        /// Set the changed values of an object
        /// </summary>
        /// <param name="change">dynamic change object</param>
        public override void SetChangedValues(dynamic change)
        {
            this.Name = change.Description;
            this.LineNbr = change.LineNbr;
        }
    }
}
