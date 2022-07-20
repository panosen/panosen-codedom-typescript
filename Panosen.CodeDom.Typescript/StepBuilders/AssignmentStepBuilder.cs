using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// 赋值
    /// </summary>
    public class AssignmentStepBuilder : StepBuilder
    {
        /// <summary>
        /// 等号左边的变量
        /// </summary>
        public string Left { get; set; }

        /// <summary>
        /// 等号右边的值
        /// </summary>
        public CodeExpression Right { get; set; }
    }

    /// <summary>
    /// AssignStepBuilder Extension
    /// </summary>
    public static class AssignmentStepBuilderExtension
    {
        /// <summary>
        /// 设置等号左边的变量
        /// </summary>
        public static TAssignmentStepBuilder SetLeft<TAssignmentStepBuilder>(this TAssignmentStepBuilder assignVariableStepBuilder, string left)
            where TAssignmentStepBuilder : AssignmentStepBuilder
        {
            assignVariableStepBuilder.Left = left;

            return assignVariableStepBuilder;
        }

        /// <summary>
        /// 设置等号右边的变量
        /// </summary>
        public static TAssignmentStepBuilder SetRight<TAssignmentStepBuilder>(this TAssignmentStepBuilder assignVariableStepBuilder, string right)
            where TAssignmentStepBuilder : AssignmentStepBuilder
        {
            assignVariableStepBuilder.Left = right;

            return assignVariableStepBuilder;
        }

        /// <summary>
        /// 设置等号右边的值
        /// </summary>
        public static TAssignmentStepBuilder SetRight<TAssignmentStepBuilder>(this TAssignmentStepBuilder assignmentStepBuilder, CodeExpression codeExpression)
            where TAssignmentStepBuilder : AssignmentStepBuilder
        {
            assignmentStepBuilder.Right = codeExpression;

            return assignmentStepBuilder;
        }

        /// <summary>
        /// 设置等号右边的值
        /// </summary>
        private static TCodeExpression SetRight<TCodeExpression>(this AssignmentStepBuilder assignmentStepBuilder)
            where TCodeExpression : CodeExpression, new()
        {
            TCodeExpression codeExpression = new TCodeExpression();

            assignmentStepBuilder.Right = codeExpression;

            return codeExpression;
        }

        /// <summary>
        /// 设置等号右边的值
        /// </summary>
        public static ReferenceExpression SetRightOfReferenceExpression<TAssignmentStepBuilder>(this TAssignmentStepBuilder assignmentStepBuilder)
            where TAssignmentStepBuilder : AssignmentStepBuilder
        {
            return SetRight<ReferenceExpression>(assignmentStepBuilder);
        }

        /// <summary>
        /// 设置等号右边的值
        /// </summary>
        public static CallMethodExpression SetRightOfCallMethodExpression<TAssignmentStepBuilder>(this TAssignmentStepBuilder assignmentStepBuilder, string methodName = null)
            where TAssignmentStepBuilder : AssignmentStepBuilder
        {
            return SetRight<CallMethodExpression>(assignmentStepBuilder).SetMethodName(methodName);
        }
    }
}
