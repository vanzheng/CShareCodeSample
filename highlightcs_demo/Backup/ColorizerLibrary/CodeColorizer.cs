using System;
using System.Xml;
using System.Xml.Xsl;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;
using System.Collections;
using log4net;


namespace ColorizerLibrary
{
	using Benchmark;
	using Collections;
	using Helpers;

	/// <summary>
	/// Code colorizer provides a flexible solution for colorizing code
	/// </summary>
	public class CodeColorizer
	{
		#region Internals
		/// <summary>
		/// Logger
		/// </summary>
		private static ILog Log = LogManager.GetLogger( typeof(CodeColorizer) );

		/// <summary>
		/// Syntax description file
		/// </summary>
		private XmlDocument LanguageSyntax;
		/// <summary>
		/// Code stylesheet
		/// </summary>
		private XslTransform LanguageStyle;
		/// <summary>
		/// Delegate for Regex.Replace
		/// </summary>
		private System.Text.RegularExpressions.MatchEvaluator ReplaceByCodeDelegate;

		/// <summary>
		/// A timer
		/// </summary>
		public AvgTimer Timer; 

		/// <summary>
		/// End of line constant string
		/// </summary>
		private String EndOfLine;

		/// <summary>
		/// Regular expressions container
		/// </summary>
		private Collections.RegexDictionary RxDic;
		#endregion

		#region Attributes
		/// <summary>
		/// Opening tag string
		/// </summary>
		public String OpeningTag;
		/// <summary>
		/// Closing tag string.
		/// </summary>
		public String ClosingTag;
		/// <summary>
		/// Tag enclosing code
		/// </summary>
		public String Tag;
		/// <summary>
		/// Language tag attribute name
		/// </summary>
		public String LangTag;
		/// <summary>
		/// Syntax file name
		/// </summary>
		public String LanguageSyntaxFileName;
		/// <summary>
		/// Style file name
		/// </summary>
		public String LanguageStyleFileName;
		/// <summary>
		/// Boxed, non boxed code flag
		/// </summary>
		public bool InBox;
		#endregion

		#region Benchmarking properties
		/// <summary>
		/// Returns the computation time/character of the last call
		/// </summary>
		public double BenchmarkSecPerChar
		{
			get
			{
				return Timer.DurationPerQuantity;
			}
		}
		/// <summary>
		/// Returns the computation time of the last call
		/// </summary>
		public double BenchmarkSec
		{
			get
			{
				return Timer.Duration;
			}
		}
		/// <summary>
		/// Returns the average computation time
		/// </summary>
		public double BenchmarkAvgSec
		{
			get
			{
				return Timer.DurationPerRun;
			}
		}
		#endregion

		#region Constructors

		/// <summary>
		/// Default constructor
		/// </summary>
		/// <param name="sLanguageSyntax">XML syntax file name</param>
		/// <param name="sLanguageStyle">XSL style file name</param>
		public CodeColorizer(String sLanguageSyntax, String sLanguageStyle)
		{
			LanguageSyntaxFileName=sLanguageSyntax;
			LanguageStyleFileName=sLanguageStyle;

			Log = LogManager.GetLogger( typeof(CodeColorizer) );

			// loading language file
			Init();
		}

		#endregion

		#region Overrides
		/// <summary>
		/// Converting to string
		/// </summary>
		/// <returns>Returns the syntax and style in a string</returns>
		public override String ToString()
		{
			return "<Syntax>"+LanguageSyntax.ToString() + 
				"</syntax>\n<style>" + LanguageStyle.ToString() + "</style>";
		}
		#endregion 

		#region Public Methods
		/// <summary>Load language files and preprocess them. Loads xsl file.</summary>
		/// <remarks>Call this method to reload the language files.</remarks>
		public bool Init()
		{
			// Replace function delegate
			ReplaceByCodeDelegate = new System.Text.RegularExpressions.MatchEvaluator( ReplaceByCode );

			// hashtable for regular expressions
			RxDic = new Collections.RegexDictionary();

			// prepare tags
			EndOfLine="\n";
			OpeningTag = "<";
			ClosingTag = ">";
			Tag = "pre";
			LangTag = "lang";	
			InBox=true;

			Timer = new AvgTimer();

			try
			{	
				// load and preprocess language data
				LanguageSyntax=new XmlDocument();
				BuildSyntax( );
				// load xsl..
				LanguageStyle=new XslTransform();
				LanguageStyle.Load( LanguageStyleFileName );
				return true;
			}
			catch(Exception e)
			{
				Log.Fatal(e);
				throw e;
			}
		}

