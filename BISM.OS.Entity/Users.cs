using SqlSugar;
using System;

namespace BISM.OS.Entity
{
    ///<summary>
    /// 用户表
    ///</summary>
    [SugarTable("Users")]
    public partial class Users
    {
        public Users() { }

        /// <summary>
        /// Desc:用户编号
        /// Default:
        /// Nullable:False
        /// </summary>           
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int UserID { get; set; }

        /// <summary>
        /// Desc:用户账号
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Accounts { get; set; }

        /// <summary>
        /// Desc:用户密码
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string Password { get; set; }

        /// <summary>
        /// Desc:全名
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string FullName { get; set; }

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

    }
}
