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
        #region Properties

        /// <summary>
        /// Assembly which we want the comments for 
        /// </summary>
        public Assembly ReferencedAssembly { get; private set; }

        /// <summary>
        /// Comments on the types of the assembly
        /// </summary>
        public IEnumerable<TypeComment> Types 
        {
            get { return this._types.Values; }
        }

        /// <summary>
        /// Comments on the types of the assembly, identified by Type for easy retrieval
        /// </summary>
        private readonly IReadOnlyDictionary<Type, TypeComment> _types;

        #endregion

        #region Ctors

        /// <summary>
        /// Creates a new empty instance of an AssemblyCommentsCollection
        /// </summary>
        /// <param name="referencedAssembly">Assembly which we want the comments for</param>
        internal AssemblyCommentsCollection(Assembly referencedAssembly)
            : this(referencedAssembly, Enumerable.Empty<TypeComment>())
        { }

        /// <summary>
        /// Creates a new instance of an AssemblyCommentsCollection
        /// </summary>
        /// <param name="referencedAssembly">Assembly which we want the comments for</param>
        internal AssemblyCommentsCollection(Assembly referencedAssembly, IEnumerable<TypeComment> comments)
        {
            if (referencedAssembly == null)
                throw new ArgumentNullException("referencedAssembly");

            this.ReferencedAssembly = referencedAssembly;
            this._types = (comments ?? Enumerable.Empty<TypeComment>()).ToDictionary(c => c.ReflectedType, c => c);
        }

        #endregion

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

        #region Methods

        /// <summary>
        /// Index operator to directly access the comment for a type. Does not throw an exception if the type has no comment
        /// </summary>
        /// <param name="key">Type which we want the comment for</param>
        /// <returns>Comment for the type</returns>
        internal TypeComment this[Type key]
        {
            get
            {
                if (key.Assembly != this.ReferencedAssembly)
                    throw new ArgumentException("The given type does not belong to the current assembly.", "key");

                TypeComment res = null;

                this._types.TryGetValue(key, out res);

                return res;
            }
        }

        #endregion
    }
}
