using System;
using System.IO;

namespace Panosen.CodeDom.Typescript.Engine
{
    public partial class TypescriptCodeEngine
    {
        /// <summary>
        /// Generate
        /// </summary>
        /// <param name="code"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void Generate(Code code, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (code == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            if (code is CodeClass)
            {
                GenerateClass(code as CodeClass, codeWriter, options);
                return;
            }

            if (code is CodeInterface)
            {
                GenerateInterface(code as CodeInterface, codeWriter, options);
                return;
            }

            if (code is CodeExpression)
            {
                GenerateExpresion(code as CodeExpression, codeWriter, options);
                return;
            }

            if (code is CodeEnum)
            {
                GenerateEnum(code as CodeEnum, codeWriter, options);
                return;
            }
        }
    }
}
