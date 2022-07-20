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
        Private = 2,

        /// <summary>
        /// protected
        /// </summary>
        Protected = 3,

        /// <summary>
        /// internal
        /// </summary>
        Internal = 4,

        /// <summary>
        /// protected internal
        /// </summary>
        ProtectedInternal = 5,

        /// <summary>
        /// private protected
        /// </summary>
        PrivateProtected = 6
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
                case AccessModifiers.Protected:
                    return "protected";
                case AccessModifiers.Internal:
                    return "internal";
                case AccessModifiers.ProtectedInternal:
                    return "protected internal";
                case AccessModifiers.PrivateProtected:
                    return "private protected";
                case AccessModifiers.None:
                default:
                    return string.Empty;
            }
        }
    }
}
