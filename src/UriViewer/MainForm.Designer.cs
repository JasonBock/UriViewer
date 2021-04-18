using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace UriViewer
{
	partial class MainForm
	{
		private PropertyGrid uriPropertiesGrid;
		private Label uriLabel;
		private Button viewUriButton;
		private ComboBox uriCombo;
		private TextBox decodedUri;
		private Container components = null;

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}

			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.uriPropertiesGrid = new System.Windows.Forms.PropertyGrid();
			this.uriLabel = new System.Windows.Forms.Label();
			this.viewUriButton = new System.Windows.Forms.Button();
			this.uriCombo = new System.Windows.Forms.ComboBox();
			this.decodedUri = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// uriPropertiesGrid
			// 
			this.uriPropertiesGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.uriPropertiesGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.uriPropertiesGrid.Location = new System.Drawing.Point(19, 163);
			this.uriPropertiesGrid.Name = "uriPropertiesGrid";
			this.uriPropertiesGrid.Size = new System.Drawing.Size(978, 730);
			this.uriPropertiesGrid.TabIndex = 4;
			// 
			// uriLabel
			// 
			this.uriLabel.Location = new System.Drawing.Point(19, 17);
			this.uriLabel.Name = "uriLabel";
			this.uriLabel.Size = new System.Drawing.Size(77, 34);
			this.uriLabel.TabIndex = 0;
			this.uriLabel.Text = "&URI:";
			this.uriLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// viewUriButton
			// 
			this.viewUriButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.viewUriButton.Location = new System.Drawing.Point(814, 17);
			this.viewUriButton.Name = "viewUriButton";
			this.viewUriButton.Size = new System.Drawing.Size(180, 49);
			this.viewUriButton.TabIndex = 2;
			this.viewUriButton.Text = "&View";
			this.viewUriButton.Click += new System.EventHandler(this.OnViewUriButtonClick);
			// 
			// uriCombo
			// 
			this.uriCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.uriCombo.Items.AddRange(new object[] {
            "file:\\\\\\c:\\SomeDirectory\\SomeAssembly.dll",
            "C:\\SomeDirectory\\SomeSubdirectory",
            "file://c:\\SomeDirectory\\SomeAssembly.dll",
            "C:\\SomeDirectory\\SomeAssembly.dll",
            "http://www.jasonbock.net",
            "http://www.jasonbock.net/JB/Default.aspx?blog=entry.20041124T014812",
            "/JB/Default.aspx?blog=entry.20041124T014812",
            "http://www.jasonbock.net/",
            "http://www.jasonbock.net/JB/Search.aspx?index=1&currentQuery=pictures",
            "http://www.dotnetlanguages.net/DNL/Default.aspx",
            "http://dotnetlanguages.net",
            "http://dotnetlanguages.net/DNL/Default.aspx",
            "http://www.dotnetlanguages.net/DNL/Default.aspx?blog=entry.20040914T110918",
            "http://localhost/DotNetLanguages"});
			this.uriCombo.Location = new System.Drawing.Point(96, 17);
			this.uriCombo.Name = "uriCombo";
			this.uriCombo.Size = new System.Drawing.Size(699, 38);
			this.uriCombo.TabIndex = 1;
			// 
			// decodedUri
			// 
			this.decodedUri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.decodedUri.Location = new System.Drawing.Point(26, 94);
			this.decodedUri.Name = "decodedUri";
			this.decodedUri.ReadOnly = true;
			this.decodedUri.Size = new System.Drawing.Size(968, 37);
			this.decodedUri.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(12, 30);
			this.ClientSize = new System.Drawing.Size(1006, 912);
			this.Controls.Add(this.decodedUri);
			this.Controls.Add(this.uriCombo);
			this.Controls.Add(this.viewUriButton);
			this.Controls.Add(this.uriLabel);
			this.Controls.Add(this.uriPropertiesGrid);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Uri Viewer";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private void OnViewUriButtonClick(object sender, System.EventArgs e)
		{
			if (this.uriCombo.Text.Trim().Length > 0)
			{
				try
				{
					var uri = new ExtendedUri(this.uriCombo.Text, UriKind.RelativeOrAbsolute);
					this.decodedUri.Text = uri.ToString();
					uriPropertiesGrid.SelectedObject = uri;
				}
				catch (Exception exception)
				{
					MessageBox.Show(exception.Message);
				}
			}
		}
	}
}