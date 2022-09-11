//Tell me please, is it necessary to do all 100 tasks in the test?
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;
using howto_floodfill;
using FTD2XX_NET;
using howto_click;

namespace FloodFill
{
    public partial class Form1 : Form
    {
        Int32 Bb, Rr, Gg;
        Int32 Bb2, Rr2, Gg2;
        Int32 part;        
        int eX, eY;
        delegate void SetTextCallback(string text);
        public Form1()
        {
            InitializeComponent();
            this.Text = "LiLu2.2_1";
        }
        private void SetText(string text)
        {
            if (this.textBox2.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                textBox2.AppendText(text + "\r\n");
            }
        }
        
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Text = comboBox5.SelectedItem.ToString();
            serialPort1.PortName = comboBox5.Text;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            #region Инициализация интерфейса
            try
            {
                string[] availablePorts = SerialPort.GetPortNames();
                foreach (string port in availablePorts)
                {
                    comboBox5.Items.Add(port);
                }
                comboBox5.Text = comboBox5.Items[0].ToString();
                serialPort1.StopBits = StopBits.One;
                serialPort1.DataBits = 8;
                serialPort1.BaudRate = 9600;
                serialPort1.PortName = comboBox5.Text;
                serialPort1.Parity = Parity.None;
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);                
            }
            catch (Exception )
            {
                MessageBox.Show("Подключите устройство!");
            }
            #endregion
            part = 1;
            button5.Enabled = false;
            #region  Загрузка1
            //part =
            textBox2.Text = null;
            //alpha = 360 / part;
            col2 = Color.Blue;
            bm = null;
            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bm;
            Graphics gr = Graphics.FromImage(bm);
            Xc = pictureBox1.Width / 2;   // Координаты центра
            Yc = pictureBox1.Height / 2;
            gr.Clear(Color.Silver);
            AN = 3;
            n = 360 / AN;
            Angle = 2 * PI / n;
            Pen Black = new Pen(Brushes.Black);
            for (i = 0; i < 17; i++)
            {
                gr.DrawEllipse(Black, Xc - r[i], Yc - r[i], 2 * r[i], 2 * r[i]);
            }
            for (int j = 0; j <= n - 1; j++)
            {
                gr.DrawLine(Black, Xc, Yc,
                   Xc + Convert.ToInt32((23 * 10) * Math.Cos(Angle * j)),
                   Yc - Convert.ToInt32((23 * 10) * Math.Sin(Angle * j)));
                gr.FillEllipse((Brushes.Black), Xc - r[0], Yc - r[0], 140, 140);

            }
            FloodTools.FloodFill(bm, 0, 0, Color.Black);
            #endregion

            #region Загрузка2
            bm2 = null;
            bm2 = new Bitmap(pictureBox10.Width, pictureBox10.Height);
            pictureBox10.Image = bm2;
            Graphics gr2 = Graphics.FromImage(bm2);
            Xc = pictureBox10.Width / 2;   // Координаты центра
            Yc = pictureBox10.Height / 2;
            gr2.Clear(Color.Silver);
            for (i = 0; i < 17; i++)
            {
                gr2.DrawEllipse(Black, Xc - r[i], Yc - r[i], 2 * r[i], 2 * r[i]);
            }
            for (int j = 0; j <= n - 1; j++)
            {
                gr2.DrawLine(Black, Xc, Yc,
                   Xc + Convert.ToInt32((23 * 10) * Math.Cos(Angle * j)),
                   Yc - Convert.ToInt32((23 * 10) * Math.Sin(Angle * j)));
                gr2.FillEllipse((Brushes.Black), Xc - r[0], Yc - r[0], 140, 140);

            }
            FloodTools.FloodFill(bm2, 0, 0, Color.Black);
            #endregion

            #region Загрузка3
            bm3 = null;
            bm3 = new Bitmap(pictureBox11.Width, pictureBox11.Height);
            pictureBox11.Image = bm3;
            Graphics gr3 = Graphics.FromImage(bm3);
            Xc = pictureBox11.Width / 2;   // Координаты центра
            Yc = pictureBox11.Height / 2;
            gr3.Clear(Color.Silver);
            for (i = 0; i < 17; i++)
            {
                gr3.DrawEllipse(Black, Xc - r[i], Yc - r[i], 2 * r[i], 2 * r[i]);
            }
            for (int j = 0; j <= n - 1; j++)
            {
                gr3.DrawLine(Black, Xc, Yc,
                   Xc + Convert.ToInt32((23 * 10) * Math.Cos(Angle * j)),
                   Yc - Convert.ToInt32((23 * 10) * Math.Sin(Angle * j)));
                gr3.FillEllipse((Brushes.Black), Xc - r[0], Yc - r[0], 140, 140);

            }
            FloodTools.FloodFill(bm3, 0, 0, Color.Black);
            #endregion

            #region Загрузка4
            bm4 = null;
            bm4 = new Bitmap(pictureBox13.Width, pictureBox13.Height);
            pictureBox13.Image = bm4;
            Graphics gr4 = Graphics.FromImage(bm4);
            Xc = pictureBox13.Width / 2;   // Координаты центра
            Yc = pictureBox13.Height / 2;
            gr4.Clear(Color.Silver);
            for (i = 0; i < 17; i++)
            {
                gr4.DrawEllipse(Black, Xc - r[i], Yc - r[i], 2 * r[i], 2 * r[i]);
            }
            for (int j = 0; j <= n - 1; j++)  
            {
                gr4.DrawLine(Black, Xc, Yc,
                   Xc + Convert.ToInt32((23 * 10) * Math.Cos(Angle * j)),
                   Yc - Convert.ToInt32((23 * 10) * Math.Sin(Angle * j)));
                gr4.FillEllipse((Brushes.Black), Xc - r[0], Yc - r[0], 140, 140);

            }
            FloodTools.FloodFill(bm4, 0, 0, Color.Black);
            #endregion

