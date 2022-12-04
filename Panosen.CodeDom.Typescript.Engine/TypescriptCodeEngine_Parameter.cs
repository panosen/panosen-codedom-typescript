using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    partial class TypescriptCodeEngine
    {
        /// <summary>
        /// GenerateParameter
        /// </summary>
        public void GenerateParameter(CodeParameter codeParameter, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeParameter == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            if (codeParameter.AttributeList != null && codeParameter.AttributeList.Count > 0)
            {
                foreach (var codeAttribute in codeParameter.AttributeList)
                {
                    GenerateAttribute(codeAttribute, codeWriter, options);
                }
                codeWriter.Write(Marks.WHITESPACE);
            }

            if (codeParameter.AccessModifiers != AccessModifiers.None)
            {
                codeWriter.Write(codeParameter.AccessModifiers.ToString().ToLower()).Write(Marks.WHITESPACE);
            }

            codeWriter.Write(codeParameter.Name);

            if (!string.IsNullOrEmpty(codeParameter.Type))
            {
                if (codeParameter.Optional)
                {
                    codeWriter.Write(Marks.QUESTION);
                }

                codeWriter.Write(Marks.COLON).Write(Marks.WHITESPACE).Write(codeParameter.Type);
            }
        }
    }
}
