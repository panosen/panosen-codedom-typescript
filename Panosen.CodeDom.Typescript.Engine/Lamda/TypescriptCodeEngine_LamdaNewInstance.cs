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
        /// x => new Studengt()
        /// </summary>
        public void GenerateLamdaNewInstance(CodeLamdaNewInstance lamda, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (lamda == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateLamdaParameter(lamda, codeWriter, options);

            // x => new ${ClassName}
            codeWriter.Write(Marks.WHITESPACE).Write(Marks.EQUAL).Write(Marks.GREATER_THAN).Write(Marks.WHITESPACE)
                .Write(Keywords.NEW);

            if (!string.IsNullOrEmpty(lamda.ClassName))
            {
                codeWriter.Write(Marks.WHITESPACE).Write(lamda.ClassName);
            }

            if (lamda.Statements == null || lamda.Statements.Count == 0)
            {
                codeWriter.Write(Marks.LEFT_BRACKET).Write(Marks.RIGHT_BRACKET);
                return;
            }

            codeWriter.WriteLine();

            codeWriter.Write(options.IndentString).WriteLine(Marks.LEFT_BRACE);
            options.PushIndent();

            var enumerator = lamda.Statements.GetEnumerator();
            var moveNext = enumerator.MoveNext();
            while (moveNext)
            {
                codeWriter.Write(options.IndentString).Write(enumerator.Current);

                moveNext = enumerator.MoveNext();
                if (moveNext)
                {
                    codeWriter.Write(Marks.COMMA);
                }

                codeWriter.WriteLine();
            }

            options.PopIndent();
            codeWriter.Write(options.IndentString).Write(Marks.RIGHT_BRACE);
        }
    }
}
