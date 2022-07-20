using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// SwitchStepBuilderCondition
    /// </summary>
    public class SwitchStepBuilderCase : StepBuilderCollection
    {
        /// <summary>
        /// case 后面跟的语句
        /// </summary>
        public DataKey ConditionExpression { get; set; }

        /// <summary>
        /// 不包含语句和break，直接贯穿到下一个case
        /// </summary>
        public bool LinkToNext { get; set; }
    }

    /// <summary>
    /// SwitchStepBuilderCaseExtension
    /// </summary>
    public static class SwitchStepBuilderCaseExtension
    {
        /// <summary>
        /// LinkToNext
        /// </summary>
        public static TSwitchStepBuilderCase SetConditionExpression<TSwitchStepBuilderCase>(this TSwitchStepBuilderCase switchStepBuilderCase, DataKey conditionExpression)
            where TSwitchStepBuilderCase : SwitchStepBuilderCase
        {
            switchStepBuilderCase.ConditionExpression = conditionExpression;

            return switchStepBuilderCase;
        }

        /// <summary>
        /// LinkToNext
        /// </summary>
        public static TSwitchStepBuilderCase SetLinkToNext<TSwitchStepBuilderCase>(this TSwitchStepBuilderCase switchStepBuilderCase, bool linkToNext)
            where TSwitchStepBuilderCase : SwitchStepBuilderCase
        {
            switchStepBuilderCase.LinkToNext = linkToNext;

            return switchStepBuilderCase;
        }
    }
}
