using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// UsingStepBuilder
    /// </summary>
    public class UsingStep : StepCollection
    {
        /// <summary>
        /// Content
        /// </summary>
        public string Content { get; set; }
    }

    /// <summary>
    /// UsingStepBuilderExtension
    /// </summary>
    public static class UsingStepBuilderExtension
    {
        /// <summary>
        /// Use
        /// </summary>
        /// <typeparam name="TUsingStepBuilder"></typeparam>
        /// <param name="usingStepBuilder"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static TUsingStepBuilder Use<TUsingStepBuilder>(this TUsingStepBuilder usingStepBuilder, string content)
            where TUsingStepBuilder : UsingStep
        {
            usingStepBuilder.Content = content;

            return usingStepBuilder;
        }
    }
}
