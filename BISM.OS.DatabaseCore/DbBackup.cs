using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BISM.OS.DatabaseCore
{
    public class DbBackup
    {
        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="path">备份文件地址如D://abc.sql</param>
        /// <returns></returns>
        public static void BackupDb(object path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 还原数据库
        /// </summary>
        /// <param name="path">指定还原文件***.sql的绝对路径</param>
        /// <param name="dbName">还原到指定数据库</param>
        /// <returns></returns>
        public static bool RestoreDb(string path, string dbName)
        {
            throw new NotImplementedException();
        }
    }
}
