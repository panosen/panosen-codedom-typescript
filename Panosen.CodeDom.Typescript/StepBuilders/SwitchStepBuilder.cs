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
    public class SwitchStepBuilder : StepBuilder
    {
        /// <summary>
        /// expression
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// cases
        /// </summary>
        public List<SwitchStepBuilderCase> ConditionList { get; set; }

        /// <summary>
        /// default
        /// </summary>
        public StepBuilderCollection DefaultStepBuilders { get; set; }
    }

    /// <summary>
    /// SwitchStepBuilderExtension
    /// </summary>
    public static class SwitchStepBuilderExtension
    {
        /// <summary>
        /// WithElseIf
        /// </summary>
        public static TSwitchStepBuilder WithCase<TSwitchStepBuilder>(this TSwitchStepBuilder switchStepBuilder, SwitchStepBuilderCase switchStepBuilderCase)
            where TSwitchStepBuilder : SwitchStepBuilder
        {
            if (switchStepBuilder.ConditionList == null)
            {
                switchStepBuilder.ConditionList = new List<SwitchStepBuilderCase>();
            }

            switchStepBuilder.ConditionList.Add(switchStepBuilderCase);

            return switchStepBuilder;
        }

        /// <summary>
        /// WithElseIf
        /// </summary>
        public static SwitchStepBuilderCase WithCase(this SwitchStepBuilder switchStepBuilder, DataKey conditonExpression)
        {
            if (switchStepBuilder.ConditionList == null)
            {
                switchStepBuilder.ConditionList = new List<SwitchStepBuilderCase>();
            }

            SwitchStepBuilderCase switchStepBuilderCase = new SwitchStepBuilderCase();
            switchStepBuilderCase.ConditionExpression = conditonExpression;

            switchStepBuilder.ConditionList.Add(switchStepBuilderCase);

            return switchStepBuilderCase;
        }
        /// <summary>
        /// WithBreak
        /// </summary>
        public static TSwitchStepBuilder WithDefault<TSwitchStepBuilder>(this TSwitchStepBuilder switchStepBuilder, StepBuilderCollection stepBuilderCollection)
            where TSwitchStepBuilder : SwitchStepBuilder
        {
            switchStepBuilder.DefaultStepBuilders = stepBuilderCollection;

            return switchStepBuilder;
        }

        /// <summary>
        /// WithDefault
        /// </summary>
        public static StepBuilderCollection WithDefault(this SwitchStepBuilder switchStepBuilder)
        {
            StepBuilderCollection stepBuilderCollection = new StepBuilderCollection();

            switchStepBuilder.DefaultStepBuilders = stepBuilderCollection;

            return stepBuilderCollection;
        }
    }
}
