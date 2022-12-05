using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    partial class TypescriptCodeEngine
    {
        private void GeneratePushIndentStep(PushIndentStep pushIndentStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).WriteLine(pushIndentStepBuilder.Key ?? string.Empty);

            if (pushIndentStepBuilder.Steps == null || pushIndentStepBuilder.Steps.Count == 0)
            {
                return;
            }

            options.PushIndent();

            foreach (var item in pushIndentStepBuilder.Steps)
            {
                GenerateStepOrCollection(item, codeWriter, options);
            }

            options.PopIndent();
        }
    }
}
