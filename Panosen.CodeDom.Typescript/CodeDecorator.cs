using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// CodeDecorator
    /// </summary>
    public abstract class CodeDecorator : CodeObject
    {
    }

    /// <summary>
    /// CodeVariableDecorator
    /// </summary>
    public class CodeVariableDecorator : CodeDecorator
    {
    }

    /// <summary>
    /// CodeMethodDecorator
    /// </summary>
    public class CodeMethodDecorator : CodeDecorator
    {
        /// <summary>
        /// Items
        /// </summary>
        public List<DataItem> Items { get; set; }
    }

    /// <summary>
    /// CodeAttributeExtension
    /// </summary>
    public static class CodeAttributeExtension
    {
        /// <summary>
        /// CodeAttribute
        /// </summary>
        public static CodeMethodDecorator AddPlainParam(this CodeMethodDecorator codeMethodDecorator, string value)
        {
            if (codeMethodDecorator.Items == null)
            {
                codeMethodDecorator.Items = new List<DataItem>();
            }

            codeMethodDecorator.Items.Add((DataValue)value);

            return codeMethodDecorator;
        }

        /// <summary>
        /// AddStringParam
        /// </summary>
        /// <returns></returns>
        public static CodeMethodDecorator AddStringParam(this CodeMethodDecorator codeMethodDecorator, string value)
        {
            if (codeMethodDecorator.Items == null)
            {
                codeMethodDecorator.Items = new List<DataItem>();
            }

            codeMethodDecorator.Items.Add(DataValue.DoubleQuotationString(value));

            return codeMethodDecorator;
        }


        /// <summary>
        /// AddDataObject
        /// </summary>
        public static CodeMethodDecorator AddDataObject(this CodeMethodDecorator codeAttribute, DataObject dataObject)
        {
            if (codeAttribute.Items == null)
            {
                codeAttribute.Items = new List<DataItem>();
            }

            codeAttribute.Items.Add(dataObject);

            return codeAttribute;
        }

        /// <summary>
        /// AddDataObject
        /// </summary>
        public static DataObject AddDataObject(this CodeMethodDecorator codeAttribute)
        {
            if (codeAttribute.Items == null)
            {
                codeAttribute.Items = new List<DataItem>();
            }

            DataObject dataObject = new DataObject();

            codeAttribute.Items.Add(dataObject);

            return dataObject;
        }

        /// <summary>
        /// AddDataValue
        /// </summary>
        public static CodeMethodDecorator AddDataValue(this CodeMethodDecorator codeAttribute, DataValue dataValue)
        {
            if (codeAttribute.Items == null)
            {
                codeAttribute.Items = new List<DataItem>();
            }

            codeAttribute.Items.Add(dataValue);

            return codeAttribute;
        }

    }
}
