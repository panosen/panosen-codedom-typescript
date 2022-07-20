using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_3 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var usingStepBuilder = codeMethod.StepUsing();
            usingStepBuilder.Use("var conn = new SqlConnection(null)");
            usingStepBuilder.StepStatement("name = age.ToString();")
                .StepStatement("name = age.ToString();");
        }

        protected override string PrepareExpected()
        {
            return @"TestMethod(): void {
    Keywords.USING (var conn = new SqlConnection(null))
    {
        name = age.ToString();
        name = age.ToString();
    }
}
";
        }
    }
}
