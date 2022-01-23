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
    /// Report change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("ReportVersion")]
    public class ReportVersion : AKChangeObjectVersion
    {
        #region Description
        [PXString]
        [PXUIField(DisplayName = "Description")]
        public virtual string Description { get; set; }
        public abstract class description : PX.Data.BQL.BqlString.Field<description> { }
        #endregion

        #region Active
        [PXString]
        [PXUIField(DisplayName = "Active")]
        public virtual string Active { get; set; }
        public abstract class active : PX.Data.BQL.BqlString.Field<active> { }
        #endregion

        /// <summary>
        /// Set the changed values of an object
        /// </summary>
        /// <param name="change">dynamic change object</param>
        public override void SetChangedValues(dynamic change)
        {
            this.Description = change.Description;
            this.Active = Convert.ToBoolean(change.IsActive) ? "Yes" : "No";
        }
    }
}
