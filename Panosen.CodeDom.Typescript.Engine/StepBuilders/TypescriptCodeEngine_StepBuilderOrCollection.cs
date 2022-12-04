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
        /// 生成方法步骤
        /// </summary>
        /// <param name="stepBuilder"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void GenerateStepBuilderOrCollection(StepOrCollection stepBuilder, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (stepBuilder == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            if (stepBuilder is EmptyStep)
            {
                codeWriter.WriteLine();
            }

            if (stepBuilder is StatementStep)
            {
                GenerateStatementStepBuilder(stepBuilder as StatementStep, codeWriter, options);
            }

            if (stepBuilder is UsingStep)
            {
                GenerateUsingStepBuilder(stepBuilder as UsingStep, codeWriter, options);
            }

            if (stepBuilder is IfStep)
            {
                GenerateIfStepBuilder(stepBuilder as IfStep, codeWriter, options);
            }

            if (stepBuilder is WhileStep)
            {
                GenerateWhileStepBuilder(stepBuilder as WhileStep, codeWriter, options);
            }

            if (stepBuilder is TryStep)
            {
                GenerateTryStepBuilder(stepBuilder as TryStep, codeWriter, options);
            }

            if (stepBuilder is SwitchStep)
            {
                GenerateSwitchStepBuilder(stepBuilder as SwitchStep, codeWriter, options);
            }

            if (stepBuilder is ForeachStep)
            {
                GenerateForeachStepBuilder(stepBuilder as ForeachStep, codeWriter, options);
            }

            if (stepBuilder is ForStep)
            {
                GenerateForStepBuilder(stepBuilder as ForStep, codeWriter, options);
            }

            if (stepBuilder is BlockStep)
            {
                GenerateBlockStepBuilder(stepBuilder as BlockStep, codeWriter, options);
            }

            if (stepBuilder is PushIndentStep)
            {
                GeneratePushIndentStepBuilder(stepBuilder as PushIndentStep, codeWriter, options);
            }

            if (stepBuilder is StatementChainStep)
            {
                GenerateStatementChainStepBuilder(stepBuilder as StatementChainStep, codeWriter, options);
            }

            if (stepBuilder is AssignmentStep)
            {
                GenerateAssignmentStepBuilder(stepBuilder as AssignmentStep, codeWriter, options);
            }
        }
    }
}
