using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// x => new Item { }
    /// </summary>
    public class CodeLamdaNewInstance : Lamda
    {
        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 步骤集合
        /// </summary>
        public StepCollection StepBuilderCollection { get; set; }

        /// <summary>
        /// Statements
        /// </summary>
        public List<string> Statements { get; set; }
    }

    /// <summary>
    /// CodeLamdaNewInstanceExpressionExtension
    /// </summary>
    public static class CodeLamdaNewInstanceExpressionExtension
    {
        /// <summary>
        /// SetBooleanExpression
        /// </summary>
        public static TCodeLamdaNewInstanceExpression SetClassName<TCodeLamdaNewInstanceExpression>(this TCodeLamdaNewInstanceExpression codeLamdaNewInstanceExpression, string className)
            where TCodeLamdaNewInstanceExpression : CodeLamdaNewInstance
        {
            codeLamdaNewInstanceExpression.ClassName = className;

            return codeLamdaNewInstanceExpression;
        }

        /// <summary>
        /// SetBooleanExpression
        /// </summary>
        public static TCodeLamdaNewInstanceExpression StepStatement<TCodeLamdaNewInstanceExpression>(this TCodeLamdaNewInstanceExpression codeLamdaNewInstanceExpression, string statement)
            where TCodeLamdaNewInstanceExpression : CodeLamdaNewInstance
        {
            if (codeLamdaNewInstanceExpression.Statements == null)
            {
                codeLamdaNewInstanceExpression.Statements = new List<string>();
            }

            codeLamdaNewInstanceExpression.Statements.Add(statement);

            return codeLamdaNewInstanceExpression;
        }
    }
}
