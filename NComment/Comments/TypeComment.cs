using NComment.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NComment
{
    /// <summary>
    /// Represents a comment of a type / class / struct, it's members, and their comments
    /// </summary>
    public class TypeComment : Comment
    {
        /// <summary>
        /// Type which the comment belongs to
        /// </summary>
        public Type ReflectedType { get; private set; }

        /// <summary>
        /// Comments on the type's members
        /// </summary>
        public IEnumerable<MemberComment> Members { get; private set; }

        /// <summary>
        /// Creates a new instance of a Comment
        /// </summary>
        /// <param name="reflectedType">Type which the comment belongs to</param>
        /// <param name="summary">Summary of the comment</param>
        internal TypeComment(Type reflectedType, Summary summary)
            : base(summary)
        {
            this.ReflectedType = reflectedType;
            this.Members = Enumerable.Empty<MemberComment>();
        }
    }
}
