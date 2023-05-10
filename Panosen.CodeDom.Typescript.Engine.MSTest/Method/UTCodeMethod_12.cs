using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_12 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var chain = codeMethod.StepStatementChain($"response.Items = bookDBContext.Countrys");

            var where = chain.AddCallMethodExpression("Where");
            var whereA = where.AddParameterOfLamdaExpression();
            whereA.AddParameter("string", "v");
            whereA.SetExpression($"v.Name == name");

            var lamda1 = chain.AddCallMethodExpression("Select").AddParameterOfLamdaNewInstance();
            lamda1.AddParameter("any", "v");
            lamda1.SetClassName($"CasLocationVo")
                .StepStatement($"Value = \"country:\" + v.Value")
                .StepStatement($"Label = v.Label");

            var lamda2 = chain.AddCallMethodExpression("Select", true).AddParameterOfLamdaNewInstance();
            lamda2.AddParameter("any", "v");
            lamda2.SetClassName($"CasLocationVo")
                .StepStatement($"Value = \"country:\" + v.Value")
                .StepStatement($"Label = v.Label");

            chain.AddCallMethodExpression("ToListA");
            chain.AddCallMethodExpression("ToListB");
        }

        protected override string PrepareExpected()
        {
            return @"TestMethod(): void {
    response.Items = bookDBContext.Countrys.Where((v: string) => v.Name == name).Select((v: any) => new CasLocationVo
    {
        Value = ""country:"" + v.Value,
        Label = v.Label
    })
        .Select((v: any) => new CasLocationVo
        {
            Value = ""country:"" + v.Value,
            Label = v.Label
        }).ToListA().ToListB();
}
";
        }
    }
}
