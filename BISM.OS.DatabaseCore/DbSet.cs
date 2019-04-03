using BISM.OS.Entity;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace BISM.OS.DatabaseCore
{
    /// <summary>
    /// ORM 扩展
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbSet<T> : SimpleClient<T> where T : class, new()
    {
        public DbSet(SqlSugarClient context) : base(context)
        {

        }

        /// <summary>
        /// 扩展假删除功能
        /// 逻辑删除
        /// </summary>
        /// <typeparam name="DbModel"></typeparam>
        /// <param name="dbModel"></param>
        /// <returns></returns>
        public bool FalseDelete<DbModel>(DbModel dbModel) where DbModel : BaseDbModel, new()
        {
            return this.Context.Updateable(dbModel).UpdateColumns(it => new DbModel() { IsDeleted = true }).ExecuteCommand() > 0;
        }

        /// <summary>
        /// 扩展假删除功能
        /// 逻辑删除
        /// </summary>
        /// <typeparam name="DbModel"></typeparam>
        /// <param name="dbModel"></param>
        /// <returns></returns>
        public bool FalseDelete<DbModel>(DbModel[] dbModels) where DbModel : BaseDbModel, new()
        {
            return this.Context.Updateable(dbModels).UpdateColumns(it => new DbModel() { IsDeleted = true }).ExecuteCommand() > 0;
        }
    }
}
