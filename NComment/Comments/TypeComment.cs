using NComment.Strings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace NComment
{
    /// <summary>
    /// Represents a comment of a type / class / struct, it's members, and their comments
    /// </summary>
    public class TypeComment : Comment
    {
        #region Properties

        /// <summary>
        /// Type which the comment belongs to
        /// </summary>
        public Type ReflectedType { get; private set; }

        /// <summary>
        /// Comments on the type's members
        /// </summary>
        public IEnumerable<MemberComment> Members 
        {
            get { return this._members.Values; }
        }

        /// <summary>
        /// Dictionary of MemberComments, identified by Member
        /// </summary>
        private readonly IReadOnlyDictionary<MemberInfo, MemberComment> _members;

        #endregion

        #region Ctors

        /// <summary>
        /// Creates a new instance of a Comment
        /// </summary>
        /// <param name="reflectedType">Type which the comment belongs to</param>
        /// <param name="summary">Summary of the comment</param>
        internal TypeComment(Type reflectedType, Summary summary)
            : base(summary)
        {
            this.ReflectedType = reflectedType;
            this._members = new Dictionary<MemberInfo, MemberComment>();    // todo
        }

        #endregion

        #region Methods

        /// <summary>
        /// Index operator to directly access the comment for a type. Does not throw an exception if the type has no comment
        /// </summary>
        /// <param name="key">Type which we want the comment for</param>
        /// <returns>Comment for the type</returns>
        internal MemberComment this[MemberInfo key]
        {
            get
            {
                MemberComment res = null;

                this._members.TryGetValue(key, out res);

                return res;
            }
        }

        #endregion
    }
}
