using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCargo.Describer
{
    /// <summary>
    /// Interface which provides a method for describing the node
    /// </summary>
    public interface INodeDescriber
    {
        /// <summary>
        /// Method for describing a node
        /// </summary>
        /// <param name="node">Source node</param>
        /// <returns>Resulting string</returns>
        string Describe(Node node);

        /// <summary>
        /// Extended method for describing the node. It works more efficiently with strings
        /// and allows to describe a tree
        /// </summary>
        /// <param name="builder">Resulting string</param>
        /// <param name="node">Source node</param>
        /// <param name="level">Nesting level</param>
        void Describe(StringBuilder builder, Node node, int level);
    }
}
