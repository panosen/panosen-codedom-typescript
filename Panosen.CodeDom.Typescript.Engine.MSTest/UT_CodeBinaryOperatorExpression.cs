using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest
{
    [TestClass]
    public class UT_CodeBinaryOperatorExpression : UTBase
    {
        protected override Code PrepareCode()
        {
            BinaryOperatorExpression codeExpression = new BinaryOperatorExpression();
            codeExpression.Operator = EnumBinaryOperator.Add;
            codeExpression.Left = "a";
            codeExpression.Right = "b";

            return codeExpression;
        }

        protected override string PrepareExpected()
        {
            return @"a + b";
        }
    }
}
