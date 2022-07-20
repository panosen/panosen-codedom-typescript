using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    partial class TypescriptCodeEngine
    {
        private void GenerateAssignmentStepBuilder(AssignmentStepBuilder assignmentStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).Write(assignmentStepBuilder.Left)
                .Write(Marks.WHITESPACE).Write(Marks.EQUAL).Write(Marks.WHITESPACE);

            GenerateExpresion(assignmentStepBuilder.Right, codeWriter, options);

            codeWriter.WriteLine(Marks.SEMICOLON);
        }
    }
}
