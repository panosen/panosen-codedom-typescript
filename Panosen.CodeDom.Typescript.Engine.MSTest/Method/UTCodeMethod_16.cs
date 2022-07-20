using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Typescript.Engine.MSTest.Method
{
    [TestClass]
    public class UTCodeMethod_16 : UTCodeMethodBase
    {
        protected override void PrepareCodeMethod(CodeMethod codeMethod)
        {
            var tryStepBuilder = codeMethod.StepTry();
            tryStepBuilder.StepStatement("var xx=0;");
            tryStepBuilder.StepStatement("var yy = 90;");
            var catch1 = tryStepBuilder.WithCatch("ok");
            catch1.StepStatement("//catch1");
            var catch2 = tryStepBuilder.WithCatch("catch2");
            catch2.StepStatement("okok2");
            catch2.StepStatement("okok22");
            var finally2 = tryStepBuilder.WithFinally();
            finally2.StepStatement("finaly");
        }

        protected override string PrepareExpected()
        {
            return @"TestMethod(): void {
    try
    {
        var xx=0;
        var yy = 90;
    }
    catch (ok)
    {
        //catch1
    }
    catch (catch2)
    {
        okok2
        okok22
    }
    finally
    {
        finaly
    }
}
";
        }
    }
}
