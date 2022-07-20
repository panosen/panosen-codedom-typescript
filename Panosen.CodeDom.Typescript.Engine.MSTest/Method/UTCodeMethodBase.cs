using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest.Method
{
    public abstract class UTCodeMethodBase
    {
        [TestMethod]
        public void Test()
        {
            CodeMethod codeMethod = new CodeMethod();
            codeMethod.Name = "TestMethod";

            PrepareCodeMethod(codeMethod);

            TypescriptCodeEngine generator = new TypescriptCodeEngine();

            StringBuilder builder = new StringBuilder();

            generator.GenerateMethod(codeMethod, builder);

            var actual = builder.ToString();

            var expeced = PrepareExpected();

            Assert.AreEqual(expeced, actual);
        }

        protected abstract void PrepareCodeMethod(CodeMethod codeMethod);

        protected abstract string PrepareExpected();
    }
}
