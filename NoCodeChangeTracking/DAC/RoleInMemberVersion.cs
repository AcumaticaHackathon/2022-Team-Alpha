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
    /// RoleInMember change object version instance
    /// </summary>
    [Serializable]
    [PXCacheName("RoleInMemberVersion")]
    public class RoleInMemberVersion : AKChangeObjectVersion
    {
        #region Rolename
        [PXString(64, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Rolename")]
        public virtual string Rolename { get; set; }
        public abstract class rolename : PX.Data.BQL.BqlString.Field<rolename> { }
        #endregion

        #region ApplicationName
        [PXString(32, InputMask = "")]
        [PXUIField(DisplayName = "Application Name")]
        public virtual string ApplicationName { get; set; }
        public abstract class applicationName : PX.Data.BQL.BqlString.Field<applicationName> { }
        #endregion

        #region ScreenID
        [PXString(8, InputMask = "")]
        [PXUIField(DisplayName = "Screen ID")]
        public virtual string ScreenID { get; set; }
        public abstract class screenID : PX.Data.BQL.BqlString.Field<screenID> { }
        #endregion

        #region Cachetype
        [PXString(255, InputMask = "")]
        [PXUIField(DisplayName = "Cachetype")]
        public virtual string Cachetype { get; set; }
        public abstract class cachetype : PX.Data.BQL.BqlString.Field<cachetype> { }
        #endregion

        #region Membername
        [PXString(255, InputMask = "")]
        [PXUIField(DisplayName = "Membername")]
        public virtual string Membername { get; set; }
        public abstract class membername : PX.Data.BQL.BqlString.Field<membername> { }
        #endregion

        /// <summary>
        /// Set the changed values of an object
        /// </summary>
        /// <param name="change">dynamic change object</param>
        public override void SetChangedValues(dynamic change)
        {
            this.Rolename = change.RoleName;
            this.ApplicationName = change.ApplicationName;
            this.ScreenID = change.ScreenID;
            this.Cachetype = change.CacheType;
            this.Membername = change.Membername;
        }
    }
}
