using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    /// <summary>
    /// 生成表达式
    /// </summary>
    partial class TypescriptCodeEngine
    {
        /// <summary>
        /// GenerateExpresion
        /// </summary>
        public void GenerateExpresion(CodeExpression codeExpression, CodeWriter codeWriter, GenerateOptions options)
        {
            if (codeExpression == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            if (codeExpression is ReferenceExpression)
            {
                GenerateReferenceExpression(codeExpression as ReferenceExpression, codeWriter, options);
                return;
            }

            if (codeExpression is BinaryOperatorExpression)
            {
                GenerateBinaryOperatorExpresion(codeExpression as BinaryOperatorExpression, codeWriter, options);
                return;
            }

            if (codeExpression is CallMethodExpression)
            {
                GenerateCallMethodExpression(codeExpression as CallMethodExpression, codeWriter, options);
                return;
            }
        }
    }
}
