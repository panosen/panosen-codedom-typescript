using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    partial class TypescriptCodeEngine
    {
        /// <summary>
        /// 生成ts文件
        /// </summary>
        public void GenerateCodeFile(CodeFile codeFile, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codeFile == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            GenerateImports(codeWriter, codeFile);

            if (codeFile.ConstantList != null && codeFile.ConstantList.Count > 0)
            {
                foreach (var codeConstant in codeFile.ConstantList)
                {
                    GenerateConstant(codeConstant, codeWriter, options);
                }

                codeWriter.WriteLine();
            }

            if (codeFile.ClassList != null && codeFile.ClassList.Count > 0)
            {
                var enumerator = codeFile.ClassList.GetEnumerator();
                var moveNext = enumerator.MoveNext();
                while (moveNext)
                {
                    GenerateClass(enumerator.Current, codeWriter, options);

                    moveNext = enumerator.MoveNext();
                    if (moveNext)
                    {
                        codeWriter.WriteLine();
                    }
                }

                codeWriter.WriteLine();
            }

            if (codeFile.InterfaceList != null && codeFile.InterfaceList.Count > 0)
            {
                var enumerator = codeFile.InterfaceList.GetEnumerator();
                var moveNext = enumerator.MoveNext();
                while (moveNext)
                {
                    GenerateInterface(enumerator.Current, codeWriter, options);

                    moveNext = enumerator.MoveNext();
                    if (moveNext)
                    {
                        codeWriter.WriteLine();
                    }
                }

                codeWriter.WriteLine();
            }

            if (codeFile.EnumList != null && codeFile.EnumList.Count > 0)
            {
                var enumerator = codeFile.EnumList.GetEnumerator();
                var moveNext = enumerator.MoveNext();
                while (moveNext)
                {
                    GenerateEnum(enumerator.Current, codeWriter, options);

                    moveNext = enumerator.MoveNext();
                    if (moveNext)
                    {
                        codeWriter.WriteLine();
                    }
                }
            }
        }

        private void GenerateImports(CodeWriter codeWriter, CodeFile codeFile)
        {
            if (codeFile.SystemImportsMap != null && codeFile.SystemImportsMap.Count > 0)
            {
                WriteImport(codeWriter, codeFile.SystemImportsMap);
            }
            if (codeFile.NpmImportsMap != null && codeFile.NpmImportsMap.Count > 0)
            {
                WriteImport(codeWriter, codeFile.NpmImportsMap);
            }
            if (codeFile.ProjectImportsMap != null && codeFile.ProjectImportsMap.Count > 0)
            {
                WriteImport(codeWriter, codeFile.ProjectImportsMap);
            }
        }

        private void WriteImport(CodeWriter codeWriter, SortedDictionary<string, List<ImportItem>> importItemsMap)
        {
            if (importItemsMap.Count <= 0)
            {
                return;
            }

            foreach (var item in importItemsMap)
            {
                if (item.Value == null || item.Value.Count == 0)
                {
                    continue;
                }

                codeWriter.Write(Keywords.IMPORT).Write(Marks.WHITESPACE);

                var defaults = item.Value.Where(v => !v.NotDefault).OrderBy(v => v.Name).ToList();
                var notDefaults = item.Value.Where(v => v.NotDefault).OrderBy(v => v.Name).ToList();

                if (defaults.Count > 0)
                {
                    WriteImportItems(codeWriter, defaults);
                }

                if (defaults.Count > 0 && notDefaults.Count > 0)
                {
                    codeWriter.Write(", ");
                }

                if (notDefaults.Count > 0)
                {
                    codeWriter.Write(Marks.LEFT_BRACE).Write(Marks.WHITESPACE);

                    WriteImportItems(codeWriter, notDefaults);

                    codeWriter.Write(Marks.WHITESPACE).Write(Marks.RIGHT_BRACE);
                }

                codeWriter.Write(Marks.WHITESPACE).Write(Keywords.FROM).Write(Marks.WHITESPACE)
                    .Write(Marks.SINGLE_QUOTATION)
                    .Write(item.Key)
                    .Write(Marks.SINGLE_QUOTATION);

                codeWriter.WriteLine(";");
            }

            codeWriter.WriteLine();
        }

        private void WriteImportItems(CodeWriter codeWriter, List<ImportItem> defaults)
        {
            var enumerator = defaults.GetEnumerator();
            bool moveNext = enumerator.MoveNext();
            while (moveNext)
            {
                var current = enumerator.Current;

                codeWriter.Write(current.Name);
                if (current.Alias != null)
                {
                    // * as 
                    codeWriter.Write(Marks.WHITESPACE).Write(Marks.STAR).Write(Marks.WHITESPACE)
                        .Write(Keywords.AS).Write(Marks.WHITESPACE);
                }

                moveNext = enumerator.MoveNext();
                if (moveNext)
                {
                    codeWriter.Write(Marks.COMMA).Write(Marks.WHITESPACE);
                }
            }
        }
    }
}

