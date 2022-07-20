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
        /// 泛型参数
        /// </summary>
        private void GenerateGeneraicParameters(List<CodeGenericParamster> genericParamsters, CodeWriter codeWriter, GenerateOptions options)
        {
            if (genericParamsters == null || genericParamsters.Count == 0)
            {
                return;
            }
            if (codeWriter == null)
            {
                return;
            }
            options = options ?? new GenerateOptions();

            codeWriter.Write(Marks.LESS_THAN);

            var enumerator = genericParamsters.GetEnumerator();
            var moveNext = enumerator.MoveNext();
            while (moveNext)
            {
                var current = enumerator.Current;
                codeWriter.Write(current.Name);

                moveNext = enumerator.MoveNext();
                if (moveNext)
                {
                    codeWriter.Write(Marks.COMMA).Write(Marks.WHITESPACE);
                }
            }

            codeWriter.Write(Marks.GREATER_THAN);
        }

        /// <summary>
        /// 泛型参数约束
        /// </summary>
        /// <param name="genericParamsters"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        private void GenerateGenericParametersConstraint(List<CodeGenericParamster> genericParamsters, CodeWriter codeWriter, GenerateOptions options)
        {
            if (genericParamsters == null || genericParamsters.Count == 0)
            {
                return;
            }
            var items = genericParamsters.Where(v => v.Constraints != null && v.Constraints.Count > 0).ToList();
            if (items.Count == 0)
            {
                return;
            }
            if (codeWriter == null)
            {
                return;
            }
            options = options ?? new GenerateOptions();

            codeWriter.WriteLine();

            options.PushIndent();

            var enumerator = items.GetEnumerator();
            var moveNext = enumerator.MoveNext();
            while (moveNext)
            {
                GenerateGenericParameterConstraint(codeWriter, options, enumerator.Current);

                moveNext = enumerator.MoveNext();
                if (moveNext)
                {
                    codeWriter.WriteLine();
                }
            }

            options.PopIndent();
        }

        private static void GenerateGenericParameterConstraint(CodeWriter codeWriter, GenerateOptions options, CodeGenericParamster genericParameter)
        {
            codeWriter.Write(options.IndentString).Write("Keywords.WHERE").Write(Marks.WHITESPACE);

            codeWriter.Write(genericParameter.Name);

            codeWriter.Write(Marks.WHITESPACE).Write(Marks.COLON).Write(Marks.WHITESPACE);

            var enumerator = genericParameter.Constraints.GetEnumerator();
            var moveNext = enumerator.MoveNext();
            while (moveNext)
            {
                var current = enumerator.Current;
                codeWriter.Write(current);

                moveNext = enumerator.MoveNext();
                if (moveNext)
                {
                    codeWriter.Write(Marks.COMMA).Write(Marks.WHITESPACE);
                }
            }


        }
    }
}
