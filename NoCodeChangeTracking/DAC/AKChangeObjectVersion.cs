using System;
using System.Collections;
using PX.Data;

namespace Aktion.Common.Acumatica.NoCodeChangeTracking.DAC
{
  [Serializable]
  [PXCacheName("AKChangeObjectVersion")]
  public class AKChangeObjectVersion : IBqlTable
  {
        public AKChangeObjectVersion() { }

        #region ChangeObjectVersionID
        // TODO: PXDBIdentity attribute is only valid for 'int' column data type
        [PXDBLong(IsKey = true)]
        [PXUIField(DisplayName = "Change Object Version ID")]
        public virtual long? ChangeObjectVersionID { get; set; }
        public abstract class changeObjectVersionID : PX.Data.BQL.BqlLong.Field<changeObjectVersionID> { }
        #endregion

        #region ChangeObjectID
        [PXDBLong()]
        [PXUIField(DisplayName = "Change Object ID")]
        [PXDBDefault(typeof(AKChangeObject.changeObjectID))]
        [PXParent(typeof(Select<AKChangeObject, Where<AKChangeObject.changeObjectID, Equal<Current<AKChangeObjectVersion.changeObjectID>>>>))]
        public virtual long? ChangeObjectID { get; set; }
        public abstract class changeObjectID : PX.Data.BQL.BqlLong.Field<changeObjectID> { }
        #endregion

        #region Version
        [PXDBLong()]
        [PXUIField(DisplayName = "Version")]
        public virtual long? Version { get; set; }
        public abstract class version : PX.Data.BQL.BqlLong.Field<version> { }
        #endregion

        #region Object
        [PXDBString(2000, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Change Object")]
        public virtual string ChangeObject { get; set; }
        public abstract class changeObject : PX.Data.BQL.BqlString.Field<changeObject> { }
        #endregion

        #region CreatedDateTime
        [PXDBCreatedDateTime()]
        [PXUIField(DisplayName = "Version Date")]
        public virtual DateTime? CreatedDateTime { get; set; }
        public abstract class createdDateTime : PX.Data.BQL.BqlDateTime.Field<createdDateTime> { }
        #endregion

        #region LastModifiedDateTime
        [PXDBLastModifiedDateTime()]
        [PXUIField(DisplayName = "Change Date")]
        public virtual DateTime? LastModifiedDateTime { get; set; }
        public abstract class lastModifiedDateTime : PX.Data.BQL.BqlDateTime.Field<lastModifiedDateTime> { }
        #endregion

        #region LastModifiedByID
        public abstract class lastModifiedByID : PX.Data.BQL.BqlGuid.Field<lastModifiedByID> { }
        [PXDBLastModifiedByID]
        [PXUIField(DisplayName = PXDBLastModifiedByIDAttribute.DisplayFieldNames.LastModifiedByID, Enabled = false)]
        public virtual Guid? LastModifiedByID { get; set; }
        #endregion

        #region ActionType
        [PXDBString(1, IsFixed = true, InputMask = "")]
        [PXUIField(DisplayName = "Action Type")]
        public virtual string ActionType { get; set; }
        public abstract class actionType : PX.Data.BQL.BqlString.Field<actionType> { }
        #endregion

        #region Selected
        [PXBool]
        [PXDefault(false)]
        [PXUIField(DisplayName = "Selected")]
        public virtual bool? Selected { get; set; }
        public abstract class selected : PX.Data.BQL.BqlBool.Field<selected> { }
        #endregion

        #region ActionName
        [PXString]
        [PXUIField(DisplayName = "Action Type")]
        public virtual string ActionName { get; set; }
        public abstract class actionName : PX.Data.BQL.BqlString.Field<actionName> { }
        #endregion

        /// <summary>
        /// Retrieve versions of a change object
        /// </summary>
        /// <param name="changeObject">change object of which to retrieve versions</param>
        /// <param name="graph">controller for querying with</param>
        /// <returns>List of versions</returns>
        /// <exception cref="NotImplementedException">Concrete class should implement</exception>
        public virtual IEnumerable GetChangeObjectVersions(AKChangeObject changeObject, PXGraph graph)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set the changed values of an object
        /// </summary>
        /// <param name="change">dynamic change object</param>
        /// <exception cref="NotImplementedException">Concrete class should implement</exception>
        public virtual void SetChangedValues(dynamic change)
        {
            throw new NotImplementedException();
        }

    }
}