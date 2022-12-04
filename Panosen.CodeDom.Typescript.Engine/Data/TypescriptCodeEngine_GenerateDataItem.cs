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
        /// GenerateDataItem
        /// </summary>
        public void GenerateDataItem(DataItem dataItem, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (dataItem is DataArray)
            {
                GenerateDataArray(dataItem as DataArray, codeWriter, options, false);
            }
            else if (dataItem is DataObject)
            {
                GenerateDataObject(dataItem as DataObject, codeWriter, options, false);
            }
            else if (dataItem is SortedDataObject)
            {
                GenerateSortedDataObject(dataItem as SortedDataObject, codeWriter, options, false);
            }
            else if (dataItem is DataValue)
            {
                GenerateDataValue(dataItem as DataValue, codeWriter, options);
            }
            else if (dataItem is CodeMethod)
            {
                GenerateMethod(dataItem as CodeMethod, codeWriter, options, false);
            }

            if (dataItem is CodeLamdaNewInstance)
            {
                GenerateLamdaNewInstance(dataItem as CodeLamdaNewInstance, codeWriter, options);
            }

            if (dataItem is CodeLamdaExpression)
            {
                GenerateLamdaExpression(dataItem as CodeLamdaExpression, codeWriter, options);
            }

            if (dataItem is CodeLamdaStepBuilderCollection)
            {
                GenerateLamdaStepCollection(dataItem as CodeLamdaStepBuilderCollection, codeWriter, options);
            }
        }
    }
}
