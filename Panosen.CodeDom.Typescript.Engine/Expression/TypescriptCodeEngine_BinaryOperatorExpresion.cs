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
        /// GenerateBinaryOperatorExpresion
        /// </summary>
        public void GenerateBinaryOperatorExpresion(BinaryOperatorExpression codeExpression, CodeWriter codeWriter, GenerateOptions options)
        {
            if (codeExpression == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(codeExpression.Left ?? string.Empty).Write(Marks.WHITESPACE).Write(codeExpression.Operator?.Value ?? string.Empty).Write(Marks.WHITESPACE).Write(codeExpression.Right ?? string.Empty);
        }
    }
}
