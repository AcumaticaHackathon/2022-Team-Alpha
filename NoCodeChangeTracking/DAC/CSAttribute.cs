using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// CSAttribute table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("CSAttribute")]
    public class CSAttribute : PX.Objects.CS.CSAttribute, ITrackedObject
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
            var attribute = (PX.Objects.CS.CSAttribute)tableRow;

            if (key != null)
            {
                attributeID = Convert.ToString(key.AttributeID);
            }

            return (attributeID != null && attribute.AttributeID == attributeID);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<AttributeVersion,
                Where<AttributeVersion.changeObjectID, Equal<Required<AttributeVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<AttributeVersion>().ToList<object>();
        }
    }
}
