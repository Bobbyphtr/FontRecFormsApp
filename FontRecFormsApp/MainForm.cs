using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace FontRecFormsApp
{
    public partial class MainForm : Form
    {

        private string imagePath = "";
        private bool isImageExist = false;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inputImageBox.AllowDrop = true;
            inputImageBox.Image = Properties.Resources.Artboard_12;
            inputImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void inputImageBox_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var fileNames = data as string[];
                if (fileNames.Length > 0)
                {
                    inputImageBox.SizeMode = PictureBoxSizeMode.Zoom;
                    try
                    {
                        inputImageBox.Image = Image.FromFile(fileNames[0]);
                        this.imagePath = fileNames[0];
                        // PlaceholderLabel.Visible = false;
                        ClearButton.Enabled = true;
                        ScanButton.Enabled = true;
                        isImageExist = true;
                        EnableCropMode();
                    }
                    catch(OutOfMemoryException ex)
                    {
                        MessageBox.Show("The file is not an image, please choose an image.");
                    }
                    
                    
                }
            } else
            {
              // PlaceholderLabel.Visible = true;
                ClearButton.Enabled = false;
            }
        }
        private void inputImageBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void OpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            bool isNotCorrectFile = true;
            while (isNotCorrectFile) {
                ofd.Title = "Open Image";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    inputImageBox.SizeMode = PictureBoxSizeMode.Zoom;
                    try
                    {
                        inputImageBox.Image = Image.FromFile(ofd.FileName);
                        this.imagePath = ofd.FileName;
                        //  PlaceholderLabel.Visible = false;
                        ClearButton.Enabled = true;
                        ScanButton.Enabled = true;
                        isNotCorrectFile = false;
                        isImageExist = true;
                        EnableCropMode();
                    }
                    catch (OutOfMemoryException ex)
                    {
                        MessageBox.Show("The file is not an image, please choose an image.");
                        isNotCorrectFile = true;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        private void EnableCropMode()
        {
            if (isImageExist)
            {
                HelpLabel.TextAlign = ContentAlignment.MiddleRight;
                HelpLabel.Text = "Click and drag inside the image to begin crop!";

                // Cropping
                inputImageBox.MouseDown += new MouseEventHandler(inputImageBox_MouseDown);
                inputImageBox.MouseMove += new MouseEventHandler(inputimageBox_MouseMove);
                inputImageBox.MouseEnter += new EventHandler(inputImageBox_MouseEnter);
                inputImageBox.MouseLeave += new EventHandler(inputImageBox_MouseLeave);
                Controls.Add(inputImageBox);
            } else
            {
                Console.WriteLine("Image doesn't exist");
            }
            
        }
        private void DisableCropMode()
        {
            CropButton.Enabled = false;
            inputImageBox.MouseDown -= new MouseEventHandler(inputImageBox_MouseDown);
            inputImageBox.MouseMove -= new MouseEventHandler(inputimageBox_MouseMove);
            inputImageBox.MouseEnter -= new EventHandler(inputImageBox_MouseEnter);
            inputImageBox.MouseLeave -= new EventHandler(inputImageBox_MouseLeave);
            inputImageBox.Controls.Remove(inputImageBox);
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            inputImageBox.Image = null;
            ClearButton.Enabled = false;
            ScanButton.Enabled = false;

            inputImageBox.Image = Properties.Resources.Artboard_12;
            inputImageBox.SizeMode = PictureBoxSizeMode.StretchImage;
            HelpLabel.Text = "Drag and drop image into the container!";

            this.imagePath = "";
            this.isImageExist = false;

            DisableCropMode();
        }
        private void CropButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            Bitmap bmp = new Bitmap(inputImageBox.Width, inputImageBox.Height);
            inputImageBox.DrawToBitmap(bmp, inputImageBox.ClientRectangle);

            Bitmap croppedImg = new Bitmap(rectW, rectH);
            
            for (int i = 0; i< rectW; i++)
            {
                for(int j = 0; j < rectH; j++)
                {
                    Color pxlclr = bmp.GetPixel(cropX + i, cropY + j);
                    croppedImg.SetPixel(i, j, pxlclr);
                }
            }

            inputImageBox.Image = (Image)croppedImg;
            inputImageBox.SizeMode = PictureBoxSizeMode.CenterImage;
            CropButton.Enabled = false;

            // Save image to temporary file
            string tempPath = Path.GetTempPath();
            croppedImg.Save(Path.Combine(tempPath, "cropped.png"), ImageFormat.Png);
            this.imagePath = Path.Combine(tempPath, "cropped.png");
        }

        int cropX, cropY, rectW, rectH;
        public Pen cropPen = new Pen(Color.Red);

        private void inputImageBox_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if(e.Button==MouseButtons.Left)
            {
                // changing the cursor style
                Cursor = Cursors.Cross;
                cropPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                // set initial x and y
                cropX = e.X;
                cropY = e.Y;
            }
        }

        private void inputImageBox_MouseEnter(object sender, EventArgs e)
        {
            base.OnMouseEnter(e);
            Cursor = Cursors.Cross;
        }

        private void inputImageBox_MouseLeave(object sender, EventArgs e)
        {
            base.OnMouseLeave(e);
            Cursor = Cursors.Default;
        }

        private void inputimageBox_MouseMove(object sender, MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.Button == MouseButtons.Left)
            {
                if (e.X != cropX && e.Y != cropY)
                {
                    CropButton.Enabled = true;
                    inputImageBox.Refresh();
                    rectW = e.X - cropX;
                    rectH = e.Y - cropY;
                    Graphics g = inputImageBox.CreateGraphics();
                    g.DrawRectangle(cropPen, cropX, cropY, rectW, rectH);
                    g.Dispose();
                }

            }
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            var python = @"C:\MyProgramFiles\Anaconda3\envs\tf_gpu\python.exe";
            var script = AppDomain.CurrentDomain.BaseDirectory + "\\Script\\DeepFontAPI.py";

            // Accessing the python script
            var psi = new ProcessStartInfo();
            psi.FileName = python;


            // Script Argv
            var picture_path = this.imagePath;
            Console.WriteLine(picture_path);

            psi.Arguments = string.Format("{0} \"{1}\"", script, picture_path);

            // Configuration
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            // Execute
            var errors = "";
            var results = "";

            Console.WriteLine("Executing Python Script");
            Console.WriteLine(python);
            using (var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }
            Console.WriteLine("Errors : "+ errors);
            Console.WriteLine("Results : "+ results);
            String[] separator = {"# "};
            String[] font_result =  results.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine(font_result);
            Cursor = Cursors.Default;
            MsgBox.Show(font_result[font_result.Length - 2], inputImageBox.Image, font_result[font_result.Length - 1].Trim().ToString());
        }
    }
}
