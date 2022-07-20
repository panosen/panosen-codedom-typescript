using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_1 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            codeMethod.Parameters = new List<CodeParameter>();
            codeMethod.Parameters.Add(new CodeParameter { Name = "name", Type = "string" });
            codeMethod.Parameters.Add(new CodeParameter { Name = "age", Type = "int" });
        }

        protected override string PrepareExpected()
        {
            return @"public TestMethod(string name, int age);
";
        }
    }
}
