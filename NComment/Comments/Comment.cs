using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NComment.Strings;

namespace NComment
{
    public abstract class Comment
    {
        /// <summary>
        /// Describe a type or a type member
        /// </summary>
        public Summary Summary { get; private set; }

        /// <summary>
        /// Creates a new instance of a Comment
        /// </summary>
        /// <param name="summary">Summary of the comment</param>
        protected Comment(Summary summary)
        {
            this.Summary = summary;
        }

        /// <summary>
        /// Implicit cast operator to a String
        /// </summary>
        /// <param name="comment">Comment to cast</param>
        /// <returns>Comment casted to a String</returns>
        public static implicit operator String(Comment comment)
        {
            return comment != null ? comment.Summary : String.Empty;
        }
    }
}