            #region Загрузка5
            bm5 = null;
            bm5 = new Bitmap(pictureBox14.Width, pictureBox14.Height);
            pictureBox14.Image = bm5;
            Graphics gr5 = Graphics.FromImage(bm5);
            Xc = pictureBox14.Width / 2;   // Координаты центра
            Yc = pictureBox14.Height / 2;
            gr5.Clear(Color.Silver);
            for (i = 0; i < 17; i++)
            {
                gr5.DrawEllipse(Black, Xc - r[i], Yc - r[i], 2 * r[i], 2 * r[i]);
            }
            for (int j = 0; j <= n - 1; j++)  
            {
                gr5.DrawLine(Black, Xc, Yc,
                   Xc + Convert.ToInt32((23 * 10) * Math.Cos(Angle * j)),
                   Yc - Convert.ToInt32((23 * 10) * Math.Sin(Angle * j)));
                gr5.FillEllipse((Brushes.Black), Xc - r[0], Yc - r[0], 140, 140);

            }
            FloodTools.FloodFill(bm5, 0, 0, Color.Black);
            #endregion

            #region вкладки
            tabPage1.Text = "1";
            tabPage2.Text = "2";
            tabPage3.Text = "3";
            tabPage4.Text = "4";
            tabPage5.Text = "5";
            #endregion
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int bytes = serialPort1.BytesToRead;
            byte[] comBuffer = new byte[bytes];
            serialPort1.Read(comBuffer, 0, bytes);
            SetText(ByteToHex(comBuffer));
            //SetText(ASCIIEncoding.GetEncodings(comBuffer));
        }
        
        private void on_call_Click(object sender, EventArgs e)
        {
            FTDI myFtdiDevice = new FTDI();
            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;
            ftStatus = myFtdiDevice.OpenByDescription("LiLu2.2_1");//LiLu2.1 было

            if (ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                MessageBox.Show(" Устройство готово к работе ");
                button5.Enabled = true;
            }
            else
            {
                MessageBox.Show(" Неудача ");
            }
            ftStatus = myFtdiDevice.Close();
            try
            {
                serialPort1.Open();
                if (serialPort1.IsOpen)
                {
                    on_call.Enabled = false;
                    off.Enabled = true;
                }
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }
        
        private void off_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
                if (!serialPort1.IsOpen)
                {
                    on_call.Enabled = true;
                    off.Enabled = false;
                    textBox1.Text = "";
                    textBox2.Text = "";
                    button5.Enabled = false;
                }
            }
            catch (Exception e4)
            {
                MessageBox.Show(e4.Message);
            }
        }
        
        // The background image.
        Bitmap bm = new Bitmap(800, 800);
        Bitmap bm2 = new Bitmap(800, 800);
        Bitmap bm3 = new Bitmap(800, 800);
        Bitmap bm4 = new Bitmap(800, 800);
        Bitmap bm5 = new Bitmap(800, 800);
        Bitmap bm_new = new Bitmap(800,800);
        double PI = 3.14159265; // PI parameter define
        int Xc, Yc;    // Round filled rectangle coordinates
        int i;            // Number of circles
        int AN;           // Degree of angle
        int n;            // Number of segments
        double Angle;
        int[] r = {70,80,90,100,110,120,130,140,150,160,170,180,190,200,210,220,230 };
        
        //Кнопка создать
        private void new_click(object sender, EventArgs e)
        {
            pressNumber = 0;
            if (tabControl1.SelectedIndex == 0)
            {
                #region создать1
                bm = null;
                bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = bm;
                Graphics gr = Graphics.FromImage(bm);
                Xc = pictureBox1.Width / 2;   // Координаты центра
                Yc = pictureBox1.Height / 2;
                gr.Clear(Color.Silver);
                AN = 3;
                n = 360 / AN;
                Angle = 2 * PI / n;
                Pen Black = new Pen(Brushes.Black);
                for (i = 0; i < 17; i++)
                {
                    gr.DrawEllipse(Black, Xc - r[i], Yc - r[i], 2 * r[i], 2 * r[i]);
                }
                for (int j = 0; j <= n - 1; j++)  
                {
                    gr.DrawLine(Black, Xc, Yc,
                       Xc + Convert.ToInt32((23 * 10) * Math.Cos(Angle * j)),
                       Yc - Convert.ToInt32((23 * 10) * Math.Sin(Angle * j)));
                    gr.FillEllipse((Brushes.Black), Xc - r[0], Yc - r[0], 140, 140);

                }
                FloodTools.FloodFill(bm, 0, 0, Color.Black);
                /*Point [] tt={new Point(0, 0), new Point(50, 0),new Point(50,200),new Point(0, 200)};
                  Graphics g = Graphics.FromImage(bm);
                  g.DrawPolygon(Pens.Black,tt);
                  g.FillPolygon(Brushes.Black, tt);*/
                //BackgroundImage = bm;
                #endregion
            }
            if (tabControl1.SelectedIndex == 1)
            {
                #region создать 2
                bm2 = null;
                bm2 = new Bitmap(pictureBox10.Width, pictureBox10.Height);
                pictureBox10.Image = bm2;
                Graphics gr2 = Graphics.FromImage(bm2);
                Xc = pictureBox10.Width / 2;   // Координаты центра
                Yc = pictureBox10.Height / 2;
                gr2.Clear(Color.Silver);
                AN = 3;
                n = 360 / AN;
                Angle = 2 * PI / n;
                Pen Black = new Pen(Brushes.Black);
                for (i = 0; i < 17; i++)
                {
                    gr2.DrawEllipse(Black, Xc - r[i], Yc - r[i], 2 * r[i], 2 * r[i]);
                }
                for (int j = 0; j <= n - 1; j++) 
                {
                    gr2.DrawLine(Black, Xc, Yc,
                       Xc + Convert.ToInt32((23 * 10) * Math.Cos(Angle * j)),
                       Yc - Convert.ToInt32((23 * 10) * Math.Sin(Angle * j)));
                    gr2.FillEllipse((Brushes.Black), Xc - r[0], Yc - r[0], 140, 140);

                }
                FloodTools.FloodFill(bm2, 0, 0, Color.Black);
                #endregion
            }

            if (tabControl1.SelectedIndex == 2)
            {
                #region создать 3
                bm3 = null;
                bm3 = new Bitmap(pictureBox11.Width, pictureBox11.Height);
                pictureBox11.Image = bm3;
                Graphics gr3 = Graphics.FromImage(bm3);
                Xc = pictureBox11.Width / 2;   // Координаты центра
                Yc = pictureBox11.Height / 2;
                gr3.Clear(Color.Silver);
                AN = 3;
                n = 360 / AN;
                Angle = 2 * PI / n;
                Pen Black = new Pen(Brushes.Black);
                for (i = 0; i < 17; i++)
                {
                    gr3.DrawEllipse(Black, Xc - r[i], Yc - r[i], 2 * r[i], 2 * r[i]);
                }
                for (int j = 0; j <= n - 1; j++)  
                {
                    gr3.DrawLine(Black, Xc, Yc,
                       Xc + Convert.ToInt32((23 * 10) * Math.Cos(Angle * j)),
                       Yc - Convert.ToInt32((23 * 10) * Math.Sin(Angle * j)));
                    gr3.FillEllipse((Brushes.Black), Xc - r[0], Yc - r[0], 140, 140);

                }
                FloodTools.FloodFill(bm3, 0, 0, Color.Black);
                #endregion
            }

            if (tabControl1.SelectedIndex == 3)
            {
                #region создать 4
                bm4 = null;
                bm4 = new Bitmap(pictureBox13.Width, pictureBox13.Height);
                pictureBox13.Image = bm4;
                Graphics gr4 = Graphics.FromImage(bm4);
                Xc = pictureBox13.Width / 2;   // Координаты центра
                Yc = pictureBox13.Height / 2;
                gr4.Clear(Color.Silver);
                AN = 3;
                n = 360 / AN;
                Angle = 2 * PI / n;
                Pen Black = new Pen(Brushes.Black);
                for (i = 0; i < 17; i++)
                {
                    gr4.DrawEllipse(Black, Xc - r[i], Yc - r[i], 2 * r[i], 2 * r[i]);
                }
                for (int j = 0; j <= n - 1; j++) 
                {
                    gr4.DrawLine(Black, Xc, Yc,
                       Xc + Convert.ToInt32((23 * 10) * Math.Cos(Angle * j)),
                       Yc - Convert.ToInt32((23 * 10) * Math.Sin(Angle * j)));
                    gr4.FillEllipse((Brushes.Black), Xc - r[0], Yc - r[0], 140, 140);

                }
                FloodTools.FloodFill(bm4, 0, 0, Color.Black);               
                #endregion
            }

            if (tabControl1.SelectedIndex == 4)
            {
                #region создать 5
                bm5 = null;
                bm5 = new Bitmap(pictureBox14.Width, pictureBox14.Height);
                pictureBox14.Image = bm5;
                Graphics gr5 = Graphics.FromImage(bm5);
                Xc = pictureBox14.Width / 2;   // Координаты центра
                Yc = pictureBox14.Height / 2;
                gr5.Clear(Color.Silver);
                AN = 3;
                n = 360 / AN;
                Angle = 2 * PI / n;
                Pen Black = new Pen(Brushes.Black);
                for (i = 0; i < 17; i++)
                {
                    gr5.DrawEllipse(Black, Xc - r[i], Yc - r[i], 2 * r[i], 2 * r[i]);
                }
                for (int j = 0; j <= n - 1; j++)
                {
                    gr5.DrawLine(Black, Xc, Yc,
                       Xc + Convert.ToInt32((23 * 10) * Math.Cos(Angle * j)),
                       Yc - Convert.ToInt32((23 * 10) * Math.Sin(Angle * j)));
                    gr5.FillEllipse((Brushes.Black), Xc - r[0], Yc - r[0], 140, 140);

                }
                FloodTools.FloodFill(bm5, 0, 0, Color.Black);                   
                #endregion
            }
        }
        
        //Кнопка открыть
        private void open_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                #region открыть 1
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Image image = Image.FromFile(dialog.FileName);
                    int width = image.Width;
                    int height = image.Height;
                    bm = new Bitmap(Image.FromFile(dialog.FileName), pictureBox1.Width, pictureBox1.Height);
                    pictureBox1.Image = bm;
                    FloodTools.FloodFill(bm, 0, 0, Color.Black);
                }
                #endregion
            }

            if (tabControl1.SelectedIndex == 1)
            {
                #region открыть 2
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Image image = Image.FromFile(dialog.FileName);
                    int width = image.Width;
                    int height = image.Height;
                    bm2 = new Bitmap(Image.FromFile(dialog.FileName), pictureBox10.Width, pictureBox10.Height);
                    pictureBox10.Image = bm2;
                    FloodTools.FloodFill(bm2, 0, 0, Color.Black);
                }
                #endregion
            }

            if (tabControl1.SelectedIndex == 2)
            {
                #region открыть 3
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Image image = Image.FromFile(dialog.FileName);
                    int width = image.Width;
                    int height = image.Height;
                    bm3 = new Bitmap(Image.FromFile(dialog.FileName), pictureBox11.Width, pictureBox11.Height);
                    pictureBox11.Image = bm3;
                    FloodTools.FloodFill(bm3, 0, 0, Color.Black);
                }
                #endregion
            }

            if (tabControl1.SelectedIndex == 3)
            {
                #region открыть 4
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Image image = Image.FromFile(dialog.FileName);
                    int width = image.Width;
                    int height = image.Height;
                    bm4 = new Bitmap(Image.FromFile(dialog.FileName), pictureBox13.Width, pictureBox13.Height);
                    pictureBox13.Image = bm4;
                    FloodTools.FloodFill(bm4, 0, 0, Color.Black);
                }
                #endregion
            }

            if (tabControl1.SelectedIndex == 4)
            {
                #region открыть 5
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Image image = Image.FromFile(dialog.FileName);
                    int width = image.Width;
                    int height = image.Height;
                    bm5 = new Bitmap(Image.FromFile(dialog.FileName), pictureBox14.Width, pictureBox14.Height);
                    pictureBox14.Image = bm5;
                    FloodTools.FloodFill(bm5, 0, 0, Color.Black);
                }
                #endregion
            }
        }
        
        //Кнопка сохранить
        private void save_Click(object sender, EventArgs e)
        {
            #region сохранить 1
            if (tabControl1.SelectedIndex == 0)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как ...";
                savedialog.FileName = "1";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter =
                    "Bitmap File(*.bmp)|*.bmp|" +
                    "GIF File(*.gif)|*.gif|" +
                    "JPEG File(*.jpg)|*.jpg|" +
                    "TIF File(*.tif)|*.tif|" +
                    "PNG File(*.png)|*.png";
                savedialog.ShowHelp = true;

                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = savedialog.FileName;

                    string strFilExtn =
                        fileName.Remove(0, fileName.Length - 3);

                    switch (strFilExtn)
                    {
                        case "bmp":
                            bm.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case "jpg":
                            bm.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case "gif":
                            bm.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case "tif":
                            bm.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                            break;
                        case "png":
                            bm.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion

            #region сохранить 2
            if (tabControl1.SelectedIndex == 1)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как ...";
                savedialog.FileName = "2";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter =
                    "Bitmap File(*.bmp)|*.bmp|" +
                    "GIF File(*.gif)|*.gif|" +
                    "JPEG File(*.jpg)|*.jpg|" +
                    "TIF File(*.tif)|*.tif|" +
                    "PNG File(*.png)|*.png";
                savedialog.ShowHelp = true;

                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = savedialog.FileName;

                    string strFilExtn =
                        fileName.Remove(0, fileName.Length - 3);

                    switch (strFilExtn)
                    {
                        case "bmp":
                            bm2.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case "jpg":
                            bm2.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case "gif":
                            bm2.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case "tif":
                            bm2.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                            break;
                        case "png":
                            bm2.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion

            #region сохранить 3
            if (tabControl1.SelectedIndex == 2)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как ...";
                savedialog.FileName = "3";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter =
                    "Bitmap File(*.bmp)|*.bmp|" +
                    "GIF File(*.gif)|*.gif|" +
                    "JPEG File(*.jpg)|*.jpg|" +
                    "TIF File(*.tif)|*.tif|" +
                    "PNG File(*.png)|*.png";
                savedialog.ShowHelp = true;

                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = savedialog.FileName;

                    string strFilExtn =
                        fileName.Remove(0, fileName.Length - 3);

                    switch (strFilExtn)
                    {
                        case "bmp":
                            bm3.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case "jpg":
                            bm3.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case "gif":
                            bm3.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case "tif":
                            bm3.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                            break;
                        case "png":
                            bm3.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion

            #region сохранить 4
            if (tabControl1.SelectedIndex == 3)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как ...";
                savedialog.FileName = "4";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter =
                    "Bitmap File(*.bmp)|*.bmp|" +
                    "GIF File(*.gif)|*.gif|" +
                    "JPEG File(*.jpg)|*.jpg|" +
                    "TIF File(*.tif)|*.tif|" +
                    "PNG File(*.png)|*.png";
                savedialog.ShowHelp = true;

                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = savedialog.FileName;

                    string strFilExtn =
                        fileName.Remove(0, fileName.Length - 3);

                    switch (strFilExtn)
                    {
                        case "bmp":
                            bm4.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case "jpg":
                            bm4.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case "gif":
                            bm4.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case "tif":
                            bm4.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                            break;
                        case "png":
                            bm4.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion

            #region сохранить 5
            if (tabControl1.SelectedIndex == 4)
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как ...";
                savedialog.FileName = "5";
                savedialog.OverwritePrompt = true;
                savedialog.CheckPathExists = true;
                savedialog.Filter =
                    "Bitmap File(*.bmp)|*.bmp|" +
                    "GIF File(*.gif)|*.gif|" +
                    "JPEG File(*.jpg)|*.jpg|" +
                    "TIF File(*.tif)|*.tif|" +
                    "PNG File(*.png)|*.png";
                savedialog.ShowHelp = true;

                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = savedialog.FileName;
                    string strFilExtn =
                        fileName.Remove(0, fileName.Length - 3);
                    
                    switch (strFilExtn)
                    {
                        case "bmp":
                            bm5.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        case "jpg":
                            bm5.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        case "gif":
                            bm5.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case "tif":
                            bm5.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                            break;
                        case "png":
                            bm5.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        default:
                            break;
                    }
                }
            }
            #endregion

        }

        //Кнопка расчитать и записать в файл,записать
        private void file_Click(object sender, EventArgs e)
        {
            int x, y;
            Color color = new Color();

            string folderName = @"D:\LiLu";
            DirectoryInfo drInfo = new DirectoryInfo(folderName);
            drInfo.Create();

            #region расчет 1 картинки
            StreamWriter steamWriter0_1 = new StreamWriter("D:\\LiLu\\0_1.txt");
            progressBar1.Value = 0;
            //progressBar1.Maximum = 2 * n;
            for (int j = 0; j <= 2 * n - 1; j++)
            {
                if (j % 2 == 1)
                {
                    for (i = 8; i >= 1; i--)
                    {
                        x = Xc + Convert.ToInt32((r[i] - 2) * Math.Cos(Angle * j / 2));
                        y = Yc - Convert.ToInt32((r[i] - 2) * Math.Sin(Angle * j / 2));
                        color = bm.GetPixel(x, y);
                        Bb = Convert.ToInt32(color.B / 255); steamWriter0_1.Write(Bb);
                        Rr = Convert.ToInt32(color.R / 255); steamWriter0_1.Write(Rr);
                        Gg = Convert.ToInt32(color.G / 255); steamWriter0_1.Write(Gg);
                    }
                    steamWriter0_1.WriteLine();
                }
            }
            for (int j = 0; j <= 2 * n - 1; j++)
            {
                if (j % 2 == 1)
                {
                    for (i = 16; i >= 9; i--)
                    {
                        x = Xc + Convert.ToInt32((r[i] - 2) * Math.Cos(Angle * j / 2));
                        y = Yc - Convert.ToInt32((r[i] - 2) * Math.Sin(Angle * j / 2));
                        color = bm.GetPixel(x, y);
                        Bb2 = Convert.ToInt32(color.B / 255); steamWriter0_1.Write(Bb2);
                        Rr2 = Convert.ToInt32(color.R / 255); steamWriter0_1.Write(Rr2);
                        Gg2 = Convert.ToInt32(color.G / 255); steamWriter0_1.Write(Gg2);
                    }
                    steamWriter0_1.WriteLine();
                }
            }
            steamWriter0_1.Close();

            string[] Mass = File.ReadAllLines(@"D:\\LiLu\\0_1.txt",
                                                System.Text.Encoding.Default);
            StreamWriter steamWriter1 = new StreamWriter
                                          ("D:\\LiLu\\1.txt");
            for (int i = 0; i < 240; i++)
            {
                //textBox2.AppendText((Mass[i]) + "\r\n");
                string res1 = CheckHex(bin2Hex(Mass[i].Substring(0, 8)));
                string res2 = CheckHex(bin2Hex(Mass[i].Substring(8, 8)));
                string res3 = CheckHex(bin2Hex(Mass[i].Substring(16, 8)));
                textBox1.AppendText(res1 + res2 + res3 + "\r\n");
            }
            steamWriter1.Write(textBox1.Text);
            steamWriter1.Close();
            #endregion
            textBox1.Text = null;

            #region расчет 2 картинки
            StreamWriter steamWriter0_2 = new StreamWriter("D:\\LiLu\\0_2.txt");
            progressBar1.Value = 0;
            //progressBar1.Maximum = 2 * n;
            for (int j = 0; j <= 2 * n - 1; j++)
            {
                if (j % 2 == 1)
                {
                    for (i = 8; i >= 1; i--)
                    {
                        x = Xc + Convert.ToInt32((r[i] - 2) * Math.Cos(Angle * j / 2));
                        y = Yc - Convert.ToInt32((r[i] - 2) * Math.Sin(Angle * j / 2));
                        color = bm2.GetPixel(x, y);
                        Bb = Convert.ToInt32(color.B / 255); steamWriter0_2.Write(Bb);
                        Rr = Convert.ToInt32(color.R / 255); steamWriter0_2.Write(Rr);
                        Gg = Convert.ToInt32(color.G / 255); steamWriter0_2.Write(Gg);
                    }
                    steamWriter0_2.WriteLine();
                }
            }
            for (int j = 0; j <= 2 * n - 1; j++)
            {
                if (j % 2 == 1)
                {
                    for (i = 16; i >= 9; i--)
                    {
                        x = Xc + Convert.ToInt32((r[i] - 2) * Math.Cos(Angle * j / 2));
                        y = Yc - Convert.ToInt32((r[i] - 2) * Math.Sin(Angle * j / 2));
                        color = bm2.GetPixel(x, y);
                        Bb2 = Convert.ToInt32(color.B / 255); steamWriter0_2.Write(Bb2);
                        Rr2 = Convert.ToInt32(color.R / 255); steamWriter0_2.Write(Rr2);
                        Gg2 = Convert.ToInt32(color.G / 255); steamWriter0_2.Write(Gg2);
                    }
                    steamWriter0_2.WriteLine();
                }
            }
            steamWriter0_2.Close();

            string[] Mass2 = File.ReadAllLines(@"D:\\LiLu\\0_2.txt",
                                                System.Text.Encoding.Default);
            StreamWriter steamWriter2 = new StreamWriter
                                          ("D:\\LiLu\\2.txt");
            for (int i = 0; i < 240; i++)
            {
                //textBox2.AppendText((Mass[i]) + "\r\n");
                string res1 = CheckHex(bin2Hex(Mass2[i].Substring(0, 8)));
                string res2 = CheckHex(bin2Hex(Mass2[i].Substring(8, 8)));
                string res3 = CheckHex(bin2Hex(Mass2[i].Substring(16, 8)));
                textBox1.AppendText(res1 + res2 + res3 + "\r\n");
            }
            steamWriter2.Write(textBox1.Text);
            steamWriter2.Close();
            #endregion
            textBox1.Text = null;

            #region расчет 3 картинки
            StreamWriter steamWriter0_3 = new StreamWriter("D:\\LiLu\\0_3.txt");
            progressBar1.Value = 0;
            //progressBar1.Maximum = 2 * n;
            for (int j = 0; j <= 2 * n - 1; j++)
            {
                if (j % 2 == 1)
                {
                    for (i = 8; i >= 1; i--)
                    {
                        x = Xc + Convert.ToInt32((r[i] - 2) * Math.Cos(Angle * j / 2));
                        y = Yc - Convert.ToInt32((r[i] - 2) * Math.Sin(Angle * j / 2));
                        color = bm3.GetPixel(x, y);
                        Bb = Convert.ToInt32(color.B / 255); steamWriter0_3.Write(Bb);
                        Rr = Convert.ToInt32(color.R / 255); steamWriter0_3.Write(Rr);
                        Gg = Convert.ToInt32(color.G / 255); steamWriter0_3.Write(Gg);
                    }
                    steamWriter0_3.WriteLine();
                }
            }
            for (int j = 0; j <= 2 * n - 1; j++)
            {
                if (j % 2 == 1)
                {
                    for (i = 16; i >= 9; i--)
                    {
                        x = Xc + Convert.ToInt32((r[i] - 2) * Math.Cos(Angle * j / 2));
                        y = Yc - Convert.ToInt32((r[i] - 2) * Math.Sin(Angle * j / 2));
                        color = bm3.GetPixel(x, y);
                        Bb2 = Convert.ToInt32(color.B / 255); steamWriter0_3.Write(Bb2);
                        Rr2 = Convert.ToInt32(color.R / 255); steamWriter0_3.Write(Rr2);
                        Gg2 = Convert.ToInt32(color.G / 255); steamWriter0_3.Write(Gg2);
                    }
                    steamWriter0_3.WriteLine();
                }
            }
            steamWriter0_3.Close();

            string[] Mass3 = File.ReadAllLines(@"D:\\LiLu\\0_3.txt",
                                                System.Text.Encoding.Default);
            StreamWriter steamWriter3 = new StreamWriter
                                          ("D:\\LiLu\\3.txt");
            for (int i = 0; i < 240; i++)
            {
                //textBox2.AppendText((Mass[i]) + "\r\n");
                string res1 = CheckHex(bin2Hex(Mass3[i].Substring(0, 8)));
                string res2 = CheckHex(bin2Hex(Mass3[i].Substring(8, 8)));
                string res3 = CheckHex(bin2Hex(Mass3[i].Substring(16, 8)));
                textBox1.AppendText(res1 + res2 + res3 + "\r\n");
            }
            steamWriter3.Write(textBox1.Text);
            steamWriter3.Close();
            #endregion
            textBox1.Text = null;

            #region расчет 4 картинки
            StreamWriter steamWriter0_4 = new StreamWriter("D:\\LiLu\\0_4.txt");
            progressBar1.Value = 0;
            //progressBar1.Maximum = 2 * n;
            for (int j = 0; j <= 2 * n - 1; j++)
            {
                if (j % 2 == 1)
                {
                    for (i = 8; i >= 1; i--)
                    {
                        x = Xc + Convert.ToInt32((r[i] - 2) * Math.Cos(Angle * j / 2));
                        y = Yc - Convert.ToInt32((r[i] - 2) * Math.Sin(Angle * j / 2));
                        color = bm4.GetPixel(x, y);
                        Bb = Convert.ToInt32(color.B / 255); steamWriter0_4.Write(Bb);
                        Rr = Convert.ToInt32(color.R / 255); steamWriter0_4.Write(Rr);
                        Gg = Convert.ToInt32(color.G / 255); steamWriter0_4.Write(Gg);
                    }
                    steamWriter0_4.WriteLine();
                }
            }
            for (int j = 0; j <= 2 * n - 1; j++)
            {
                if (j % 2 == 1)
                {
                    for (i = 16; i >= 9; i--)
                    {
                        x = Xc + Convert.ToInt32((r[i] - 2) * Math.Cos(Angle * j / 2));
                        y = Yc - Convert.ToInt32((r[i] - 2) * Math.Sin(Angle * j / 2));
                        color = bm4.GetPixel(x, y);
                        Bb2 = Convert.ToInt32(color.B / 255); steamWriter0_4.Write(Bb2);
                        Rr2 = Convert.ToInt32(color.R / 255); steamWriter0_4.Write(Rr2);
                        Gg2 = Convert.ToInt32(color.G / 255); steamWriter0_4.Write(Gg2);
                    }
                    steamWriter0_4.WriteLine();
                }
            }
            steamWriter0_4.Close();

            string[] Mass4 = File.ReadAllLines(@"D:\\LiLu\\0_4.txt",
                                                System.Text.Encoding.Default);
            StreamWriter steamWriter4 = new StreamWriter
                                          ("D:\\LiLu\\4.txt");
            for (int i = 0; i < 240; i++)
            {
                //textBox2.AppendText((Mass[i]) + "\r\n");
                string res1 = CheckHex(bin2Hex(Mass4[i].Substring(0, 8)));
                string res2 = CheckHex(bin2Hex(Mass4[i].Substring(8, 8)));
                string res3 = CheckHex(bin2Hex(Mass4[i].Substring(16, 8)));
                textBox1.AppendText(res1 + res2 + res3 + "\r\n");
            }
            steamWriter4.Write(textBox1.Text);
            steamWriter4.Close();
            #endregion
            textBox1.Text = null;

            #region расчет 5 картинки
            StreamWriter steamWriter0_5 = new StreamWriter("D:\\LiLu\\0_5.txt");
            progressBar1.Value = 0;
            //progressBar1.Maximum = 2 * n;
            for (int j = 0; j <= 2 * n - 1; j++)
            {
                if (j % 2 == 1)
                {
                    for (i = 8; i >= 1; i--)
                    {
                        x = Xc + Convert.ToInt32((r[i] - 2) * Math.Cos(Angle * j / 2));
                        y = Yc - Convert.ToInt32((r[i] - 2) * Math.Sin(Angle * j / 2));
                        color = bm5.GetPixel(x, y);
                        Bb = Convert.ToInt32(color.B / 255); steamWriter0_5.Write(Bb);
                        Rr = Convert.ToInt32(color.R / 255); steamWriter0_5.Write(Rr);
                        Gg = Convert.ToInt32(color.G / 255); steamWriter0_5.Write(Gg);
                    }
                    steamWriter0_5.WriteLine();
                }
            }
            for (int j = 0; j <= 2 * n - 1; j++)
            {
                if (j % 2 == 1)
                {
                    for (i = 16; i >= 9; i--)
                    {
                        x = Xc + Convert.ToInt32((r[i] - 2) * Math.Cos(Angle * j / 2));
                        y = Yc - Convert.ToInt32((r[i] - 2) * Math.Sin(Angle * j / 2));
                        color = bm5.GetPixel(x, y);
                        Bb2 = Convert.ToInt32(color.B / 255); steamWriter0_5.Write(Bb2);
                        Rr2 = Convert.ToInt32(color.R / 255); steamWriter0_5.Write(Rr2);
                        Gg2 = Convert.ToInt32(color.G / 255); steamWriter0_5.Write(Gg2);
                    }
                    steamWriter0_5.WriteLine();
                }
            }
            steamWriter0_5.Close();

            string[] Mass5 = File.ReadAllLines(@"D:\\LiLu\\0_5.txt",
                                                System.Text.Encoding.Default);
            StreamWriter steamWriter5 = new StreamWriter
                                          ("D:\\LiLu\\5.txt");
            for (int i = 0; i < 240; i++)
            {
                //textBox2.AppendText((Mass[i]) + "\r\n");
                string res1 = CheckHex(bin2Hex(Mass5[i].Substring(0, 8)));
                string res2 = CheckHex(bin2Hex(Mass5[i].Substring(8, 8)));
                string res3 = CheckHex(bin2Hex(Mass5[i].Substring(16, 8)));
                textBox1.AppendText(res1 + res2 + res3 + "\r\n");
            }
            steamWriter5.Write(textBox1.Text);
            steamWriter5.Close();
            #endregion
            textBox1.Text = null;
            button5.Enabled = true;
////***********************************************////
            progressBar1.Value = 0;
            progressBar1.Maximum = 1200;

            #region запись 1 картинки
            StreamReader f_read = File.OpenText("D:\\LiLu\\1.txt");
            try
            {
                string read = null;
                while ((read = f_read.ReadLine()) != null)
                {
                    Thread.Sleep(100);
                    byte[] newMsg1 = HexStr2DecArr(read);//новая переменная(на отправку)
                    serialPort1.Write(newMsg1, 0, newMsg1.Length);
                    progressBar1.Value++;
                }
                f_read.Dispose();
                f_read.Close();
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
            #endregion

            #region запись 2 картинки
            StreamReader f_read2 = File.OpenText("D:\\LiLu\\2.txt");
            try
            {
                string read2 = null;
                while ((read2 = f_read2.ReadLine()) != null)
                {
                    Thread.Sleep(100);
                    byte[] newMsg2 = HexStr2DecArr(read2);//новая переменная(на отправку)
                    serialPort1.Write(newMsg2, 0, newMsg2.Length);
                    progressBar1.Value++;
                }
                f_read2.Dispose();
                f_read2.Close();
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
            #endregion

            #region запись 3 картинки
            StreamReader f_read3 = File.OpenText("D:\\LiLu\\3.txt");
            try
            {
                string read3 = null;
                while ((read3 = f_read3.ReadLine()) != null)
                {
                    Thread.Sleep(100);
                    byte[] newMsg3 = HexStr2DecArr(read3);//новая переменная(на отправку)
                    serialPort1.Write(newMsg3, 0, newMsg3.Length);
                    progressBar1.Value++;
                }
                f_read3.Dispose();
                f_read3.Close();
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
            #endregion

            #region запись 4 картинки
            StreamReader f_read4 = File.OpenText("D:\\LiLu\\4.txt");
            try
            {
                string read4 = null;
                while ((read4 = f_read4.ReadLine()) != null)
                {
                    Thread.Sleep(100);
                    byte[] newMsg4 = HexStr2DecArr(read4);//новая переменная(на отправку)
                    serialPort1.Write(newMsg4, 0, newMsg4.Length);
                    progressBar1.Value++;
                }
                f_read4.Dispose();
                f_read4.Close();
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
            #endregion

            #region запись 5 картинки
            StreamReader f_read5 = File.OpenText("D:\\LiLu\\5.txt");
            try
            {
                string read5 = null;
                while ((read5 = f_read5.ReadLine()) != null)
                {
                    Thread.Sleep(100);
                    byte[] newMsg5 = HexStr2DecArr(read5);//новая переменная(на отправку)
                    serialPort1.Write(newMsg5, 0, newMsg5.Length);
                    progressBar1.Value++;
                }
                f_read5.Dispose();
                f_read5.Close();
                MessageBox.Show("Готово!");

                string dir = @"D:\LiLu";
                Directory.Delete(dir, true);
            }
            catch (Exception e3)
            {
                MessageBox.Show(e3.Message);
            }
            #endregion
            button5.Enabled = false;
        }

        // Flood the clicked point with a random color.            
        private Color[] colors = { Color.Lime, Color.Blue, Color.Cyan, Color.Red, Color.Yellow, Color.Magenta, Color.White };//Color.Black, 
        
        static int pressNumber = 0;
        Color col2 = new Color();

        #region Выбор цвета
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            col2 = pictureBox2.BackColor;
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            col2 = pictureBox3.BackColor;
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            col2 = pictureBox4.BackColor;
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            col2 = pictureBox5.BackColor;
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            col2 = pictureBox6.BackColor;
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            col2 = pictureBox7.BackColor;
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            col2 = pictureBox8.BackColor;
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            col2 = pictureBox9.BackColor;
        }
        #endregion

        #region управление мышкой
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            pressNumber++;
            AN = 3;
            n = 360 / AN;
            Angle = 2 * PI / n;
            eX = e.X; eY = e.Y;
            Color col = new Color();
            if (e.Button == MouseButtons.Right)
            {
                col = col2;
                col2 = col;
                pressNumber = 0;
            }
            else
            {
                //click(bm, eX, eY, col2);
                clickTools.click_mouse(bm, eX, eY, col2, pictureBox1,
                                       part, n, AN, Angle, Xc, Yc);
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            eX = e.X; eY = e.Y;
            if (e.Button == MouseButtons.Right)
            {
                //if (pressNumber % 2 == 1)
                //{
                //click(bm, eX, eY, col2);
                clickTools.click_mouse(bm, eX, eY, col2, pictureBox1,
                                       part, n, AN, Angle, Xc, Yc);
                //}
            }
        }

        private void pictureBox10_MouseClick(object sender, MouseEventArgs e)
        {
            pressNumber++;
            AN = 3;
            n = 360 / AN;
            Angle = 2 * PI / n;
            eX = e.X; eY = e.Y;
            Color col = new Color();
            if (e.Button == MouseButtons.Right)
            {
                col = col2;
                col2 = col;
                pressNumber = 0;
            }
            else
            {
                //click(bm2, eX, eY, col2);
                clickTools.click_mouse(bm2, eX, eY, col2, pictureBox10,
                                       part, n, AN, Angle, Xc, Yc);
            }
        }
        private void pictureBox10_MouseMove(object sender, MouseEventArgs e)
        {
            eX = e.X; eY = e.Y;
            if (e.Button == MouseButtons.Right)
            {

                //click(bm2, eX, eY, col2);
                clickTools.click_mouse(bm2, eX, eY, col2, pictureBox10,
                                       part, n, AN, Angle, Xc, Yc);
            }
        }

        private void pictureBox11_MouseClick(object sender, MouseEventArgs e)
        {
            pressNumber++;
            AN = 3;
            n = 360 / AN;
            Angle = 2 * PI / n;
            eX = e.X; eY = e.Y;
            Color col = new Color();
            if (e.Button == MouseButtons.Right)
            {
                col = col2;
                col2 = col;
                pressNumber = 0;
            }
            else
            {
                //click(bm3, eX, eY, col2);
                clickTools.click_mouse(bm3, eX, eY, col2, pictureBox11,
                                       part, n, AN, Angle, Xc, Yc);
            }
        }
        private void pictureBox11_MouseMove(object sender, MouseEventArgs e)
        {
            eX = e.X; eY = e.Y;
            if (e.Button == MouseButtons.Right)
            {
                //click(bm3, eX, eY, col2);
                clickTools.click_mouse(bm3, eX, eY, col2, pictureBox11,
                                       part, n, AN, Angle, Xc, Yc);
            }
        }

        private void pictureBox13_MouseClick(object sender, MouseEventArgs e)
        {
            pressNumber++;
            AN = 3;
            n = 360 / AN;
            Angle = 2 * PI / n;
            eX = e.X; eY = e.Y;
            Color col = new Color();
            if (e.Button == MouseButtons.Right)
            {
                col = col2;
                col2 = col;
                pressNumber = 0;
            }
            else
            {
                //click(bm4, eX, eY, col2);
                clickTools.click_mouse(bm4, eX, eY, col2, pictureBox13,
                                       part, n, AN, Angle, Xc, Yc);
            }
        }
        private void pictureBox13_MouseMove(object sender, MouseEventArgs e)
        {
            eX = e.X; eY = e.Y;
            if (e.Button == MouseButtons.Right)
            {
                //click(bm4, eX, eY, col2);
                clickTools.click_mouse(bm4, eX, eY, col2, pictureBox13,
                                       part, n, AN, Angle, Xc, Yc);
            }
        }

        private void pictureBox14_MouseClick(object sender, MouseEventArgs e)
        {
            pressNumber++;
            eX = e.X; eY = e.Y;
            AN = 3;
            n = 360 / AN;
            Angle = 2 * PI / n;
            Color col = new Color();
            if (e.Button == MouseButtons.Right)
            {
                col = col2;
                col2 = col;
                pressNumber = 0;
            }
            else
            {
                //click(bm5, eX, eY,col2);
                clickTools.click_mouse(bm5, eX, eY, col2, pictureBox14,
                                       part, n, AN, Angle, Xc, Yc);
            }
        }
        private void pictureBox14_MouseMove(object sender, MouseEventArgs e)
        {
            eX = e.X; eY = e.Y;
            if (e.Button == MouseButtons.Right)
            {
                //click(bm5, eX, eY, col2);
                clickTools.click_mouse(bm5, eX, eY, col2, pictureBox14,
                                       part, n, AN, Angle, Xc, Yc);

            }
        }
        #endregion        

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            pressNumber = 0;
            part = 1;
        }

        #region выпадающий список
        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            toolStripSplitButton1.ShowDropDown(); 
        }
        private void X1_Click(object sender, EventArgs e)
        {
            part = 1;
        }
        private void X2_Click(object sender, EventArgs e)
        {
            part = 2;
        }
        private void X3_Click(object sender, EventArgs e)
        {
            part = 3;
        }
        private void X4_Click(object sender, EventArgs e)
        {
            part = 4;
        }
        private void X5_Click(object sender, EventArgs e)
        {
            part = 5;
        }
        private void X6_Click(object sender, EventArgs e)
        {
            part = 6;
        }
        private void X10_Click(object sender, EventArgs e)
        {
            part = 10;
        }
        private void X12_Click(object sender, EventArgs e)
        {
            part = 12;
        }
        #endregion

        public void click(Bitmap bm, int eX, int eY,Color col2)
        {
            double radius, cos, sin, arccos, arcsin, tekyshii_gradus;
            int ugol;
            int alpha;
            alpha = 360 / part;
            int[,] a = new int[17, n];
            AN = 3;            
            n = 360 / AN;//120
            Angle = 2 * PI / n;
            Xc = pictureBox1.Width / 2;   // Координаты центра
            Yc = pictureBox1.Height / 2;
            radius = (double)(Math.Sqrt(Convert.ToDouble(Math.Pow((Xc - eX), 2) + Math.Pow((Yc - eY), 2))));
            cos = (double)(eX - Xc) / (radius);
            sin = (double)(Yc - eY) / (radius);
            arccos = Math.Acos(cos) * 180 / PI;
            arcsin = Math.Asin(sin) * 180 / PI;

            Color old_color = bm.GetPixel(eX, eY);
            if (arccos > 0 && arcsin > 0)
            {
                tekyshii_gradus = arccos;
                Color cvet = new Color();
                ugol = (int)tekyshii_gradus;
                int x0, y0;
                for (int i = 0; i < part; i++)
                {
                    x0 = Xc + Convert.ToInt32((radius - Angle) * Math.Cos(tekyshii_gradus * PI / 180));
                    y0 = Yc - Convert.ToInt32((radius - Angle) * Math.Sin(tekyshii_gradus * PI / 180));
                    tekyshii_gradus = tekyshii_gradus + alpha;
                    cvet = bm.GetPixel(x0, y0);
                    if ((cvet.R == 0) && (cvet.G == 0) && (cvet.B == 0)) return;
                    if ((old_color.R == 0) && (old_color.G == 0) && (old_color.B == 0)) return;
                    FloodTools.FloodFill(bm, x0, y0, col2);
                    Refresh();
                }
            }
            if (arccos > 0 && arcsin < 0)
            {
                tekyshii_gradus = 360 - arccos;
                
                ugol = (int)tekyshii_gradus;
                Color cvet = new Color();
                int x0, y0;
                for (int i = 0; i < part; i++)
                {
                    x0 = Xc + Convert.ToInt32((radius - Angle) * Math.Cos(tekyshii_gradus * PI / 180));
                    y0 = Yc - Convert.ToInt32((radius - Angle) * Math.Sin(tekyshii_gradus * PI / 180));
                    tekyshii_gradus = tekyshii_gradus + alpha;
                    cvet = bm.GetPixel(x0, y0);
                    if ((cvet.R == 0) && (cvet.G == 0) && (cvet.B == 0)) return;
                    if ((old_color.R == 0) && (old_color.G == 0) && (old_color.B == 0)) return;
                    FloodTools.FloodFill(bm, x0, y0, col2);
                    Refresh();
                }
            }
        }

        //Функции
        #region
        private string ByteToHex(byte[] comByte)
        {
            StringBuilder builder = new StringBuilder(comByte.Length * 3);
            foreach (byte data in comByte)
                builder.Append(Convert.ToString(data, 16).PadLeft(2, '0').PadRight(3, ' '));
            return builder.ToString().ToUpper();
        }
        
        private byte[] HexToByte(string msg)
        {
            msg = msg.Replace(" ", "");
            byte[] comBuffer = new byte[msg.Length / 2];
            for (int i = 0; i < msg.Length; i += 2)
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            return comBuffer;
        }
        
        public static string CheckHex(string input)
        {
            string result = input;
            if (input.Length % 2 != 0)
                result = '0' + result;
            return result;
        }
        
        public static byte[] HexStr2DecArr(string input)
        {
            string normalHex = CheckHex(input);
            byte[] result = new byte[normalHex.Length / 2];
            for (int i = 0, first = 0, second = 1; i < result.Length; ++i, first = first + 2, second = second + 2)
                result[i] = Hex2Dec(normalHex[first].ToString() + normalHex[second].ToString());
            return result;
        }
        
        public static byte Hex2Dec(string input)
        {
            byte result = 0;
            result = byte.Parse(input, System.Globalization.NumberStyles.HexNumber);
            return result;
        }    
         
        public string bin2Hex(string strBin)
        {
            int decNumber = bin2Dec(strBin);
            return dec2Hex(decNumber);
        }

        private string dec2Hex(int val)
        {
            return val.ToString("X");
        }

        public int bin2Dec(string strBin)
        {
            return Convert.ToInt32(strBin, 2);
        }
        #endregion

    }
}