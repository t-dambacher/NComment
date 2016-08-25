using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NComment.Strings
{
    public abstract class StringComment
    {

        /// <summary>
        /// Implicit cast operator to a String
        /// </summary>
        /// <param name="commentString">String comment to cast</param>
        /// <returns>String comment casted to a String</returns>
        public static implicit operator String(StringComment commentString)
        {
            return commentString != null ? commentString.ToString() : String.Empty;
        }
    }
}
