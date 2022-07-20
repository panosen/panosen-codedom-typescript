using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// 属性访问修饰符
    /// </summary>
    public enum CodePropertyAccess
    {
        /// <summary>
        /// { get; set; }
        /// </summary>
        Default,

        /// <summary>
        /// { get; }
        /// </summary>
        OnlyGet,

        /// <summary>
        /// { get; private set; }
        /// </summary>
        PrivateSet,

        /// <summary>
        /// { get; protected set; }
        /// </summary>
        ProtectedSet
    }
}
