using NComment.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NComment
{
    public class MemberComment : Comment
    {
        public MemberInfo ReflectedMember { get; private set; }

        public String Name { get; private set; }

        /// <summary>
        /// Creates a new instance of a Comment
        /// </summary>
        /// <param name="summary">Summary of the comment</param>
        internal MemberComment(MemberInfo reflectedMember, Summary summary)
            : base(summary)
        {
            this.ReflectedMember = reflectedMember;
        }
    }
}
