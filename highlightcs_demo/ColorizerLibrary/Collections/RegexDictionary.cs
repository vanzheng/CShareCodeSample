using System;
using System.Xml;
using System.Text.RegularExpressions;
using System.Collections;
using log4net;

namespace ColorizerLibrary.Collections
{
	using ColorizerLibrary.Helpers;

	/// <summary>
	///  Dictionnary associating string to Regex
	/// </summary>
	/// <remarks>This implementation uses a HashTable to store the Regex objects</remarks>
	public class RegexDictionary
	{
		#region Internals
		private static readonly ILog Log = log4net.LogManager.GetLogger( typeof( RegexDictionary ));
		private IDictionary Dictionary;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor.
		/// </summary>
		public RegexDictionary()
		{
			Dictionary = new Hashtable();
		}
#endregion

		#region Protected Methods
		/// <summary>
		/// Adds a pair string - Regex to the Dictionary
		/// </summary>
		/// <param name="key">string identifying the regular expression string</param>
		/// <param name="regExp">Regular expression string</param>
		protected void Add( string key, Regex regExp )
		{
			if (key  == null)
			{
				Exception e = new Exception("Key cannot be null");
				if (Log.IsErrorEnabled) Log.Error(e);
				throw e;
			}
			if (regExp  == null)
			{
				Exception e = new Exception("RegExp cannot be null");
				if (Log.IsErrorEnabled) Log.Error(e);
				throw e;
			}

			Dictionary.Add( key, regExp );
		}

		/// <summary>
		/// Retreive the regular expression options from the language node
		/// </summary>
		/// <param name="languageNode">langue name</param>
		/// <returns>RegexOptions enumeration combination</returns>
		static protected RegexOptions GetRegexOptions( XmlNode languageNode)
		{
			RegexOptions regOp = RegexOptions.Multiline | RegexOptions.Compiled;
			// check if case sensitive...
			XmlNode caseNode = languageNode.Attributes.GetNamedItem("not-case-sensitive");
			if (caseNode != null && caseNode.Value=="yes")
				return regOp | RegexOptions.IgnoreCase;
			else
				return regOp;
		}
		#endregion

		#region Key Add / Remove
		/// <summary>
		/// Add a regex depending on 2 node
		/// </summary>
		/// <param name="languageNode">Langage node</param>
		/// <param name="subNode">Sub node</param>
		/// <param name="sRegExp">Regular expression string</param>
		public void AddKey( XmlNode languageNode, XmlNode subNode, string sRegExp)
		{
			Regex regExp = new Regex( sRegExp, GetRegexOptions(languageNode) );
			if (regExp == null)
			{
				Exception e = new Exception( "Could not create regular expression");
				if (Log.IsFatalEnabled) Log.Fatal(e);
				throw e;
			}

			Add( XmlHelper.GetIdFromNode(languageNode) 
				+ "." + XmlHelper.GetIdFromNode(subNode) ,  regExp);
		}

		/// <summary>
		/// Add a regex depending on 3 node
		/// </summary>
		/// <param name="languageNode">Langage node</param>
		/// <param name="subNode">Sub node</param>
		/// <param name="subNode2">Sub node 2</param>
		/// <param name="sRegExp">Regular expression string</param>
		/// <exception>If node don't have Id field</exception>
		public void AddKey( XmlNode languageNode, XmlNode subNode, XmlNode subNode2, string sRegExp)
		{
			Regex regExp = new Regex( sRegExp, GetRegexOptions(languageNode) );
			if (regExp == null)
			{
				Exception e = new Exception( "Could not create regular expression");
				if (Log.IsFatalEnabled) Log.Fatal(e);
				throw e;
			}

			Add( XmlHelper.GetIdFromNode(languageNode) 
				+ "." + XmlHelper.GetIdFromNode(subNode) 
				+ "." + XmlHelper.GetIdFromNode(subNode2) ,  
				regExp);
		}

		/// <summary>
		/// Retreives the regular expression out of 2 nodes
		/// </summary>
		/// <param name="languageNode"></param>
		/// <param name="subNode"></param>
		/// <returns>Regular expression</returns>
		/// <exception>If can't find Regex object</exception>
		public Regex GetKey(XmlNode languageNode, XmlNode subNode)
		{
			return (Regex)Dictionary[ XmlHelper.GetIdFromNode(languageNode) 
				+ "." + XmlHelper.GetIdFromNode(subNode) ];
		}

		/// <summary>
		/// Retreives the regular expression out of 3 nodes
		/// </summary>
		/// <param name="languageNode"></param>
		/// <param name="subNode"></param>
		/// <param name="subNode2"></param>
		/// <returns>Regular expression</returns>
		/// <exception>If can't find Regex object</exception>
		public Regex GetKey(XmlNode languageNode, XmlNode subNode, XmlNode subNode2)
		{
			return (Regex)Dictionary[
							XmlHelper.GetIdFromNode(languageNode) 
							+ "." + XmlHelper.GetIdFromNode(subNode) 
							+ "." + XmlHelper.GetIdFromNode(subNode2)];
		}

		#endregion
	}
}
