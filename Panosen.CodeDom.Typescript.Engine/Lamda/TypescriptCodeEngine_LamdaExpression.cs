﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    partial class TypescriptCodeEngine
    {
        /// <summary>
        /// ${param} => ${expression}
        /// </summary>
        public void GenerateLamdaExpression(CodeLamdaExpression lamda, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (lamda == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            // x => new ${ClassName}
            codeWriter.Write(lamda.Parameter)
                .Write(Marks.WHITESPACE).Write(Marks.EQUAL).Write(Marks.GREATER_THAN).Write(Marks.WHITESPACE)
                .Write(lamda.Expression);
        }
    }
}
