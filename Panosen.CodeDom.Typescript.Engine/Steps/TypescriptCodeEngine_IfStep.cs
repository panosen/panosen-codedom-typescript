using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    partial class TypescriptCodeEngine
    {
        private void GenerateIfStep(IfStep ifStepBuilder, CodeWriter codeWriter, GenerateOptions options)
        {
            if (ifStepBuilder == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            //if
            {
                codeWriter.Write(options.IndentString).Write(Keywords.IF).Write(Marks.WHITESPACE).Write(Marks.LEFT_BRACKET).Write(ifStepBuilder.Condition ?? string.Empty)
                    .Write(Marks.RIGHT_BRACKET).Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);
                options.PushIndent();

                GenerateStepOrCollectionList(ifStepBuilder.Steps, codeWriter, options);

                options.PopIndent();
                codeWriter.Write(options.IndentString).Write(Marks.RIGHT_BRACE);
            }

            //else if
            {
                if (ifStepBuilder.ElseIfStepBuilders != null && ifStepBuilder.ElseIfStepBuilders.Count > 0)
                {
                    foreach (var elseIfStepBuilder in ifStepBuilder.ElseIfStepBuilders)
                    {
                        codeWriter.Write(Marks.WHITESPACE).Write(Keywords.ELSE).Write(Marks.WHITESPACE)
                            .Write(Keywords.IF).Write(Marks.WHITESPACE)
                            .Write(Marks.LEFT_BRACKET).Write(elseIfStepBuilder.Condition ?? string.Empty)
                            .Write(Marks.RIGHT_BRACKET).Write(Marks.WHITESPACE)
                            .WriteLine(Marks.LEFT_BRACE);
                        options.PushIndent();

                        GenerateStepOrCollectionList(elseIfStepBuilder.Steps, codeWriter, options);

                        options.PopIndent();
                        codeWriter.Write(options.IndentString).Write(Marks.RIGHT_BRACE);
                    }
                }
            }

            //else
            {
                if (ifStepBuilder.ElseStepBuilder != null)
                {
                    codeWriter.Write(Marks.WHITESPACE).Write(Keywords.ELSE).Write(Marks.WHITESPACE).WriteLine(Marks.LEFT_BRACE);
                    options.PushIndent();

                    GenerateStepOrCollectionList(ifStepBuilder.ElseStepBuilder.Steps, codeWriter, options);

                    options.PopIndent();
                    codeWriter.Write(options.IndentString).Write(Marks.RIGHT_BRACE);
                }
            }

            codeWriter.WriteLine();
        }
    }
}
