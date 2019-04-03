using BISM.OS.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BISM.OS.IService
{
    public interface IUsersService
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="entity">用户</param>
        /// <returns>用户编号</returns>
        int Add(Users entity);

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <param name="entity">用户</param>
        /// <returns>真假</returns>
        bool Edit(Users entity);
    }
}
