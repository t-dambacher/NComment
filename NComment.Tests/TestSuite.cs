using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NComment.Tests
{
    /// <summary>
    /// Base class for test suites
    /// </summary>
    public abstract class TestSuite
    {
        /// <summary>
        /// Returns the test assembly (ie, the current one)
        /// </summary>
        /// <returns>Test assembly</returns>
        protected Assembly GetTestAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
