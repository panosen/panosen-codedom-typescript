using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_17 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var switchStepBuilder = codeMethod.StepSwitch("value");
            for (int i = 0; i < 3; i++)
            {
                var tempCase = switchStepBuilder.WithCase(i);
                {
                    tempCase.StepStatement("//test");
                    tempCase.StepStatement($"console.log({i})");
                }
            }
            for (int i = 3; i < 6; i++)
            {
                var tempCase = switchStepBuilder.WithCase(i);
            }
            for (int i = 6; i < 9; i++)
            {
                var tempCase = switchStepBuilder.WithCase(i).SetLinkToNext(true);
            }
            {
                var defaultCase = switchStepBuilder.WithDefault();
                defaultCase.StepStatement("//test");
                defaultCase.StepStatement($"console.log(11)");
            }
        }

        protected override string PrepareExpected()
        {
            return @"public TestMethod()
{
    switch (value)
    {
        case 0:
            {
                //test
                console.log(0)
            }
            break;
        case 1:
            {
                //test
                console.log(1)
            }
            break;
        case 2:
            {
                //test
                console.log(2)
            }
            break;
        case 3:
            break;
        case 4:
            break;
        case 5:
            break;
        case 6:
        case 7:
        case 8:
        default:
            {
                //test
                console.log(11)
            }
            break;
    }
}
";
        }
    }
}
