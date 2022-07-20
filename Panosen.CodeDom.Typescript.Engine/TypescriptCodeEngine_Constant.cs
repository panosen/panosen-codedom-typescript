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
        /// GenerateConstant
        /// </summary>
        /// <param name="codeConstant"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        public void GenerateConstant(CodeConstant codeConstant, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeConstant == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateSummary(codeConstant.Summary, codeWriter, options);
            codeWriter.Write(options.IndentString);

            if (codeConstant.AccessModifiers != AccessModifiers.None)
            {
                codeWriter.Write(codeConstant.AccessModifiers.Value()).Write(Marks.WHITESPACE);
            }

            codeWriter.Write(Keywords.CONST).Write(Marks.WHITESPACE);

            codeWriter.Write(codeConstant.Name ?? string.Empty);

            codeWriter.Write(Marks.COLON).Write(Marks.WHITESPACE);

            codeWriter.Write(codeConstant.Type ?? string.Empty);

            codeWriter.Write(Marks.WHITESPACE).Write(Marks.EQUAL).Write(Marks.WHITESPACE).Write(codeConstant.Value ?? "NULL");

            codeWriter.WriteLine(Marks.SEMICOLON);
        }
    }
}
