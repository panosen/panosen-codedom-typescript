using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// IfStepBuilder
    /// </summary>
    public class IfStep : StepCollection
    {
        /// <summary>
        /// Condition
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// ElseIfStepBuilders
        /// </summary>
        public List<ElseIfStep> ElseIfStepBuilders { get; set; }

        /// <summary>
        /// ElseStepBuilder
        /// </summary>
        public ElseStep ElseStepBuilder { get; set; }
    }

    /// <summary>
    /// IfStepBuilderExtension
    /// </summary>
    public static class IfStepBuilderExtension
    {
        /// <summary>
        /// WithElseIf
        /// </summary>
        /// <param name="ifStepBuilder"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static ElseIfStep WithElseIf(this IfStep ifStepBuilder, string condition)
        {
            if (ifStepBuilder.ElseIfStepBuilders == null)
            {
                ifStepBuilder.ElseIfStepBuilders = new List<ElseIfStep>();
            }

            ElseIfStep elseIfStepBuilder = new ElseIfStep();
            elseIfStepBuilder.Condition = condition;
            ifStepBuilder.ElseIfStepBuilders.Add(elseIfStepBuilder);

            return elseIfStepBuilder;
        }

        /// <summary>
        /// WithElse
        /// </summary>
        /// <param name="ifStepBuilder"></param>
        /// <returns></returns>
        public static ElseStep WithElse(this IfStep ifStepBuilder)
        {
            ElseStep elseStepBuilder = new ElseStep();

            ifStepBuilder.ElseStepBuilder = elseStepBuilder;

            return elseStepBuilder;
        }
    }
}
