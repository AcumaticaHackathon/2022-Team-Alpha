using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// CSScreenAttribute table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("CSScreenAttribute")]
    public class CSScreenAttribute : PX.CS.CSScreenAttribute, ITrackedObject
    {
        /// <summary>
        /// Whether a dynamic object key matches a table row object
        /// </summary>
        /// <param name="key">dynamic object holding key fields</param>
        /// <param name="tableRow">table row object</param>
        /// <returns>whether the key matches</returns>
        public bool IsKeyMatch(dynamic key, object tableRow)
        {
            string attributeID = null;
            string screenID = null;
            string typeValue = null;
            var screenAttribute = (CSScreenAttribute)tableRow;

            if (key != null)
            {
                attributeID = Convert.ToString(key.AttributeID);
                screenID = Convert.ToString(key.ScreenID);
                typeValue = Convert.ToString(key.TypeValue);
            }

            return (attributeID != null && screenAttribute.AttributeID == attributeID
                && screenID != null && screenAttribute.ScreenID == screenID
                && typeValue != null && screenAttribute.TypeValue == typeValue);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<ScreenAttributeVersion,
                Where<ScreenAttributeVersion.changeObjectID, Equal<Required<ScreenAttributeVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<ScreenAttributeVersion>().ToList<object>();
        }
    }
}
