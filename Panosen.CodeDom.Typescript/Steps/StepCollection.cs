using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Typescript
{
    /// <summary>
    /// 一批语句
    /// </summary>
    public class StepCollection : StepOrCollection, IEnumerable<StepOrCollection>
    {
        /// <summary>
        /// Steps
        /// </summary>
        public List<StepOrCollection> Steps { get; } = new List<StepOrCollection>();

        /// <summary>
        /// StepMap
        /// </summary>
        public Dictionary<string, StepOrCollection> StepMap { get; } = new Dictionary<string, StepOrCollection>();

        /// <summary>
        /// Steps[index]
        /// </summary>
        public StepOrCollection this[int index]
        {
            get
            {
                return this.Steps[index];
            }
        }

        /// <summary>
        /// Steps[index]
        /// </summary>
        public StepOrCollection this[string name]
        {
            get
            {
                return this.StepMap[name];
            }
        }

        #region IEnumerable Members

        /// <summary>
        /// IEnumerable.GetEnumerator()
        /// </summary>
        public IEnumerator<StepOrCollection> GetEnumerator()
        {
            return this.Steps.GetEnumerator();
        }

        /// <summary>
        /// IEnumerable.GetEnumerator()
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Steps.GetEnumerator();
        }

        #endregion
    }
}
