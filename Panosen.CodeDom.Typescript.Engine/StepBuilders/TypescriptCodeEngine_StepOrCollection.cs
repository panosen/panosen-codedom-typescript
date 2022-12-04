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
        public void GenerateStepOrCollection(StepOrCollection stepBuilder, CodeWriter codeWriter, GenerateOptions options = null)
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
                GenerateStatementStep(stepBuilder as StatementStep, codeWriter, options);
            }

            if (stepBuilder is UsingStep)
            {
                GenerateUsingStep(stepBuilder as UsingStep, codeWriter, options);
            }

            if (stepBuilder is IfStep)
            {
                GenerateIfStep(stepBuilder as IfStep, codeWriter, options);
            }

            if (stepBuilder is WhileStep)
            {
                GenerateWhileStep(stepBuilder as WhileStep, codeWriter, options);
            }

            if (stepBuilder is TryStep)
            {
                GenerateTryStep(stepBuilder as TryStep, codeWriter, options);
            }

            if (stepBuilder is SwitchStep)
            {
                GenerateSwitchStep(stepBuilder as SwitchStep, codeWriter, options);
            }

            if (stepBuilder is ForeachStep)
            {
                GenerateForeachStep(stepBuilder as ForeachStep, codeWriter, options);
            }

            if (stepBuilder is ForStep)
            {
                GenerateForStep(stepBuilder as ForStep, codeWriter, options);
            }

            if (stepBuilder is BlockStep)
            {
                GenerateBlockStep(stepBuilder as BlockStep, codeWriter, options);
            }

            if (stepBuilder is PushIndentStep)
            {
                GeneratePushIndentStep(stepBuilder as PushIndentStep, codeWriter, options);
            }

            if (stepBuilder is StatementChainStep)
            {
                GenerateStatementChainStep(stepBuilder as StatementChainStep, codeWriter, options);
            }

            if (stepBuilder is AssignmentStep)
            {
                GenerateAssignmentStep(stepBuilder as AssignmentStep, codeWriter, options);
            }
        }
    }
}
