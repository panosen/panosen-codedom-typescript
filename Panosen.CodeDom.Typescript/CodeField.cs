using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// 字段
    /// </summary>
    public class CodeField : CodeObject
    {

        /// <summary>
        /// 访问修饰符
        /// </summary>
        public AccessModifiers AccessModifiers { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// static
        /// </summary>
        public bool IsStatic { get; set; }

        /// <summary>
        /// 是否是只读字段
        /// </summary>
        public bool IsReadOnly { get; set; }

        /// <summary>
        /// volatile
        /// </summary>
        public bool IsVolatile { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public DataItem Value { get; set; }
    }
}
