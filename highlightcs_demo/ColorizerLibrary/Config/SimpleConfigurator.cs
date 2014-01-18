using System;
using log4net;

namespace ColorizerLibrary.Config
{
	/// <summary>
	/// Simple configurator
	/// </summary>
	public class SimpleConfigurator : IConfigurator
	{
		#region Internals
		private static readonly ILog Log = LogManager.GetLogger( typeof(SimpleConfigurator) );
		private static string syntax="highlight.xml";
		private static string style="highlight.xsl";
		#endregion

		#region Constructor
		public SimpleConfigurator()
		{
		}
		#endregion

		/// <summary>
		/// Creates code colorizer
		/// </summary>
		/// <returns></returns>
		public CodeColorizer Configure()
		{
			if (Log.IsInfoEnabled) Log.Info("Building Code colorizer");
			return new CodeColorizer( syntax, style );
		}


		/// <summary>
		/// Syntax XML file name
		/// </summary>
		public static void SetSyntaxFileName( string s)
		{
			if (Log.IsInfoEnabled) Log.Info("Setting syntax file: " + s);
			syntax=s;
		}
		/// <summary>
		/// Syntax XML file name
		/// </summary>
		public static void SetStyleFileName(string s)
		{
			if (Log.IsInfoEnabled) Log.Info("Setting style file: " + s);
			style=s;
		}
	}
}
