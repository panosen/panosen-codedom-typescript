using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_15 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var chain = codeMethod.StepStatementChain();
            chain.AddCallMethodExpression("MethodA");
            chain.AddCallMethodExpression("MethodB");
        }

        protected override string PrepareExpected()
        {
            return @"public TestMethod()
{
    MethodA().MethodB();
}
";
        }
    }
}
