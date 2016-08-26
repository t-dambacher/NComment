using NComment.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NComment
{
    /// <summary>
    /// Represents a comment associated with a member from a type
    /// </summary>
    public class MemberComment : Comment
    {
        /// <summary>
        /// Member associated with the comment
        /// </summary>
        public MemberInfo ReflectedMember { get; private set; }

        /// <summary>
        /// Name of the member
        /// </summary>
        public String Name { get; private set; }

        /// <summary>
        /// Creates a new instance of a Comment
        /// </summary>
        /// <param name="reflectedMember">Member associated with the comment</param>
        /// <param name="summary">Summary of the comment</param>
        internal MemberComment(MemberInfo reflectedMember, Summary summary)
            : base(summary)
        {
            this.ReflectedMember = reflectedMember;
        }
    }
}
