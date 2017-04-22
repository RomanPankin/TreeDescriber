using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCargo.Describer
{
    /// <summary>
    /// Class that describes the node with 2 children
    /// </summary>
    public class TwoChildrenNodeDescriber : NodeDescriber
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
                .Append("new TwoChildrenNode(\"")
                .Append(node.Name)
                .Append("\"");

            Node firstChild = ((TwoChildrenNode)node).FirstChild;
            Node secondChild = ((TwoChildrenNode)node).SecondChild;

            if (firstChild != null || secondChild != null)
            {
                INodeDescriber describer = NodeDescriberFactory.GetDescriber();
                level++;

                builder.Append(",");

                if (firstChild != null)
                {
                    builder.Append("\n");
                    describer.Describe(builder, firstChild, level);
                }

                builder.Append(",");

                if (secondChild != null)
                {
                    builder.Append("\n");
                    describer.Describe(builder, secondChild, level);
                }
            }

            builder.Append(")");

            return builder;
        }
    }
}
