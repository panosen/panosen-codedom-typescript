using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// ${Parameter} => ${Expression}
    /// </summary>
    public class CodeLamdaExpression : Lamda
    {
        /// <summary>
        /// ${Expression}
        /// </summary>
        public string Expression { get; set; }
    }

    /// <summary>
    /// CodeLamdaExpressionExtension
    /// </summary>
    public static class CodeLamdaExpressionExtension
    {
        /// <summary>
        /// SetExpression
        /// </summary>
        public static TCodeLamdaStatementExpression SetExpression<TCodeLamdaStatementExpression>(this TCodeLamdaStatementExpression lamda, string expression)
            where TCodeLamdaStatementExpression : CodeLamdaExpression
        {
            lamda.Expression = expression;

            return lamda;
        }
    }
}
