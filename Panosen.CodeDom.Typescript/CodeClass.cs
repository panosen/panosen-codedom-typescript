using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// 类
    /// </summary>
    public class CodeClass : CodeObject
    {
        /// <summary>
        /// export
        /// </summary>
        public bool Export { get; set; }

        /// <summary>
        /// 是否是抽象类
        /// </summary>
        public bool IsAbstract { get; set; }

        /// <summary>
        /// 是否是静态类
        /// </summary>
        public bool IsStatic { get; set; }

        /// <summary>
        /// 是否是分布类
        /// </summary>
        public bool IsPartial { get; set; }

        /// <summary>
        /// 访问修饰符
        /// </summary>
        public AccessModifiers AccessModifiers { get; set; }

        /// <summary>
        /// 属性
        /// </summary>
        public List<CodeProperty> PropertyList { get; set; }

        /// <summary>
        /// 字段
        /// </summary>
        public List<CodeField> FieldList { get; set; }

        /// <summary>
        /// 方法
        /// </summary>
        public List<CodeMethod> MethodList { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public CodeMethod Constructor { get; set; }

        /// <summary>
        /// 该类实现的接口
        /// </summary>
        public List<CodeInterface> InterfaceList { get; set; }

        /// <summary>
        /// 该类实现的接口
        /// </summary>
        public CodeClass BaseClass { get; set; }

        /// <summary>
        /// 常量
        /// </summary>
        public List<CodeConstant> ConstantList { get; set; }

        /// <summary>
        /// 特性
        /// </summary>
        public List<CodeDecorator> AttributeList { get; set; }

        /// <summary>
        /// 泛型参数
        /// </summary>
        public List<CodeGenericParamster> GenericParamsterList { get; set; }
    }

    /// <summary>
    /// CodeClass 扩展方法
    /// </summary>
    public static class CodeClassExtension
    {
        /// <summary>
        /// 设置CodeClass名称
        /// </summary>
        public static TCodeClass SetName<TCodeClass>(this TCodeClass codeClass, string name)
            where TCodeClass : CodeClass
        {
            codeClass.Name = name;

            return codeClass;
        }

        /// <summary>
        /// 添加特性
        /// </summary>
        public static CodeClass AddDecorator(this CodeClass codeClass, CodeDecorator codeAttribute)
        {
            if (codeClass.AttributeList == null)
            {
                codeClass.AttributeList = new List<CodeDecorator>();
            }

            codeClass.AttributeList.Add(codeAttribute);

            return codeClass;
        }

        /// <summary>
        /// 添加装饰器
        /// </summary>
        public static CodeDecorator AddVariableDecorator(this CodeClass codeClass, string name)
        {
            if (codeClass.AttributeList == null)
            {
                codeClass.AttributeList = new List<CodeDecorator>();
            }

            var codeAttribute = new CodeVariableDecorator();
            codeAttribute.Name = name;

            codeClass.AttributeList.Add(codeAttribute);

            return codeAttribute;
        }

        /// <summary>
        /// 添加装饰器
        /// </summary>
        public static CodeMethodDecorator AddMethodDecorator(this CodeClass codeClass, string name)
        {
            if (codeClass.AttributeList == null)
            {
                codeClass.AttributeList = new List<CodeDecorator>();
            }

            var codeAttribute = new CodeMethodDecorator();
            codeAttribute.Name = name;

            codeClass.AttributeList.Add(codeAttribute);

            return codeAttribute;
        }

        /// <summary>
        /// 添加接口
        /// </summary>
        public static CodeInterface AddInterface(this CodeClass codeClass, string name, string summary = null)
        {
            if (codeClass.InterfaceList == null)
            {
                codeClass.InterfaceList = new List<CodeInterface>();
            }

            CodeInterface codeInterface = new CodeInterface();
            codeInterface.Name = name;
            codeInterface.Summary = summary;

            codeClass.InterfaceList.Add(codeInterface);

            return codeInterface;
        }

        /// <summary>
        /// 设置基类
        /// </summary>
        public static TCodeClass SetBaseClass<TCodeClass>(this TCodeClass codeClass, string name) where TCodeClass : CodeClass
        {
            CodeClass baseCodeClass = new CodeClass();
            baseCodeClass.Name = name;

            codeClass.BaseClass = baseCodeClass;

            return codeClass;
        }

        /// <summary>
        /// 设置访问修饰符
        /// </summary>
        public static TCodeClass SetAccessModifiers<TCodeClass>(this TCodeClass codeClass, AccessModifiers accessModifiers) where TCodeClass : CodeClass
        {
            codeClass.AccessModifiers = accessModifiers;

            return codeClass;
        }

        /// <summary>
        /// 添加一个方法
        /// </summary>
        public static TCodeClass AddMethod<TCodeClass>(this TCodeClass codeClass, CodeMethod codeMethod) where TCodeClass : CodeClass
        {
            if (codeClass.MethodList == null)
            {
                codeClass.MethodList = new List<CodeMethod>();
            }

            codeClass.MethodList.Add(codeMethod);

            return codeClass;
        }

        /// <summary>
        /// 添加一个方法
        /// </summary>
        public static CodeMethod AddMethod(this CodeClass codeClass, string name, string summary = null)
        {
            if (codeClass.MethodList == null)
            {
                codeClass.MethodList = new List<CodeMethod>();
            }

            CodeMethod codeMethod = new CodeMethod();
            codeMethod.Name = name;
            codeMethod.Summary = summary;

            codeClass.MethodList.Add(codeMethod);

            return codeMethod;
        }

        /// <summary>
        /// 添加一批方法
        /// </summary>
        public static TCodeClass AddMethods<TCodeClass>(this TCodeClass codeClass, List<CodeMethod> codeMethods)
            where TCodeClass : CodeClass
        {
            if (codeMethods == null || codeMethods.Count == 0)
            {
                return codeClass;
            }
            if (codeClass.MethodList == null)
            {
                codeClass.MethodList = new List<CodeMethod>();
            }

            codeClass.MethodList.AddRange(codeMethods);

            return codeClass;
        }

        /// <summary>
        /// 添加构造函数
        /// </summary>
        public static TCodeClass AddConstructor<TCodeClass>(this TCodeClass codeClass, CodeMethod codeMethod)
            where TCodeClass : CodeClass
        {
            codeClass.Constructor = codeMethod;

            return codeClass;
        }

        /// <summary>
        /// 添加构造函数
        /// </summary>
        public static CodeMethod AddConstructor(this CodeClass codeClass)
        {
            CodeMethod codeMethod = new CodeMethod();
            codeMethod.Name = "constructor";
            codeMethod.StepCollection = new StepCollection();

            codeClass.Constructor = codeMethod;

            return codeMethod;
        }

        /// <summary>
        /// 添加字段
        /// </summary>
        public static TCodeClass AddField<TCodeClass>(this TCodeClass codeClass, CodeField codeField) where TCodeClass : CodeClass
        {
            if (codeClass.FieldList == null)
            {
                codeClass.FieldList = new List<CodeField>();
            }

            codeClass.FieldList.Add(codeField);

            return codeClass;
        }

        /// <summary>
        /// 添加字段
        /// </summary>
        public static CodeField AddField(this CodeClass codeClass,
            string type,
            string name,
            bool isStatic = false,
            string summary = null,
            DataItem value = null,
            bool optional = false,
            AccessModifiers accessModifiers = AccessModifiers.Private)
        {
            if (codeClass.FieldList == null)
            {
                codeClass.FieldList = new List<CodeField>();
            }

            CodeField codeField = new CodeField();
            codeField.Type = type;
            codeField.Name = name;
            codeField.IsStatic = isStatic;
            codeField.Optional = optional;
            codeField.Summary = summary;
            codeField.AccessModifiers = accessModifiers;
            codeField.Value = value;

            codeClass.FieldList.Add(codeField);

            return codeField;
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        public static TCodeClass AddProperty<TCodeClass>(this TCodeClass codeClass, CodeProperty codeProperty) where TCodeClass : CodeClass
        {
            if (codeClass.PropertyList == null)
            {
                codeClass.PropertyList = new List<CodeProperty>();
            }

            codeClass.PropertyList.Add(codeProperty);

            return codeClass;
        }

        /// <summary>
        /// 添加属性
        /// </summary>
        public static CodeProperty AddProperty(this CodeClass codeClass, string type, string name,
            DataItem value = null,
            string summary = null,
            bool isVirtual = false,
            bool isOverride = false,
            CodePropertyAccess codePropertyAccess = CodePropertyAccess.Default,
            AccessModifiers accessModifiers = AccessModifiers.Public)
        {
            if (codeClass.PropertyList == null)
            {
                codeClass.PropertyList = new List<CodeProperty>();
            }

            CodeProperty codeProperty = new CodeProperty();
            codeProperty.Name = name;
            codeProperty.Type = type;
            codeProperty.CodePropertyAccess = codePropertyAccess;
            codeProperty.Summary = summary;
            codeProperty.IsVirtual = isVirtual;
            codeProperty.IsOverride = isOverride;
            codeProperty.Value = value;
            codeProperty.AccessModifiers = accessModifiers;

            codeClass.PropertyList.Add(codeProperty);

            return codeProperty;
        }

        /// <summary>
        /// 添加常量
        /// </summary>
        public static TCodeClass AddConstant<TCodeClass>(this TCodeClass codeClass, CodeConstant codeConstant) where TCodeClass : CodeClass
        {
            if (codeClass.ConstantList == null)
            {
                codeClass.ConstantList = new List<CodeConstant>();
            }

            codeClass.ConstantList.Add(codeConstant);

            return codeClass;
        }

        /// <summary>
        /// 添加泛型参数
        /// </summary>
        public static CodeGenericParamster AddGenericParameter<TCodeClass>(this TCodeClass codeClass, string name, string summary = null) where TCodeClass : CodeClass
        {
            if (codeClass.GenericParamsterList == null)
            {
                codeClass.GenericParamsterList = new List<CodeGenericParamster>();
            }

            CodeGenericParamster codeGenericParamster = new CodeGenericParamster();
            codeGenericParamster.Name = name;
            codeGenericParamster.Summary = summary;
            codeClass.GenericParamsterList.Add(codeGenericParamster);

            return codeGenericParamster;
        }

        /// <summary>
        /// 添加常量
        /// </summary>
        public static TCodeClass AddGenericParameter<TCodeClass>(this TCodeClass codeClass, CodeGenericParamster codeGenericParamster) where TCodeClass : CodeClass
        {
            if (codeClass.GenericParamsterList == null)
            {
                codeClass.GenericParamsterList = new List<CodeGenericParamster>();
            }

            codeClass.GenericParamsterList.Add(codeGenericParamster);

            return codeClass;
        }

        /// <summary>
        /// 添加常量
        /// </summary>
        public static CodeConstant AddConstant(this CodeClass codeClass, AccessModifiers accessModifiers, string type, string name, string value, string summary = null)
        {
            if (codeClass.ConstantList == null)
            {
                codeClass.ConstantList = new List<CodeConstant>();
            }

            CodeConstant codeConstant = new CodeConstant();
            codeConstant.AccessModifiers = accessModifiers;
            codeConstant.Name = name;
            codeConstant.Type = type;
            codeConstant.Value = value;
            codeConstant.Summary = summary;

            codeClass.ConstantList.Add(codeConstant);

            return codeConstant;
        }

        /// <summary>
        /// 设置IsAbstract
        /// </summary>
        public static TCodeClass SetIsAbstract<TCodeClass>(this TCodeClass codeClass, bool isAbstract) where TCodeClass : CodeClass
        {
            codeClass.IsAbstract = isAbstract;

            return codeClass;
        }

        /// <summary>
        /// 设置IsAbstract
        /// </summary>
        public static TCodeClass SetIsStatic<TCodeClass>(this TCodeClass codeClass, bool isStatic) where TCodeClass : CodeClass
        {
            codeClass.IsStatic = isStatic;

            return codeClass;
        }

        /// <summary>
        /// 设置IsPartial
        /// </summary>
        public static TCodeClass SetIsPartial<TCodeClass>(this TCodeClass codeClass, bool isPartial) where TCodeClass : CodeClass
        {
            codeClass.IsPartial = isPartial;

            return codeClass;
        }
    }
}
