using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Configuration;
using System.Xml;
using ColorizerLibrary;
using log4net;


namespace ColorizerLibrary.Control
{
	/// <summary>
	/// A syntax colorizing control
	/// </summary>
	[DefaultProperty("Text"),
		ToolboxData("<{0}:TextColorizerControl runat=server></{0}:TextColorizerControl>")]
	public class TextColorizerControl : System.Web.UI.WebControls.WebControl
	{
		#region internals
		static private readonly ILog Log = LogManager.GetLogger( typeof(TextColorizerControl) );
		private string text;
		private CodeColorizer Colorizer;
		#endregion

		#region Constructors
		/// <summary>
		/// Default constructor
		/// </summary>
		public TextColorizerControl()
		{
		}
		#endregion

		#region Override Methods
		/// <summary>
		/// Renders the code
		/// </summary>
		/// <remarks>You must specify a colorizing engine using SetSyntaxEngine before calling this method</remarks>
		/// <param name="output">HTML writer</param>
		protected override void Render(HtmlTextWriter output)
		{
			Log.Info("Rendering");
			if (text==null)
			{
				Log.Info("Text not set for rendering");
				output.Write("<b>Text not set !</b>");
				return;
			}
			if(Colorizer==null )
			{
				Log.Error("Colorizer not set");
				output.Write("<b>Colorizer not set !</b>");
				return;
			}
			output.Write( Colorizer.ProcessAndHighlightText( text ) );
			output.Write( "<br/>Performance: " + Colorizer.BenchmarkSec + 
					"s, " + Colorizer.BenchmarkSecPerChar + 
					"s/char, " + Colorizer.BenchmarkAvgSec + " s" );

		}
		#endregion

		#region Properties
		[Bindable(true),
		Category("Appearance"),
		DefaultValue("empty")]
		public string Text
		{
			get
			{
				return text;
			}

			set
			{
				text = value;
			}
		}

		/// <summary>
		/// The syntax engine does the job.
		/// </summary>
		public CodeColorizer SyntaxEngine
		{
			get
			{
				return Colorizer;
			}
			set
			{
				Colorizer = value;
			}
		}
		#endregion
	}
}
