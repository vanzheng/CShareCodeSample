using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Threading;
using log4net;

namespace ColorizerLibrary.Benchmark
{
	/// <summary>
	/// A basic timer class
	/// </summary>
	public class BasicTimer
	{
			#region Win32Imports
		[DllImport("Kernel32.dll")]
		private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);  

		[DllImport("Kernel32.dll")]
		private static extern bool QueryPerformanceFrequency(out long lpFrequency);
			#endregion
		
			#region Internals
		private static readonly ILog Log = LogManager.GetLogger( typeof(BasicTimer) );

		private long StartTime;
		private long StopTime;
		private long Freq;
			#endregion
		
		/// <summary>
		/// Constructor
		/// </summary>
		public BasicTimer()
		{
			StartTime = 0;
			StopTime  = 0;

			if (QueryPerformanceFrequency(out Freq) == false)
			{
				// high-performance counter not supported 
				throw new Win32Exception(); 
			}
		}
		
		/// <summary>
		/// Starts the timer
		/// </summary>
		public virtual void Start()
		{
			// lets do the waiting threads there work
			Thread.Sleep(0);  

			QueryPerformanceCounter(out StartTime);
		}
		
		/// <summary>
		/// Stops the timer
		/// </summary>
		public virtual void Stop()
		{
			QueryPerformanceCounter(out StopTime);
			if (Log.IsInfoEnabled) Log.Info("Timer duration: " + Duration );
		}
		
		/// <summary>
		/// Returns the duration of the last call
		/// </summary>
		public double Duration
		{
			get
			{
				return (double)(StopTime - StartTime) / (double) Freq;
			}
		}
	}
}
