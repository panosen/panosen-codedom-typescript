using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// ForeachStepBuilder
    /// </summary>
    public class ForeachStep : StepCollection
    {
        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Item
        /// </summary>
        public string Item { get; set; }

        /// <summary>
        /// Items
        /// </summary>
        public string Items { get; set; }
    }
}
