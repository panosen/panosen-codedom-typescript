using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// 方法参数
    /// </summary>
    public class CodeParameter : CodeObject
    {
        /// <summary>
        /// 参数类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 特性
        /// </summary>
        public List<CodeDecorator> AttributeList { get; set; }
    }

    /// <summary>
    /// CodeParameterExtension
    /// </summary>
    public static class CodeParameterExtension
    {
        /// <summary>
        /// AddDecorator
        /// </summary>
        public static TCodeParameter AddDecorator<TCodeParameter>(this TCodeParameter codeParameter, CodeDecorator codeAttribute)
            where TCodeParameter : CodeParameter
        {
            if (codeParameter.AttributeList == null)
            {
                codeParameter.AttributeList = new List<CodeDecorator>();
            }

            codeParameter.AttributeList.Add(codeAttribute);

            return codeParameter;
        }

        /// <summary>
        /// AddDecorator
        /// </summary>
        public static CodeVariableDecorator AddVariableDecorator<TCodeParameter>(this TCodeParameter codeParameter, string name)
            where TCodeParameter : CodeParameter
        {
            if (codeParameter.AttributeList == null)
            {
                codeParameter.AttributeList = new List<CodeDecorator>();
            }

            var codeAttribute = new CodeVariableDecorator();
            codeAttribute.Name = name;

            codeParameter.AttributeList.Add(codeAttribute);

            return codeAttribute;
        }

        /// <summary>
        /// AddDecorator
        /// </summary>
        public static CodeMethodDecorator AddMethodDecorator<TCodeParameter>(this TCodeParameter codeParameter, string name)
            where TCodeParameter : CodeParameter
        {
            if (codeParameter.AttributeList == null)
            {
                codeParameter.AttributeList = new List<CodeDecorator>();
            }

            var codeAttribute = new CodeMethodDecorator();
            codeAttribute.Name = name;

            codeParameter.AttributeList.Add(codeAttribute);

            return codeAttribute;
        }
    }
}
