using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCargo.Describer
{
    /// <summary>
    /// Class that describes the node with only 1 child
    /// </summary>
    public class SingleChildNodeDescriber : NodeDescriber
    {
        /// <summary>
        /// Extended method for describing the node. It works more efficiently with strings
        /// and allows to describe a tree
        /// </summary>
        /// <param name="builder">Resulting string</param>
        /// <param name="node">Source node</param>
        /// <param name="level">Nesting level</param>
        /// <returns>Resulting string</returns>
        public override StringBuilder Describe(StringBuilder builder, Node node, int level)
        {
            AddIntent(builder, level)
                .Append("new SingleChildNode(\"")
                .Append(node.Name)
                .Append("\"");

            Node child = ((SingleChildNode)node).Child;
            if (child != null)
            {
                builder.Append(",\n");
                NodeDescriberFactory.GetDescriber().Describe(builder, child, level + 1);
            }

            builder.Append(")");

            return builder;
        }
    }
}
