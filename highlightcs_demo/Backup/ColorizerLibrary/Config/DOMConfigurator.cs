using System;
using System.Configuration;
using System.Xml;
using log4net;


namespace ColorizerLibrary.Config
{
	/// <summary>
	/// Configure a colorizer from DOM
	/// </summary>
	public class DOMConfigurator
	{
		#region Internals
		private static readonly ILog Log = LogManager.GetLogger( typeof( DOMConfigurator) );
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public DOMConfigurator()
		{
		}
		#endregion

		/// <summary>
		/// Loads the configuration from the Web.Config and create a CodeColorizer
		/// </summary>
		/// <returns>Initialized colorizer</returns>
		/// <exception cref="Exception">Throws if ColorizerLibrary node is not found</exception>
		/// <exception cref="Exception">Throws if ColorizerLibrary/syntax node is not found</exception>
		/// <exception cref="Exception">Throws if ColorizerLibrary/style node is not found</exception>
		public static CodeColorizer Configure()
		{
			XmlElement config=(XmlElement)ConfigurationSettings.GetConfig("ColorizerLibrary");
			if (config==null)
				throw (new Exception("Could not load web.config configuration"));

			XmlNode node=config.SelectSingleNode("param[@name=\"syntax\"]");
			if (node==null)
				throw (new Exception("Could not find syntax parameter in web.config"));

			String syntax=node.Attributes["value"].Value;
			if (Log.IsInfoEnabled) Log.Info("Syntax file name: "+syntax);

			node=config.SelectSingleNode("param[@name=\"style\"]");
			if (node==null)
				throw (new Exception("Could not find style parameter in web.config"));

			String style=node.Attributes["value"].Value;
			if (Log.IsInfoEnabled) Log.Info("Style file name: "+style);

			return new CodeColorizer(syntax, style);			
		}
	}
}
