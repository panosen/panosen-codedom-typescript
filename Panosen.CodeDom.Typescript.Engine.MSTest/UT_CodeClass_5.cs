using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest
{
    [TestClass]
    public class UT_CodeClass_5 : UTBase
    {
        protected override string PrepareExpected()
        {
            return @"/**
 * 学生
 */
public class Student {

    @Newtonsoft.Json.JsonProperty(""age"", Newtonsoft.Json.NullValueHandling.Ignore)
    public int Age { get; set; }

    @Newtonsoft.Json.JsonProperty(""name"")
    public string Name { get; set; }

    @Newtonsoft.Json.JsonProperty(""123"")
    public string Remark { get; set; }
}
";
        }

        protected override Code PrepareCode()
        {
            CodeClass codeClass = new CodeClass();
            codeClass.Name = "Student";
            codeClass.Summary = "学生";
            codeClass.AccessModifiers = AccessModifiers.Public;

            codeClass.AddProperty("int", "Age")
                .AddMethodDecorator("Newtonsoft.Json.JsonProperty")
                .AddStringParam("age")
                .AddPlainParam("Newtonsoft.Json.NullValueHandling.Ignore");

            codeClass.AddProperty("string", "Name")
                .AddMethodDecorator("Newtonsoft.Json.JsonProperty")
                .AddStringParam("name");

            codeClass.AddProperty("string", "Remark")
                .AddMethodDecorator("Newtonsoft.Json.JsonProperty")
                .AddStringParam("123");

            return codeClass;
        }
    }
}
