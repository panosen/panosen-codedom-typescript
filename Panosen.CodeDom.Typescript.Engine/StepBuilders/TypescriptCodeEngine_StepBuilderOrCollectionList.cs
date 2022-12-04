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
        private void GenerateStepBuilderOrCollectionList(List<StepOrCollection> stepBuilders, CodeWriter codeWriter, GenerateOptions options)
        {
            if (stepBuilders == null || stepBuilders.Count <= 0)
            {
                return;
            }

            foreach (var item in stepBuilders)
            {
                GenerateStepBuilderOrCollection(item, codeWriter, options);
            }
        }
    }
}
