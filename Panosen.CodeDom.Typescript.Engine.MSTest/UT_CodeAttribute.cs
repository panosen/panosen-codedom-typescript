using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Panosen.CodeDom.Typescript.Engine.MSTest
{
    [TestClass]
    public class UT_CodeAttribute : UTBase
    {
        protected override string PrepareExpected()
        {
            return @"class Student {

    @Apple
    @Banana(1)
    @Candy(""2"")
    @Dog(""3"", ""4"")
    public int Property0 { get; set; }
}
";
        }

        protected override Code PrepareCode()
        {
            CodeClass codeClass = new CodeClass();
            codeClass.Name = "Student";

            {
                var codeProperty = codeClass.AddProperty("int", $"Property0");
                codeProperty.AddVariableDecorator("Apple");
                codeProperty.AddMethodDecorator("Banana").AddPlainParam("1");
                codeProperty.AddMethodDecorator("Candy").AddStringParam("2");
                codeProperty.AddMethodDecorator("Dog").AddStringParam("3").AddStringParam("4");
            }

            return codeClass;
        }
    }
}
