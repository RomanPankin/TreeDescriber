using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCargo.Writer
{
    /// <summary>
    /// Interface which writes string representation of the node to the specific file
    /// </summary>
    public interface INodeWriter
    {
        Task WriteToFileAsync(Node node, string filePath);
    }
}