		/// <summary>Processes HTML and highlight code in <pre>...</pre> and in <code>...</code></summary>
		/// <param name="sValue">HTML code</param>
		/// <returns>HTML with colored code</returns>
		/// Available languages: C++ -> cpp, JSCript -> jscript, VBScript -> vbscript
		/// <remarks>Author: Jonathan de Halleux, dehalleux@pelikhan.com, 2003</remarks>
		public String ProcessAndHighlightText( String sValue )
		{
			String sRegExp;
			Regex regExp;
		
			Timer.Start(sValue.Length);

			// building regular expression
			sRegExp = OpeningTag 
				+"\\s*"
				+ Tag
				+".*?"
				+ClosingTag
				+"((.|\\n)*?)"
				+OpeningTag
				+"\\s*/\\s*"
				+Tag
				+"\\s*"
				+ClosingTag;

			regExp=new Regex(sRegExp, RegexOptions.IgnoreCase | RegexOptions.Multiline);

			// render pre
			String result=regExp.Replace( sValue, ReplaceByCodeDelegate);
			Timer.Stop();

			return result;
		}

		#endregion 

		#region private Methods

		/// <summary>Builds keywords family regular expressions</summary>
		/// <param name="languageNode">language node</param>
		/// <remarks>This method create regular expression that match a whole keyword family and 
		///	add it as a parameter "regexp" to the keywordlist node.</remarks>
		/// <remarks>Author: Jonathan de Halleux, dehalleux@pelikhan.com, 2003</remarks>
		private void BuildKeywordRegExp( XmlNode languageNode )
		{
			String sRegExp;
			XmlNode rootNode,preNode, postNode;
	
			rootNode = languageNode.SelectSingleNode("/*");

			// iterating keywords	
			foreach (XmlNode keywordListNode in rootNode.SelectNodes("keywordlists/keywordlist")) 
			{
				sRegExp="\\b";
		
				// adding pre...
				preNode = keywordListNode.Attributes.GetNamedItem("pre");
				if (preNode != null)
					sRegExp+=preNode.Value;
		
				sRegExp+="(";
		
				// build regular expression...
				// iterate kw elements
				foreach (XmlNode kwNode in keywordListNode.SelectNodes("kw") )
				{
					sRegExp+= Regex.Escape( kwNode.InnerText ) + "|"; 
				}
		
				// close string
				if (sRegExp.Length > 1)
					sRegExp=sRegExp.Remove(sRegExp.Length-1,1);

				sRegExp+=")";
				// adding pre...
				postNode = keywordListNode.Attributes.GetNamedItem("post");
				if (postNode != null)
					sRegExp+=postNode.Value;
			
				sRegExp+="\\b";

				// add to keywordListNode
				XmlHelper.XmlSetAttribute( keywordListNode, "regexp", sRegExp );
			}

		}


