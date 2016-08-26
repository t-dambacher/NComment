using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NComment.Parsers
{
    /// <summary>
    /// Parser of a xml comments file
    /// </summary>
    internal sealed class CommentsParser
    {
        #region Properties

        /// <summary>
        /// Assembly which we parse the comments
        /// </summary>
        private readonly Assembly _assembly;

        /// <summary>
        /// Resolver to retrieve the comments file
        /// </summary>
        private readonly CommentsFileResolver _fileResolver;

        #endregion

        #region Ctors

        /// <summary>
        /// Creates a new instance of a CommentsParser for the given assembly
        /// </summary>
        /// <param name="assembly">Assembly which we parse the comments</param>
        public CommentsParser(Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException("assembly");

            this._assembly = assembly;
            this._fileResolver = new CommentsFileResolver(assembly);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Parse the xml comments file for the given file (if any), 
        /// </summary>
        /// <returns>The comments collection for this assembly</returns>
        public AssemblyCommentsCollection Parse()
        {
            FileInfo commentsFile = this._fileResolver.ResolveCommentsFile();
            if (commentsFile == null)
                return null;

            return new AssemblyCommentsCollection(this._assembly, ParseCommentsFromFile(commentsFile));
        }

        /// <summary>
        /// Parses the comments file
        /// </summary>
        /// <param name="commentsFile">Xml file, containing the comments of the current assembly, to parse</param>
        /// <returns>List of TypeComments</returns>
        private IEnumerable<TypeComment> ParseCommentsFromFile(FileInfo commentsFile)
        {
            return Enumerable.Empty<TypeComment>(); // todo
        }

        #endregion
    }
}
