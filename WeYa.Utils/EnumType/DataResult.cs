/********************************************************************************
** 作者： androllen
** 日期： 16/5/17 16:47:12
** 微博： http://weibo.com/Androllen
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeYa.Utils
{
    /// <summary>
    /// 服务器返回json应答码
    /// </summary>
    public enum DataResult
    {
        Result_OK,
        /// <summary>
        /// 针对单个命令的云端服务故障
        /// </summary>
        Result_ServiceErr,
        /// <summary>
        /// 协议格式错误(针对各个命令，命令协议格式完整，数据类型正确)
        /// </summary>
        Result_ProErr,
        /// <summary>
        /// 是否是Json or 是否为空
        /// </summary>
        Result_NullErr,
        /// <summary>
        /// 
        /// </summary>
        Result_NetNotFound,
        /// <summary>
        /// 链接超时
        /// </summary>
        Result_TimeOut
    }
}
