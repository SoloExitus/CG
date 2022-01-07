using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task5___TestPointInPolygonAngleMethod
{
    public partial class Form1 : Form
    {
        enum Mode
        {
            None = 0,
            EnterPolygon,
            EnterPoint,
        }

        Mode CurrentMode = Mode.None;

        double scale = 1;
        double scaleStep = 0.02;

        PointF TestPoint = new PointF();

        int MinPolygonVertexCount = 3;
        int MaxPolygonVertexCount = 21;

        List<PointF> PolygonVertexes = new List<PointF>();
        PointF CenterPolygon = new PointF();

        bool isTestPointIntered = false;

        bool isPointEdit = false;

        int GrabPointIndex = -2;

        bool isUpdate = false;


        Graphics G;
        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(MouseWheelScroll);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CurrentMode = Mode.None;
            G = CreateGraphics();
            timer1.Start();
        }

        /*private double VectorNorm( ref PointF Vector)
        {
            return Math.Sqrt(Vector.X * Vector.X + Vector.Y * Vector.Y);
        }

        private double MinAngleVectors(ref PointF V1, ref PointF V2)
        {
            double pseScalar = V1.X * V2.Y - V1.Y * V2.X;
            return Math.Asin(pseScalar / VectorNorm(ref V1) / VectorNorm(ref V2));
        }*/

        private double MinAngleBetweenVectors( ref PointF f,ref PointF s)
        {
            return Math.Atan2(f.X * s.Y - f.Y * s.X, f.X * s.X + f.Y * s.Y);
        }


        private double RadtoAngle(double rad)
        {
            return rad * 180 / Math.PI;
        }

        private bool TestPointInPolugon()
        {
            double radAngle = 0;
            int tangle = 0;
            for(int i=0;i< PolygonVertexes.Count(); i++)
            {
                PointF first = new PointF(PolygonVertexes[i].X - TestPoint.X, PolygonVertexes[i].Y - TestPoint.Y);
                PointF second = new PointF(PolygonVertexes[(i + 1) % PolygonVertexes.Count()].X - TestPoint.X, PolygonVertexes[(i + 1) % PolygonVertexes.Count()].Y - TestPoint.Y);
                double curVector = MinAngleBetweenVectors(ref first, ref second);
                tangle -= (int)RadtoAngle(curVector);
                radAngle -= curVector;

            }

            int angle = (int)(Math.Abs(RadtoAngle(radAngle)));

            int diff = 360 - angle;

            if (diff < 10)
                return true;
            return false;
        }

        private void Draw()
        {
            System.Drawing.SolidBrush GreenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
            System.Drawing.SolidBrush RedBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            System.Drawing.SolidBrush PolygonVartexesBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

            System.Drawing.SolidBrush TestPointBrush = RedBrush;

            System.Drawing.SolidBrush PolygonBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Yellow);
            //Draw  TriangleVertexes
            for (int i = 0; i < PolygonVertexes.Count(); i++)
            {
                G.FillEllipse(PolygonVartexesBrush, PolygonVertexes[i].X - 4, PolygonVertexes[i].Y - 4, 8, 8);
            }

            if (PolygonVertexes.Count() > 2)
            {
                //G.DrawPolygon(new Pen(Color.Black, 2), PolygonVertexes.ToArray());
                G.FillPolygon(PolygonBrush, PolygonVertexes.ToArray());
            }

            if (isTestPointIntered)
            {

                if (TestPointInPolugon())
                {
                    TestPointBrush = GreenBrush;
                }
                G.FillEllipse(TestPointBrush, TestPoint.X - 4, TestPoint.Y - 4, 8, 8);
            }
        }

        private void CalculateCenterPolygon()
        {
            float centerX = 0;
            float centerY = 0;

            foreach (PointF Vertex in PolygonVertexes)
            {
                centerX += Vertex.X;
                centerY += Vertex.Y;
            }
            CenterPolygon.X = centerX / PolygonVertexes.Count();
            CenterPolygon.Y = centerY / PolygonVertexes.Count();
        }

        private bool TryGrabPoint(PointF vertex, PointF location)
        {
            double dist = Math.Sqrt(Math.Pow(location.X - vertex.X, 2) + Math.Pow(location.Y - vertex.Y, 2));
            if (dist < 4.0)
            {
                return true;
            }
            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                G.Clear(Color.White);
                Draw();
                isUpdate = false;
            }

        }

        private void ModeNone_CheckedChanged(object sender, EventArgs e)
        {
            CurrentMode = Mode.None;
        }

        private void ModePolygon_CheckedChanged(object sender, EventArgs e)
        {
            CurrentMode = Mode.EnterPolygon;
        }

        private void ModePoint_CheckedChanged(object sender, EventArgs e)
        {
            CurrentMode = Mode.EnterPoint;
        }

        private void ModePoint_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPointEdit)
            {
                if (GrabPointIndex == -1) TestPoint = e.Location;
                if (GrabPointIndex >= 0) PolygonVertexes[GrabPointIndex] = e.Location;
                isUpdate = true;
            }
        }

        private void ModePoint_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (CurrentMode)
                {
                    case Mode.None:
                        return;
                    case Mode.EnterPolygon:
                        PolygonVertexes.Add(new PointF(e.Location.X, e.Location.Y));
                        CalculateCenterPolygon();
                        isUpdate = true;
                        break;
                    case Mode.EnterPoint:
                        TestPoint.X = e.Location.X;
                        TestPoint.Y = e.Location.Y;
                        isTestPointIntered = true;
                        isUpdate = true;
                        break;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {

                switch (CurrentMode)
                {
                    case Mode.EnterPolygon:
                        for (int i = 0; i < PolygonVertexes.Count(); i++)
                        {
                            if (TryGrabPoint(PolygonVertexes[i], e.Location))
                            {
                                GrabPointIndex = i;
                                isPointEdit = true;
                                return;
                            }
                        }
                        break;
                    case Mode.EnterPoint:
                        if (isTestPointIntered)
                        {
                            if (TryGrabPoint(TestPoint, e.Location))
                            {
                                GrabPointIndex = -1;
                                isPointEdit = true;
                            }
                        }
                        break;
                }

            }
        }

        private void ModePoint_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                GrabPointIndex = -2;
                isPointEdit = false;
                CalculateCenterPolygon();
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            isTestPointIntered = false;
            PolygonVertexes.Clear();
            GrabPointIndex = -2;
            isPointEdit = false;
            CalculateCenterPolygon();
            isUpdate = true;
        }

        private void ArbitraryPolygon_Click(object sender, EventArgs e)
        {
            PolygonVertexes.Clear();
            Random rnd = new Random();

            int pointCount = rnd.Next(MinPolygonVertexCount, MaxPolygonVertexCount);

            for (int i = 0; i < pointCount; i++)
            {
                PointF newPoint = new PointF(rnd.Next(0, 800), rnd.Next(0, 600));
                PolygonVertexes.Add(newPoint);
            }

            CalculateCenterPolygon();
            isUpdate = true;
        }

        private void MaxVCUpDown_ValueChanged(object sender, EventArgs e)
        {
            int NewValue = (int)MaxVCUpDown.Value;
            if (NewValue > MinPolygonVertexCount)
                MaxPolygonVertexCount = NewValue;
        }

        private void MinVCUpDown_ValueChanged(object sender, EventArgs e)
        {
            int NewValue = (int)MinVCUpDown.Value;
            MinPolygonVertexCount = NewValue > 2 ? NewValue : 3;
        }

        private void MouseWheelScroll(object sender, MouseEventArgs e)
        {

            if (CurrentMode == Mode.EnterPolygon)
            {
                double scaleDelta = scale * e.Delta / 2000;

                if (scale + scaleDelta <= 0) return;

                for (int i = 0; i < PolygonVertexes.Count(); i++)
                {
                    // перемещаем фигуру в начало координат (из глобальных в локальную)
                    PointF transform = new PointF(PolygonVertexes[i].X - CenterPolygon.X, PolygonVertexes[i].Y - CenterPolygon.Y);

                    // масшатбирование
                    transform.X *= (float)(scale + scaleDelta / scale);
                    transform.Y *= (float)(scale + scaleDelta / scale);

                    // в глобальную
                    PolygonVertexes[i] = new PointF(transform.X + CenterPolygon.X, transform.Y + CenterPolygon.Y);
                }
                scale = scale + scaleDelta;
                isUpdate = true;
            }


        }
    }
}
