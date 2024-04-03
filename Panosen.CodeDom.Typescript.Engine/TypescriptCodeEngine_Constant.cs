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
        /// GenerateConstant
        /// </summary>
        public void GenerateConstant(CodeConstant codeConstant, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeConstant == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeConstant.Summary, codeWriter, options);
            codeWriter.Write(options.IndentString);

            if (codeConstant.AccessModifiers != AccessModifiers.None)
            {
                codeWriter.Write(codeConstant.AccessModifiers.Value()).Write(Marks.WHITESPACE);
            }

            if (codeConstant.Export)
            {
                codeWriter.Write(Keywords.EXPORT).Write(Marks.WHITESPACE);
            }

            codeWriter.Write(Keywords.STATIC).Write(Marks.WHITESPACE);

            codeWriter.Write(Keywords.READONLY).Write(Marks.WHITESPACE);

            codeWriter.Write(codeConstant.Name ?? string.Empty);

            codeWriter.Write(Marks.COLON).Write(Marks.WHITESPACE);

            codeWriter.Write(codeConstant.Type ?? string.Empty);

            codeWriter.Write(Marks.WHITESPACE).Write(Marks.EQUAL).Write(Marks.WHITESPACE);

            GenerateDataValue(codeConstant.Value, codeWriter, options);

            codeWriter.WriteLine(Marks.SEMICOLON);
        }
    }
}
