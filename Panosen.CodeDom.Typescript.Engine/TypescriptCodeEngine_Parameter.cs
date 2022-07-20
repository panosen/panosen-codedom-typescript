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
        /// <param name="codeParameter"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
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

            codeWriter.Write(codeParameter.Name);

            if (!string.IsNullOrEmpty(codeParameter.Type))
            {
                codeWriter.Write(Marks.COLON).Write(Marks.WHITESPACE).Write(codeParameter.Type);
            }
        }
    }
}
