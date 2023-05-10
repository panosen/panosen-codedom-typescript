using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// Lamda
    /// </summary>
    public class Lamda : DataItem
    {
        /// <summary>
        /// 参数
        /// </summary>
        public List<CodeParameter> Parameters { get; set; }
    }

    /// <summary>
    /// Lamda
    /// </summary>
    public static class XExtension
    {
        /// <summary>
        /// Add Parameter
        /// </summary>
        public static TLamda AddParameter<TLamda>(this TLamda codeMethod, CodeParameter parameter)
            where TLamda : Lamda
        {
            if (codeMethod.Parameters == null)
            {
                codeMethod.Parameters = new List<CodeParameter>();
            }

            codeMethod.Parameters.Add(parameter);

            return codeMethod;
        }

        /// <summary>
        /// Add Parameter
        /// </summary>
        public static CodeParameter AddParameter<TLamda>(this TLamda codeMethod, string type, string name, string summary = null, bool optional = false, AccessModifiers accessModifiers = AccessModifiers.None)
            where TLamda : Lamda
        {
            if (codeMethod.Parameters == null)
            {
                codeMethod.Parameters = new List<CodeParameter>();
            }

            var parameter = new CodeParameter();
            parameter.Name = name;
            parameter.Type = type;
            parameter.Optional = optional;
            parameter.Summary = summary;
            parameter.AccessModifiers = accessModifiers;

            codeMethod.Parameters.Add(parameter);

            return parameter;
        }
    }
}
