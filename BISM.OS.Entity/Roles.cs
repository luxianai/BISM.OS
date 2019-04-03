using SqlSugar;
using System;

namespace BISM.OS.Entity
{
    ///<summary>
    /// 角色表
    ///</summary>
    [SugarTable("Roles")]
    public partial class Roles
    {
        public Roles() { }

        /// <summary>
        /// Desc:角色编号
        /// Default:
        /// Nullable:False
        /// </summary>          
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int RoleID { get; set; }

        /// <summary>
        /// Desc:角色名称
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string RoleName { get; set; }

        /// <summary>
        /// Desc:状态
        /// Default:
        /// Nullable:False
        /// </summary>           
        public bool Status { get; set; }

        /// <summary>
        /// Desc:是否删除
        /// Default:0
        /// Nullable:False
        /// </summary>           
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Desc:创建日期
        /// Default:DateTime.Now
        /// Nullable:False
        /// </summary>           
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Desc:创建人
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? CreatedID { get; set; }

        /// <summary>
        /// Desc:更新日期
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// Desc:更新人
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? UpdatedID { get; set; }

    }
}
