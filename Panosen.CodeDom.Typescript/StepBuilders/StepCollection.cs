using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{

    /// <summary>
    /// 实现此接口的
    /// </summary>
    public interface IStepCollection
    {
        /// <summary>
        /// StepBuilders
        /// </summary>
        List<StepOrCollection> StepBuilders { get; set; }
    }

    /// <summary>
    /// 一批语句
    /// </summary>
    public class StepCollection : StepOrCollection, IStepCollection
    {
        #region IStepBuilderCollection Members

        /// <summary>
        /// IStepBuilderCollection.StepBuilders
        /// </summary>
        public List<StepOrCollection> StepBuilders { get; set; }

        #endregion
    }

    /// <summary>
    /// StepBuilderCollection 扩展
    /// </summary>
    public static class IStepBuilderCollectionExtension
    {
        /// <summary>
        /// 添加一个步骤
        /// </summary>
        public static TStepBuilderCollection Step<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, Step stepBuilder)
            where TStepBuilderCollection : IStepCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepOrCollection>();
            }

            stepBuilderCollection.StepBuilders.Add(stepBuilder);

            return stepBuilderCollection;
        }

        /// <summary>
        /// 添加一个空行
        /// </summary>
        public static TStepBuilderCollection StepEmpty<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection)
            where TStepBuilderCollection : IStepCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepOrCollection>();
            }

            stepBuilderCollection.StepBuilders.Add(new EmptyStep());

            return stepBuilderCollection;
        }

        /// <summary>
        /// 添加一个步骤
        /// </summary>
        public static TStepBuilderCollection StepStatement<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string statement)
            where TStepBuilderCollection : IStepCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepOrCollection>();
            }

            StatementStep statementStepBuilder = new StatementStep();
            statementStepBuilder.Statement = statement;
            stepBuilderCollection.StepBuilders.Add(statementStepBuilder);

            return stepBuilderCollection;
        }

        /// <summary>
        /// 添加一个 using 块
        /// </summary>
        public static UsingStep StepUsing<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string content = null)
            where TStepBuilderCollection : IStepCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepOrCollection>();
            }

            UsingStep usingStepBuilder = new UsingStep();
            usingStepBuilder.Content = content;

            stepBuilderCollection.StepBuilders.Add(usingStepBuilder);

            return usingStepBuilder;
        }

        /// <summary>
        /// 添加一个 if 块
        /// </summary>
        public static IfStep StepIf<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string condition = null)
            where TStepBuilderCollection : IStepCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepOrCollection>();
            }

            IfStep ifStepBuilder = new IfStep();
            ifStepBuilder.Condition = condition;

            stepBuilderCollection.StepBuilders.Add(ifStepBuilder);

            return ifStepBuilder;
        }

        /// <summary>
        /// 添加一个 if 块
        /// </summary>
        public static WhileStep StepWhile<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string condition = null)
            where TStepBuilderCollection : IStepCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepOrCollection>();
            }

            WhileStep whileStepBuilder = new WhileStep();
            whileStepBuilder.Condition = condition;

            stepBuilderCollection.StepBuilders.Add(whileStepBuilder);

            return whileStepBuilder;
        }

        /// <summary>
        /// switch语句块
        /// </summary>
        public static SwitchStep StepSwitch<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string expression = null)
            where TStepBuilderCollection : IStepCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepOrCollection>();
            }

            SwitchStep switchStepBuilder = new SwitchStep();
            switchStepBuilder.Expression = expression;

            stepBuilderCollection.StepBuilders.Add(switchStepBuilder);

            return switchStepBuilder;
        }

        /// <summary>
        /// 添加一个 try 块
        /// </summary>
        public static TryStep StepTry<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection)
            where TStepBuilderCollection : IStepCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepOrCollection>();
            }

            TryStep ifStepBuilder = new TryStep();

            stepBuilderCollection.StepBuilders.Add(ifStepBuilder);

            return ifStepBuilder;
        }

        /// <summary>
        /// 添加一个 foreach 块
        /// </summary>
        public static ForeachStep StepForeach<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string item, string items)
            where TStepBuilderCollection : IStepCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepOrCollection>();
            }

            return StepForeach(stepBuilderCollection, null, item, items);
        }

        /// <summary>
        /// 添加一个 foreach 块
        /// </summary>
        public static ForeachStep StepForeach<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string type, string item, string items)
            where TStepBuilderCollection : IStepCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepOrCollection>();
            }

            ForeachStep foreachStepBuilder = new ForeachStep();
            foreachStepBuilder.Type = type;
            foreachStepBuilder.Item = item;
            foreachStepBuilder.Items = items;

            stepBuilderCollection.StepBuilders.Add(foreachStepBuilder);

            return foreachStepBuilder;
        }

        /// <summary>
        /// 添加一个 for 块
        /// </summary>
        public static ForStep StepFor<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string start, string middle, string end)
            where TStepBuilderCollection : IStepCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepOrCollection>();
            }

            ForStep forStepBuilder = new ForStep();
            forStepBuilder.Start = start;
            forStepBuilder.Middle = middle;
            forStepBuilder.End = end;

            stepBuilderCollection.StepBuilders.Add(forStepBuilder);

            return forStepBuilder;
        }

        /// <summary>
        /// 添加一个代码块
        /// </summary>
        public static BlockStep StepBlock<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection)
            where TStepBuilderCollection : IStepCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepOrCollection>();
            }

            BlockStep blockStepBuilder = new BlockStep();

            stepBuilderCollection.StepBuilders.Add(blockStepBuilder);

            return blockStepBuilder;
        }

        /// <summary>
        /// 添加一个缩进块
        /// </summary>
        public static PushIndentStep StepPushIndent<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string key)
            where TStepBuilderCollection : IStepCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepOrCollection>();
            }

            PushIndentStep pushIndentStepBuilder = new PushIndentStep();
            pushIndentStepBuilder.Key = key;

            stepBuilderCollection.StepBuilders.Add(pushIndentStepBuilder);

            return pushIndentStepBuilder;
        }

        /// <summary>
        /// 调用方法
        /// </summary>
        public static StatementChainStep StepStatementChain<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string target = null)
            where TStepBuilderCollection : IStepCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepOrCollection>();
            }

            StatementChainStep statementChainStepBuilder = new StatementChainStep();
            statementChainStepBuilder.Target = target;

            stepBuilderCollection.StepBuilders.Add(statementChainStepBuilder);

            return statementChainStepBuilder;
        }

        /// <summary>
        /// 为变量赋值
        /// </summary>
        public static AssignmentStep StepAssignment<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection)
            where TStepBuilderCollection : IStepCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepOrCollection>();
            }

            AssignmentStep assignVariableStepBuilder = new AssignmentStep();

            stepBuilderCollection.StepBuilders.Add(assignVariableStepBuilder);

            return assignVariableStepBuilder;
        }
    }
}
