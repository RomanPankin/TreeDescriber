using eCargo.Describer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eCargo.Writer
{
    /// <summary>
    /// Class which writes string representation of the node to the specific file
    /// </summary>
    public class NodeWriter : INodeWriter
    {
        public Task WriteToFileAsync(Node node, string filePath)
        {
            return Task.Factory.StartNew(() =>
            {
                INodeDescriber describer = NodeDescriberFactory.GetDescriber();
                string text = describer.Describe(node);

                using (StreamWriter w = new StreamWriter(filePath))
                {
                    w.Write(text);
                }
            });
        }
    }
}
