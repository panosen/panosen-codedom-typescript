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
        /// 生成SortedDataObject对应的字符串
        /// </summary>
        public void GenerateSortedDataObject(SortedDataObject sortedDataObject, CodeWriter codeWriter, GenerateOptions options = null, bool endWithLine = true)
        {
            if (sortedDataObject == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            codeWriter.Write(Marks.LEFT_BRACE);
            if (sortedDataObject.DataItemMap != null && sortedDataObject.DataItemMap.Count > 0)
            {
                //大括号后面的换行
                codeWriter.WriteLine();
                options.PushIndent();

                var enumerator = sortedDataObject.DataItemMap.GetEnumerator();
                var moveNext = enumerator.MoveNext();
                while (moveNext)
                {
                    var dataArrayItem = enumerator.Current;

                    codeWriter.Write(options.IndentString);

                    codeWriter.Write(options.DataObjectKeyQuotation);
                    codeWriter.Write(dataArrayItem.Key.Value);
                    codeWriter.Write(options.DataObjectKeyQuotation);
                    codeWriter.Write(": ");

                    GenerateDataItem(dataArrayItem.Value, codeWriter, options);

                    moveNext = enumerator.MoveNext();
                    if (moveNext)
                    {
                        codeWriter.Write(",");
                    }
                    codeWriter.WriteLine();
                }

                //大括号前面的缩进
                options.PopIndent();
                codeWriter.Write(options.IndentString);
            }

            codeWriter.Write(Marks.RIGHT_BRACE);

            if (endWithLine)
            {
                codeWriter.WriteLine();
            }
        }
    }
}
