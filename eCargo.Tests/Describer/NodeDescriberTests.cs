using Microsoft.VisualStudio.TestTools.UnitTesting;
using eCargo.Describer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCargo.Describer.Tests
{
    [TestClass()]
    public class NodeDescriberTests
    {
        [TestMethod()]
        public void DescribeNull()
        {
            var describer = NodeDescriberFactory.GetDescriber();
            
            Assert.AreEqual("", describer.Describe(null));
        }

        [TestMethod()]
        public void DescribeNoChildrenNodeTest()
        {
            var describer = NodeDescriberFactory.GetDescriber();

            var node1 = new NoChildrenNode(null);
            var node2 = new NoChildrenNode("node2");

            Assert.AreEqual("new NoChildrenNode(\"\")", describer.Describe(node1));
            Assert.AreEqual("new NoChildrenNode(\"node2\")", describer.Describe(node2)); 
        }

        [TestMethod()]
        public void DescribeSingleChildNodeTest()
        {
            var describer = NodeDescriberFactory.GetDescriber();

            var node1 = new SingleChildNode("node1", null);
            var node2 = new SingleChildNode("node2", new NoChildrenNode("node2.1"));

            Assert.AreEqual("new SingleChildNode(\"node1\")", describer.Describe(node1));
            Assert.AreEqual("new SingleChildNode(\"node2\",\n    new NoChildrenNode(\"node2.1\"))", describer.Describe(node2));
        }

        [TestMethod()]
        public void DescribeTwoChildrenNodeTest()
        {
            var describer = NodeDescriberFactory.GetDescriber();

            var node1 = new TwoChildrenNode("node1", null, null);
            var node2 = new TwoChildrenNode("node2", new NoChildrenNode("node2.1"), null);
            var node3 = new TwoChildrenNode("node3", null, new NoChildrenNode("node3.2"));
            var node4 = new TwoChildrenNode("node4", new NoChildrenNode("node4.1"), new NoChildrenNode("node4.2"));

            Assert.AreEqual("new TwoChildrenNode(\"node1\")", describer.Describe(node1));
            Assert.AreEqual("new TwoChildrenNode(\"node2\",\n    new NoChildrenNode(\"node2.1\"))", describer.Describe(node2));
            Assert.AreEqual("new TwoChildrenNode(\"node3\",\n    new NoChildrenNode(\"node3.2\"))", describer.Describe(node3));
            Assert.AreEqual("new TwoChildrenNode(\"node4\",\n    new NoChildrenNode(\"node4.1\"),\n    new NoChildrenNode(\"node4.2\"))", describer.Describe(node4));
        }

        [TestMethod()]
        public void DescribeTreeTest()
        {
            var describer = NodeDescriberFactory.GetDescriber();

            var node = new SingleChildNode("root",
                            new TwoChildrenNode("child1",
                                new NoChildrenNode("leaf1"),
                                new SingleChildNode("child2",
                                    new NoChildrenNode("leaf2"))));

            Assert.AreEqual(
                "new SingleChildNode(\"root\",\n"+
                "    new TwoChildrenNode(\"child1\",\n" +
                "        new NoChildrenNode(\"leaf1\"),\n" +
                "        new SingleChildNode(\"child2\",\n" +
                "            new NoChildrenNode(\"leaf2\"))))",
                describer.Describe(node)
            );
        }
    }
}