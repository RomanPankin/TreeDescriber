using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCargo.Transformer
{
    /// <summary>
    /// Interface which provides a method for transforming nodes
    /// </summary>
    public interface INodeTransformer
    {
        /// <summary>
        /// Method which transforms the tree of nodes into a matching tree that uses the correct node types
        /// </summary>
        /// <param name="node">Source node</param>
        /// <returns>Transformed node</returns>
        Node Transform(Node node);
    }
}
