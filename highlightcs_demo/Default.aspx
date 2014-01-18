<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="TextColorizerTest.WebForm1" %>
<%@ Register TagPrefix="cc1" Namespace="ColorizerLibrary.Control" Assembly="ColorizerLibrary" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="highlight.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<h3>Syntax highlighting C# Control demonstration</h3>
			<ul>
				<li>
					Encapsulated source code in <b>pre</b> and <b>code</b>
				tags.
				<li>
					Use <b>lang</b> parameter to choose the language:
					<ul>
						<li>
						c, C
						<li>
						cpp, C++
						<li>
						vbscript, VBScript
						<li>
						jscript, JavaScript
						<li>
							xml, XML</li>
					</ul>
				</li>
			</ul>
			Example:
			<pre>&lt;pre lang="cpp"&gt;/* 
Testing the colorzing
*/			
#define A_CONSTANT
using namespace std;
int main( int argc, char* argv[])
{	
	const char* szHello="Hello world";
	cout&lt;&lt;szHello;
	
	// returning 0
	return 0;
}
&lt;/pre&gt;				
</P>				
</pre>
			<table>
				<tr>
					<td><TEXTAREA id="textArea" name="TEXTAREA1" rows="14" cols="77" runat="server">						</TEXTAREA></td>
				</tr>
				<tr>
					<td><INPUT id="ProcessBtn" type="button" value="Colorize" runat="server">
					</td>
				</tr>
				<tr>
					<td>
						<cc1:TextColorizerControl id="TextColorizerControl1" runat="server"></cc1:TextColorizerControl></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
