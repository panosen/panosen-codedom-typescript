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
        public void GenerateField(CodeField codeField, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeField == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeField.Summary, codeWriter, options);

            codeWriter.Write(options.IndentString);

            if (codeField.AccessModifiers != AccessModifiers.None)
            {
                codeWriter.Write(codeField.AccessModifiers.Value()).Write(Marks.WHITESPACE);
            }

            if (codeField.IsStatic)
            {
                codeWriter.Write(Keywords.STATIC).Write(Marks.WHITESPACE);
            }

            codeWriter.Write(codeField.Name ?? string.Empty);

            if (codeField.Optional)
            {
                codeWriter.Write(Marks.QUESTION);
            }

            codeWriter.Write(Marks.COLON).Write(Marks.WHITESPACE);

            codeWriter.Write(codeField.Type ?? string.Empty);

            if (codeField.Value != null)
            {
                codeWriter.Write(Marks.WHITESPACE).Write(Marks.EQUAL).Write(Marks.WHITESPACE);

                GenerateDataItem(codeField.Value, codeWriter, options);
            }

            codeWriter.WriteLine(Marks.SEMICOLON);
        }
    }
}
