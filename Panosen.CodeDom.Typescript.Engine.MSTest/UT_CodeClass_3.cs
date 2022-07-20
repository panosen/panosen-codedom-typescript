using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest
{
    [TestClass]
    public class UT_CodeClass_3 : UTBase
    {
        protected override string PrepareExpected()
        {
            return @"/// <summary>
/// 学生
/// </summary>
public class Student<T>
{
}
";
        }

        protected override Code PrepareCode()
        {
            CodeClass codeClass = new CodeClass();
            codeClass.Name = "Student";
            codeClass.Summary = "学生";
            codeClass.AccessModifiers = AccessModifiers.Public;

            codeClass.AddGenericParameter("T");

            return codeClass;
        }
    }
}
