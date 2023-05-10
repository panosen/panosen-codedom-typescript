using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_14 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var chain = codeMethod.StepStatementChain("services");
            {
                chain.AddCallMethodExpression("AddAuth").AddParameter("Scheme");
            }
            {
                var exp = chain.AddCallMethodExpression("AddJwtBearer");
                exp.AddParameter("OK");
                var lamda = exp.AddParameterOfLamdaStepBuilderCollection();
                lamda.AddParameter("any", "options");
                lamda.StepStatement("//ok");
                lamda.StepStatement("x = 1;");
            }
        }

        protected override string PrepareExpected()
        {
            return @"TestMethod(): void {
    services.AddAuth(Scheme).AddJwtBearer(OK, (options: any) => {
        //ok
        x = 1;
    });
}
";
        }
    }
}
