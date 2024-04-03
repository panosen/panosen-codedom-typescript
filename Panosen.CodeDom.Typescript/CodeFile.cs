using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// code file
    /// </summary>
    public class CodeFile
    {
        /// <summary>
        /// 系统导入项
        /// </summary>
        public SortedDictionary<string, List<ImportItem>> SystemImportsMap { get; set; }

        /// <summary>
        /// npm导入项
        /// </summary>
        /// 
        public SortedDictionary<string, List<ImportItem>> NpmImportsMap { get; set; }

        /// <summary>
        /// 项目导入项
        /// </summary>
        public SortedDictionary<string, List<ImportItem>> ProjectImportsMap { get; set; }

        /// <summary>
        /// 类
        /// </summary>
        public List<CodeClass> ClassList { get; set; }

        /// <summary>
        /// 接口
        /// </summary>
        public List<CodeInterface> InterfaceList { get; set; }

        /// <summary>
        /// 枚举
        /// </summary>
        public List<CodeEnum> EnumList { get; set; }

        /// <summary>
        /// 常量
        /// </summary>
        public List<CodeConstant> ConstantList { get; set; }
    }

    /// <summary>
    /// 导入项
    /// </summary>
    public class ImportItem
    {
        /// <summary>
        /// 导入项的名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// true, 带大括号；false，不带大括号
        /// </summary>
        public bool NotDefault { get; set; }
    }

    /// <summary>
    /// CodeFile 扩展
    /// </summary>
    public static class CodeFileExtension
    {

        /// <summary>
        /// 添加一个类
        /// </summary>
        public static CodeFile AddClass(this CodeFile codeFile, CodeClass codeClass)
        {
            if (codeFile.ClassList == null)
            {
                codeFile.ClassList = new List<CodeClass>();
            }

            codeFile.ClassList.Add(codeClass);
            return codeFile;
        }

        /// <summary>
        /// 添加一个类
        /// </summary>
        public static CodeClass AddClass(this CodeFile codeFile, string name, string summary = null, bool export = false)
        {
            if (codeFile.ClassList == null)
            {
                codeFile.ClassList = new List<CodeClass>();
            }

            CodeClass codeClass = new CodeClass();
            codeClass.Name = name;
            codeClass.Summary = summary;
            codeClass.Export = export;

            codeFile.ClassList.Add(codeClass);

            return codeClass;
        }

        /// <summary>
        /// 添加一个接口
        /// </summary>
        public static CodeFile AddInterface(this CodeFile codeFile, CodeInterface codeInterface)
        {
            if (codeFile.InterfaceList == null)
            {
                codeFile.InterfaceList = new List<CodeInterface>();
            }

            codeFile.InterfaceList.Add(codeInterface);
            return codeFile;
        }

        /// <summary>
        /// 添加一个接口
        /// </summary>
        public static CodeInterface AddInterface(this CodeFile codeFile, string name, string summary = null, AccessModifiers accessModifiers = AccessModifiers.None, bool export = false)
        {
            if (codeFile.InterfaceList == null)
            {
                codeFile.InterfaceList = new List<CodeInterface>();
            }

            CodeInterface codeInterface = new CodeInterface();
            codeInterface.Name = name;
            codeInterface.Summary = summary;
            codeInterface.AccessModifiers = accessModifiers;
            codeInterface.Export = export;

            codeFile.InterfaceList.Add(codeInterface);

            return codeInterface;
        }

        /// <summary>
        /// 添加一个枚举
        /// </summary>
        public static CodeFile AddEnum(this CodeFile codeFile, CodeEnum codeEnum)
        {
            if (codeFile.EnumList == null)
            {
                codeFile.EnumList = new List<CodeEnum>();
            }

            codeFile.EnumList.Add(codeEnum);
            return codeFile;
        }

        /// <summary>
        /// 添加一个枚举
        /// </summary>
        public static CodeEnum AddEnum(this CodeFile codeFile, string name, string summary = null, bool export = false)
        {
            if (codeFile.EnumList == null)
            {
                codeFile.EnumList = new List<CodeEnum>();
            }

            CodeEnum codeEnum = new CodeEnum();
            codeEnum.Name = name;
            codeEnum.Summary = summary;
            codeEnum.Export = export;

            codeFile.EnumList.Add(codeEnum);

            return codeEnum;
        }

        /// <summary>
        /// 导入项
        /// </summary>
        public static TCodeFile AddSystemImport<TCodeFile>(this TCodeFile codeFile, string name, string source, string alias = null, bool notDefault = false)
            where TCodeFile : CodeFile
        {
            if (codeFile.SystemImportsMap == null)
            {
                codeFile.SystemImportsMap = new SortedDictionary<string, List<ImportItem>>();
            }

            AddImport(codeFile.SystemImportsMap, name, alias, notDefault, source);

            return codeFile;
        }

        /// <summary>
        /// 导入项
        /// </summary>
        public static TCodeFile AddNpmImport<TCodeFile>(this TCodeFile codeFile, string name, string source, string alias = null, bool notDefault = false)
            where TCodeFile : CodeFile
        {
            if (codeFile.NpmImportsMap == null)
            {
                codeFile.NpmImportsMap = new SortedDictionary<string, List<ImportItem>>();
            }

            AddImport(codeFile.NpmImportsMap, name, alias, notDefault, source);

            return codeFile;
        }

        /// <summary>
        /// 导入项
        /// </summary>
        public static TCodeFile AddProjectImport<TCodeFile>(this TCodeFile codeFile, string name, string source, string alias = null, bool notDefault = false)
            where TCodeFile : CodeFile
        {
            if (codeFile.ProjectImportsMap == null)
            {
                codeFile.ProjectImportsMap = new SortedDictionary<string, List<ImportItem>>();
            }

            AddImport(codeFile.ProjectImportsMap, name, alias, notDefault, source);

            return codeFile;
        }

        private static void AddImport(SortedDictionary<string, List<ImportItem>> importMap, string name, string alias, bool notDefault, string source)
        {
            if (!importMap.ContainsKey(source))
            {
                importMap.Add(source, new List<ImportItem>());
            }

            if (importMap[source].Any(v => v.Name == name && v.Alias == alias && v.NotDefault == notDefault))
            {
                return;
            }

            var importItem = new ImportItem();
            importItem.Name = name;
            importItem.Alias = alias;
            importItem.NotDefault = notDefault;

            importMap[source].Add(importItem);
        }

        /// <summary>
        /// 添加常量
        /// </summary>
        public static TCodeFile AddConstant<TCodeFile>(this TCodeFile codeFile, CodeConstant codeConstant)
            where TCodeFile : CodeFile
        {
            if (codeFile.ConstantList == null)
            {
                codeFile.ConstantList = new List<CodeConstant>();
            }

            codeFile.ConstantList.Add(codeConstant);

            return codeFile;
        }

        /// <summary>
        /// 添加常量
        /// </summary>
        public static CodeConstant AddConstant<TCodeFile>(this TCodeFile codeFile, string type, string name, string value, bool export = false, AccessModifiers accessModifiers = AccessModifiers.None)
            where TCodeFile : CodeFile
        {
            if (codeFile.ConstantList == null)
            {
                codeFile.ConstantList = new List<CodeConstant>();
            }

            var codeConstant = new CodeConstant();
            codeConstant.Type = type;
            codeConstant.Name = name;
            codeConstant.Value = value;
            codeConstant.Export = export;
            codeConstant.AccessModifiers = accessModifiers;

            codeFile.ConstantList.Add(codeConstant);

            return codeConstant;
        }
    }
}
