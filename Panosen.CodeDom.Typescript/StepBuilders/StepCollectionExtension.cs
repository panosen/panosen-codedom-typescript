using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// StepCollection 扩展
    /// </summary>
    public static class StepCollectionExtension
    {
        /// <summary>
        /// 添加一个步骤
        /// </summary>
        public static TStepCollection AddStep<TStepCollection>(this TStepCollection stepBuilderCollection, Step stepBuilder)
            where TStepCollection : StepCollection
        {
            stepBuilderCollection.Steps.Add(stepBuilder);

            return stepBuilderCollection;
        }

        /// <summary>
        /// 添加一个步骤
        /// </summary>
        public static TStepCollection AddStep<TStepCollection>(this TStepCollection stepBuilderCollection, string name, Step stepBuilder)
            where TStepCollection : StepCollection
        {
            stepBuilderCollection.Steps.Add(stepBuilder);
            stepBuilderCollection.StepMap.Add(name, stepBuilder);

            return stepBuilderCollection;
        }

        /// <summary>
        /// 添加一个步骤集合
        /// </summary>
        public static TStepCollection AddStepCollection<TStepCollection>(this TStepCollection stepBuilderCollection, StepCollection stepBuilder)
            where TStepCollection : StepCollection
        {
            stepBuilderCollection.Steps.Add(stepBuilder);

            return stepBuilderCollection;
        }

        /// <summary>
        /// 添加一个步骤集合
        /// </summary>
        public static TStepCollection AddStepCollection<TStepCollection>(this TStepCollection stepBuilderCollection, string name, StepCollection stepBuilder)
            where TStepCollection : StepCollection
        {
            stepBuilderCollection.Steps.Add(stepBuilder);
            stepBuilderCollection.StepMap.Add(name, stepBuilder);

            return stepBuilderCollection;
        }

        /// <summary>
        /// 添加一个步骤集合
        /// </summary>
        public static StepCollection AddStepCollection<TStepCollection>(this TStepCollection stepBuilderCollection)
            where TStepCollection : StepCollection
        {
            StepCollection stepBuilder = new StepCollection();

            stepBuilderCollection.Steps.Add(stepBuilder);

            return stepBuilder;
        }

        /// <summary>
        /// 添加一个步骤集合
        /// </summary>
        public static StepCollection AddStepCollection<TStepCollection>(this TStepCollection stepBuilderCollection, string name)
            where TStepCollection : StepCollection
        {
            StepCollection stepBuilder = new StepCollection();

            stepBuilderCollection.Steps.Add(stepBuilder);
            stepBuilderCollection.StepMap.Add(name, stepBuilder);

            return stepBuilder;
        }

        /// <summary>
        /// 添加一个空行
        /// </summary>
        public static TStepCollection StepEmpty<TStepCollection>(this TStepCollection stepBuilderCollection)
            where TStepCollection : StepCollection
        {
            stepBuilderCollection.Steps.Add(new EmptyStep());

            return stepBuilderCollection;
        }

        /// <summary>
        /// 添加一个步骤
        /// </summary>
        public static TStepCollection StepStatement<TStepCollection>(this TStepCollection stepBuilderCollection, string statement)
            where TStepCollection : StepCollection
        {
            StatementStep statementStep = new StatementStep();
            statementStep.Statement = statement;
            stepBuilderCollection.Steps.Add(statementStep);

            return stepBuilderCollection;
        }

        /// <summary>
        /// 添加一个 using 块
        /// </summary>
        public static UsingStep StepUsing<TStepCollection>(this TStepCollection stepBuilderCollection, string content = null)
            where TStepCollection : StepCollection
        {
            UsingStep usingStep = new UsingStep();
            usingStep.Content = content;

            stepBuilderCollection.Steps.Add(usingStep);

            return usingStep;
        }

        /// <summary>
        /// 添加一个 if 块
        /// </summary>
        public static IfStep StepIf<TStepCollection>(this TStepCollection stepBuilderCollection, string condition = null)
            where TStepCollection : StepCollection
        {
            IfStep ifStep = new IfStep();
            ifStep.Condition = condition;

            stepBuilderCollection.Steps.Add(ifStep);

            return ifStep;
        }

        /// <summary>
        /// 添加一个 if 块
        /// </summary>
        public static WhileStep StepWhile<TStepCollection>(this TStepCollection stepBuilderCollection, string condition = null)
            where TStepCollection : StepCollection
        {
            WhileStep whileStep = new WhileStep();
            whileStep.Condition = condition;

            stepBuilderCollection.Steps.Add(whileStep);

            return whileStep;
        }

        /// <summary>
        /// switch语句块
        /// </summary>
        public static SwitchStep StepSwitch<TStepCollection>(this TStepCollection stepBuilderCollection, string expression = null)
            where TStepCollection : StepCollection
        {
            SwitchStep switchStep = new SwitchStep();
            switchStep.Expression = expression;

            stepBuilderCollection.Steps.Add(switchStep);

            return switchStep;
        }

        /// <summary>
        /// 添加一个 try 块
        /// </summary>
        public static TryStep StepTry<TStepCollection>(this TStepCollection stepBuilderCollection)
            where TStepCollection : StepCollection
        {
            TryStep ifStep = new TryStep();

            stepBuilderCollection.Steps.Add(ifStep);

            return ifStep;
        }

        /// <summary>
        /// 添加一个 foreach 块
        /// </summary>
        public static ForeachStep StepForeach<TStepCollection>(this TStepCollection stepBuilderCollection, string item, string items)
            where TStepCollection : StepCollection
        {
            return StepForeach(stepBuilderCollection, null, item, items);
        }

        /// <summary>
        /// 添加一个 foreach 块
        /// </summary>
        public static ForeachStep StepForeach<TStepCollection>(this TStepCollection stepBuilderCollection, string type, string item, string items)
            where TStepCollection : StepCollection
        {
            ForeachStep foreachStep = new ForeachStep();
            foreachStep.Type = type;
            foreachStep.Item = item;
            foreachStep.Items = items;

            stepBuilderCollection.Steps.Add(foreachStep);

            return foreachStep;
        }

        /// <summary>
        /// 添加一个 for 块
        /// </summary>
        public static ForStep StepFor<TStepCollection>(this TStepCollection stepBuilderCollection, string start, string middle, string end)
            where TStepCollection : StepCollection
        {
            ForStep forStep = new ForStep();
            forStep.Start = start;
            forStep.Middle = middle;
            forStep.End = end;

            stepBuilderCollection.Steps.Add(forStep);

            return forStep;
        }

        /// <summary>
        /// 添加一个代码块
        /// </summary>
        public static BlockStep StepBlock<TStepCollection>(this TStepCollection stepBuilderCollection)
            where TStepCollection : StepCollection
        {
            BlockStep blockStep = new BlockStep();

            stepBuilderCollection.Steps.Add(blockStep);

            return blockStep;
        }

        /// <summary>
        /// 添加一个缩进块
        /// </summary>
        public static PushIndentStep StepPushIndent<TStepCollection>(this TStepCollection stepBuilderCollection, string key)
            where TStepCollection : StepCollection
        {
            PushIndentStep pushIndentStep = new PushIndentStep();
            pushIndentStep.Key = key;

            stepBuilderCollection.Steps.Add(pushIndentStep);

            return pushIndentStep;
        }

        /// <summary>
        /// 调用方法
        /// </summary>
        public static StatementChainStep StepStatementChain<TStepCollection>(this TStepCollection stepBuilderCollection, string target = null)
            where TStepCollection : StepCollection
        {
            StatementChainStep statementChainStep = new StatementChainStep();
            statementChainStep.Target = target;

            stepBuilderCollection.Steps.Add(statementChainStep);

            return statementChainStep;
        }

        /// <summary>
        /// 为变量赋值
        /// </summary>
        public static AssignmentStep StepAssignment<TStepCollection>(this TStepCollection stepBuilderCollection)
            where TStepCollection : StepCollection
        {
            AssignmentStep assignVariableStep = new AssignmentStep();

            stepBuilderCollection.Steps.Add(assignVariableStep);

            return assignVariableStep;
        }
    }
}
