using NComment.Repositories;
using System;
using System.ComponentModel;
using System.Reflection;

namespace NComment
{
    /// <summary>
    /// Extensions methods to provide easy use of the API, on the System.Reflection types
    /// </summary>
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public static class Extensions
    {
        /// <summary>
        /// Get the XML comment from the class represented by the given type
        /// </summary>
        /// <param name="type">Type whom we want the xml comment</param>
        /// <returns>Xml comment from the type</returns>
        public static TypeComment GetXmlComment(this Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            AssemblyCommentsCollection comments = new AssembliesCommentsRepository().Get(type.Assembly);
            return comments[type];
        }

        /// <summary>
        /// Get the XML comment from the given member
        /// </summary>
        /// <param name="member">Member whom we want the xml comment</param>
        /// <returns>Xml comment from the member</returns>
        public static MemberComment GetXmlComment(this MemberInfo member)
        {
            if (member == null)
                throw new ArgumentNullException("member");

            TypeComment typeComment = GetXmlComment(member.DeclaringType);
            if (typeComment == null)
                return null;

            return typeComment[member];
        }
    }
}
