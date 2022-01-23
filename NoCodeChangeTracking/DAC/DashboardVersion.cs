using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// Dashboard change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("DashboardVersion")]
    public class DashboardVersion : AKChangeObjectVersion
    {
        #region Name
        [PXString]
        [PXUIField(DisplayName = "Name")]
        public virtual string Name { get; set; }
        public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
        #endregion

        #region ScreenID
        [PXString]
        [PXUIField(DisplayName = "Screen ID")]
        public virtual string ScreenID { get; set; }
        public abstract class screenID : PX.Data.BQL.BqlString.Field<screenID> { }
        #endregion

        public override void SetChangedValues(dynamic change)
        {
            this.Name = change.Name;
            this.ScreenID = change.ScreenID;
        }
    }
}
