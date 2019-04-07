using System;
using System.Collections.Generic;
using System.Text;

namespace BISM.OS.Common
{
    public class ConfigHelper : Common.BaseConfig
    {
        public static bool MSSQLIsEnableLogEvent
        {
            get
            {
                return Configuration["DatabaseConfig:SQLIsEnableLogEvent"].ToBool();
            }
        }

        public static string MSSQLConnectionString
        {
            get
            {
                return Configuration["DatabaseConfig:MSSQLConnectionString"];
            }
        }

        #region Redis

        public static bool RedisEnable
        {
            get
            {
                return Configuration["Redis:Enable"].ToBool();
            }
        }

        public static string RedisConnectionString
        {
            get
            {
                return Configuration["Redis:ConnectionString"];
            }
        }

        public static string RedisInstanceName
        {
            get
            {
                return Configuration["Redis:InstanceName"];
            }
        }

        #endregion

        #region Memory Cache

        public static bool MemoryCacheEnable
        {
            get
            {
                return Configuration["MemoryCache:Enable"].ToBool();
            }
        }

        #endregion

        #region 七牛

        public static string QiNiuAccessKey
        {
            get
            {
                return Configuration["QiNiu:AccessKey"];
            }
        }

        public static string QiNiuSecretKey
        {
            get
            {
                return Configuration["QiNiu:SecretKey"];
            }
        }

        public static string QiNiuScope
        {
            get
            {
                return Configuration["QiNiu:Scope"];
            }
        }

        public static string QiNiuReturnBody
        {
            get
            {
                return Configuration["QiNiu:ReturnBody"];
            }
        }

        #endregion
    }
}
