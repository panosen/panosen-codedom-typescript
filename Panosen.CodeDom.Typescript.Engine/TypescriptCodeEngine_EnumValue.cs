using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    partial class TypescriptCodeEngine
    {
        /// <summary>
        /// 生成字段
        /// </summary>
        public void GenerateEnumValue(CodeEnumValue codeEnumValue, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeEnumValue == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeEnumValue.Summary, codeWriter, options);

            codeWriter.Write(options.IndentString);

            codeWriter.Write(codeEnumValue.Name ?? string.Empty);

            if (codeEnumValue.Value != null)
            {
                codeWriter.Write(Marks.WHITESPACE).Write(Marks.EQUAL).Write(Marks.WHITESPACE);

                GenerateDataItem(codeEnumValue.Value, codeWriter, options);
            }
        }
    }
}
