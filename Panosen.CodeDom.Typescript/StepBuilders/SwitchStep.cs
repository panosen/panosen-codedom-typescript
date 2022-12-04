using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// switch
    /// </summary>
    public class SwitchStep : Step
    {
        /// <summary>
        /// expression
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// cases
        /// </summary>
        public List<SwitchStepCase> ConditionList { get; set; }

        /// <summary>
        /// default
        /// </summary>
        public StepCollection DefaultStepBuilders { get; set; }
    }

    /// <summary>
    /// SwitchStepBuilderExtension
    /// </summary>
    public static class SwitchStepBuilderExtension
    {
        /// <summary>
        /// WithElseIf
        /// </summary>
        public static TSwitchStepBuilder WithCase<TSwitchStepBuilder>(this TSwitchStepBuilder switchStepBuilder, SwitchStepCase switchStepBuilderCase)
            where TSwitchStepBuilder : SwitchStep
        {
            if (switchStepBuilder.ConditionList == null)
            {
                switchStepBuilder.ConditionList = new List<SwitchStepCase>();
            }

            switchStepBuilder.ConditionList.Add(switchStepBuilderCase);

            return switchStepBuilder;
        }

        /// <summary>
        /// WithElseIf
        /// </summary>
        public static SwitchStepCase WithCase(this SwitchStep switchStepBuilder, DataKey conditonExpression)
        {
            if (switchStepBuilder.ConditionList == null)
            {
                switchStepBuilder.ConditionList = new List<SwitchStepCase>();
            }

            SwitchStepCase switchStepBuilderCase = new SwitchStepCase();
            switchStepBuilderCase.ConditionExpression = conditonExpression;

            switchStepBuilder.ConditionList.Add(switchStepBuilderCase);

            return switchStepBuilderCase;
        }
        /// <summary>
        /// WithBreak
        /// </summary>
        public static TSwitchStepBuilder WithDefault<TSwitchStepBuilder>(this TSwitchStepBuilder switchStepBuilder, StepCollection stepBuilderCollection)
            where TSwitchStepBuilder : SwitchStep
        {
            switchStepBuilder.DefaultStepBuilders = stepBuilderCollection;

            return switchStepBuilder;
        }

        /// <summary>
        /// WithDefault
        /// </summary>
        public static StepCollection WithDefault(this SwitchStep switchStepBuilder)
        {
            StepCollection stepBuilderCollection = new StepCollection();

            switchStepBuilder.DefaultStepBuilders = stepBuilderCollection;

            return stepBuilderCollection;
        }
    }
}