		/// <summary>Builds regular expression out of contextNode</summary>
		/// <param name="languageNode">language node</param>
		/// <param name="contextNode">context node</param>
		/// <remarks>This method create regular expression that match all the context rules
		/// add it as a parameter "regexp" to the context node.</remarks>
		/// <exception>If keyword family not corresponding to keyword attribute.</exception>
		/// <exception>Regular expression rule missing regexp argument</exception>
		/// <remarks>Author: Jonathan de Halleux, dehalleux@pelikhan.com, 2003</remarks>
		private String BuildRuleRegExp( XmlNode languageNode, XmlNode contextNode )
		{
			String sRegExp,xp;
			XmlNode regExpExprNode, rootNode; 
	
			rootNode = languageNode.SelectSingleNode("/*");
			sRegExp="(";

			foreach (XmlNode ruleNode in contextNode.ChildNodes)
			{
				if (ruleNode.Name == "#comment")
					continue;
			
				// apply rule...
				if (ruleNode.Name == "detect2chars")
				{
					String char0=ruleNode.Attributes.GetNamedItem("char").Value;
					String char1=ruleNode.Attributes.GetNamedItem("char1").Value;
					sRegExp+=Regex.Escape( char0 + char1 ) + "|";
				}
				else if (ruleNode.Name == "detectchar")
				{
					String char0=ruleNode.Attributes.GetNamedItem("char").Value;
					sRegExp+=Regex.Escape( char0 ) + "|";
				}
				else if (ruleNode.Name == "linecontinue")
				{
					sRegExp+="\n|";
				}
				else if (ruleNode.Name == "regexp" )
				{
					regExpExprNode = ruleNode.Attributes.GetNamedItem("expression");
					if ( regExpExprNode == null )
						throw (new Exception("Regular expression rule missing expression attribute"));
				
					sRegExp+=regExpExprNode.Value + "|";

					// adding regular expression to dictionnary
					RxDic.AddKey( languageNode, contextNode, ruleNode, regExpExprNode.Value);
				}
				else if (ruleNode.Name == "keyword")
				{
					// finding keywordlist
					XmlNode keywordListNameNode = ruleNode.Attributes.GetNamedItem("family");
					if (keywordListNameNode == null)
						throw (new Exception("Keyword rule missing family"));
					xp="keywordlists/keywordlist[@id=\""
						+ keywordListNameNode.Value 
						+ "\"]";
					XmlNode keywordListNode = rootNode.SelectSingleNode(xp);
					if (keywordListNode == null)
						throw (new Exception("Could not find keywordlist (xp: "+ xp + ")"));
				
					XmlNode keywordListRegExpNode = keywordListNode.Attributes.GetNamedItem("regexp");
					if (keywordListRegExpNode == null)
						throw (new Exception("Could not find keywordlist regular expression"));
				
					// adding regexp
					sRegExp+=keywordListRegExpNode.Value+"|";

					
					// adding regular expression to dictionnary
					RxDic.AddKey( languageNode, contextNode, keywordListNode, "(" + keywordListRegExpNode.Value + ")" );
				}
			}

			if (sRegExp.Length > 1)
				sRegExp=sRegExp.Remove(sRegExp.Length-1,1)+")";
			else
				sRegExp="";
	
			return sRegExp;	
		}


		/// <summary>Precompiles regular expressions, search strings and prepares rules attribute</summary>
		/// <param name="languageNode"><seealso cref="XmlNode"/> context node</param>
		/// <exception>If rule id not corresponding to a rule family</exception>
		/// <remarks>Author: Jonathan de Halleux, dehalleux@pelikhan.com, 2003</remarks>
		private void BuildRules( XmlNode languageNode )
		{
			XmlNodeList contextList;
			String sRegExp, contextId;
			XmlNode rootNode;

			rootNode = languageNode.SelectSingleNode("/*");
	
			// first building keyword regexp
			BuildKeywordRegExp( languageNode );	
	
			contextList = languageNode.SelectNodes("contexts/context");
			// create regular expressions for context
			foreach (XmlNode contextNode in contextList)
			{
				sRegExp = BuildRuleRegExp( languageNode, contextNode );

				contextId = contextNode.Attributes.GetNamedItem("id").Value;
				// add attribute
				XmlHelper.XmlSetAttribute( contextNode, "regexp", sRegExp );	

				// creating regular expression and adding to hash table
				RxDic.AddKey( languageNode, contextNode, sRegExp );
			}
		}


		/// <summary>Prepares syntax xml file</summary>
		/// <remarks>Author: Jonathan de Halleux, dehalleux@pelikhan.com, 2003</remarks>
		private void BuildSyntax( )
		{
			XmlNode needBuildNode, highlightNode;

			LanguageSyntax.Load( LanguageSyntaxFileName );

			// check if build needed...
			highlightNode = LanguageSyntax.DocumentElement.SelectSingleNode("/highlight");
			if (highlightNode == null)
				throw (new Exception("Could not find highlight node"));
			
			needBuildNode=highlightNode.Attributes.GetNamedItem("needs-build");
			if (needBuildNode == null  || needBuildNode.Value=="yes")
			{
				// iterate languages and prebuild
				foreach (XmlNode languageNode in highlightNode.SelectNodes("languages/language"))
				{
					/////////////////////////////////////////////////////////////////////////		
					// build regular expressions
					BuildRules( languageNode );	
				}

				// updating...
				XmlHelper.XmlSetAttribute(
					LanguageSyntax.DocumentElement.SelectSingleNode("/highlight"),
					"needs-build","no");
			}
	
			// save file if asked
			XmlNode saveBuildNode = LanguageSyntax.DocumentElement.SelectSingleNode("/highlight").Attributes.GetNamedItem("save-build");
			if (saveBuildNode != null && saveBuildNode.Value == "yes")
				LanguageSyntax.Save( LanguageSyntaxFileName );
		}


