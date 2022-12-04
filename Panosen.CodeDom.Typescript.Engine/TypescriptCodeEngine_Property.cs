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
        /// 生成属性
        /// </summary>
        /// <param name="codeProperty"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void GenerateProperty(CodeProperty codeProperty, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeProperty == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeProperty.Summary, codeWriter, options);

            if (codeProperty.AttributeList != null && codeProperty.AttributeList.Count > 0)
            {
                foreach (var attribute in codeProperty.AttributeList)
                {
                    codeWriter.Write(options.IndentString);
                    GenerateAttribute(attribute, codeWriter, options);
                    codeWriter.WriteLine();
                }
            }

            codeWriter.Write(options.IndentString);

            if (codeProperty.AccessModifiers != AccessModifiers.None)
            {
                codeWriter.Write(codeProperty.AccessModifiers.Value()).Write(Marks.WHITESPACE);
            }
            else
            {
                codeWriter.Write(AccessModifiers.Public.Value()).Write(Marks.WHITESPACE);
            }

            if (codeProperty.IsVirtual)
            {
                codeWriter.Write("Keywords.VIRTUAL").Write(Marks.WHITESPACE);
            }

            if (codeProperty.IsOverride)
            {
                codeWriter.Write("Keywords.OVERRIDE").Write(Marks.WHITESPACE);
            }

            codeWriter.Write(codeProperty.Type ?? string.Empty).Write(Marks.WHITESPACE).Write(codeProperty.Name ?? string.Empty);

            //标准属性
            if ((codeProperty.GetStepBuilderCollection == null || codeProperty.GetStepBuilderCollection.Steps == null || codeProperty.SetStepBuilderCollection.Steps.Count == 0)
                && (codeProperty.SetStepBuilderCollection == null || codeProperty.SetStepBuilderCollection.Steps == null || codeProperty.SetStepBuilderCollection.Steps.Count == 0))
            {
                GenerateStandardProperty(codeWriter, codeProperty, options);
                return;
            }

            //非标准属性
            GenerateCustomizedProperty(codeWriter, codeProperty, options);
        }

        private void GenerateStandardProperty(CodeWriter codeWriter, CodeProperty codeProperty, GenerateOptions options)
        {
            codeWriter.Write(Marks.WHITESPACE);

            codeWriter.Write(Marks.LEFT_BRACE);

            switch (codeProperty.CodePropertyAccess)
            {
                case CodePropertyAccess.OnlyGet:
                    codeWriter.Write(" get; ");
                    break;
                case CodePropertyAccess.PrivateSet:
                    codeWriter.Write(" get; private set; ");
                    break;
                case CodePropertyAccess.ProtectedSet:
                    codeWriter.Write(" get; protected set; ");
                    break;
                case CodePropertyAccess.Default:
                default:
                    codeWriter.Write(" get; set; ");
                    break;
            }

            codeWriter.Write(Marks.RIGHT_BRACE);

            if (codeProperty.Value != null)
            {
                codeWriter.Write(Marks.WHITESPACE).Write(Marks.EQUAL).Write(Marks.WHITESPACE);

                GenerateDataItem(codeProperty.Value, codeWriter, options);

                codeWriter.Write(Marks.SEMICOLON);
            }

            codeWriter.WriteLine();
        }

        private void GenerateCustomizedProperty(CodeWriter codeWriter, CodeProperty codeProperty, GenerateOptions options)
        {
            codeWriter.WriteLine();

            codeWriter.Write(options.IndentString).WriteLine(Marks.LEFT_BRACE);
            options.PushIndent();

            GenerateCustomizedPropertyStepBuilders(codeWriter, Keywords.GET, codeProperty.GetStepBuilderCollection, options);

            GenerateCustomizedPropertyStepBuilders(codeWriter, Keywords.SET, codeProperty.SetStepBuilderCollection, options);

            options.PopIndent();
            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }

        private void GenerateCustomizedPropertyStepBuilders(CodeWriter codeWriter, string keywords, StepCollection stepBuilderCollection, GenerateOptions options)
        {
            if (stepBuilderCollection == null || stepBuilderCollection.Steps == null || stepBuilderCollection.Steps.Count == 0)
            {
                return;
            }

            //如果只有一行语句，则使用单行模式
            if (stepBuilderCollection.Steps.Count == 1 && stepBuilderCollection.Steps.First() is StatementStep)
            {
                codeWriter.Write(options.IndentString).Write(keywords);

                codeWriter.Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACE).Write(Marks.WHITESPACE);

                codeWriter.Write((stepBuilderCollection.Steps.First() as StatementStep).Statement);

                codeWriter.Write(Marks.WHITESPACE).WriteLine(Marks.RIGHT_BRACE);
            }
            else
            {
                codeWriter.Write(options.IndentString).WriteLine(keywords);

                codeWriter.Write(options.IndentString).WriteLine(Marks.LEFT_BRACE);
                options.PushIndent();

                foreach (var item in stepBuilderCollection.Steps)
                {
                    GenerateStepOrCollection(item, codeWriter, options);
                }

                options.PopIndent();
                codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
            }
        }
    }
}
