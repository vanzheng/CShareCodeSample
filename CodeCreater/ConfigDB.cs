using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.IO;
using System.Xml;
using System.Reflection;
using WinClassLib;

namespace CSharpWinApp
{
	/// <summary>
	/// ConfigDB ��ժҪ˵����
	/// </summary>
	public class ConfigDB : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lblServerIP;
		private System.Windows.Forms.Label lblAccount;
		private System.Windows.Forms.TextBox txtServerIP;
		private System.Windows.Forms.TextBox txtAccount;
		private System.Windows.Forms.Label lblPwd;
		private System.Windows.Forms.TextBox txtAcctPwd;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Label lblDBName;
		private System.Windows.Forms.TextBox txtDBName;
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ConfigDB()
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtDBName = new System.Windows.Forms.TextBox();
			this.lblDBName = new System.Windows.Forms.Label();
			this.txtAcctPwd = new System.Windows.Forms.TextBox();
			this.lblPwd = new System.Windows.Forms.Label();
			this.txtAccount = new System.Windows.Forms.TextBox();
			this.lblAccount = new System.Windows.Forms.Label();
			this.txtServerIP = new System.Windows.Forms.TextBox();
			this.lblServerIP = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtDBName);
			this.groupBox1.Controls.Add(this.lblDBName);
			this.groupBox1.Controls.Add(this.txtAcctPwd);
			this.groupBox1.Controls.Add(this.lblPwd);
			this.groupBox1.Controls.Add(this.txtAccount);
			this.groupBox1.Controls.Add(this.lblAccount);
			this.groupBox1.Controls.Add(this.txtServerIP);
			this.groupBox1.Controls.Add(this.lblServerIP);
			this.groupBox1.Location = new System.Drawing.Point(9, 16);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(272, 152);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "MSSQL Server����������";
			// 
			// txtDBName
			// 
			this.txtDBName.Location = new System.Drawing.Point(88, 48);
			this.txtDBName.Name = "txtDBName";
			this.txtDBName.TabIndex = 7;
			this.txtDBName.Text = "";
			// 
			// lblDBName
			// 
			this.lblDBName.Location = new System.Drawing.Point(8, 56);
			this.lblDBName.Name = "lblDBName";
			this.lblDBName.Size = new System.Drawing.Size(80, 16);
			this.lblDBName.TabIndex = 6;
			this.lblDBName.Text = "���ݿ����ƣ�";
			// 
			// txtAcctPwd
			// 
			this.txtAcctPwd.Location = new System.Drawing.Point(88, 112);
			this.txtAcctPwd.Name = "txtAcctPwd";
			this.txtAcctPwd.PasswordChar = '*';
			this.txtAcctPwd.TabIndex = 5;
			this.txtAcctPwd.Text = "textBox1";
			// 
			// lblPwd
			// 
			this.lblPwd.Location = new System.Drawing.Point(16, 120);
			this.lblPwd.Name = "lblPwd";
			this.lblPwd.Size = new System.Drawing.Size(72, 16);
			this.lblPwd.TabIndex = 4;
			this.lblPwd.Text = "��¼���룺";
			// 
			// txtAccount
			// 
			this.txtAccount.Location = new System.Drawing.Point(88, 80);
			this.txtAccount.Name = "txtAccount";
			this.txtAccount.TabIndex = 3;
			this.txtAccount.Text = "sa";
			// 
			// lblAccount
			// 
			this.lblAccount.Location = new System.Drawing.Point(16, 88);
			this.lblAccount.Name = "lblAccount";
			this.lblAccount.Size = new System.Drawing.Size(72, 16);
			this.lblAccount.TabIndex = 2;
			this.lblAccount.Text = "��¼�ʻ���";
			// 
			// txtServerIP
			// 
			this.txtServerIP.Location = new System.Drawing.Point(162, 16);
			this.txtServerIP.Name = "txtServerIP";
			this.txtServerIP.TabIndex = 1;
			this.txtServerIP.Text = "127.0.0.1";
			// 
			// lblServerIP
			// 
			this.lblServerIP.Location = new System.Drawing.Point(8, 24);
			this.lblServerIP.Name = "lblServerIP";
			this.lblServerIP.Size = new System.Drawing.Size(160, 16);
			this.lblServerIP.TabIndex = 0;
			this.lblServerIP.Text = "SQL Server ������IP��ַ��";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(168, 184);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(55, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "ȷ��";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(232, 184);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(55, 23);
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "�˳�";
			// 
			// ConfigDB
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 221);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ConfigDB";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "�������ݿ������";
			this.Load += new System.EventHandler(this.ConfigDB_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		//ȷ������
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			OpraterConfig(true);
		}

		private void ConfigDB_Load(object sender, System.EventArgs e)
		{
			OpraterConfig(false);
		}

		#region " ���������ļ��ķ��� "
		private void OpraterConfig(bool isset)
		{
			try
			{
				string assemblyFilePath = Assembly.GetExecutingAssembly().Location;
				string assemblyDirPath = Path.GetDirectoryName(assemblyFilePath);
				string configFilePath = assemblyDirPath + "\\AppConfig.config";

    
				Config config = new Config(configFilePath);
				if(isset)
				{
					config.SetValue("RemoteSQLServerUri",txtServerIP.Text,true);
					config.SetValue("RemoteSQLServerUser",txtAccount.Text,true);
					config.SetValue("RemoteSQLServerPWD",txtAcctPwd.Text,true);
					config.SetValue("RemoteSQLServerDB",txtDBName.Text,true);
					MessageBox.Show("���óɹ�");
					btnOK.Enabled = false;
				}
				else
				{
					txtServerIP.Text = config.GetValue("RemoteSQLServerUri");
					txtAccount.Text = config.GetValue("RemoteSQLServerUser");
					txtAcctPwd.Text = config.GetValue("RemoteSQLServerPWD");
					txtDBName.Text = config.GetValue("RemoteSQLServerDB");
				}
			}
			catch
			{
				btnOK.Enabled = true;
			}
		}
		#endregion

	}
}
