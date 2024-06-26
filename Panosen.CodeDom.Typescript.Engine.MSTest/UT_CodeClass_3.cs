﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            return @"/**
 * 学生
 */
class Student<T> {
}
";
        }

        protected override CodeClass PrepareCode()
        {
            CodeClass codeClass = new CodeClass();
            codeClass.Name = "Student";
            codeClass.Summary = "学生";

            codeClass.AddGenericParameter("T");

            return codeClass;
        }
    }
}
