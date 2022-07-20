using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_10 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var xx = codeMethod.StepStatementChain("this");
            xx.AddCallMethodExpression("MethodC");
            xx.AddCallMethodExpression("MethodD", true).AddParameterOfLamdaNewInstance().SetParameter("v").SetClassName("Student").StepStatement("Name = 2");
        }

        protected override string PrepareExpected()
        {
            return @"public TestMethod()
{
    this.MethodC()
        .MethodD(v => new Student
        {
            Name = 2
        });
}
";
        }
    }
}
