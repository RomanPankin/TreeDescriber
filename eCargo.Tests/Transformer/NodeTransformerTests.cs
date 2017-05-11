using eCargo.Describer;
using eCargo.Transformer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCargo.Transformer.Tests
{
    [TestClass()]
    public class NodeDescriberTests
    {
        [TestMethod()]
        public void TransformNull()
        {
            var transformer = new NodeTransformer();
            var describer = NodeDescriberFactory.GetDescriber();
            var node1 = transformer.Transform(null);

            Assert.AreEqual("", describer.Describe(node1));
        }

        [TestMethod()]
        public void TransformNoChildrenTest()
        {
            var transformer = new NodeTransformer();
            var describer = NodeDescriberFactory.GetDescriber();

            var node1 = transformer.Transform(
                    new ManyChildrenNode("node1")
                );

            Assert.AreEqual("new NoChildrenNode(\"node1\")", describer.Describe(node1));
        }

        [TestMethod()]
        public void TransformSingleChildTest()
        {
            var transformer = new NodeTransformer();
            var describer = NodeDescriberFactory.GetDescriber();

            var node1 = transformer.Transform(
                    new ManyChildrenNode("node1", new Node[] {
                        new ManyChildrenNode("node2")
                    })
                );

            Assert.AreEqual("new SingleChildNode(\"node1\",\n    new NoChildrenNode(\"node2\"))", describer.Describe(node1));
        }

        [TestMethod()]
        public void TransformTwoChildrenTest()
        {
            var transformer = new NodeTransformer();
            var describer = NodeDescriberFactory.GetDescriber();

            var node1 = transformer.Transform(
                    new ManyChildrenNode("node1", new Node[] {
                        new ManyChildrenNode("node2"),
                        new ManyChildrenNode("node3")
                    })
                );

            Assert.AreEqual("new TwoChildrenNode(\"node1\",\n    new NoChildrenNode(\"node2\"),\n    new NoChildrenNode(\"node3\"))", describer.Describe(node1));
        }

        [TestMethod()]
        public void TransformTreeTest()
        {
            var transformer = new NodeTransformer();
            var describer = NodeDescriberFactory.GetDescriber();

            var node1 = transformer.Transform(
                    new ManyChildrenNode("root",
                        new ManyChildrenNode("child1",
                            new ManyChildrenNode("leaf1"),
                            new ManyChildrenNode("child2",
                                new ManyChildrenNode("leaf2"))))
                );

            Assert.AreEqual(
                "new SingleChildNode(\"root\",\n" +
                "    new TwoChildrenNode(\"child1\",\n" +
                "        new NoChildrenNode(\"leaf1\"),\n" +
                "        new SingleChildNode(\"child2\",\n" +
                "            new NoChildrenNode(\"leaf2\"))))",
                describer.Describe(node1)
            );
        }
    }
}
