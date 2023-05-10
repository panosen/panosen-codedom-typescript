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
        /// ${param} => ${expression}
        /// </summary>
        public void GenerateLamdaExpression(CodeLamdaExpression lamda, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (lamda == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateLamdaParameter(lamda, codeWriter, options);

            // x => new ${ClassName}
            codeWriter
                .Write(Marks.WHITESPACE).Write(Marks.EQUAL).Write(Marks.GREATER_THAN).Write(Marks.WHITESPACE)
                .Write(lamda.Expression);
        }

        private void GenerateLamdaParameter(Lamda lamda, CodeWriter codeWriter, GenerateOptions options = null)
        {
            codeWriter.Write(Marks.LEFT_BRACKET);

            if (lamda.Parameters != null && lamda.Parameters.Count > 0)
            {
                var enumerator = lamda.Parameters.GetEnumerator();
                var moveNext = enumerator.MoveNext();
                while (moveNext)
                {
                    codeWriter.Write(enumerator.Current.Name).Write(Marks.COLON).Write(Marks.WHITESPACE).Write(enumerator.Current.Type);

                    moveNext = enumerator.MoveNext();
                    if (moveNext)
                    {
                        codeWriter.Write(Marks.COMMA).Write(Marks.WHITESPACE);
                    }
                }
            }

            codeWriter.Write(Marks.RIGHT_BRACKET);
        }
    }
}
