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
        /// 生成接口
        /// </summary>
        public void GenerateInterface(CodeInterface codeInterface, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeInterface == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeInterface.Summary, codeWriter, options);

            codeWriter.Write(options.IndentString);

            if (codeInterface.AccessModifiers != AccessModifiers.None)
            {
                codeWriter.Write(codeInterface.AccessModifiers.Value()).Write(Marks.WHITESPACE);
            }

            if (codeInterface.Export)
            {
                codeWriter.Write(Keywords.EXPORT).Write(Marks.WHITESPACE);
            }

            codeWriter.Write(Keywords.INTERFACE).Write(Marks.WHITESPACE).Write(codeInterface.Name ?? string.Empty);

            if (codeInterface.ParentInterfaceList != null && codeInterface.ParentInterfaceList.Count > 0)
            {
                codeWriter.Write(Marks.COLON);
                for (int i = 0; i < codeInterface.ParentInterfaceList.Count; i++)
                {
                    codeWriter.Write(Marks.WHITESPACE).Write(codeInterface.ParentInterfaceList[i].Name);
                    if (i < codeInterface.ParentInterfaceList.Count - 1)
                    {
                        codeWriter.Write(Marks.COMMA);
                    }
                }
            }

            codeWriter.Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);

            options.PushIndent();

            if (codeInterface.FieldList != null && codeInterface.FieldList.Count > 0)
            {
                foreach (var codeField in codeInterface.FieldList)
                {
                    codeWriter.WriteLine();
                    GenerateField(codeField, codeWriter, options);
                }
            }

            if (codeInterface.MethodList != null && codeInterface.MethodList.Count > 0)
            {
                foreach (var codeMethod in codeInterface.MethodList)
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
