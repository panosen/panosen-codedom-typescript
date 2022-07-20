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

            chain.AddCallMethodExpression("Where")
                .AddParameterOfLamdaExpression().SetParameter("v").SetExpression($"v.Name == name");

            chain.AddCallMethodExpression("Select").AddParameterOfLamdaNewInstance().SetClassName($"CasLocationVo").SetParameter("v")
                .StepStatement($"Value = \"country:\" + v.Value")
                .StepStatement($"Label = v.Label");

            chain.AddCallMethodExpression("Select", true).AddParameterOfLamdaNewInstance().SetClassName($"CasLocationVo").SetParameter("v")
                .StepStatement($"Value = \"country:\" + v.Value")
                .StepStatement($"Label = v.Label");

            chain.AddCallMethodExpression("ToListA");
            chain.AddCallMethodExpression("ToListB");
        }

        protected override string PrepareExpected()
        {
            return @"TestMethod(): void {
    response.Items = bookDBContext.Countrys.Where(v => v.Name == name).Select(v => new CasLocationVo
    {
        Value = ""country:"" + v.Value,
        Label = v.Label
    })
        .Select(v => new CasLocationVo
        {
            Value = ""country:"" + v.Value,
            Label = v.Label
        }).ToListA().ToListB();
}
";
        }
    }
}
