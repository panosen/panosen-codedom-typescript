using Microsoft.VisualStudio.TestTools.UnitTesting;
using Panosen.CodeDom.Typescript.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine.MSTest
{
    [TestClass]
    public class Example_CodeClass : UTBase
    {
        protected override Code PrepareCode()
        {
            CodeClass codeClass = new CodeClass();
            codeClass.Name = "Student";
            codeClass.Summary = "学生";
            codeClass.Export = true;

            codeClass.AddInterface("ITom1");
            codeClass.AddInterface("ITom2");

            {
                codeClass.AddVariableDecorator("Component1");
                codeClass.AddMethodDecorator("Component2");

                var dataObject = codeClass.AddMethodDecorator("Component3").AddDataObject();
                dataObject.AddDataValue("name").SetValue("tom");
                dataObject.AddDataValue("age").SetValue("18");
            }

            codeClass.AddConstructor(PrepareConstructor());

            codeClass.AddMethod(PrepareMethod());

            return codeClass;
        }

        private CodeMethod PrepareConstructor()
        {
            CodeMethod codeMethod = new CodeMethod();
            codeMethod.Name = "theCon";

            codeMethod.StepBuilders = new List<StepOrCollection>();

            return codeMethod;
        }

        private CodeMethod PrepareMethod()
        {
            CodeMethod codeMethod = new CodeMethod();
            codeMethod.Name = "calc";

            codeMethod.StepBuilders = new List<StepOrCollection>();

            return codeMethod;
        }

        protected override string PrepareExpected()
        {
            return @"/**
 * 学生
 */
@Component1
@Component2()
@Component3({
    name: tom,
    age: 18
})
export class Student implements ITom1, ITom2 {

    theCon(): void {
    }

    calc(): void {
    }
}
";
        }
    }
}
