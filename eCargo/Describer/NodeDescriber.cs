using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCargo.Describer
{
    /// <summary>
    /// Class that describes base node without children and name
    /// </summary>
    public class NodeDescriber : INodeDescriber
    {
        /// <summary>
        /// Indent that shows the nesting level of the node
        /// </summary>
        public static readonly string LEVEL_INDENT = "    ";

        /// <summary>
        /// Method for describing the node
        /// </summary>
        /// <param name="node">Source node</param>
        /// <returns>Resulting string</returns>
        public string Describe(Node node)
        {
            return Describe(new StringBuilder(), node, 0).ToString();
        }

        /// <summary>
        /// Extended method for describing the node. It works more efficiently with strings
        /// and allows to describe a tree
        /// </summary>
        /// <param name="builder">Resulting string</param>
        /// <param name="node">Source node</param>
        /// <param name="level">Nesting level</param>
        /// <returns>Resulting string</returns>
        public virtual StringBuilder Describe(StringBuilder builder, Node node, int level)
        {
            return builder;
        }

        /// <summary>
        /// Method which adds intent to the resulting string to show the nesting level
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        protected StringBuilder AddIntent(StringBuilder builder, int level)
        {
            for (int I = 0; I < level; I++)
                builder.Append(LEVEL_INDENT);

            return builder;
        }
    }
}
