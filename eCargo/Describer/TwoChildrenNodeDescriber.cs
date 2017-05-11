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
        public override void Describe(StringBuilder builder, Node node, int level)
        {
            if (node == null || builder == null) return;

            INodeDescriber describer = NodeDescriberFactory.GetDescriber();
            Node firstChild = ((TwoChildrenNode)node).FirstChild;
            Node secondChild = ((TwoChildrenNode)node).SecondChild;

            this.AddIntent(builder, level);

            builder.Append( $"new TwoChildrenNode(\"{node.Name}\"" );
            if (firstChild != null)
            {
                builder.Append(",\n");
                describer.Describe(builder, firstChild, level+1);
            }

            if (secondChild != null)
            {
                builder.Append(",\n");
                describer.Describe(builder, secondChild, level+1);
            }

            builder.Append( ")" );
        }
    }
}
