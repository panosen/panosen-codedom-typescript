using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest
{
    [TestClass]
    public class UT_CodeFile
    {
        [TestMethod]
        public void TestMethod1()
        {
            var option = GetData();

            TypescriptCodeEngine generator = new TypescriptCodeEngine();

            StringBuilder builder = new StringBuilder();

            generator.GenerateCodeFile(option, builder);

            var actual = builder.ToString();

            var expeced = @"import Ref, { List } from 'core';

import Ok from 'ok';

import ZhangSan from './zhang-san';

/**
 * Myclass 0
 */
class MyClass0 {
}

/**
 * Myclass 1
 */
class MyClass1 {
}
";

            Assert.AreEqual(expeced, actual);
        }

        private CodeFile GetData()
        {
            CodeFile codeFile = new CodeFile();

            codeFile.AddSystemImport("Ref", "core");
            codeFile.AddSystemImport("List", "core", null, true);

            codeFile.AddNpmImport("Ok", "ok");

            codeFile.AddProjectImport("ZhangSan", "./zhang-san");


            for (int i = 0; i < 2; i++)
            {
                codeFile.AddClass($"MyClass{i}", summary: $"Myclass {i}");
            }

            return codeFile;
        }
    }
}
