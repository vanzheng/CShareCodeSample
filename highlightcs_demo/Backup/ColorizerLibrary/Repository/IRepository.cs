using System;

namespace ColorizerLibrary.Repository
{
	/// <summary>
	/// Description résumée de IRepository.
	/// </summary>
	interface IRepository
	{
		/// <summary>
		/// Returns a code colorizer associated to a key
		/// </summary>
		CodeColorizer GetColorizer( string key );
	}
}
