using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
    /// <summary>
    /// CSAttributeGroup table adapter for tracking changes
    /// </summary>
    [Serializable]
    [PXCacheName("CSAttributeGroup")]
    public class CSAttributeGroup : PX.Objects.CS.CSAttributeGroup, ITrackedObject
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
            string entityClassID = null;
            string entityType = null;
            var attributeGroup = (PX.Objects.CS.CSAttributeGroup)tableRow;

            if (key != null)
            {
                attributeID = Convert.ToString(key.AttributeID);
                entityClassID = Convert.ToString(key.EntityClassID);
                entityType = Convert.ToString(key.EntityType);
            }

            return (attributeID != null && attributeGroup.AttributeID == attributeID
                && entityClassID != null && attributeGroup.EntityClassID == entityClassID
                && entityType != null && attributeGroup.EntityType == entityType);
        }

        /// <summary>
        /// Retrieve versions for a changed object
        /// </summary>
        /// <param name="changeObject">changed object</param>
        /// <param name="graph">controller to query with</param>
        /// <returns>list of object versions</returns>
        public List<object> GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            return new PXSelect<AttributeGroupVersion,
                Where<AttributeGroupVersion.changeObjectID, Equal<Required<AttributeGroupVersion.changeObjectID>>>>(graph)
                .Select(changeObject.ChangeObjectID).RowCast<AttributeGroupVersion>().ToList<object>();
        }
    }
}
