using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.ArchivaFlow.Domain.Shared
{
    public enum MediaCatagory : byte
    {
        /// <summary>
        /// 纸质
        /// </summary>
        Paper = 1,
        /// <summary>
        /// 电子
        /// </summary>
        Electronic = 2,
        /// <summary>
        /// 物理
        /// </summary>
        Physical = 3
    }
}
