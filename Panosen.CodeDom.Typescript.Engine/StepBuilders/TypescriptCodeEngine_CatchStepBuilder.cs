using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    partial class TypescriptCodeEngine
    {
        private void GenerateCacheStepBuilder(CatchStep catchStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            if (catchStepBuilder == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(options.IndentString).Write(Keywords.CATCH);
            if (!string.IsNullOrEmpty(catchStepBuilder.ExceptionType))
            {
                codeWriter.Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACKET).Write(catchStepBuilder.ExceptionType);

                if (!string.IsNullOrEmpty(catchStepBuilder.ExceptionName))
                {
                    codeWriter.Write(Marks.WHITESPACE).Write(catchStepBuilder.ExceptionName);
                }

                codeWriter.Write(Marks.RIGHT_BRACKET);
            }
            codeWriter.WriteLine();

            GenerateStepBuilderOrCollectionListAsBlock(catchStepBuilder.StepBuilders, codeWriter, options);
        }
    }
}
