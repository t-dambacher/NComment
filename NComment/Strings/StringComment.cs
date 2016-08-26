using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NComment.Strings
{
    /// <summary>
    /// Represents a string comment
    /// </summary>
    public abstract class StringComment
    {
        #region Properties

        /// <summary>
        /// Parts of the string
        /// </summary>
        private readonly String[] _parts;

        /// <summary>
        /// References comments in the current StringComment
        /// </summary>
        private readonly IEnumerable<StringCommentReference> _references;

        /// <summary>
        /// Result of a ToString call
        /// </summary>
        private String _toStringResult;

        #endregion

        #region Ctor

        internal StringComment()
            : this(new String[0], null) // todo
        { }

        internal StringComment(IEnumerable<String> parts, IEnumerable<StringCommentReference> references)
        {
            this._parts = new String[0];
            this._references = references ?? Enumerable.Empty<StringCommentReference>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Format the current StringComment as a String
        /// </summary>
        /// <returns>Current StringComment as a String</returns>
        public override String ToString()
        {
            return _toStringResult ?? (_toStringResult = PerformToString());
        }

        /// <summary>
        /// Format the current StringComment as a String
        /// </summary>
        /// <remarks>
        /// The ToString method is lazyloaded, so the actual implementation of ToString is here
        /// </remarks>
        /// <returns>Current StringComment as a String</returns>
        private String PerformToString()
        {
            Int32 capacity = CalculateResultStringLength();

            StringBuilder res = new StringBuilder(capacity);

            


            return res.ToString();
        }

        /// <summary>
        /// Calculates the length of the returned string
        /// </summary>
        /// <returns></returns>
        private Int32 CalculateResultStringLength()
        {
            Int32 capacity = 0;
            if (this._parts.Any())
                capacity += this._parts.Sum(s => s.Length);

            if (this._references.Any())
                capacity += this._references.Sum(r => r.Reference.ToString().Length);

            return capacity;
        }

        #endregion

        #region Static

        /// <summary>
        /// Implicit cast operator to a String
        /// </summary>
        /// <param name="commentString">String comment to cast</param>
        /// <returns>String comment casted to a String</returns>
        public static implicit operator String(StringComment commentString)
        {
            return commentString != null ? commentString.ToString() : String.Empty;
        }

        #endregion
    }
}
