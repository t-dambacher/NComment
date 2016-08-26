using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Parse the xml comments file for the given file (if any), 
        /// </summary>
        /// <param name="assembly">The assembly which we want the comments from</param>
        /// <returns>The comments collection for this assembly</returns>
        public AssemblyCommentsCollection Parse(Assembly assembly)
        {
            return null;   // todo tda
        }
    }
}
