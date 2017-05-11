using Microsoft.VisualStudio.TestTools.UnitTesting;
using eCargo.Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace eCargo.Writer.Tests
{
    [TestClass()]
    public class NodeWriterTests
    {
        [TestMethod()]
        public async Task WriteEmpty()
        {
            var filePath = "test-tree-empty.txt";

            INodeWriter implementation = new NodeWriter();
            await implementation.WriteToFileAsync(null, filePath);

            var result = File.ReadAllText(filePath);
            Assert.AreEqual("", result);
        }

        [TestMethod()]
        public async Task WriteToFileAsyncTest()
        {
            var filePath = "test-tree.txt";
            var node = new SingleChildNode("root",
                           new TwoChildrenNode("child1",
                               new NoChildrenNode("leaf1"),
                               new SingleChildNode("child2",
                                   new NoChildrenNode("leaf2"))));

            INodeWriter implementation = new NodeWriter();
            await implementation.WriteToFileAsync(node, filePath);

            var result = File.ReadAllText(filePath);
            Assert.AreEqual(
                "new SingleChildNode(\"root\",\n" +
                "    new TwoChildrenNode(\"child1\",\n" +
                "        new NoChildrenNode(\"leaf1\"),\n" +
                "        new SingleChildNode(\"child2\",\n" +
                "            new NoChildrenNode(\"leaf2\"))))",
                result
            );
        }
    }
}