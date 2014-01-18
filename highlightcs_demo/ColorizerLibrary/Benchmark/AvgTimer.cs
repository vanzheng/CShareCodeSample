using System;
using log4net;

namespace ColorizerLibrary.Benchmark
{
	/// <summary>
	/// A timer with averaging and counting
	/// </summary>
	public class AvgTimer : BasicTimer
	{
			#region Internals
		private static readonly ILog Log = LogManager.GetLogger( typeof(AvgTimer) );
		private long TotalQuantity;
		private double TotalTime;
		private long RunNumber;
			#endregion

			#region Constructors
		/// <summary>
		/// An averaging/normalizing timer.
		/// </summary>
		/// <example>In this example, we measure the time to parse a string. The string length will be passed to the 
		/// timer to have a sec/char time measurement.
		/// <code>
		/// string str;
		/// AvgTimer timer = new AvgTimer();
		/// //Start timer
		/// timer.Start( str.Length);
		/// ... // do things
		/// timer.Stop();
		/// result = "The processing timer per character is " + timer.DurationPerQuantity;
		/// </code>
		/// </example>
		public AvgTimer()
		{
			Reset();
		}
			#endregion

			#region Public Methods
		/// <summary>
		/// Starts timer
		/// </summary>
		/// <param name="quantity">Quantity that will be processed</param>
		public void Start(long quantity)
		{
			TotalQuantity+=quantity;
			base.Start();
		}

		/// <summary>
		/// Stops the timer
		/// </summary>
		public override void Stop()
		{
			base.Stop();
			TotalTime+=Duration;
			++RunNumber;

			if (Log.IsInfoEnabled) Log.Info("DurationPerQuantity: " + DurationPerQuantity 
									   +", DurationPerRun: " + DurationPerRun
									   +", TotalTime: " + TotalTime
									   +", Number of runs: " + RunNumber );
		}

		/// <summary>
		/// Resests internal run counter and time integrator
		/// </summary>
		public void Reset()
		{
			TotalQuantity=0;
			TotalTime=0;
			RunNumber=0;
		}
			#endregion

			#region Properties
		/// <summary>
		/// Returns the sum of timer runs
		/// </summary>
		/// <value>Sum of timer runs</value>
		public double TotalDuration
		{
			get
			{
				return TotalTime;
			}
		}

		/// <summary>
		/// Returns the number of runs that the timer has done
		/// </summary>
		/// <value>Run count</value>
		public long RunCount
		{
			get
			{
				return RunNumber;
			}
		}

		/// <summary>
		/// Returns a normalized time measurement
		/// </summary>
		/// <value><see cref="TotalTime"/> divided by <see cref="TotalQuantity"/></value>
		public double DurationPerQuantity
		{
			get
			{
				return (double)TotalTime / (double) TotalQuantity;
			}
		}

		/// <summary>
		/// Returns average time per run
		/// </summary>
		/// <value>Duration divided by <seealso cref="RunNumber"/></value>
		public double DurationPerRun
		{
			get
			{
				return (double)TotalTime / (double)RunNumber;
			}
		}
			#endregion
	}
}
