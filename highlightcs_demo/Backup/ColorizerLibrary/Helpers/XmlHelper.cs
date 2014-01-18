using System;
using System.Xml;
using System.Web;
using log4net;

namespace ColorizerLibrary.Helpers
{
	/// <summary>
	/// Some basic function helpers for xml creation.
	/// </summary>
	public class XmlHelper
	{
		#region Internals
		private static readonly ILog Log = LogManager.GetLogger( typeof(XmlHelper) );
		#endregion

		#region Static methods
		/// <summary>adds a CDATA child elem</summary>
		/// <param name="node">node to append child</param>
		/// <param name="nodeName">new child node name</param>
		/// <param name="cdata">CDATA value</param>
		/// <exception>If could not create child node</exception>
		/// <exception>If could not create CDATA node</exception>
		/// <remarks>Author: Jonathan de Halleux, dehalleux@pelikhan.com, 2003</remarks>
		/// 		
		static public void XmlAddChildCDATAElem( XmlNode node, String nodeName, String cdata )
		{
			XmlNode newNode = node.OwnerDocument.CreateElement( nodeName );
			if (newNode == null)
			{
				if (Log.IsFatalEnabled) Log.Fatal("Could not create node");
				return;
			}

			node.AppendChild( newNode );
			
			XmlNode newCDATANode = node.OwnerDocument.CreateCDataSection( HttpUtility.HtmlEncode(cdata) );
			if (newCDATANode == null)
			{
				if (Log.IsFatalEnabled) Log.Fatal("Could not add CDATA node: " + nodeName + ", " + cdata );
				return;
			}
			newNode.AppendChild( newCDATANode );
		}
		/// <summary>adds a text child elem</summary>
		/// <param name="node">node to append child</param>
		/// <param name="nodeName">new child node name</param>
		/// <param name="text">text value</param>
		/// <exception>If could not create child node</exception>
		/// <remarks>Author: Jonathan de Halleux, dehalleux@pelikhan.com, 2003</remarks>
		static public void XmlAddChildElem( XmlNode node, String nodeName, String text )
		{
			XmlNode newNode = node.OwnerDocument.CreateElement( nodeName);
			if (newNode == null)
			{
				if (Log.IsFatalEnabled) Log.Fatal("Could not create node");
				return;		
			}
			newNode.Value = HttpUtility.HtmlEncode(text);
			node.AppendChild( newNode );
		}

		/// <summary>
		/// Adds an attribute to the node
		/// <param name="node">node to modify</param>
		/// <param name="name">Attribute name</param>
		/// <param name="text">Attribute value</param>
		/// </summary>
		public static void XmlSetAttribute(XmlNode node, string name, string text)
		{
			XmlAttribute attr = node.OwnerDocument.CreateAttribute(null,name,null);
			attr.Value=text;
			node.Attributes.Append( attr );				
		}	

		/// <summary>
		/// Extracts the value of the id attribute
		/// </summary>
		/// <param name="node">A xml node</param>
		/// <returns>Value of the id attribute</returns>
		/// <exception cref="System.Exception">Throws if the node is not null</exception>
		/// <exception cref="System.Exception">Throws if the id attribute is not found</exception>
		static public string GetIdFromNode (XmlNode node)
		{
			if (node == null)
			{
				Exception e = new Exception( "Could not find id parameter of node because it is null!");
				if (Log.IsFatalEnabled) Log.Fatal(e);
				throw e;
			}

			XmlNode Id = node.Attributes.GetNamedItem("id");
			if (Id == null)
			{
				Exception e = new Exception( "Could not find id parameter of node " + node.Name );
				if (Log.IsFatalEnabled) Log.Fatal(e);
				throw e;
			}

			return Id.Value;
		}
	
		#endregion

	}
}
