using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript.Engine
{
    /// <summary>
    /// TypescriptCodeEngine
    /// </summary>
    partial class TypescriptCodeEngine
    {
        /// <summary>
        /// 生成列表
        /// </summary>
        /// <param name="dataArray"></param>
        /// <param name="codeWriter"></param>
        /// <param name="options"></param>
        /// <param name="endWithLine"></param>
        public void GenerateDataArray(DataArray dataArray, CodeWriter codeWriter, GenerateOptions options = null, bool endWithLine = true)
        {
            if (dataArray == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            if (dataArray.Items == null || dataArray.Items.Count == 0)
            {
                codeWriter.Write(Marks.LEFT_SQUARE_BRACKET).Write(Marks.RIGHT_SQUARE_BRACKET);
            }
            else
            {
                codeWriter.Write(Marks.LEFT_SQUARE_BRACKET);

                if (dataArray.Items.Count > 0)
                {
                    if (options.DataArrayItemBreakLine)
                    {
                        GenerateDataArrayItemsBreakLine(dataArray.Items, codeWriter, options);

                        codeWriter.Write(options.IndentString);
                        codeWriter.Write(Marks.RIGHT_SQUARE_BRACKET);
                    }
                    else
                    {
                        GenerateDataArrayItemsSameLine(dataArray.Items, codeWriter, options);

                        codeWriter.Write(Marks.RIGHT_SQUARE_BRACKET);
                    }
                }
                else
                {
                    codeWriter.Write(Marks.RIGHT_SQUARE_BRACKET);
                }
            }

            if (endWithLine)
            {
                codeWriter.WriteLine();
            }
        }

        private void GenerateDataArrayItemsSameLine(List<DataItem> dataItems, CodeWriter codeWriter, GenerateOptions options)
        {
            var enumerator = dataItems.GetEnumerator();
            var moveNext = enumerator.MoveNext();
            while (moveNext)
            {
                GenerateDataItem(enumerator.Current, codeWriter, options);

                moveNext = enumerator.MoveNext();
                if (moveNext)
                {
                    codeWriter.Write(Marks.COMMA);
                    codeWriter.Write(Marks.WHITESPACE);
                }
            }
        }

        private void GenerateDataArrayItemsBreakLine(List<DataItem> dataItems, CodeWriter codeWriter, GenerateOptions options)
        {
            codeWriter.WriteLine();
            options.PushIndent();

            var enumerator = dataItems.GetEnumerator();
            var moveNext = enumerator.MoveNext();
            while (moveNext)
            {
                codeWriter.Write(options.IndentString);

                GenerateDataItem(enumerator.Current, codeWriter, options);

                moveNext = enumerator.MoveNext();
                if (moveNext)
                {
                    codeWriter.Write(Marks.COMMA);
                }

                codeWriter.WriteLine();
            }

            options.PopIndent();
        }
    }
}
