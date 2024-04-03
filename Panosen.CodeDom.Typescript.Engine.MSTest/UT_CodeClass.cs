using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest
{
    [TestClass]
    public class UT_CodeClass : UTBase
    {
        protected override string PrepareExpected()
        {
            return @"/**
 * 学生
 */
export class Student {

    /**
     * 常量 0
     */
    const Constant0: string = ""aa"";

    /**
     * 常量 1
     */
    const Constant1: string = ""aa"";

    /**
     * 字段 0
     */
    private Field0: string;

    /**
     * 字段 1
     */
    private Field1: string;

    /**
     * 字段 2
     */
    private Field2: number = 222;

    /**
     * 字段 3
     */
    private Field3: string = ""333"";

    public TheConstructor() {
    }

    /**
     * 方法 0
     */
    public Method0(p1: number, p2: number, p3: number): number {
    }

    /**
     * 方法 1
     */
    public Method1(p1: number, p2: number, p3: number): number {
    }

    methodX(
        p1: number,
        p2: number,
        p3: number,
        p4: number
    ): void {
    }
}
";
        }

        protected override CodeClass PrepareCode()
        {
            CodeClass codeClass = new CodeClass();
            codeClass.Name = "Student";
            codeClass.Summary = "学生";
            codeClass.Export = true;

            {
                codeClass.AddField("string", "Field0", summary: "字段 0");
            }
            {
                codeClass.AddField("string", "Field1", summary: "字段 1");
            }
            {
                codeClass.AddField("number", "Field2", summary: "字段 2", value: (DataValue)222);
            }
            {
                codeClass.AddField("string", "Field3", summary: "字段 3", value: DataValue.DoubleQuotationString("333"));
            }

            codeClass.ConstantList = new List<CodeConstant>();
            for (int i = 0; i < 2; i++)
            {
                var codeConstant = new CodeConstant();
                codeClass.ConstantList.Add(codeConstant);

                codeConstant.Name = $"Constant{i}";
                codeConstant.Type = "string";
                codeConstant.Value = "\"aa\"";
                codeConstant.Summary = $"常量 {i}";
            }

            codeClass.MethodList = new List<CodeMethod>();
            for (int i = 0; i < 2; i++)
            {
                var codeMethod = new CodeMethod();
                codeClass.MethodList.Add(codeMethod);

                codeMethod.Name = $"Method{i}";
                codeMethod.Type = "number";
                codeMethod.Summary = $"方法 {i}";
                codeMethod.AccessModifiers = AccessModifiers.Public;

                codeMethod.StepCollection = new StepCollection();

                codeMethod.Parameters = new List<CodeParameter>();
                for (int j = 0; j < 3; j++)
                {
                    var codeParameter = new CodeParameter();
                    codeMethod.Parameters.Add(codeParameter);

                    codeParameter.Name = $"p{j + 1}";
                    codeParameter.Type = "number";
                }
            }

            var methodX = codeClass.AddMethod("methodX");
            methodX.Type = "void";
            for (int i = 0; i < 4; i++)
            {
                methodX.AddParameter("number", $"p{i + 1}");
            }
            methodX.StepCollection = new StepCollection();

            codeClass.AddConstructor(new CodeMethod
            {
                Name = "TheConstructor",
                AccessModifiers = AccessModifiers.Public,
                StepCollection = new StepCollection()
            });

            return codeClass;
        }
    }
}
