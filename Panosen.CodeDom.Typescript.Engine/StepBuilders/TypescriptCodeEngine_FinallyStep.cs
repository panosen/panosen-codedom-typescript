using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    partial class TypescriptCodeEngine
    {
        private void GenerateFinallyStep(FinallyStep finallyStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            if (finallyStepBuilder == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).WriteLine(Keywords.FINALLY);

            GenerateStepOrCollectionListAsBlock(finallyStepBuilder.Steps, codeWriter, options);
        }
    }
}
