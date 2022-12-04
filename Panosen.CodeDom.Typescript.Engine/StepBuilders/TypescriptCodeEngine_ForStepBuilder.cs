using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    partial class TypescriptCodeEngine
    {
        private void GenerateForStepBuilder(ForStep forStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).Write(Keywords.FOR).Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACKET)
                .Write(forStepBuilder.Start ?? string.Empty).Write(Marks.SEMICOLON).Write(Marks.WHITESPACE)
                .Write(forStepBuilder.Middle ?? string.Empty).Write(Marks.SEMICOLON).Write(Marks.WHITESPACE)
                .Write(forStepBuilder.End ?? string.Empty)
                .WriteLine(Marks.RIGHT_BRACKET);

            GenerateStepBuilderOrCollectionListAsBlock(forStepBuilder.StepBuilders, codeWriter, options);
        }
    }
}
