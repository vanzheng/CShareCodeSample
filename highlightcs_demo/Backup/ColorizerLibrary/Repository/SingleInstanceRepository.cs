using System;
using log4net;

namespace ColorizerLibrary.Repository
{
	using Config;

	/// <summary>
	/// Description résumée de CodeColorizerRepository.
	/// </summary>
	public class SingleInstanceRepository : IRepository
	{
		#region internals
		private static readonly ILog Log = LogManager.GetLogger( typeof(SimpleConfigurator) );
		private static CodeColorizer SyntaxEngine;
		private IConfigurator config = new SimpleConfigurator();
		#endregion
		public SingleInstanceRepository()
		{
		}

		public CodeColorizer GetColorizer( string key )
		{
			if (SyntaxEngine == null)
			{
				lock(SyntaxEngine)
				{
					SyntaxEngine = config.Configure();
					if (SyntaxEngine == null)
						throw (new Exception("Could not create colorizer engine"));
				}
			}

			return SyntaxEngine;
		}

	}
}
