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
        /// 生成类
        /// </summary>
        public void GenerateClass(CodeClass codeClass, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeClass == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeClass.Summary, codeWriter, options);

            if (codeClass.AttributeList != null && codeClass.AttributeList.Count > 0)
            {
                foreach (var codeAttribute in codeClass.AttributeList)
                {
                    codeWriter.Write(options.IndentString);
                    GenerateAttribute(codeAttribute, codeWriter, options);
                    codeWriter.WriteLine();
                }
            }

            codeWriter.Write(options.IndentString);

            if (codeClass.Export)
            {
                codeWriter.Write(Keywords.EXPORT).Write(Marks.WHITESPACE);
            }

            if (codeClass.IsStatic)
            {
                codeWriter.Write("Keywords.STATIC").Write(Marks.WHITESPACE);
            }

            if (codeClass.IsAbstract)
            {
                codeWriter.Write("Keywords.ABSTRACT").Write(Marks.WHITESPACE);
            }

            if (codeClass.IsPartial)
            {
                codeWriter.Write("Keywords.PARTIAL").Write(Marks.WHITESPACE);
            }

            codeWriter.Write(Keywords.CLASS).Write(Marks.WHITESPACE).Write(codeClass.Name ?? string.Empty);

            //泛型参数
            GenerateGeneraicParameters(codeClass.GenericParamsterList, codeWriter, options);

            //extends
            if (codeClass.BaseClass != null)
            {
                codeWriter.Write(Marks.WHITESPACE).Write(Keywords.EXTENDS).Write(Marks.WHITESPACE).Write(codeClass.BaseClass.Name);
            }

            //implements
            if (codeClass.InterfaceList != null && codeClass.InterfaceList.Count > 0)
            {
                codeWriter.Write(Marks.WHITESPACE).Write(Keywords.IMPLEMENTS).Write(Marks.WHITESPACE)
                    .Write(string.Join(", ", codeClass.InterfaceList.Select(v => v.Name)));
            }

            //泛型参数约束
            GenerateGenericParametersConstraint(codeClass.GenericParamsterList, codeWriter, options);

            codeWriter.Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);

            options.PushIndent();

            if (codeClass.ConstantList != null && codeClass.ConstantList.Count > 0)
            {
                foreach (var codeConstant in codeClass.ConstantList)
                {
                    codeWriter.WriteLine();
                    GenerateConstant(codeConstant, codeWriter, options);
                }
            }

            if (codeClass.FieldList != null && codeClass.FieldList.Count > 0)
            {
                foreach (var codeField in codeClass.FieldList)
                {
                    codeWriter.WriteLine();
                    GenerateField(codeField, codeWriter, options);
                }
            }

            if (codeClass.Constructor != null)
            {
                codeWriter.WriteLine();
                GenerateMethod(codeClass.Constructor, codeWriter, options);
            }

            if (codeClass.MethodList != null && codeClass.MethodList.Count > 0)
            {
                foreach (var codeMethod in codeClass.MethodList)
                {
                    codeWriter.WriteLine();
                    GenerateMethod(codeMethod, codeWriter, options);
                }
            }

            options.PopIndent();

            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
