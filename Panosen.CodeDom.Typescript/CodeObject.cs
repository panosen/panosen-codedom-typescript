using System;
using System.Collections.Generic;
using System.Reflection;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// 有名称的编程对象
    /// </summary>
    public abstract class CodeObject
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 注释
        /// </summary>
        public string Summary { get; set; }
    }

    /// <summary>
    /// CodeObject Extension
    /// </summary>
    public static class CodeObjectExtension
    {
        /// <summary>
        /// Set Name
        /// </summary>
        public static TCodeObject SetName<TCodeObject>(this TCodeObject codeObject, string name) where TCodeObject : CodeObject
        {
            codeObject.Name = name;

            return codeObject;
        }

        /// <summary>
        /// Set Name
        /// </summary>
        public static TCodeObject SetSummary<TCodeObject>(this TCodeObject codeObject, string summary) where TCodeObject : CodeObject
        {
            codeObject.Summary = summary;

            return codeObject;
        }
    }
}
