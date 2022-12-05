using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    partial class TypescriptCodeEngine
    {
        private void GenerateBlockStep(BlockStep blockStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).WriteLine(Marks.LEFT_BRACE);
            options.PushIndent();

            GenerateStepOrCollection(blockStepBuilder, codeWriter, options);

            options.PopIndent();
            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
