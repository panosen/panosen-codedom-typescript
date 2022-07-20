using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    partial class TypescriptCodeEngine
    {
        private void GeneratePushIndentStepBuilder(PushIndentStepBuilder pushIndentStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).WriteLine(pushIndentStepBuilder.Key ?? string.Empty);

            if (pushIndentStepBuilder.StepBuilders == null || pushIndentStepBuilder.StepBuilders.Count == 0)
            {
                return;
            }

            options.PushIndent();

            foreach (var item in pushIndentStepBuilder.StepBuilders)
            {
                GenerateStepBuilderOrCollection(item, codeWriter, options);
            }

            options.PopIndent();
        }
    }
}
