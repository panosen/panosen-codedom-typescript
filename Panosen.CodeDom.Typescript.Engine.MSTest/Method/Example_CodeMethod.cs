using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panosen.CodeDom.Typescript.Engine;
using Panosen.CodeDom.Typescript.Engine.MSTest.Method;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine.MSTest
{
    [TestClass]
    public class Example_CodeMethod : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            codeMethod.Name = "TestMethod";
            codeMethod.Type = "void";

            codeMethod.AddParameter("string", "name");
            codeMethod.AddParameter("number", "age");

            codeMethod.StepStatement("var x = 0;");
        }

        protected override string PrepareExpected()
        {
            return @"TestMethod(name: string, age: number): void {
    var x = 0;
}
";
        }
    }
}