		/// <summary>Finds the rule that trigerred the match</summary>
		/// <param name="languageNode">language node</param>
		/// <param name="contextNode">context node</param>
		/// <param name="sMatch">that matched the context regular expression</param>
		/// <remarks>If the Regex finds a rule occurence, this method is used to find which rule has been trigerred.</remarks>
		/// <exception>Triggers if sMatch does not match any rule of contextNode</exception>
		/// <remarks>Author: Jonathan de Halleux, dehalleux@pelikhan.com, 2003</remarks>
		private XmlNode FindRule( XmlNode languageNode, XmlNode contextNode, String sMatch )
		{
			XmlNode kwNode,familyNode,rootNode; 
			Regex regExp;
			String xp;
			Match arr;
	
			rootNode=languageNode.SelectSingleNode("/*");

			// building regular expression	
			foreach (XmlNode ruleNode in contextNode.ChildNodes)
			{
				if (ruleNode.Name == "#comment")
					continue;
	
				if (ruleNode.Name == "detect2chars")
				{
					String char0=ruleNode.Attributes.GetNamedItem("char").Value;
					String char1=ruleNode.Attributes.GetNamedItem("char1").Value;
					if ( sMatch == char0 + char1)			
						return ruleNode;
				}
				else if (ruleNode.Name == "detectchar")
				{
					String char0=ruleNode.Attributes.GetNamedItem("char").Value;
					if (char0 == sMatch)
						return ruleNode;
				}
				else if (ruleNode.Name == "linecontinue")
				{
					if ( EndOfLine == sMatch)
						return ruleNode;
				}
				else if (ruleNode.Name == "regexp")
				{
					XmlNode regExpExprNode=ruleNode.Attributes.GetNamedItem("expression");
					if ( regExpExprNode == null )
						throw (new Exception("Regular expression rule missing expression attribute"));
			

					regExp = RxDic.GetKey( languageNode, contextNode, ruleNode );
					arr = regExp.Match(sMatch);
					if ( arr.Success )
						return ruleNode;
				}	
				else if (ruleNode.Name == "keyword")
				{
					familyNode = ruleNode.Attributes.GetNamedItem("family");
					if ( familyNode == null)
						throw (new Exception("Could not find family attribute for keyword"));
					xp="keywordlists/keywordlist[@id=\"" 
						+ familyNode.Value 
						+ "\"]";
					kwNode = rootNode.SelectSingleNode( xp );
					if ( kwNode == null)
						throw (new Exception("Could not find keyword family "
									+ ruleNode.Attributes.GetNamedItem("attribute").Value 
									+ "(xp: "+xp+")"));

					// estimate regular expression	
					regExp = RxDic.GetKey(languageNode, contextNode, kwNode);
					if (regExp == null)
					{
						Exception e=new Exception("Could not find regular expression object keyword." + familyNode.Value );
						if (Log.IsFatalEnabled) Log.Fatal(e);
						throw e;
					}

					//sRegExp="(" + regExpNode.Value + ")";
					//regExp = new Regex( sRegExp, regOp );
					arr=regExp.Match(sMatch);
					if ( !arr.Success )
						return ruleNode;
				}
			}
			return null;
		}


