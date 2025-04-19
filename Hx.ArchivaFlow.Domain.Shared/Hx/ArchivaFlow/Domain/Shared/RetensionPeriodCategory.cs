using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hx.ArchivaFlow.Domain.Shared
{
    public enum RetensionPeriodCategory : byte
    {
        /// <summary>
        /// 永久
        /// </summary>
        Permanent = 0,
        /// <summary>
        /// 长期
        /// </summary>
        LongTerm = 1,
        /// <summary>
        /// 短期
        /// </summary>
        ShortTerm = 2
    }
}
