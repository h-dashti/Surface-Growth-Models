using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using NameSpacePlot;

namespace GrowingSurfaces
{
    public partial class FormGrowSurface : Form
    {
        #region Fields
        GrowSurface surface;
        Bitmap bitMapSurface;
        Color colorParticles = Color.Blue;
        int sizeRect = 2;

        Point[] ptOccuiped;
        //StreamWriter sW_SurfaceWidth;

        Rectangle rectPlotCurve;
        Plot plotCurveW_t, plotCurvehAve_t;
        Pen penLine = new Pen(Color.Blue);
        Pen penAxes = new Pen(Color.FromArgb(192, 192, 255));
        Pen penRects = new Pen(Color.Red);
        #endregion


        #region Methods

        void Reset()
        {
            int L, h;
            try
            {
                L = int.Parse(textBox_L.Text); //pictureBox1.Width / sizeRect;
                h = int.Parse(textBox_H.Text);//pictureBox1.Height / sizeRect;
            }
            catch (FormatException e) { MessageBox.Show(e.ToString()); return; }

            if (L < 20) sizeRect = 20;
            else if (L < 60) sizeRect = 10;
            //else if (L < 100) sizeRect = 4;
            //else if (L <= 200) sizeRect = 2;
            else sizeRect = 1;

            Deposition method = Deposition.EdenModel;
            if (radioButtonEden.Checked) method = Deposition.EdenModel;
            else if (radioButtonRandom.Checked) method = Deposition.Random;
            else if (radioButtonBallistic.Checked) method = Deposition.Ballistic;
            else if (radioButtonDLA.Checked) method = Deposition.DLA;
            else if (radioButtonRSOS.Checked) method = Deposition.RSOS;
            else if (radioButtonRDSR.Checked) method = Deposition.RDSR;
            else if (radioButtonWolfV.Checked) method = Deposition.WV;
            else if (radioButtonDST.Checked) method = Deposition.DST;

            labelMethod.Text = method.ToString();

            pictureBox1.Size = new Size(L * sizeRect, h * sizeRect);
            groupBoxStructure.Left = pictureBox1.Right + 10;
            groupBoxMethod.Left = groupBoxStructure.Left;
            pictureBox_W_t.Left = groupBoxMethod.Right + 10;
            pictureBoxHave.Left = pictureBox_W_t.Left;

            SubstrateType sunType = checkBoxWedged.Checked ? 
                SubstrateType.Wegded : SubstrateType.Flat;


            surface = new GrowSurface(L, h * 100, method, sunType);
            ptOccuiped = new Point[L];
            for (int n = 0; n < L; n++)
                ptOccuiped[n].X = n;

            bitMapSurface = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            DrawBitMap();

            rectPlotCurve = new Rectangle(50, 30, pictureBox_W_t.Width - 60, pictureBox_W_t.Height - 40);
            plotCurveW_t = new Plot(rectPlotCurve);
            plotCurvehAve_t = new Plot(rectPlotCurve);
            TakeWidthSurafce();


            //if (sW_SurfaceWidth != null)
            //    sW_SurfaceWidth.Close();
            //string pathOut = CreateDirectory() + "\\" + method + " L=" + L + " H=" + h + ".txt";
            //pathOut = PathOut(pathOut);
            //sW_SurfaceWidth = new StreamWriter(pathOut);

            label_Step.Text = "num particles = " + surface.nAddedParticles;

            GC.Collect();
        }

        void DrawBitMap()
        {
            int L = surface.L;
            int height = bitMapSurface.Height;
            //if (h * sizeRect >= bitMapSurface.Height) return;

            Graphics g = Graphics.FromImage(bitMapSurface);
            //g.Clear(pictureBox1.BackColor);
            
            if (sizeRect == 1)
            {
                for (int n = 0; n < ptOccuiped.Length; n++)
                    if (ptOccuiped[n].Y < height)
                        bitMapSurface.SetPixel(ptOccuiped[n].X, ptOccuiped[n].Y, colorParticles);
            }
            else
            {
                for (int n = 0; n < ptOccuiped.Length; n++)
                    if (ptOccuiped[n].Y *sizeRect < height)
                    {
                        Rectangle rect = new Rectangle(ptOccuiped[n].X * sizeRect, ptOccuiped[n].Y * sizeRect, sizeRect, sizeRect);
                        g.FillRectangle(new SolidBrush(colorParticles), rect);
                    }
            }

            g.Dispose();


        }

        void TakeWidthSurafce()
        {
            double w, have;
            surface.FindSurfaceWidth(out w,  out have);
            double logsteps = Math.Log10(surface.nAddedParticles);
            plotCurveW_t.AddPoint(logsteps, Math.Log10(w));
            plotCurvehAve_t.AddPoint(logsteps, Math.Log10(have));
        }

