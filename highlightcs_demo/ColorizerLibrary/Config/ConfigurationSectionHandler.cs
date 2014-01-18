using System;
using System.Configuration;
using System.Xml;
using log4net;


namespace ColorizerLibrary.Config
{
	/// <summary>
	/// Configuration handler for code colorizer
	/// </summary>
	/// <remarks>Returns the XmlNode ColorizerLibrary of the Web.config</remarks>
	/// <remarks>Used in DomConfigurator</remarks>
	public class ConfigurationSectionHandler : IConfigurationSectionHandler
	{
		private static readonly ILog Log = LogManager.GetLogger( typeof(ConfigurationSectionHandler) );

		/// <summary>
		/// Default constructor
		/// </summary>
		public ConfigurationSectionHandler()
		{
			if (Log.IsInfoEnabled) Log.Info("Create ColorizerLibraryConfigurationSectionHandler");
		}

		/// <summary>
		/// Returns the section parameter
		/// </summary>
		/// <param name="parent"></param>
		/// <param name="configContext"></param>
		/// <param name="section"></param>
		/// <returns>section</returns>
		public object Create(object parent,object configContext,XmlNode section)
		{
			if (Log.IsInfoEnabled) Log.Info("CodeColorizer AppSettings:\n" + section.ToString() );
			return section;
		}
	}
}
