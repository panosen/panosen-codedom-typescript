using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// try
    /// </summary>
    public class TryStep : StepCollection
    {
        /// <summary>
        /// catch
        /// </summary>
        public List<CatchStep> CatchStepBuilders { get; set; }

        /// <summary>
        /// finally
        /// </summary>
        public FinallyStep FinallyStepBuilder { get; set; }
    }

    /// <summary>
    /// try catch
    /// </summary>
    public static class TryStepBuilderExtension
    {
        /// <summary>
        /// catch(exceptionType, exceptionName)
        /// </summary>
        public static CatchStep WithCatch(this TryStep tryStepBuilder, string exceptionType = null, string exceptionName = null)
        {
            if (tryStepBuilder.CatchStepBuilders == null)
            {
                tryStepBuilder.CatchStepBuilders = new List<CatchStep>();
            }

            CatchStep catchStepBuilder = new CatchStep();
            catchStepBuilder.ExceptionType = exceptionType;
            catchStepBuilder.ExceptionName = exceptionName;
            tryStepBuilder.CatchStepBuilders.Add(catchStepBuilder);

            return catchStepBuilder;
        }

        /// <summary>
        /// finally
        /// </summary>
        public static FinallyStep WithFinally(this TryStep tryStepBuilder)
        {
            FinallyStep finallyStepBuilder = new FinallyStep();

            tryStepBuilder.FinallyStepBuilder = finallyStepBuilder;

            return finallyStepBuilder;
        }
    }
}
