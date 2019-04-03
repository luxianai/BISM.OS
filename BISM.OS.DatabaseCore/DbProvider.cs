using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace BISM.OS.DatabaseCore
{
    public class DbProvider
    {
        public static SqlSugarClient GetMasterInstance()
        {
            return new SqlSugarClient(GetSqlServerConnectionConfig());
        }

        private static ConnectionConfig GetSqlServerConnectionConfig()
        {
            return new ConnectionConfig()
            {
                ConnectionString = "", // "SERVER=.;DATABASE=BISM-OSDB;UID=sa;PWD=123;",
                DbType = DbType.SqlServer,
                InitKeyType = InitKeyType.Attribute,// 从特性读取主键和自增列信息
                IsAutoCloseConnection = true // 开启自动释放模式和EF原理一样
            };
        }
    }
}
