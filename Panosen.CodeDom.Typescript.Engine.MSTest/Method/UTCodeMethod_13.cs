﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_13 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var chain = codeMethod.StepStatementChain("services");
            chain.AddCallMethodExpression("AddAuth").AddParameter("Scheme");
            var exp = chain.AddCallMethodExpression("AddJwtBearer");
            exp.AddParameter("OK");
            var builders = exp.AddParameterOfLamdaStepBuilderCollection();
            builders.StepStatement("//ok");
            builders.StepStatement("x = 1;");
        }

        protected override string PrepareExpected()
        {
            return @"TestMethod(): void {
    services.AddAuth(Scheme).AddJwtBearer(OK, () => {
        //ok
        x = 1;
    });
}
";
        }
    }
}
