using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TMX.Data.Utlilties
{
  public class XML
  {
    public static bool HasChildNodes(XmlNode node)
    {
      if (node.ChildNodes.Count < 1)
        return false;
      if (node.ChildNodes.Count == 1 && node.ChildNodes[0].NodeType == XmlNodeType.Text)
        return false;
      return true;
    }
  }
}
