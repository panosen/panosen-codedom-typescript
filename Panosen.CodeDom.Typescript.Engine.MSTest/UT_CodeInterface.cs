using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest
{
    [TestClass]
    public class UT_CodeInterface : UTBase
    {
        protected override Code PrepareCode()
        {
            CodeInterface codeInterface = new CodeInterface();
            codeInterface.Name = "IStudentRepository";
            codeInterface.Summary = "Student";
            codeInterface.AccessModifiers = AccessModifiers.Public;

            codeInterface.AddParent("IStudent");
            codeInterface.AddParent("ITeacher");

            codeInterface.MethodList = new List<CodeMethod>();
            for (int i = 0; i < 2; i++)
            {
                var codeMethod = new CodeMethod();
                codeInterface.MethodList.Add(codeMethod);

                codeMethod.Name = $"Method{i}";
                codeMethod.Type = "int";
                codeMethod.Summary = $"Method {i}";

                codeMethod.Parameters = new List<CodeParameter>();
                for (int j = 0; j < 3; j++)
                {
                    var codeParameter = new CodeParameter();
                    codeMethod.Parameters.Add(codeParameter);

                    codeParameter.Name = $"p{j + 1}";
                    codeParameter.Type = "int";
                }
            }

            return codeInterface;
        }

        protected override string PrepareExpected()
        {
            return @"/**
 * Student
 */
public interface IStudentRepository extends IStudent, ITeacher {

    /**
     * Method 0
     */
    Method0(p1: int, p2: int, p3: int): int;

    /**
     * Method 1
     */
    Method1(p1: int, p2: int, p3: int): int;
}
";
        }
    }
}
