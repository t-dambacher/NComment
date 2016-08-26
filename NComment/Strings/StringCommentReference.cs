using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NComment.Strings
{
    /// <summary>
    /// Represents a reference, in a StringComment, to an other StringComment
    /// </summary>
    internal sealed class StringCommentReference
    {
        /// <summary>
        /// Position of the referenced StringComment in the current StringComment
        /// </summary>
        public Int32 Position { get; private set; }

        /// <summary>
        /// Referenced StringComment
        /// </summary>
        public IReferencableComment Reference { get; private set; }

        /// <summary>
        /// Creates a new instance of a StringCommentReference
        /// </summary>
        /// <param name="position">Position of the referenced StringComment in the current StringComment</param>
        /// <param name="reference">Referenced StringComment</param>
        public StringCommentReference(Int32 position, IReferencableComment reference)
        {
            this.Position = position;
            this.Reference = reference;
        }
    }
}
