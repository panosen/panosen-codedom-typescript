using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    partial class TypescriptCodeEngine
    {
        private void GenerateAttribute(CodeDecorator codeAttribute, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeAttribute is CodeVariableDecorator)
            {
                GenerateVariableAttribute(codeAttribute as CodeVariableDecorator, codeWriter, options);
            }

            if (codeAttribute is CodeMethodDecorator)
            {
                GenerateMethodAttribute(codeAttribute as CodeMethodDecorator, codeWriter, options);
            }
        }

        private void GenerateVariableAttribute(CodeVariableDecorator codeAttribute, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeAttribute == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(Marks.AT).Write(codeAttribute.Name ?? string.Empty);
        }

        private void GenerateMethodAttribute(CodeMethodDecorator codeDecorator, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeDecorator == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(Marks.AT).Write(codeDecorator.Name ?? string.Empty);

            codeWriter.Write(Marks.LEFT_BRACKET);

            if (codeDecorator.Items != null && codeDecorator.Items.Count > 0)
            {
                var enumerator = codeDecorator.Items.GetEnumerator();
                var moveNext = enumerator.MoveNext();
                while (moveNext)
                {
                    GenerateDataItem(enumerator.Current, codeWriter, options);

                    moveNext = enumerator.MoveNext();
                    if (moveNext)
                    {
                        codeWriter.Write(Marks.COMMA).Write(Marks.WHITESPACE);
                    }
                }
            }

            {
                codeWriter.Write(Marks.RIGHT_BRACKET);
            }
        }
    }
}
