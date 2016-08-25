using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NComment
{
    /// <summary>
    /// Represents a collection of comments on an Assembly and its types
    /// </summary>
    public class AssemblyCommentsCollection : IEnumerable<TypeComment>
    {
        /// <summary>
        /// Assembly 
        /// </summary>
        public Assembly Assembly { get; private set; }

        /// <summary>
        /// Comments on the types of the assembly
        /// </summary>
        public IEnumerable<TypeComment> Types { get; private set; }

        /// <summary>
        /// Creates a new instance of an AssemblyCommentsCollection
        /// </summary>
        /// <param name="assembly"></param>
        internal AssemblyCommentsCollection(Assembly assembly)
        {
            this.Assembly = assembly;
            this.Types = Enumerable.Empty<TypeComment>();
        }

        #region Implementation of IEnumerable<TypeComment>

        /// <summary>
        /// Returns an enumerator iterating over a collection
        /// </summary>
        /// <returns>Enumerator iterating over a collection</returns>
        public IEnumerator<TypeComment> GetEnumerator()
        {
            return this.Types.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator iterating over a collection
        /// </summary>
        /// <returns>Enumerator iterating over a collection</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}
