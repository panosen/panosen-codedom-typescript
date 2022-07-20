using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest
{
    [TestClass]
    public class UT_CodeClass_4 : UTBase
    {
        protected override string PrepareExpected()
        {
            return @"/**
 * 学生
 */
public class Student<TAdd, TMinus, TCalc>
    Keywords.WHERE TAdd : Add
    Keywords.WHERE TMinus : Minus, IMinus {
}
";
        }

        protected override Code PrepareCode()
        {
            CodeClass codeClass = new CodeClass();
            codeClass.Name = "Student";
            codeClass.Summary = "学生";
            codeClass.AccessModifiers = AccessModifiers.Public;

            codeClass.AddGenericParameter("TAdd").AddConstraint("Add");
            codeClass.AddGenericParameter("TMinus").AddConstraint("Minus", "IMinus");
            codeClass.AddGenericParameter("TCalc");

            return codeClass;
        }
    }
}
