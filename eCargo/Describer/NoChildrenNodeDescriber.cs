using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCargo.Describer
{
    /// <summary>
    /// Class that describes the node without children
    /// </summary>
    public class NoChildrenNodeDescriber : NodeDescriber
    {
        /// <summary>
        /// Extended method for describing the node. It works more efficiently with strings
        /// and allows to describe a tree
        /// </summary>
        /// <param name="builder">Resulting string</param>
        /// <param name="node">Source node</param>
        /// <param name="level">Nesting level</param>
        /// <returns>Resulting string</returns>
        public override void Describe(StringBuilder builder, Node node, int level)
        {
            this.AddIntent(builder, level);

            builder.Append( $"new NoChildrenNode(\"{node.Name}\")" );
        }
    }
}
