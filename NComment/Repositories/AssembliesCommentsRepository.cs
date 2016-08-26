using NComment.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NComment.Repositories
{
    /// <summary>
    /// Repository of AssemblyCommentsCollection
    /// </summary>
    /// <remarks>
    /// This class is the entry point for retrieving comments. It uses a parser to parse the files, and store the results into a static cache, for easy retrieval afterwards.
    /// </remarks>
    internal sealed class AssembliesCommentsRepository
    {
        /// <summary>
        /// Static instance of a dictionary, holding a reference to the AssemblyCommentsCollections during the whole application lifecycle
        /// </summary>
        private static readonly Dictionary<Assembly, AssemblyCommentsCollection> _cache = new Dictionary<Assembly, AssemblyCommentsCollection>();

        /// <summary>
        /// Parser of comments
        /// </summary>
        private readonly CommentsParser _parser;

        /// <summary>
        /// Creates a new instance of a AssembliesCommentsRepository
        /// </summary>
        public AssembliesCommentsRepository()
        {
            this._parser = new CommentsParser();
        }

        /// <summary>
        /// Retrieves the comments collection for a given assembly
        /// </summary>
        /// <param name="assembly">The assembly which we want the comments from</param>
        /// <returns>The comments collection for this assembly</returns>
        public AssemblyCommentsCollection Get(Assembly assembly)
        {
            AssemblyCommentsCollection res = null;

            // Tries to get the result from the cache
            if (!_cache.TryGetValue(assembly, out res))
            {
                res = _parser.Parse(assembly);

                // If the parser returns nothing (ie, no comments file is found), we create a empty collection and store it in the cache
                if (res == null)
                {
                    res = new AssemblyCommentsCollection(assembly);
                }

                _cache.Add(assembly, res);
            }

            return res;
        }
    }
}
