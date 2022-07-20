﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// ForStepBuilder
    /// </summary>
    public class ForStepBuilder : StepBuilderCollection
    {
        /// <summary>
        /// Start
        /// </summary>
        public string Start { get; set; }

        /// <summary>
        /// Middle
        /// </summary>
        public string Middle { get; set; }

        /// <summary>
        /// End
        /// </summary>
        public string End { get; set; }
    }
}
