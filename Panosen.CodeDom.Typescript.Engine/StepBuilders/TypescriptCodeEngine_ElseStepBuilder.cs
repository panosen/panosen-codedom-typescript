using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    partial class TypescriptCodeEngine
    {
        private void GenerateElseStepBuilder(ElseStepBuilder elseStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            if (elseStepBuilder == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).WriteLine(Keywords.ELSE);

            GenerateStepBuilderOrCollectionListAsBlock(elseStepBuilder.StepBuilders, codeWriter, options);
        }
    }
}
