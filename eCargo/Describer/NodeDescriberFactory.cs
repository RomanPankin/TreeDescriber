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
        private static Dictionary<Type, INodeDescriber> nodeToDescriber = new Dictionary<Type, INodeDescriber>();

        static NodeDescriberFactory()
        {
            RegisterDescriber(typeof(Node), new NodeDescriber());
            RegisterDescriber(typeof(NoChildrenNode), new NoChildrenNodeDescriber());
            RegisterDescriber(typeof(SingleChildNode), new SingleChildNodeDescriber());
            RegisterDescriber(typeof(TwoChildrenNode), new TwoChildrenNodeDescriber());
        }

        /// <summary>
        /// Method returns factory that describes node of any type
        /// </summary>
        /// <returns></returns>
        public static INodeDescriber GetDescriber()
        {
            return globalFactory;
        }

        /// <summary>
        /// Method allows to add a match between node's type and node's description
        /// </summary>
        /// <param name="node">Node's type</param>
        /// <param name="describer">Node's description</param>
        public static void RegisterDescriber(Type node, INodeDescriber describer)
        {
            nodeToDescriber.Add(node, describer);
        }

        /// <summary>
        /// Method returns node's description by the type
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private static INodeDescriber GetDescriberForNode(Type node)
        {
            return nodeToDescriber[node];
        }

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
        public StringBuilder Describe(StringBuilder builder, Node node, int level)
        {
            if (builder == null) builder = new StringBuilder();
            if (node == null) return builder;

            INodeDescriber describer = GetDescriberForNode(node.GetType());
            return describer.Describe(builder, node, level);
        }
    }
}
