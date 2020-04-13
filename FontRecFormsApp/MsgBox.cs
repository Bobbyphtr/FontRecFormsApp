using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace FontRecFormsApp
{
    public partial class MsgBox : Form
    {
        public MsgBox()
        {
            InitializeComponent();
        }

        public static MsgBox msgBox; static DialogResult result = DialogResult.OK;
        
        public static DialogResult Show(string fontName, Image inputImage, string fontfile)
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
            msgBox = new MsgBox();
            msgBox.inputPictureBox.Image = inputImage;
            msgBox.fontLabel.Text = fontName;

            string base_dir = System.AppDomain.CurrentDomain.BaseDirectory;
            string template1 = "a quick brown fox jumps over the lazy dog";
            string template2 = "A QUICK BROWN FOX JUMPS OVER THE LAZY DOG";

            // Gonna Change font here
            Console.WriteLine(base_dir + @"\Fonts_500\" + fontfile);
            pfc.AddFontFile(base_dir + @"\Fonts_500\" + fontfile);
            Console.WriteLine(pfc.Families[0]);
            msgBox.previewLabel.Font = new Font(pfc.Families[0], 16);
            msgBox.previewLabel2.Font = new Font(pfc.Families[0], 16);
            msgBox.previewLabel.Text = template1;
            msgBox.previewLabel2.Text = template2;

            msgBox.previewLabel.Invalidate();
            msgBox.previewLabel.Update();
            msgBox.previewLabel.Refresh();
            msgBox.previewLabel2.Invalidate();
            msgBox.previewLabel2.Update();
            msgBox.previewLabel2.Refresh();
            msgBox.ShowDialog();
            return result;
        }

        private void CustomMsgBox_Load(object sender, EventArgs e)
        {

        }
    }
}
