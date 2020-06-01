using System;
using System.Drawing;
using System.Collections.Generic;


namespace NameSpacePlot
{
    public class Plot
    {
        public double maxX, minX, maxY, minY;
        public List<double> arrX, arrY;
        public Rectangle rectPlot;
        private double scaleX, scaleY;
        Font fontData = new System.Drawing.Font("Courier New", 6F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        Font fontLabel = new System.Drawing.Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        Brush textBrush = new SolidBrush(Color.DarkBlue);

        public Plot(Rectangle rectPlot)
        {
            arrX = new List<double>();
            arrY = new List<double>();
            this.rectPlot = rectPlot;
        }

        public void Reset()
        {
            arrX.Clear();
            arrY.Clear();
        }

        public void AddPoint(double x, double y)
        {
            if (double.IsInfinity(x) || double.IsInfinity(y))
                return;
            int  count = arrX.Count;
            if (count == 0)
            {
                minX = maxX = x;
                minY = maxY = y;
            }
            else
            {
                if (x > maxX) maxX = x;
                else if (x < minX) minX = x;

                if (y > maxY) maxY = y;
                else if (y < minY) minY = y;
            }
            arrX.Add(x);
            arrY.Add(y);

        }
       
      
        public void DrawLines(Graphics g, Pen penLine, Pen  pentPoint)
        {
            int i = 0, count = arrX.Count;
            if (count <= 0)
                return;

            int sizePoint = 4;
            int width = rectPlot.Width, height = rectPlot.Height;
            scaleX = (double)width / (maxX - minX);
            scaleY = (double)height / (maxY - minY);

            int xPlot, yPlot, xPlot0 = 0, yPLot0 = 0;
            for (i = 0; i < count; i++)
            {
                xPlot = (maxX == minX) ? width / 2 + rectPlot.X : (int)Math.Round(scaleX * (arrX[i] - minX)) + rectPlot.X;
                yPlot = (maxY == minY) ? height / 2 + rectPlot.Y : (int)Math.Round(scaleY * (arrY[i] - minY)) + rectPlot.Y;

                g.DrawRectangle(pentPoint, new Rectangle(xPlot - sizePoint / 2, yPlot - sizePoint / 2, sizePoint, sizePoint));
                if (i != 0)
                    g.DrawLine(penLine, xPlot0, yPLot0, xPlot, yPlot);

                xPlot0 = xPlot;
                yPLot0 = yPlot;
            }

            

        }
        public void DrawAxes(Graphics g, Pen penAxes, string xLabel, string yLabel, int numLines)
        {
            int deltaX = rectPlot.Width / (numLines + 1);
            int deltaY = rectPlot.Height / (numLines + 1);
            for (int i = 1; i <= numLines; i++)
            {
                g.DrawLine(penAxes, rectPlot.X + deltaX * i, rectPlot.Y - 5,
                    rectPlot.X + deltaX * i, rectPlot.Bottom);

                g.DrawLine(penAxes, rectPlot.X - 5, rectPlot.Y + deltaY * i,
                    rectPlot.Right, rectPlot.Y + deltaY * i);
            }
            g.DrawRectangle(new Pen(Color.DarkBlue), rectPlot);

            #region Draw Texts
            double d;
            string st;
            SizeF sizeFont;
            g.ScaleTransform(1, -1);
            // Draw String X
            for (int i = 1; i <= numLines; i++)
            {
                if ((i - 1) % 3 == 0)
                {
                    d = (maxX == minX) ? deltaX * i * 2.0 / rectPlot.Width + minX - 1 : deltaX * i / scaleX + minX;
                    st = d.ToString("f4");
                    sizeFont = g.MeasureString(st, fontData);
                    g.DrawString(st, fontData, textBrush, rectPlot.X + deltaX * i - sizeFont.Width / 2, -rectPlot.Y + 6);
                }
            }
            g.DrawString(xLabel, fontLabel, textBrush, rectPlot.X + 3 * deltaX, -rectPlot.Y + 12);

            
            // Draw String Y
            for (int i = 1; i <= numLines; i++)
            {
                if ((i - 1) % 3 == 0)
                {
                    d = (maxY == minY) ? deltaY * i * 2.0 / rectPlot.Height + minY - 1 : deltaY * i / scaleY + minY;
                    st = d.ToString("f4");
                    sizeFont = g.MeasureString(st, fontData);
                    g.DrawString(st, fontData, textBrush, 1, -rectPlot.Y - deltaY * i - fontData.Size - 3);
                }
            }
            g.DrawString(yLabel, fontLabel, textBrush, rectPlot.X - 40, -rectPlot.Bottom);


            g.ScaleTransform(1,-1);

            #endregion



        }

    }
}
