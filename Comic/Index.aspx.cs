using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Comic
{
	public partial class Index : System.Web.UI.Page
	{
		Panel pnlTextBox;
		protected void Page_Load(object sender, EventArgs e)
		{
			GetSubDirectories();
		}
		protected void Page_PreInit(object sender, EventArgs e)
		{
			
			pnlTextBox = new Panel();
			pnlTextBox.ID = "pnlTextBox";
			this.form1.Controls.Add(pnlTextBox);
			
		}
		public void GetSubDirectories()
		{
			string root = @"D:\MM\Manga";
			string[] subdirectoryEntries = Directory.GetDirectories(root);
			// Loop through them to see if they have any other subdirectories
			int i = 1, j =1;

			Literal lt = new Literal();
			lt.Text = "<table><tr>";
			pnlTextBox.Controls.Add(lt);

			foreach (string subdirectory in subdirectoryEntries)
			{
				Literal lt1 = new Literal();
				lt1.Text = "<td>";
				pnlTextBox.Controls.Add(lt1);

				Label lbl = new Label();
				lbl.ID = "Label" + i;
				lbl.Text = subdirectory.Substring(subdirectory.LastIndexOf(@"\") + 1);
				lbl.Font.Bold = true;
				lbl.Font.Size = 21;
				lbl.CssClass = "label";
				lbl.Width = 200;
				lbl.Height = 60;
				pnlTextBox.Controls.Add(lbl);

				Literal lt2 = new Literal();
				lt2.Text = "</br>";
				pnlTextBox.Controls.Add(lt2);

				DirectoryInfo d = new DirectoryInfo(subdirectory);
				FileInfo[] Files = d.GetFiles("*.jpg");
				foreach (FileInfo file in Files)
				{
					Image img = new Image();
					img.ID = "img" + i;
					img.ImageUrl = subdirectory.Substring(6) + @"\" + file.Name;
					img.Height = 300;
					img.Width = 200;
					pnlTextBox.Controls.Add(img);
				}

				Literal lt3 = new Literal();
				lt3.Text = "</br>";
				pnlTextBox.Controls.Add(lt3);

				Button btn = new Button();
				btn.ID = subdirectory.Substring(subdirectory.LastIndexOf(@"\") + 1);
				btn.Text = "Read";
				btn.Font.Bold = true;
				btn.Font.Size = 15;
				btn.Click += new System.EventHandler(btn_Click);
				pnlTextBox.Controls.Add(btn);

				i = i + 1;

				Literal lt4 = new Literal();
				lt4.Text = "</td>";
				pnlTextBox.Controls.Add(lt4);

				if (j == 3)
				{
					Literal lt6 = new Literal();
					lt6.Text = "</tr><tr>";
					pnlTextBox.Controls.Add(lt6);
					j = 1;

				}
				else
					j = j + 1;
			}

			Literal lt5 = new Literal();
			lt5.Text = "</tr></table>";
			pnlTextBox.Controls.Add(lt5);
		}

		public void btn_Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			string buttonId = button.ID;
			Session["Book"] = buttonId;
			Response.Redirect("Chapter.aspx");
		}
	}
}