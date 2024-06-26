﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest
{
    [TestClass]
    public class UT_CodeEnum
    {
        [TestMethod]
        public void Test()
        {
            var option = PrepareCode();

            TypescriptCodeEngine generator = new TypescriptCodeEngine();

            StringBuilder builder = new StringBuilder();

            generator.GenerateEnum(option, builder);

            var actual = builder.ToString();

            var expeced = PrepareExpected();

            Assert.AreEqual(expeced, actual);
        }

        protected string PrepareExpected()
        {
            return @"/**
 * 状态
 */
export enum Status
{

    A_0,

    A_1,

    A_2,

    /**
     * of 0
     */
    B_0,

    /**
     * of 1
     */
    B_1,

    /**
     * of 2
     */
    B_2,

    C_0 = 10,

    C_1 = 11,

    C_2 = 12
}
";
        }

        protected CodeEnum PrepareCode()
        {
            CodeEnum codeEnum = new CodeEnum();
            codeEnum.Name = "Status";
            codeEnum.Summary = "状态";
            codeEnum.Export = true;

            for (int i = 0; i < 3; i++)
            {
                codeEnum.AddValue($"A_{i}");
            }

            for (int i = 0; i < 3; i++)
            {
                codeEnum.AddValue($"B_{i}", summary: $"of {i}");
            }

            for (int i = 0; i < 3; i++)
            {
                codeEnum.AddValue($"C_{i}", value: (DataValue)(i + 10));
            }

            return codeEnum;
        }
    }
}
