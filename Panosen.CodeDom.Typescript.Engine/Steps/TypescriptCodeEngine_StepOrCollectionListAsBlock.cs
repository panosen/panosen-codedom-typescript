using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    /// <summary>
    /// 生成对象 命名空间 类 枚举 属性  方法
    /// </summary>
    partial class TypescriptCodeEngine
    {
        private void GenerateStepOrCollectionListAsBlock(List<StepOrCollection> stepBuilders, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.Write(options.IndentString).WriteLine(Marks.LEFT_BRACE);
            options.PushIndent();

            GenerateStepOrCollectionList(stepBuilders, codeWriter, options);

            options.PopIndent();
            codeWriter.Write(options.IndentString).WriteLine(Marks.RIGHT_BRACE);
        }
    }
}
