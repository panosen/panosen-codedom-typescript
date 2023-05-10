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
            var methodd = xx.AddCallMethodExpression("MethodD", true);

            var lamda = methodd.AddParameterOfLamdaNewInstance();
            lamda.AddParameter("any", "v");
            lamda.SetClassName("Student").StepStatement("Name = 2");
        }

        protected override string PrepareExpected()
        {
            return @"TestMethod(): void {
    this.MethodC()
        .MethodD((v: any) => new Student
        {
            Name = 2
        });
}
";
        }
    }
}
