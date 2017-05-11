using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCargo.Describer
{
    /// <summary>
    /// Class that provides factory to describe node of any type
    /// </summary>
    public class NodeDescriberFactory : INodeDescriber
    {
        private static NodeDescriberFactory globalFactory = new NodeDescriberFactory();
        private static Dictionary<Type, INodeDescriber> nodeToDescriber = new Dictionary<Type, INodeDescriber>() {
            { typeof(NoChildrenNode), new NoChildrenNodeDescriber() },
            { typeof(SingleChildNode), new SingleChildNodeDescriber() },
            { typeof(TwoChildrenNode), new TwoChildrenNodeDescriber() }
        };

        private NodeDescriberFactory() { }

        /// <summary>
        /// Method returns factory that describes node of any type
        /// </summary>
        /// <returns></returns>
        public static INodeDescriber GetDescriber()
        {
            return globalFactory;
        }

        /// <summary>
        /// Method for describing the node
        /// </summary>
        /// <param name="node">Source node</param>
        /// <returns>Resulting string</returns>
        public string Describe(Node node)
        {
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
        public void Describe(StringBuilder builder, Node node, int level)
        {
            if (node == null || builder == null) return;

            INodeDescriber describer = nodeToDescriber[ node.GetType() ];
            if (describer == null) throw new Exception( "There is no describer for the node" );

            describer.Describe(builder, node, level);
        }
    }
}
