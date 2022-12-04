using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// 访问修饰符
    /// </summary>
    public enum AccessModifiers
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,

        /// <summary>
        /// public
        /// </summary>
        Public = 1,

        /// <summary>
        /// private
        /// </summary>
        Private = 2
    }

    /// <summary>
    /// AccessModifiersExtension
    /// </summary>
    public static class AccessModifiersExtension
    {
        /// <summary>
        /// 值
        /// </summary>
        /// <param name="accessModifiers"></param>
        /// <returns></returns>
        public static string Value(this AccessModifiers accessModifiers)
        {
            switch (accessModifiers)
            {
                case AccessModifiers.Public:
                    return "public";
                case AccessModifiers.Private:
                    return "private";
                case AccessModifiers.None:
                default:
                    return string.Empty;
            }
        }
    }
}
