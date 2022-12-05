using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// IStepCollectionHost
    /// </summary>
    public interface IStepCollectionHost
    {
        /// <summary>
        /// StepCollection
        /// </summary>
        StepCollection StepCollection { get; set; }
    }
}
