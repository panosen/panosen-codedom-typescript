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
        /// 生成方法
        /// </summary>
        public void GenerateMethod(CodeMethod codeMethod, CodeWriter codeWriter, GenerateOptions options = null, bool endWithNewLine = true)
        {
            if (codeMethod == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeMethod.Summary, codeWriter, options);

            if (codeMethod.AttributeList != null && codeMethod.AttributeList.Count > 0)
            {
                foreach (var codeAttribute in codeMethod.AttributeList)
                {
                    codeWriter.Write(options.IndentString);
                    GenerateAttribute(codeAttribute, codeWriter, options);
                    codeWriter.WriteLine();
                }
            }

            codeWriter.Write(options.IndentString);

            if (codeMethod.AccessModifiers != AccessModifiers.None)
            {
                codeWriter.Write(codeMethod.AccessModifiers.Value()).Write(Marks.WHITESPACE);
            }

            if (codeMethod.IsOverride)
            {
                codeWriter.Write("Keywords.OVERRIDE").Write(Marks.WHITESPACE);
            }

            if (codeMethod.IsStatic)
            {
                codeWriter.Write(Keywords.STATIC).Write(Marks.WHITESPACE);
            }

            if (codeMethod.IsAsync)
            {
                codeWriter.Write("Keywords.ASYNC").Write(Marks.WHITESPACE);
            }

            if (codeMethod.IsImplicit)
            {
                codeWriter.Write("Keywords.IMPLICIT").Write(Marks.WHITESPACE);
            }

            if (codeMethod.IsOperator)
            {
                codeWriter.Write("Keywords.OPERATOR").Write(Marks.WHITESPACE);
            }

            codeWriter.Write(codeMethod.Name ?? string.Empty);

            //泛型参数
            GenerateGeneraicParameters(codeMethod.GenericParamsterList, codeWriter, options);

            codeWriter.Write(Marks.LEFT_BRACKET);

            GenerateMethodParameters(codeMethod.Parameters, codeWriter, options);

            codeWriter.Write(Marks.RIGHT_BRACKET);

            //泛型参数约束
            GenerateGenericParametersConstraint(codeMethod.GenericParamsterList, codeWriter, options);

            codeWriter.Write(Marks.COLON).Write(Marks.WHITESPACE);
            if (!string.IsNullOrEmpty(codeMethod.Type))
            {
                codeWriter.Write(codeMethod.Type);
            }
            else
            {
                codeWriter.Write(Keywords.VOID);
            }

            if (codeMethod.StepBuilders == null)
            {
                codeWriter.WriteLine(Marks.SEMICOLON);
                return;
            }

            codeWriter.Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);

            options.PushIndent();

            foreach (var stepBuilder in codeMethod.StepBuilders)
            {
                GenerateStepBuilderOrCollection(stepBuilder, codeWriter, options);
            }

            options.PopIndent();

            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }

        private void GenerateMethodParameters(List<CodeParameter> parameters, CodeWriter codeWriter, GenerateOptions options)
        {
            if (parameters == null || parameters.Count == 0)
            {
                return;
            }

            //如果方法超过3个参数，那么开启多行模式
            var wrapParameter = parameters.Count > 3;
            if (wrapParameter)
            {
                GenerateMethodParametersWrapped(parameters, codeWriter, options);
                return;
            }

            var enumerator = parameters.GetEnumerator();
            var moveNext = enumerator.MoveNext();
            while (moveNext)
            {
                GenerateParameter(enumerator.Current, codeWriter, options);

                moveNext = enumerator.MoveNext();
                if (moveNext)
                {
                    codeWriter.Write(Marks.COMMA).Write(Marks.WHITESPACE);
                }
            }
        }

        /// <summary>
        /// 如果方法超过3个参数，那么开启多行模式
        /// </summary>
        private void GenerateMethodParametersWrapped(List<CodeParameter> parameters, CodeWriter codeWriter, GenerateOptions options)
        {
            options.PushIndent();
            codeWriter.WriteLine();

            var enumerator = parameters.GetEnumerator();
            var moveNext = enumerator.MoveNext();
            while (moveNext)
            {
                codeWriter.Write(options.IndentString);

                GenerateParameter(enumerator.Current, codeWriter, options);

                moveNext = enumerator.MoveNext();
                if (moveNext)
                {
                    codeWriter.WriteLine(Marks.COMMA);
                }
            }

            options.PopIndent();
        }
    }
}
