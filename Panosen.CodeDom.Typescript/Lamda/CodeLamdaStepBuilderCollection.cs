using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// ${Parameter} => ${Expression}
    /// </summary>
    public class CodeLamdaStepBuilderCollection : Lamda, IStepCollectionHost
    {
        #region IStepCollectionHost Members

        /// <summary>
        /// 步骤
        /// </summary>
        public StepCollection StepCollection { get; set; }

        #endregion
    }

    /// <summary>
    /// CodeLamdaStepBuilderCollectionExtension
    /// </summary>
    public static class CodeLamdaStepBuilderCollectionExtension
    {
    }
}
