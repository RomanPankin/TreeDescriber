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
    public abstract class NodeDescriber : INodeDescriber
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
            if (node == null) return "";

            StringBuilder result = new StringBuilder();
            Describe(result, node, 0);

            return result.ToString();
        }

        /// <summary>
        /// Extended method for describing the node. It works more efficiently with strings
        /// and allows to describe a tree
        /// </summary>
        /// <param name="builder">Resulting string</param>
        /// <param name="node">Source node</param>
        /// <param name="level">Nesting level</param>
        public abstract void Describe(StringBuilder builder, Node node, int level);

        /// <summary>
        /// Method which adds intent to the resulting string to show the nesting level
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        protected void AddIntent(StringBuilder builder, int level)
        {
            for (int I = 0; I < level; I++)
                builder.Append(LEVEL_INDENT);
        }
    }
}
