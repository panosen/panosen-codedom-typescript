using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_5 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var ifStepBuilder = codeMethod.StepIf("1").StepStatement("ok");
            ifStepBuilder.WithElseIf("b").StepStatement("333");
            ifStepBuilder.WithElseIf("b2").StepStatement("3343");
            ifStepBuilder.WithElse().StepStatement("okok");
        }

        protected override string PrepareExpected()
        {
            return @"TestMethod(): void {
    if (1)
    {
        ok
    }
    else if (b)
    {
        333
    }
    else if (b2)
    {
        3343
    }
    else
    {
        okok
    }
}
";
        }
    }
}
