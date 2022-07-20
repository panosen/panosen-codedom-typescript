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
        /// GenerateReferenceExpression
        /// </summary>
        public void GenerateReferenceExpression(ReferenceExpression codeExpression, CodeWriter codeWriter, GenerateOptions options)
        {
            if (codeExpression == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            if (codeExpression.Target == null) { return; }
            if (codeExpression.Reference == null) { return; }

            GenerateExpresion(codeExpression.Target, codeWriter, options);
            codeWriter.Write(".");

            GenerateExpresion(codeExpression.Reference, codeWriter, options);
        }
    }
}