        int CalculateTimerInterval()
        {
            int maxInterval = 600, minInterval = 10,
                min = trackBar_Latency.Minimum, max = trackBar_Latency.Maximum, value = trackBar_Latency.Value;

            return ((minInterval - maxInterval) * (value - min)) / (max - min) + maxInterval;
        }
        void Initialize()
        {
            timer1.Interval = CalculateTimerInterval();
            textBox_L.Text = "600";
            textBox_H.Text = "600";
            numericUpDownIt.Value = 100;
        }


        string PathOut(string mainPath)
        {
            int i = 1, index;
            index = mainPath.IndexOf(".");
            string format = mainPath.Substring(index);
            string path0 = mainPath.Substring(0, index);
            string path = mainPath;

            while (File.Exists(path))
            {
                path = path0 + "(" + i + ")" + format;
                i++;
            }

            return path;

        }
        string CreateDirectory()
        {
            string dirMain = "OUT";
            if (!Directory.Exists(dirMain))
                Directory.CreateDirectory(dirMain);

            return dirMain;
        }

        void DoSimulation()
        {
            int steps = (int)numericUpDownIt.Value;
            ptOccuiped = new Point[steps];
            for (int i = 0; i < steps; i++)
            {
                int x = -1, y = -1;
                surface.Deposite(ref x, ref y);
                ptOccuiped[i] = new Point(x, y);
            }

            label_Step.Text = "num particles = " + surface.nAddedParticles;
            //if (surface.nAddedParticles % surface.L == 0 || surface.nAddedParticles % surface.L == 1)
                TakeWidthSurafce();

            DrawBitMap();
            pictureBox1.Invalidate();
            pictureBox_W_t.Invalidate();
            pictureBoxHave.Invalidate();
        }
        #endregion



        public FormGrowSurface()
        {
            InitializeComponent();
            Initialize();
            Reset();
        }

        private void buttonAutomatic_Click(object sender, EventArgs e)
        {
            if (buttonAutomatic.Text == "Automatic Depositions")
            {

                buttonAutomatic.Text = "Pause";
                timer1.Start();
            }
            else if (buttonAutomatic.Text == "Pause")
            {

                buttonAutomatic.Text = "Automatic Depositions";
                timer1.Stop();
            }
           
        }


     
        private void buttonDeposition_Click(object sender, EventArgs e)
        {
            DoSimulation();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DoSimulation();
        }
       

        private void buttonReset_Click(object sender, EventArgs e)
        {
            Reset();
            pictureBox1.Invalidate();
            pictureBox_W_t.Invalidate();
            pictureBoxHave.Invalidate();
        }

       

   
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TranslateTransform(0, pictureBox1.Height);
            g.ScaleTransform(1, -1);
            g.DrawImage(bitMapSurface, 0, 0);


            int L = surface.L;
            for (int i = 1; i < L; i++)
                g.DrawLine(new Pen(Color.Red, 3), (i - 1) * sizeRect + sizeRect / 2, (surface.h_x[i - 1] + 1) * sizeRect,
                    i * sizeRect + sizeRect / 2, (surface.h_x[i] + 1) * sizeRect);
        }
        private void pictureBox_W_t_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TranslateTransform(0, pictureBox_W_t.Height);
            g.ScaleTransform(1, -1);
            plotCurveW_t.DrawAxes(g, penAxes, "Log(t)", "Log(W)", 7);
            plotCurveW_t.DrawLines(g, penLine, penRects);
        }

        private void pictureBoxHave_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TranslateTransform(0, pictureBoxHave.Height);
            g.ScaleTransform(1, -1);
            plotCurvehAve_t.DrawAxes(g, penAxes, "Log(t)", "Log(<h>)", 7);
            plotCurvehAve_t.DrawLines(g, penLine, penRects);
        }

        private void FormGrowSurface_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer1 != null && timer1.Enabled)
                timer1.Stop();
        }

        private void trackBar_Latency_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = CalculateTimerInterval();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "Designed by Hor Dashti (h.dashti2@gmail.com)";
            MessageBox.Show(text, "About");
        }

        private void pictureBox_W_t_DoubleClick(object sender, EventArgs e)
        {
            plotCurveW_t.Reset();
            pictureBox_W_t.Invalidate();
        }

        private void pictureBoxHave_DoubleClick(object sender, EventArgs e)
        {
            plotCurvehAve_t.Reset();
            pictureBoxHave.Invalidate();
        }

        int snapshots = 0;
        private void buttonSnapshot_Click(object sender, EventArgs e)
        {
            string namefile = snapshots.ToString() + ".jpeg";
            bitMapSurface.Save(namefile);
            snapshots++;
        }

       

        

       

       
    }
}