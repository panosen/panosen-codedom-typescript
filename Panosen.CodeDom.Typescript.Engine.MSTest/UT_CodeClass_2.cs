using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest
{
    [TestClass]
    public class UT_CodeClass_2 : UTBase
    {
        protected override string PrepareExpected()
        {
            return @"/**
 * 学生
 */
public class Student {

    /**
     * 方法 0
     */
    public Method0(p1: int, p2: int, p3: int): int {
    }

    /**
     * 方法 1
     */
    public Method1<THelp, TCalc, TService>(p1: int, p2: int, p3: int)
        Keywords.WHERE THelp : Help, IHelp
        Keywords.WHERE TCalc : Calc, ICalc: int {
    }

    methodX(
        p1: int,
        p2: int,
        p3: int,
        p4: int
    ): void {
    }
}
";
        }

        protected override Code PrepareCode()
        {
            CodeClass codeClass = new CodeClass();
            codeClass.Name = "Student";
            codeClass.Summary = "学生";
            codeClass.AccessModifiers = AccessModifiers.Public;

            {
                var codeMethod = codeClass.AddMethod("Method0", $"方法 0");
                codeMethod.Type = "int";
                codeMethod.AccessModifiers = AccessModifiers.Public;

                for (int j = 0; j < 3; j++)
                {
                    codeMethod.AddParameter("int", $"p{j + 1}");
                }

                codeMethod.StepBuilders = new List<StepBuilderOrCollection>();
            }
            {
                var codeMethod = codeClass.AddMethod("Method1", $"方法 1");
                codeMethod.Type = "int";
                codeMethod.AccessModifiers = AccessModifiers.Public;

                for (int j = 0; j < 3; j++)
                {
                    codeMethod.AddParameter("int", $"p{j + 1}");
                }

                codeMethod.AddGenericParameter("THelp").AddConstraint("Help").AddConstraint("IHelp");
                codeMethod.AddGenericParameter("TCalc").AddConstraint("Calc").AddConstraint("ICalc");
                codeMethod.AddGenericParameter("TService");

                codeMethod.StepBuilders = new List<StepBuilderOrCollection>();
            }

            var methodX = codeClass.AddMethod("methodX");
            for (int i = 0; i < 4; i++)
            {
                methodX.AddParameter("int", $"p{i + 1}");
            }
            methodX.StepBuilders = new List<StepBuilderOrCollection>();

            return codeClass;
        }
    }
}
