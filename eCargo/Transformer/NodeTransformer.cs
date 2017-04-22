using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCargo.Transformer
{
    /// <summary>
    /// Class that implements node's transformations
    /// </summary>
    public class NodeTransformer : INodeTransformer
    {
        /// <summary>
        /// Method which transforms the tree of nodes into a matching tree that uses the correct node types
        /// </summary>
        /// <param name="node">Source node</param>
        /// <returns>Transformed node</returns>
        public Node Transform(Node node)
        {
            if (node == null) return null;
            if (!(node is ManyChildrenNode))
                throw new Exception("Node must be of ManyChildrenNode type");

            Node result = null;
            ManyChildrenNode sourceNode = (ManyChildrenNode)node;
            Node [] transformedChild = this.TransforChildren(sourceNode);
            
            switch (transformedChild.Length)
            {
                case 0:
                    result = new NoChildrenNode(sourceNode.Name);
                    break;
                case 1:
                    result = new SingleChildNode(
                                sourceNode.Name,
                                transformedChild[0]
                             );
                    break;
                case 2:
                    result = new TwoChildrenNode(
                                sourceNode.Name,
                                transformedChild[0],
                                transformedChild[1]
                             );
                    break;
                default:
                    throw new Exception("Unknown transformation");
            }

            return result;
        }

        private Node[] TransforChildren(ManyChildrenNode node)
        {
            List<Node> result = new List<Node>();

            foreach (Node child in node.Children)
            {
                Node transformedChild = this.Transform(child);
                result.Add(transformedChild);
            }

            return result.ToArray();
        }
    }
}
