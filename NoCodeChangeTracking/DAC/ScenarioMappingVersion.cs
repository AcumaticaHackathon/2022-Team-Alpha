using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// ScenarioMappingVersion change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("ScenarioMappingVersion")]
    public class ScenarioMappingVersion : AKChangeObjectVersion
    {
        #region Name
        [PXString(128, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Name")]
        public virtual string Name { get; set; }
        public abstract class name : PX.Data.BQL.BqlString.Field<name> { }
        #endregion

        #region ScreenID
        [PXString(8, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Screen ID")]
        public virtual string ScreenID { get; set; }
        public abstract class screenID : PX.Data.BQL.BqlString.Field<screenID> { }
        #endregion

        #region GraphName
        [PXString(128, InputMask = "")]
        [PXUIField(DisplayName = "Graph Name")]
        public virtual string GraphName { get; set; }
        public abstract class graphName : PX.Data.BQL.BqlString.Field<graphName> { }
        #endregion

        /// <summary>
        /// Set the changed values of an object
        /// </summary>
        /// <param name="change">dynamic change object</param>
        public override void SetChangedValues(dynamic change)
        {
            this.Name = change.Name;
            this.ScreenID = change.ScreenID;
            this.GraphName = change.GraphName;
        }
    }
}