		/// <summary>Applies the context rules succesively to sString</summary>
		/// <param name="languageNode">language node</param>
		/// <param name="contextNode">context node</param>
		/// <param name="sString">String to parse and convert</param>
		/// <param name="parsedCodeNode">mother node for dumping parsed code</param>
		/// <remarks>This methods uses the pre-computed regular expressions of context rules, rule matching, etc...
		/// the result is outputted in the xmlResult document, starting at parsedCodeNode node.</remarks>
		/// <remarks>Author: Jonathan de Halleux, dehalleux@pelikhan.com, 2003</remarks>
		private void ApplyRules( XmlNode languageNode, XmlNode contextNode, String sString, XmlNode parsedCodeNode)
		{
			Regex regExp;
			Match arr;
			XmlNode attributeNode, attributeContextNode;

			// get regExp 
			regExp = (Regex)RxDic.GetKey( languageNode, contextNode);

			while (sString.Length > 0)
			{
				// apply
				arr = regExp.Match( sString );
				if (!arr.Success)
				{
					XmlHelper.XmlAddChildCDATAElem( 
						parsedCodeNode,
						contextNode.Attributes.GetNamedItem("attribute").Value, 
						sString );
			
					// finished parsing
					break;
				}
				else
				{
					// adding text
					attributeContextNode=contextNode.Attributes.GetNamedItem("attribute");
					if (attributeContextNode != null && attributeContextNode.Value!="hidden" )
					{
						XmlHelper.XmlAddChildCDATAElem(
							parsedCodeNode, 
							attributeContextNode.Value,
							sString.Substring(0, arr.Index ) );
					}
			
					// find rule...
					XmlNode ruleNode = FindRule( languageNode, contextNode, arr.ToString() );
					if (ruleNode == null)
						throw (new Exception("Didn't matching rule, regular expression false ? ( context: " + contextNode.Attributes.GetNamedItem("id").Value ));
			
					// check if rule nees to be added to result...
					attributeNode=ruleNode.Attributes.GetNamedItem("attribute");
					if (attributeNode != null && attributeNode.Value!="hidden" )
					{
						XmlHelper.XmlAddChildCDATAElem(
							parsedCodeNode,
							ruleNode.Attributes.GetNamedItem("attribute").Value ,
							arr.ToString());
					}
			
					// update context if necessary
					if ( contextNode.Attributes.GetNamedItem("id").Value 
							!= ruleNode.Attributes.GetNamedItem("context").Value )
					{
						// return new context 
						String xpContext = "contexts/context[@id=\"" 
							+ ruleNode.Attributes.GetNamedItem("context").Value
							+ "\"]";
						contextNode = languageNode.SelectSingleNode( xpContext);
						if (contextNode == null)
							throw (new Exception("Didn't matching context, error in xml specification ?"));
					
						// build new regular expression
						regExp = RxDic.GetKey( languageNode, contextNode);
					}
					sString = sString.Substring(arr.Index + arr.Length);			
				}
			}
		}


		/// <summary>Create and populate an xml document with the corresponging language</summary>
		/// <param name="sLang">language string description. For C++, use cpp.</param> 
		/// <param name="sRootTag">Root tag (under parsed code) for the generated xml tree.</param> 
		/// <param name="sCode">Code to parse</param>
		/// <returns><seealso cref="XmlDocument"/> document containing parsed node.</returns>
		/// <remarks>This method builds an XML tree containing context node. Use an xsl file to render it.</remarks>
		/// <remarks>Author: Jonathan de Halleux, dehalleux@pelikhan.com, 2003</remarks>
		private XmlDocument BuildHighlightTree( String sLang, String sRootTag, String sCode )
		{
			XmlNode languageNode;
			String xp,sInBox;
			XmlNode resultMainNode;
			String sDefault;
			XmlNode contextsNode, contextNode;
			XmlDocument xmlResult;

			if (InBox)
				sInBox = "yes";
			else
				sInBox="no";
			try
			{			
				/////////////////////////////////////////////////////////////////////////		
				// getting language
				xp="/highlight/languages/language[@id=\"" + sLang + "\"]";
				languageNode=LanguageSyntax.DocumentElement.SelectSingleNode( xp );
				if (languageNode == null)
					throw ( new Exception(
									"Could not find " + sLang + "language (xpath: " + xp + ")"
								)  
						);

	
				/////////////////////////////////////////////////////////////////////////		
				// getting context
				contextsNode=languageNode.SelectSingleNode( "contexts" );
				if (contextsNode == null)
					throw (new Exception("Could not find contexts node for " + sLang + "language"));

				/////////////////////////////////////////////////////////////////////////		
				// getting default context	
				sDefault=contextsNode.Attributes.GetNamedItem("default").Value;
				xp="context[@id=\"" +  sDefault + "\"]";
				contextNode=contextsNode.SelectSingleNode( xp );
				if (contextNode == null)
					throw (new Exception("Could not find default context for " + sLang + "language (xpath: " + xp + ")"));
	
				// create result xml
				xmlResult = new XmlDocument();

				///////////////////////////////////////////////////////////////////////////	
				// creating main node
				resultMainNode=xmlResult.CreateElement( "parsedcode" );
				if (resultMainNode == null)
					throw (new Exception("Could not create main node parsedcode"));

				xmlResult.AppendChild(resultMainNode);
					
				///////////////////////////////////////////////////////////////////////////	
				// adding language attribute
				XmlHelper.XmlSetAttribute(resultMainNode,"lang", sRootTag );
				XmlHelper.XmlSetAttribute(resultMainNode, "in-box", sInBox );

				///////////////////////////////////////////////////////////////////////////	
				// parse and populate xmlResult
				ApplyRules( languageNode, contextNode, sCode, resultMainNode);

				return xmlResult;
			}
			catch(Exception e)
			{
				Log.Fatal(e);
				return null;
			}
		}

