using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace NComment.Parsers
{
    /// <summary>
    /// Class resolving the xml comments file for a given assembly
    /// </summary>
    internal sealed class CommentsFileResolver
    {
        /// <summary>
        /// Assembly which we resolve the comments file from
        /// </summary>
        private readonly Assembly _assembly;

        /// <summary>
        /// Creates a new instance of a CommentsFileResolver
        /// </summary>
        /// <param name="assembly">Assembly which we resolve the comments file from</param>
        public CommentsFileResolver(Assembly assembly)
        {
            if (assembly == null)
                throw new ArgumentNullException("assembly");

            this._assembly = assembly;
        }

        /// <summary>
        /// Tries to resolve the XML file associated with the current assembly
        /// </summary>
        /// <returns>Path to the comments file, or null if it was not found</returns>
        public FileInfo ResolveCommentsFile()
        {
            String commentsFilename = GetCommentsFilename();
            if (String.IsNullOrWhiteSpace(commentsFilename))
                return null;

            return GetFallbackDirectories()
                .Select(d => ResolveCommentsFile(d, commentsFilename))
                .FirstOrDefault(f => f != null);
        }

        /// <summary>
        /// Returns the comments file name
        /// </summary>
        /// <returns>Comments file name</returns>
        private String GetCommentsFilename()
        {
            String assemblyPath = this._assembly.Location;
            if (String.IsNullOrWhiteSpace(assemblyPath))
                return null;

            String assemblyFilename = Path.GetFileNameWithoutExtension(assemblyPath);
            return assemblyFilename + ".xml";
        }

        /// <summary>
        /// Check if the given file exists into the directory
        /// </summary>
        /// <param name="directoryPath">Directory in which to check</param>
        /// <param name="filename">Comments file</param>
        /// <returns>FileInfo to the file if it exists, null otherwise</returns>
        private FileInfo ResolveCommentsFile(String directoryPath, String filename)
        {
            String commentsFile = Path.Combine(directoryPath, filename);
            if (!File.Exists(commentsFile))
                return null;

            return new FileInfo(commentsFile);
        }

        /// <summary>
        /// Returns the fallback directories on which to enumerate to find the comment file.
        /// </summary>
        /// <returns>List of fallback directories</returns>
        private IEnumerable<String> GetFallbackDirectories()
        {
            return new[]
            {
                Path.GetDirectoryName(this._assembly.Location),
                AppDomain.CurrentDomain.BaseDirectory,
                AppDomain.CurrentDomain.RelativeSearchPath,
                AppDomain.CurrentDomain.SetupInformation.PrivateBinPath


                // todo: should include other locations. At least, the GAC (/!\ x86 or x64), and some folders in Program Files / Program Files (x86)
            }
            .Where(d => !String.IsNullOrWhiteSpace(d))
            .Distinct();
        }
    }
}
