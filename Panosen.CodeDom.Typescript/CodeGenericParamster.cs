using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// 泛型参数
    /// </summary>
    public class CodeGenericParamster : CodeObject
    {
        /// <summary>
        /// 约束
        /// </summary>
        public List<string> Constraints { get; set; }
    }

    /// <summary>
    /// CodeConstraint Extension
    /// </summary>
    public static class CodeGenericParamsterExtension
    {
        /// <summary>
        /// 添加约束
        /// </summary>
        public static TCodeConstraint AddConstraint<TCodeConstraint>(this TCodeConstraint codeConstraint, params string[] constraints) where TCodeConstraint : CodeGenericParamster
        {
            if (constraints == null || constraints.Length == 0)
            {
                return codeConstraint;
            }

            if (codeConstraint.Constraints == null)
            {
                codeConstraint.Constraints = new List<string>();
            }

            codeConstraint.Constraints.AddRange(constraints);

            return codeConstraint;
        }
    }
}
