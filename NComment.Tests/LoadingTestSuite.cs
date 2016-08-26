using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NComment.Repositories;
using System.Reflection;
using NComment.Parsers;
using System.IO;

namespace NComment.Tests
{
    /// <summary>
    /// Test class for the loading part of the NComment API
    /// </summary>
    [TestClass]
    public class LoadingTestSuite : TestSuite
    {
        /// <summary>
        /// Test category for the current class
        /// </summary>
        const String CATEGORY = "Loading";

        /// <summary>
        /// Asserts that the comments for a given collection are loaded only once per AppDomain
        /// </summary>
        [TestMethod, TestCategory(CATEGORY)]
        public void Assert_Comments_Are_Only_Loaded_Once()
        {
            Assembly testAssembly = GetTestAssembly();

            AssemblyCommentsCollection firstLoadedCollection = GetCommentsCollection(testAssembly);
            AssemblyCommentsCollection secondLoadedCollection = GetCommentsCollection(testAssembly);

            Boolean isReferenceEqual = Object.ReferenceEquals(firstLoadedCollection, secondLoadedCollection);

            Assert.IsTrue(isReferenceEqual, "The assembly comments collection has been loaded twice, but shouldn't.");
        }

        /// <summary>
        /// Asserts that the comments for a the test assembly is not empty
        /// </summary>
        [TestMethod, TestCategory(CATEGORY)]
        public void Assert_Comments_Are_Not_Empty()
        {
            AssemblyCommentsCollection comments = GetCommentsCollection(GetTestAssembly());
            Assert.IsTrue(comments.Types.Any(), "The test assembly comments have not been successfully loaded.");
        }

        /// <summary>
        /// Asserts that the test assembly's comments file is found by the file resolver
        /// </summary>
        [TestMethod, TestCategory(CATEGORY)]
        public void Assert_TestAssembly_CommentsFile_Is_Found()
        {
            CommentsFileResolver fileResolver = new CommentsFileResolver(GetTestAssembly());
            FileInfo commentsFile = fileResolver.ResolveCommentsFile();
            Assert.IsNotNull(commentsFile, "The file resolver did not found the test assembly's XML comment file.");
        }

        /// <summary>
        /// Asserts that the test assembly's comments file is found by the file resolver
        /// </summary>
        [TestMethod, TestCategory(CATEGORY)]
        public void Assert_DotNetFramework_CommentsFile_Is_Found()
        {
            CommentsFileResolver fileResolver = new CommentsFileResolver(GetSystemAssembly());
            FileInfo commentsFile = fileResolver.ResolveCommentsFile();
            Assert.IsNotNull(commentsFile, "The file resolver did not found the System assembly's XML comment file.");
        }

        /// <summary>
        /// Retrieves a comments collection for a given assembly
        /// </summary>
        /// <param name="assembly">Assembly which we want the comments from</param>
        /// <returns>Comments collection</returns>
        private AssemblyCommentsCollection GetCommentsCollection(Assembly assembly)
        {
            AssembliesCommentsRepository repository = new AssembliesCommentsRepository();
            return repository.Get(assembly);
        }
    }
}
