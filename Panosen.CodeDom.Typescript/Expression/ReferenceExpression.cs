using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// ${Target}.${Reference}
    /// </summary>
    public class ReferenceExpression : CodeExpression
    {
        /// <summary>
        /// ${Target}
        /// </summary>
        public CodeExpression Target { get; set; }

        /// <summary>
        /// ${Reference}
        /// </summary>
        public CodeExpression Reference { get; set; }
    }
}
