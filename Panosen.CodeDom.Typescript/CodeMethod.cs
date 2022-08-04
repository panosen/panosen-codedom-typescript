using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// 方法
    /// </summary>
    public class CodeMethod : DataItem, IStepBuilderCollection
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 注释
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 访问修饰符
        /// </summary>
        public AccessModifiers AccessModifiers { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public List<CodeParameter> Parameters { get; set; }

        /// <summary>
        /// 特性
        /// </summary>
        public List<CodeDecorator> AttributeList { get; set; }

        /// <summary>
        /// 是否是静态方法
        /// </summary>
        public bool IsStatic { get; set; }

        /// <summary>
        /// async
        /// </summary>
        public bool IsAsync { get; set; }

        /// <summary>
        /// implicit
        /// </summary>
        public bool IsImplicit { get; set; }

        /// <summary>
        /// operator
        /// </summary>
        public bool IsOperator { get; set; }

        /// <summary>
        /// 是否是覆盖或实现基类
        /// </summary>
        public bool IsOverride { get; set; }

        /// <summary>
        /// 泛型参数
        /// </summary>
        public List<CodeGenericParamster> GenericParamsterList { get; set; }

        #region IStepBuilderCollection Members

        /// <summary>
        /// IStepBuilderCollection.StepBuilders
        /// </summary>
        public List<StepBuilderOrCollection> StepBuilders { get; set; }

        #endregion
    }

    /// <summary>
    /// CodeMethod Extension
    /// </summary>
    public static class CodeMethodExtension
    {

        /// <summary>
        /// 设置访问修饰符
        /// </summary>
        public static TCodeMethod SetAccessModifiers<TCodeMethod>(this TCodeMethod codeMethod, AccessModifiers accessModifiers) where TCodeMethod : CodeMethod
        {
            codeMethod.AccessModifiers = accessModifiers;

            return codeMethod;
        }

        /// <summary>
        /// 设置 IsStatic
        /// </summary>
        public static TCodeMethod SetIsStatic<TCodeMethod>(this TCodeMethod codeMethod, bool isStatic) where TCodeMethod : CodeMethod
        {
            codeMethod.IsStatic = isStatic;

            return codeMethod;
        }

        /// <summary>
        /// 设置 IsAsync
        /// </summary>
        public static TCodeMethod SetIsAsync<TCodeMethod>(this TCodeMethod codeMethod, bool isAsync) where TCodeMethod : CodeMethod
        {
            codeMethod.IsAsync = isAsync;

            return codeMethod;
        }

        /// <summary>
        /// 设置 IsImplicit
        /// </summary>
        public static TCodeMethod SetIsImplicit<TCodeMethod>(this TCodeMethod codeMethod, bool isImplicit) where TCodeMethod : CodeMethod
        {
            codeMethod.IsImplicit = isImplicit;

            return codeMethod;
        }

        /// <summary>
        /// 设置 IsOperator
        /// </summary>
        public static TCodeMethod SetIsOperator<TCodeMethod>(this TCodeMethod codeMethod, bool isOperator) where TCodeMethod : CodeMethod
        {
            codeMethod.IsOperator = isOperator;

            return codeMethod;
        }

        /// <summary>
        /// 设置 IsOverride
        /// </summary>
        public static TCodeMethod SetIsOverride<TCodeMethod>(this TCodeMethod codeMethod, bool isOverride) where TCodeMethod : CodeMethod
        {
            codeMethod.IsOverride = isOverride;

            return codeMethod;
        }

        /// <summary>
        /// 添加泛型参数
        /// </summary>
        public static TCodeMethod AddGenericParameter<TCodeMethod>(this TCodeMethod codeMethod, CodeGenericParamster codeGenericParamster) where TCodeMethod : CodeMethod
        {
            if (codeMethod.GenericParamsterList == null)
            {
                codeMethod.GenericParamsterList = new List<CodeGenericParamster>();
            }

            codeMethod.GenericParamsterList.Add(codeGenericParamster);

            return codeMethod;
        }

        /// <summary>
        /// 添加泛型参数
        /// </summary>
        public static CodeGenericParamster AddGenericParameter<TCodeMethod>(this TCodeMethod codeMethod, string name, string summary = null) where TCodeMethod : CodeMethod
        {
            if (codeMethod.GenericParamsterList == null)
            {
                codeMethod.GenericParamsterList = new List<CodeGenericParamster>();
            }

            CodeGenericParamster codeGenericParamster = new CodeGenericParamster();
            codeGenericParamster.Name = name;
            codeGenericParamster.Summary = summary;

            codeMethod.GenericParamsterList.Add(codeGenericParamster);

            return codeGenericParamster;
        }

        /// <summary>
        /// Add Parameter
        /// </summary>
        public static CodeParameter AddParameter(this CodeMethod codeMethod, CodeParameter parameter)
        {
            if (codeMethod.Parameters == null)
            {
                codeMethod.Parameters = new List<CodeParameter>();
            }

            codeMethod.Parameters.Add(parameter);

            return parameter;
        }

        /// <summary>
        /// Add Parameter
        /// </summary>
        public static CodeParameter AddParameter(this CodeMethod codeMethod, string type, string name, string summary = null, bool optional = false)
        {
            if (codeMethod.Parameters == null)
            {
                codeMethod.Parameters = new List<CodeParameter>();
            }

            CodeParameter parameter = new CodeParameter();
            parameter.Name = name;
            parameter.Type = type;
            parameter.Optional = optional;
            parameter.Summary = summary;

            codeMethod.Parameters.Add(parameter);

            return parameter;
        }

        /// <summary>
        /// Add Attribute
        /// </summary>
        public static CodeMethod AddDecorator(this CodeMethod codeMethod, CodeDecorator codeAttribute)
        {
            if (codeMethod.AttributeList == null)
            {
                codeMethod.AttributeList = new List<CodeDecorator>();
            }

            codeMethod.AttributeList.Add(codeAttribute);

            return codeMethod;
        }

        /// <summary>
        /// Add Attribute
        /// </summary>
        public static CodeVariableDecorator AddVariableDecorator(this CodeMethod codeMethod, string name)
        {
            if (codeMethod.AttributeList == null)
            {
                codeMethod.AttributeList = new List<CodeDecorator>();
            }

            var codeAttribute = new CodeVariableDecorator();
            codeAttribute.Name = name;

            codeMethod.AttributeList.Add(codeAttribute);

            return codeAttribute;
        }

        /// <summary>
        /// Add Attribute
        /// </summary>
        public static CodeMethodDecorator AddMethodDecorator(this CodeMethod codeMethod, string name)
        {
            if (codeMethod.AttributeList == null)
            {
                codeMethod.AttributeList = new List<CodeDecorator>();
            }

            var codeAttribute = new CodeMethodDecorator();
            codeAttribute.Name = name;

            codeMethod.AttributeList.Add(codeAttribute);

            return codeAttribute;
        }
    }
}
