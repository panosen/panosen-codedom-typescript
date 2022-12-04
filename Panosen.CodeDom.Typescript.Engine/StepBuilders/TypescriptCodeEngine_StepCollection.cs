using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    partial class TypescriptCodeEngine
    {
        /// <summary>
        /// 生成方法步骤
        /// </summary>
        public void GenerateStepCollection(StepCollection stepBuilderCollection, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (stepBuilderCollection == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            foreach (var item in stepBuilderCollection.Steps)
            {
                GenerateStepOrCollection(item, codeWriter, options);
            }
        }
    }
}
