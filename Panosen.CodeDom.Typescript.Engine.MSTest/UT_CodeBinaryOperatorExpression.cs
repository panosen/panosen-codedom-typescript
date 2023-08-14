using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest
{
    [TestClass]
    public class UT_CodeBinaryOperatorExpression
    {
        [TestMethod]
        public void Test()
        {
            var expression = PrepareCode();

            TypescriptCodeEngine generator = new TypescriptCodeEngine();

            StringBuilder builder = new StringBuilder();

            generator.GenerateExpresion(expression, builder);

            var actual = builder.ToString();

            var expeced = PrepareExpected();

            Assert.AreEqual(expeced, actual);
        }

        protected BinaryOperatorExpression PrepareCode()
        {
            BinaryOperatorExpression codeExpression = new BinaryOperatorExpression();
            codeExpression.Operator = EnumBinaryOperator.Add;
            codeExpression.Left = "a";
            codeExpression.Right = "b";

            return codeExpression;
        }

        protected string PrepareExpected()
        {
            return @"a + b";
        }
    }
}
