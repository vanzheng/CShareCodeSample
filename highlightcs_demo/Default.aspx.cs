using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using ColorizerLibrary;
using System.Configuration;
using log4net;

namespace TextColorizerTest
{
	/// <summary>
	/// Description résumée de [!output SAFE_CLASS_NAME].
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		private static readonly ILog Log = LogManager.GetLogger( typeof(WebForm1) );
		protected System.Web.UI.HtmlControls.HtmlTextArea textArea;
		protected System.Web.UI.HtmlControls.HtmlInputButton ProcessBtn;
		protected ColorizerLibrary.Control.TextColorizerControl TextColorizerControl1;
		private CodeColorizer Colorizer;

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				log4net.Config.DOMConfigurator.Configure();
				if (Log.IsInfoEnabled) Log.Info("Load page");

				Colorizer = ColorizerLibrary.Config.DOMConfigurator.Configure();
				TextColorizerControl1.SyntaxEngine = Colorizer;
			}
			catch( Exception exception)
			{
				Log.Fatal( exception );
				throw exception;
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN : Cet appel est requis par le Concepteur Web Form ASP.NET.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{    
			this.ProcessBtn.ServerClick += new System.EventHandler(this.ProcessBtn_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ProcessBtn_ServerClick(object sender, System.EventArgs e)
		{
			if (Log.IsInfoEnabled) Log.Info("Button hit...");
			TextColorizerControl1.Text = textArea.InnerText;
		}
	}
}
