using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    partial class TypescriptCodeEngine
    {
        private void GenerateIfStepBuilder(IfStepBuilder ifStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            if (ifStepBuilder == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).Write(Keywords.IF).Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACKET).Write(ifStepBuilder.Condition ?? string.Empty).WriteLine(Marks.RIGHT_BRACKET);

            GenerateStepBuilderOrCollectionListAsBlock(ifStepBuilder.StepBuilders, codeWriter, options);

            if (ifStepBuilder.ElseIfStepBuilders != null && ifStepBuilder.ElseIfStepBuilders.Count > 0)
            {
                foreach (var elseIfStepBuilder in ifStepBuilder.ElseIfStepBuilders)
                {
                    GenerateElseIfStepBuilder(elseIfStepBuilder, codeWriter, options);
                }
            }

            GenerateElseStepBuilder(ifStepBuilder.ElseStepBuilder, codeWriter, options);
        }
    }
}
