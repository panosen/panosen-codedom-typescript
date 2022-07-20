using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// ${Left} ${Operator} ${Right}
    /// </summary>
    public class BinaryOperatorExpression : CodeExpression
    {
        /// <summary>
        /// ${Operator}
        /// </summary>
        public BinaryOperator Operator { get; set; }

        /// <summary>
        /// $"{Left}"
        /// </summary>
        public string Left { get; set; }

        /// <summary>
        /// $"{Right}"
        /// </summary>
        public string Right { get; set; }
    }
}
