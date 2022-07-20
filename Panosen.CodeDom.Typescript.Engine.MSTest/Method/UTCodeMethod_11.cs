using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_11 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var assignment = codeMethod.StepAssignment();
            assignment.SetLeft("var x");
            assignment.SetRightOfCallMethodExpression().SetMethodName("calc");
        }

        protected override string PrepareExpected()
        {
            return @"public TestMethod()
{
    var x = calc();
}
";
        }
    }
}
