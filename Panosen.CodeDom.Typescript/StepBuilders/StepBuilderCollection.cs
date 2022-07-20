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
    public interface IStepBuilderCollection
    {
        /// <summary>
        /// StepBuilders
        /// </summary>
        List<StepBuilderOrCollection> StepBuilders { get; set; }
    }

    /// <summary>
    /// 一批语句
    /// </summary>
    public class StepBuilderCollection : StepBuilderOrCollection, IStepBuilderCollection
    {
        #region IStepBuilderCollection Members

        /// <summary>
        /// IStepBuilderCollection.StepBuilders
        /// </summary>
        public List<StepBuilderOrCollection> StepBuilders { get; set; }

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
        public static TStepBuilderCollection Step<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, StepBuilder stepBuilder)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            stepBuilderCollection.StepBuilders.Add(stepBuilder);

            return stepBuilderCollection;
        }

        /// <summary>
        /// 添加一个空行
        /// </summary>
        public static TStepBuilderCollection StepEmpty<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            stepBuilderCollection.StepBuilders.Add(new EmptyStepBuilder());

            return stepBuilderCollection;
        }

        /// <summary>
        /// 添加一个步骤
        /// </summary>
        public static TStepBuilderCollection StepStatement<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string statement)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            StatementStepBuilder statementStepBuilder = new StatementStepBuilder();
            statementStepBuilder.Statement = statement;
            stepBuilderCollection.StepBuilders.Add(statementStepBuilder);

            return stepBuilderCollection;
        }

        /// <summary>
        /// 添加一个 using 块
        /// </summary>
        public static UsingStepBuilder StepUsing<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string content = null)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            UsingStepBuilder usingStepBuilder = new UsingStepBuilder();
            usingStepBuilder.Content = content;

            stepBuilderCollection.StepBuilders.Add(usingStepBuilder);

            return usingStepBuilder;
        }

        /// <summary>
        /// 添加一个 if 块
        /// </summary>
        public static IfStepBuilder StepIf<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string condition = null)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            IfStepBuilder ifStepBuilder = new IfStepBuilder();
            ifStepBuilder.Condition = condition;

            stepBuilderCollection.StepBuilders.Add(ifStepBuilder);

            return ifStepBuilder;
        }

        /// <summary>
        /// 添加一个 if 块
        /// </summary>
        public static WhileStepBuilder StepWhile<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string condition = null)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            WhileStepBuilder whileStepBuilder = new WhileStepBuilder();
            whileStepBuilder.Condition = condition;

            stepBuilderCollection.StepBuilders.Add(whileStepBuilder);

            return whileStepBuilder;
        }

        /// <summary>
        /// switch语句块
        /// </summary>
        public static SwitchStepBuilder StepSwitch<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string expression = null)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            SwitchStepBuilder switchStepBuilder = new SwitchStepBuilder();
            switchStepBuilder.Expression = expression;

            stepBuilderCollection.StepBuilders.Add(switchStepBuilder);

            return switchStepBuilder;
        }

        /// <summary>
        /// 添加一个 try 块
        /// </summary>
        public static TryStepBuilder StepTry<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            TryStepBuilder ifStepBuilder = new TryStepBuilder();

            stepBuilderCollection.StepBuilders.Add(ifStepBuilder);

            return ifStepBuilder;
        }

        /// <summary>
        /// 添加一个 foreach 块
        /// </summary>
        public static ForeachStepBuilder StepForeach<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string item, string items)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            return StepForeach(stepBuilderCollection, null, item, items);
        }

        /// <summary>
        /// 添加一个 foreach 块
        /// </summary>
        public static ForeachStepBuilder StepForeach<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string type, string item, string items)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            ForeachStepBuilder foreachStepBuilder = new ForeachStepBuilder();
            foreachStepBuilder.Type = type;
            foreachStepBuilder.Item = item;
            foreachStepBuilder.Items = items;

            stepBuilderCollection.StepBuilders.Add(foreachStepBuilder);

            return foreachStepBuilder;
        }

        /// <summary>
        /// 添加一个 for 块
        /// </summary>
        public static ForStepBuilder StepFor<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string start, string middle, string end)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            ForStepBuilder forStepBuilder = new ForStepBuilder();
            forStepBuilder.Start = start;
            forStepBuilder.Middle = middle;
            forStepBuilder.End = end;

            stepBuilderCollection.StepBuilders.Add(forStepBuilder);

            return forStepBuilder;
        }

        /// <summary>
        /// 添加一个代码块
        /// </summary>
        public static BlockStepBuilder StepBlock<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            BlockStepBuilder blockStepBuilder = new BlockStepBuilder();

            stepBuilderCollection.StepBuilders.Add(blockStepBuilder);

            return blockStepBuilder;
        }

        /// <summary>
        /// 添加一个缩进块
        /// </summary>
        public static PushIndentStepBuilder StepPushIndent<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string key)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            PushIndentStepBuilder pushIndentStepBuilder = new PushIndentStepBuilder();
            pushIndentStepBuilder.Key = key;

            stepBuilderCollection.StepBuilders.Add(pushIndentStepBuilder);

            return pushIndentStepBuilder;
        }

        /// <summary>
        /// 调用方法
        /// </summary>
        public static StatementChainStepBuilder StepStatementChain<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection, string target = null)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            StatementChainStepBuilder statementChainStepBuilder = new StatementChainStepBuilder();
            statementChainStepBuilder.Target = target;

            stepBuilderCollection.StepBuilders.Add(statementChainStepBuilder);

            return statementChainStepBuilder;
        }

        /// <summary>
        /// 为变量赋值
        /// </summary>
        public static AssignmentStepBuilder StepAssignment<TStepBuilderCollection>(this TStepBuilderCollection stepBuilderCollection)
            where TStepBuilderCollection : IStepBuilderCollection
        {
            if (stepBuilderCollection.StepBuilders == null)
            {
                stepBuilderCollection.StepBuilders = new List<StepBuilderOrCollection>();
            }

            AssignmentStepBuilder assignVariableStepBuilder = new AssignmentStepBuilder();

            stepBuilderCollection.StepBuilders.Add(assignVariableStepBuilder);

            return assignVariableStepBuilder;
        }
    }
}
