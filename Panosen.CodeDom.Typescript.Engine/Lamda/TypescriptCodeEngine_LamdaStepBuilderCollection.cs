using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    partial class TypescriptCodeEngine
    {
        /// <summary>
        /// ${param} => ${expression}
        /// </summary>
        public void GenerateLamdaStepCollection(CodeLamdaStepBuilderCollection lamda, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (lamda == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            /*
             x => {
                 //do
             }
             */
            codeWriter.Write(lamda.Parameter)
                .Write(Marks.WHITESPACE).Write(Marks.EQUAL).Write(Marks.GREATER_THAN).Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);
            options.PushIndent();

            GenerateStepCollection(lamda.StepCollection, codeWriter, options);

            options.PopIndent();
            codeWriter.Write(options.IndentString).Write(Marks.RIGHT_BRACE);
        }
    }
}
