using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comic
{
	public partial class Chapter : System.Web.UI.Page
	{
		Panel pnlTextBox;
		protected void Page_Load(object sender, EventArgs e)
		{
			string root = @"D:\MM\Manga\Comic\Comic\Comic\Manga\" + Session["Book"].ToString();
			string[] subdirectoryEntries = Directory.GetDirectories(root);
			int i = 1, j = 1;

			foreach (string subdirectory in subdirectoryEntries)
			{
				Button btn = new Button();
				btn.ID = subdirectory.Substring(subdirectory.LastIndexOf(@"\") + 1);
				btn.Text = subdirectory.Substring(subdirectory.LastIndexOf(@"\") + 1);
				btn.Font.Bold = true;
				btn.Font.Size = 15;
				btn.Width = 500;
				btn.Height = 50;
				btn.Click += new System.EventHandler(btn_Click);
				pnlTextBox.Controls.Add(btn);

				Literal lt1 = new Literal();
				lt1.Text = "</br></br>";
				pnlTextBox.Controls.Add(lt1);
			}
		}

		public void btn_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string buttonId = button.ID;

			string root = @"D:\MM\Manga\Comic\Comic\Comic\Manga\" + Session["Book"].ToString();
			string[] subdirectoryEntries = Directory.GetDirectories(root);
			int i = 1;

			foreach (string subdirectory in subdirectoryEntries)
			{
				if (i == 2)
				{
					Session["NChapter"] = subdirectory.Substring(subdirectory.LastIndexOf(@"\") + 1);
					i = 1;
				}
				if(subdirectory.Substring(subdirectory.LastIndexOf(@"\") + 1) == buttonId)
				{
					i = 2;
				}
			}
				
			
			Session["Chapter"] = buttonId;
			Response.Redirect("Read.aspx");
		}

		protected void Page_PreInit(object sender, EventArgs e)
		{

			pnlTextBox = new Panel();
			pnlTextBox.ID = "pnlTextBox";
			this.form1.Controls.Add(pnlTextBox);

		}
	}
}