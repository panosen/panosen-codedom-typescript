using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    partial class TypescriptCodeEngine
    {
        private void GenerateUsingStepBuilder(UsingStep usingStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).Write("Keywords.USING").Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACKET).Write(usingStepBuilder.Content ?? string.Empty).WriteLine(Marks.RIGHT_BRACKET);

            GenerateStepBuilderOrCollectionListAsBlock(usingStepBuilder.StepBuilders, codeWriter, options);
        }
    }
}