		/// <summary>Apply syntax matching to sCode with the corresponding language sLang</summary>
		/// <param name="sLang">language string description. For C++, use cpp.</param> 
		/// <param name="sRootTag">Root tag (under parsed code) for the generated xml tree.</param> 
		/// <param name="sCode">Code to parse</param>
		/// <returns>the highlighted code.</returns>
		/// <remarks>Author: Jonathan de Halleux, dehalleux@pelikhan.com, 2003</remarks>
		private String HighlightCode( String sLang, String sRootTag, String sCode)
		{

			try
			{		
				// re-build highlight tree	
				XmlDocument xmlResult = BuildHighlightTree( sLang, sRootTag, sCode );
				if (xmlResult == null)
					throw (new Exception("Highlight tree failed"));

				// render xml
				StringWriter sw = new StringWriter();
				LanguageStyle.Transform(  xmlResult, null, sw );
				return sw.ToString();
			}
			catch(Exception e)
			{
				Log.Fatal( e );
				return sCode;
			}
		}


		/// <summary>Find the lang in the tag</summary>
		/// <param name="sMatch">a string</param>
		/// <returns>the value of the parameter corresponding to sGlobDefaultLong</returns>
		private String FindLang( String sMatch )
		{
			String  sRegExp;
			Regex regExp;
			Match arr;
	
			// build regular expression
			sRegExp= LangTag + "\\s*=(\"[a-z]+\"|[a-z]+)";
			regExp = new Regex( sRegExp, RegexOptions.Multiline | RegexOptions.IgnoreCase); 

			arr = regExp.Match( sMatch );
			if (!arr.Success || arr.Length < 2 )
				return null;
			else
			{	
				String a1=arr.Groups[1].ToString();
				if (a1[0]=='"' || a1[0]=='\'')
				{
					int l=a1.Length;
					return a1.Substring(1, l-2);
				}
				else
					return a1;
			}
		}

		/// <summary> Helper function to be used in String::Replace</summary>
		/// <param name="match">Full match</param>
		private String ReplaceByCode( System.Text.RegularExpressions.Match match )
		{
			String sMatch = match.Groups[0].ToString();
			String sValue = match.Groups[1].ToString();
			String sLang, sTemplate, xp;
			XmlNode languageNode;
	
			// get language
			sLang = FindLang( sMatch );
			// if no language... do nothing
			if (sLang == null)
			{
				Log.Info("Could not find language " + sMatch);
				return sMatch;
			}

			// find language in language file if not found return text...
			xp="/highlight/languages/language[@id=\"" + sLang + "\"]";
			languageNode=LanguageSyntax.DocumentElement.SelectSingleNode( xp );
			if (languageNode == null)
			{
				Log.Error("Could not find language node for " + sMatch);
				return sMatch;
			}
	
			//highlight code
			sTemplate = sLang;
	
			return HighlightCode( sLang, sTemplate, sValue);
		}
		#endregion
	}
}
