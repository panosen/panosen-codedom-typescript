using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_2 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            codeMethod.StepStatement("name = age.ToString();");
            codeMethod.StepStatement("name = age.ToString();");
        }

        protected override string PrepareExpected()
        {
            return @"public TestMethod()
{
    name = age.ToString();
    name = age.ToString();
}
";
        }
    }
}
