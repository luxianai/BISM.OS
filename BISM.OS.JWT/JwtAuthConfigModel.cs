using System;
using System.Collections.Generic;
using System.Text;

namespace BISM.OS.JWT
{
    public class JwtAuthConfigModel : Common.BaseConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public JwtAuthConfigModel()
        {
            try
            {
                JWTSecretKey = Configuration["JwtAuth:SecurityKey"];
                WebExp = double.Parse(Configuration["JwtAuth:WebExp"]);
                AppExp = double.Parse(Configuration["JwtAuth:AppExp"]);
                OtherExp = double.Parse(Configuration["JwtAuth:OtherExp"]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// 加密key
        /// </summary>
        public string JWTSecretKey = "GUNIU-2018_%^&*%$#)(+;";

        /// <summary>
        /// Web程序 超时日期
        /// </summary>
        public double WebExp { get; set; } = 12;

        /// <summary>
        /// App程序 超时日期
        /// </summary>
        public double AppExp { get; set; } = 12;

        /// <summary>
        /// 其他程序 超时日期
        /// </summary>
        public double OtherExp { get; set; } = 12;
    }
}
