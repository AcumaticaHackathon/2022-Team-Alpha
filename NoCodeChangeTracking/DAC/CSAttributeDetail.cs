using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// CSAttributeDetail table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("CSAttributeDetail")]
    public class CSAttributeDetail : PX.Objects.CS.CSAttributeDetail, ITrackedObject
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
            string valueID = null;
            var attributeDetail = (PX.Objects.CS.CSAttributeDetail)tableRow;

            if (key != null)
            {
                attributeID = Convert.ToString(key.AttributeID);
                valueID = Convert.ToString(key.ValueID);
            }

            return (attributeID != null && attributeDetail.AttributeID == attributeID
                && valueID != null && attributeDetail.ValueID == valueID);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<AttributeDetailVersion,
                Where<AttributeDetailVersion.changeObjectID, Equal<Required<AttributeDetailVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<AttributeDetailVersion>().ToList<object>();
        }
    }
}
