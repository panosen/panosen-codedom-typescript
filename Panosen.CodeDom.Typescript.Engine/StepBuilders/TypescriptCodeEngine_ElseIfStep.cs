using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    partial class TypescriptCodeEngine
    {
        private void GenerateElseIfStep(ElseIfStep elseIfStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            if (elseIfStepBuilder == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).Write(Keywords.ELSE).Write(Marks.WHITESPACE)
                .Write(Keywords.IF).Write(Marks.WHITESPACE)
                .Write(Marks.LEFT_BRACKET).Write(elseIfStepBuilder.Condition ?? string.Empty)
                .WriteLine(Marks.RIGHT_BRACKET);

            GenerateStepOrCollectionListAsBlock(elseIfStepBuilder.Steps, codeWriter, options);
        }
    }
}
