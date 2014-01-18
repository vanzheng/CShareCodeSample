using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

using System.CodeDom;
using System.CodeDom.Compiler;
using WinClassLib;
using Microsoft.CSharp;
using System.Runtime.InteropServices;

namespace CSharpWinApp
{
	/// <summary>
	/// SQLNetPlus ��ժҪ˵����
	/// </summary>
	public class SQLNetPlus : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu SysMenu;
		private System.Windows.Forms.MenuItem MenuConfigDB;
		private System.Windows.Forms.MenuItem MenuConnectDB;
		private System.Windows.Forms.MenuItem MenuCloseFrm;
		private System.Windows.Forms.RadioButton rbtnTable;
		private System.Windows.Forms.RadioButton rbtnView;
		private System.Windows.Forms.RadioButton rbtnProc;
		private System.Windows.Forms.ListBox list;
		private System.Windows.Forms.TextBox txtCode;
		private System.Windows.Forms.Button btnBuildCode;
		private System.Windows.Forms.Label lblClassName;
		private System.Windows.Forms.TextBox txtClassName;
		private System.Windows.Forms.MenuItem MenuContact;

		#region ϵͳ���ɴ���
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SQLNetPlus()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.SysMenu = new System.Windows.Forms.MainMenu();
			this.MenuConfigDB = new System.Windows.Forms.MenuItem();
			this.MenuConnectDB = new System.Windows.Forms.MenuItem();
			this.MenuCloseFrm = new System.Windows.Forms.MenuItem();
			this.rbtnTable = new System.Windows.Forms.RadioButton();
			this.rbtnView = new System.Windows.Forms.RadioButton();
			this.rbtnProc = new System.Windows.Forms.RadioButton();
			this.list = new System.Windows.Forms.ListBox();
			this.txtCode = new System.Windows.Forms.TextBox();
			this.btnBuildCode = new System.Windows.Forms.Button();
			this.lblClassName = new System.Windows.Forms.Label();
			this.txtClassName = new System.Windows.Forms.TextBox();
			this.MenuContact = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// SysMenu
			// 
			this.SysMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.MenuConfigDB,
																					this.MenuConnectDB,
																					this.MenuContact,
																					this.MenuCloseFrm});
			// 
			// MenuConfigDB
			// 
			this.MenuConfigDB.Index = 0;
			this.MenuConfigDB.Text = "���ݿ�����";
			this.MenuConfigDB.Click += new System.EventHandler(this.MenuConfigDB_Click);
			// 
			// MenuConnectDB
			// 
			this.MenuConnectDB.Index = 1;
			this.MenuConnectDB.Text = "�������ݿ�";
			this.MenuConnectDB.Click += new System.EventHandler(this.MenuConnectDB_Click);
			// 
			// MenuCloseFrm
			// 
			this.MenuCloseFrm.Index = 3;
			this.MenuCloseFrm.Text = "�˳�ϵͳ";
			this.MenuCloseFrm.Click += new System.EventHandler(this.MenuCloseFrm_Click);
			// 
			// rbtnTable
			// 
			this.rbtnTable.Checked = true;
			this.rbtnTable.Location = new System.Drawing.Point(9, 5);
			this.rbtnTable.Name = "rbtnTable";
			this.rbtnTable.Size = new System.Drawing.Size(64, 24);
			this.rbtnTable.TabIndex = 1;
			this.rbtnTable.TabStop = true;
			this.rbtnTable.Text = "�û���";
			this.rbtnTable.CheckedChanged += new System.EventHandler(this.RadioClick);
			// 
			// rbtnView
			// 
			this.rbtnView.Location = new System.Drawing.Point(145, 5);
			this.rbtnView.Name = "rbtnView";
			this.rbtnView.Size = new System.Drawing.Size(48, 24);
			this.rbtnView.TabIndex = 2;
			this.rbtnView.Text = "��ͼ";
			this.rbtnView.CheckedChanged += new System.EventHandler(this.RadioClick);
			// 
			// rbtnProc
			// 
			this.rbtnProc.Location = new System.Drawing.Point(73, 5);
			this.rbtnProc.Name = "rbtnProc";
			this.rbtnProc.Size = new System.Drawing.Size(72, 24);
			this.rbtnProc.TabIndex = 3;
			this.rbtnProc.Text = "�洢����";
			this.rbtnProc.CheckedChanged += new System.EventHandler(this.RadioClick);
			// 
			// list
			// 
			this.list.ItemHeight = 12;
			this.list.Location = new System.Drawing.Point(8, 32);
			this.list.Name = "list";
			this.list.Size = new System.Drawing.Size(192, 484);
			this.list.TabIndex = 4;
			// 
			// txtCode
			// 
			this.txtCode.Location = new System.Drawing.Point(208, 31);
			this.txtCode.Multiline = true;
			this.txtCode.Name = "txtCode";
			this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtCode.Size = new System.Drawing.Size(608, 487);
			this.txtCode.TabIndex = 5;
			this.txtCode.Text = "";
			// 
			// btnBuildCode
			// 
			this.btnBuildCode.Location = new System.Drawing.Point(712, 3);
			this.btnBuildCode.Name = "btnBuildCode";
			this.btnBuildCode.TabIndex = 6;
			this.btnBuildCode.Text = "���ɴ���";
			this.btnBuildCode.Click += new System.EventHandler(this.btnBuildCode_Click);
			// 
			// lblClassName
			// 
			this.lblClassName.Location = new System.Drawing.Point(496, 8);
			this.lblClassName.Name = "lblClassName";
			this.lblClassName.Size = new System.Drawing.Size(48, 16);
			this.lblClassName.TabIndex = 7;
			this.lblClassName.Text = "������";
			// 
			// txtClassName
			// 
			this.txtClassName.Location = new System.Drawing.Point(544, 3);
			this.txtClassName.Name = "txtClassName";
			this.txtClassName.TabIndex = 8;
			this.txtClassName.Text = "test";
			// 
			// MenuContact
			// 
			this.MenuContact.Index = 2;
			this.MenuContact.Text = "��ϵ��ʽ";
			this.MenuContact.Click += new System.EventHandler(this.MenuContact_Click);
			// 
			// SQLNetPlus
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(824, 529);
			this.Controls.Add(this.txtClassName);
			this.Controls.Add(this.lblClassName);
			this.Controls.Add(this.btnBuildCode);
			this.Controls.Add(this.txtCode);
			this.Controls.Add(this.list);
			this.Controls.Add(this.rbtnProc);
			this.Controls.Add(this.rbtnView);
			this.Controls.Add(this.rbtnTable);
			this.MaximizeBox = false;
			this.Menu = this.SysMenu;
			this.Name = "SQLNetPlus";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SQLNetPlus";
			this.Load += new System.EventHandler(this.SQLNetPlus_Load);
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new SQLNetPlus());
		}
	

		//���ݿ�����
		private void MenuConfigDB_Click(object sender, System.EventArgs e)
		{
			ConfigDB f = new ConfigDB();
			f.ShowDialog();
		}

		//�˳�ϵͳ
		private void MenuCloseFrm_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		//��������¼�
		private void SQLNetPlus_Load(object sender, System.EventArgs e)
		{
		}

		//�������ݿ⣬�ڴ˰����ݿ���洢���̡���ͼȫ���г���
		private void MenuConnectDB_Click(object sender, System.EventArgs e)
		{
			RadioClick(null,null);
		}

		#region �û����洢���̡���ͼ��ת����ʾ
		//�û����洢���̡���ͼ��ת����ʾ
		private void RadioClick(object sender, System.EventArgs e)
		{
			list.Items.Clear();
			string name = "table";
			if(rbtnTable.Checked == true)
				name = "table";
			else if(rbtnView.Checked == true)
				name = "view";
			else if(rbtnProc.Checked == true)
				name = "proc";
			
			DataSet ds = getDataSet(name);

			for(int i=0;i<ds.Tables[0].Rows.Count;i++)
			{
				list.Items.Add(ds.Tables[0].Rows[i]["Name"]);
			}
		}

		private DataSet getDataSet(string name)
		{
			DataAccess da = getDataAccess();
			DataSet ds = da.GetDataSet(name,true);
			return ds;
		}

		private DataAccess getDataAccess()
		{
			string assemblyFilePath = Assembly.GetExecutingAssembly().Location;
			string assemblyDirPath = Path.GetDirectoryName(assemblyFilePath);
			string configPath = assemblyDirPath + "\\AppConfig.config";
			DataAccess da = new DataAccess(configPath);
			return da;
		}

		#endregion

		//���ɴ��밴ť
		/// <summary>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnBuildCode_Click(object sender, System.EventArgs e)
		{
			if(txtClassName.Text == "")
			{
				MessageBox.Show("�������������");
				return;
			}
			string name = "table";
			if(rbtnTable.Checked == true)
				name = "table";
			else if(rbtnView.Checked == true)
				name = "view";
			else if(rbtnProc.Checked == true)
				name = "proc";
			string sql  = "";
			if(list.SelectedItem != null)
				GetGeneralCode(list.SelectedItem.ToString(),name);
		}

		private void GetGeneralCode(string selectName,string name)
		{
			CSharpCodeProvider provider = new CSharpCodeProvider();
			ICodeGenerator generator = provider.CreateGenerator();
			StreamWriter writer = new StreamWriter(@"c:\" + txtClassName.Text + ".cs",false);
			CodeCompileUnit unit = new CodeCompileUnit();
			CodeNamespace nspace = new CodeNamespace("SQLNetPlus"); //������ƿռ�
			nspace.Imports.Add(new CodeNamespaceImport("System"));
			CodeTypeDeclaration info = new CodeTypeDeclaration(txtClassName.Text);
			
			CodeConstructor ct = new CodeConstructor();

			DataAccess da = getDataAccess();
			DataSet ds = da.GetDataSet(selectName,false);

			if(name != "proc")
			{
				ct.Attributes=MemberAttributes.Public;
				ct.Statements.Add(new CodeSnippetStatement("this.conStr=System.Configuration.ConfigurationSettings.AppSettings[\"DBConnStr\"];")); //����
				ct.Statements.Add(new CodeSnippetStatement("if( this.conStr==null || this.conStr.Length==0)"));            //����
				ct.Statements.Add(new CodeSnippetStatement("throw new Exception();"));

				info.Members.Add(ct);

				for(int i=0;i<ds.Tables[0].Rows.Count;i++)
				{
					//˽�г�Ա������ֱ�����ֶ���(����s_)��������
					CodeMemberField f = new CodeMemberField();
					f.Name="s_" + ds.Tables[0].Rows[i]["Name"];
					f.Type = new CodeTypeReference((da.getTypeString(ds.Tables[0].Rows[i]["datatype"].ToString())));
					info.Members.Add(f);
					//�������ԣ����ֶ�����������
					CodeMemberProperty p = new CodeMemberProperty();
					p.Name=ds.Tables[0].Rows[i]["Name"].ToString();
					p.Type=f.Type;
					p.Attributes = MemberAttributes.Public|MemberAttributes.Final;
					p.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(),f.Name)));
					p.SetStatements.Add(new CodeAssignStatement(
						new CodeFieldReferenceExpression(new CodeThisReferenceExpression(),f.Name),
						new CodePropertySetValueReferenceExpression()));
					info.Members.Add(p);
				}
			}
			else
			{
				ct.Attributes=MemberAttributes.Public;
				info.Members.Add(ct);

				//��ӷ���
				CodeMemberMethod m = new CodeMemberMethod();
				m.ReturnType = new CodeTypeReference("System.Data.DataSet");
				m.Name = "ExecProc_" + selectName;
				m.Attributes = MemberAttributes.Public|MemberAttributes.Final;
				int rows = ds.Tables[0].Rows.Count;
				CodeSnippetStatement codebody = null;
				codebody = new CodeSnippetStatement("SqlParameter[] parms =new SqlParameter[" + (rows+1).ToString() + "];");
				m.Statements.Add(codebody);
				for(int i=0;i<rows;i++)
				{
					string paramName = ds.Tables[0].Rows[i]["name"].ToString(); 
					string paramName1 = "p_" + paramName.Substring(1,paramName.Length-1);
					CodeTypeReference paramType = new CodeTypeReference((da.getTypeString(ds.Tables[0].Rows[i]["datatype"].ToString())));
					CodeParameterDeclarationExpression parameters = null;
					parameters = new CodeParameterDeclarationExpression(paramType, paramName1);
					m.Parameters.Add(parameters);
					string paramOutput = ds.Tables[0].Rows[i]["isoutparam"].ToString();
					codebody = new CodeSnippetStatement("parms[" + i.ToString() + "]=new SqlParameter(\"" + paramName + "\", " + paramName1 + ");");
					m.Statements.Add(codebody); 
					if(paramOutput == "1")
					{
						codebody = new CodeSnippetStatement("parms[" + i.ToString() + "].Direction=ParameterDirection.Output;");
						m.Statements.Add(codebody);
					}
				}
				codebody = new CodeSnippetStatement("parms[" + rows.ToString() + "]=new SqlParameter(\"RETURN_VALUE\", SqlDbType.Int);");
				m.Statements.Add(codebody); 

				codebody = new CodeSnippetStatement("parms[" + rows.ToString() + "].Direction=ParameterDirection.ReturnValue;");
				m.Statements.Add(codebody); 

				codebody = new CodeSnippetStatement("return ExecuteDataset(\"" + selectName + "\",parms);");
				m.Statements.Add(codebody); 

				info.Members.Add(m);

			}
			nspace.Types.Add(info);
			unit.Namespaces.Add(nspace);                
			generator.GenerateCodeFromCompileUnit(unit,writer,new CodeGeneratorOptions());
			writer.Close();
			StreamReader sr = new StreamReader(@"c:\" + txtClassName.Text + ".cs",System.Text.Encoding.GetEncoding("GB2312"));
			txtCode.Text = sr.ReadToEnd();
			sr.Close();
		}

		//��ϵ��ʽ
		private void MenuContact_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("�ҵ���ϵ��ʽ��http://fineboy.cnblogs.com");
		}
	}
}
