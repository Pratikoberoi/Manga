using System;
using System.IO;
using System.Web.UI.WebControls;

namespace Comic
{
	public partial class CStrip : System.Web.UI.Page
	{
		Panel pnlTextBox;
		protected void Page_PreInit(object sender, EventArgs e)
		{

			pnlTextBox = new Panel();
			pnlTextBox.ID = "pnlTextBox";
			this.form1.Controls.Add(pnlTextBox);

		}
		protected void Page_Load(object sender, EventArgs e)
		{
			string dir = @"Manga\" + Session["Book"].ToString() + @"\" + Session["Chapter"].ToString();
			DirectoryInfo d = new DirectoryInfo(@"D:\MM\Manga\Comic\Comic\Comic\Manga\" + Session["Book"].ToString() + @"\" + Session["Chapter"].ToString());
			FileInfo[] Files = d.GetFiles("*.jpg");
			int i = 1;
			foreach (FileInfo file in Files)
			{
				Literal lt = new Literal();

				Image img = new Image();
				img.ID = "img" + i;
				img.ImageUrl = dir + @"\" + file.Name;
				img.Width = 1000;
				pnlTextBox.Controls.Add(img);

				i = i + 1;
			}

			Button btn = new Button();
			btn.ID = Session["NChapter"].ToString();
			btn.Text = Session["NChapter"].ToString();
			btn.Font.Bold = true;
			btn.Font.Size = 15;
			btn.Width = 500;
			btn.Height = 200;
			btn.Click += new System.EventHandler(btn_Click);
			pnlTextBox.Controls.Add(btn);

		}

		public void btn_Click(object sender, EventArgs e)
		{
			Session["Chapter"] = Session["NChapter"];

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
				if (subdirectory.Substring(subdirectory.LastIndexOf(@"\") + 1) == Session["Chapter"].ToString())
				{
					i = 2;
				}
			}

			Response.Redirect("Read.aspx");
		}
	}
}