﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// catch
    /// </summary>
    public class CatchStepBuilder : StepBuilderCollection
    {
        /// <summary>
        /// Exception
        /// </summary>
        public string ExceptionType { get; set; }

        /// <summary>
        /// e
        /// </summary>
        public string ExceptionName { get; set; }
    }
}
