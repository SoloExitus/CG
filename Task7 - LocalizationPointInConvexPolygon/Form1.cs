using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task6___LocalizationPointInConvexPolygon
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

        PointF TestPoint = new PointF();

        int Qmin = 1;
        int Qmax = 360;

        int Rmin = 1;
        int Rmax = 700;

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

            QminUpDown.Value = 1;
            QmaxUpDown.Value = 180;

            RminUpDown.Value = 1;
            RmaxUpDown.Value = 700;

            G = CreateGraphics();
            timer1.Start();
        }

        private double AngleBetweenVectors(ref PointF f, ref PointF s)
        {
            return Math.Atan2(f.X * s.Y - f.Y * s.X, f.X * s.X + f.Y * s.Y);
        }


        private double RadtoAngle(double rad)
        {
            return rad * 180 / Math.PI;
        }

        private double Convert(double a)
        {
            return a >= 0 ? a : Math.PI * 2 + a;
        }

        private bool TestPointInPolugon()
        {
            PointF VecFirst = new PointF(PolygonVertexes[0].X - CenterPolygon.X, PolygonVertexes[0].Y - CenterPolygon.Y);
            PointF VecSecond = new PointF(PolygonVertexes[1].X - CenterPolygon.X, PolygonVertexes[1].Y - CenterPolygon.Y);

            // true - по часовой
            bool Direction =  AngleBetweenVectors(ref VecFirst, ref VecSecond) >= 0? true : false;

            // коэффициент для изменение знака, чтобы положительное увеличение угла соответсвовало увеличению индексов
            int DirInt = Direction ? 1 : -1; 
           

            PointF point = new PointF(TestPoint.X - CenterPolygon.X, TestPoint.Y - CenterPolygon.Y);

            double test = RadtoAngle(AngleBetweenVectors(ref VecFirst, ref point));
            double angleToTestPoint = RadtoAngle(Convert(DirInt * AngleBetweenVectors(ref VecFirst, ref point)));

            int li = 0;
            int ri = PolygonVertexes.Count();

            bool res = false;

            while(li != ri)
            {
                int mid = (li + ri) / 2;
                PointF Pmid = PolygonVertexes[mid];
                PointF NPmid = PolygonVertexes[(mid + 1) % PolygonVertexes.Count()];

                PointF VecPMid = new PointF(Pmid.X - CenterPolygon.X, Pmid.Y - CenterPolygon.Y);

                double angleToPmid = RadtoAngle(Convert(DirInt * AngleBetweenVectors(ref VecFirst, ref VecPMid)));

                
                if (angleToTestPoint < angleToPmid)
                {
                    ri = mid;
                    continue;
                }

                PointF VecNPMid = new PointF(NPmid.X - CenterPolygon.X, NPmid.Y - CenterPolygon.Y);
                double angleToNPmid = RadtoAngle(Convert(DirInt * AngleBetweenVectors(ref VecFirst, ref VecNPMid)));

                angleToNPmid = angleToNPmid == 0 ? 360 : angleToNPmid;

                if (angleToTestPoint > angleToNPmid)
                {
                    li = (mid +1);
                    continue;
                }

                if (SideVectorPoint(ref Pmid, ref NPmid, ref TestPoint) * SideVectorPoint(ref Pmid, ref NPmid, ref CenterPolygon) >= 0 )
                {
                    res = true;
                }

                break;

            }

            return res;
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

            if (isTestPointIntered && PolygonVertexes.Count() > 2 && is_Convex())
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
                if (GrabPointIndex >= 0)
                {
                    PolygonVertexes[GrabPointIndex] = e.Location;
                    CalculateCenterPolygon();
                }
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


        private bool TestConvex(ref PointF P)
        {
            PointF A = PolygonVertexes[0];
            PointF B = PolygonVertexes[1];

            PointF Last = PolygonVertexes[PolygonVertexes.Count() - 1];

            bool f = SideVectorPoint(ref A, ref B, ref P) < 0;
            bool s = SideVectorPoint(ref A, ref Last, ref P) < 0;

            return (f && s);
        }

        private int SideVectorPoint(ref PointF A, ref PointF B, ref PointF P)
        {
            PointF VecU = new PointF(B.X - A.X, B.Y - A.Y);
            PointF VecV = new PointF(P.X - A.X, P.Y - A.Y);

            return (int)(VecU.X * VecV.Y - VecU.Y * VecV.X);
        }

        private void Ganerate_Click(object sender, EventArgs e)
        {
            PolygonVertexes.Clear();
            Random rnd = new Random();
            int fi = 0;

            PointF T = new PointF(this.ClientRectangle.Width / 2, this.ClientRectangle.Height / 2);
            PolygonVertexes.Add(T);


            while (true)
            {
                int r = rnd.Next(Rmin, Rmax);
                fi += rnd.Next(Qmin, Qmax);

                double fiToRad = fi * Math.PI / 180;
                PointF Last = PolygonVertexes[PolygonVertexes.Count() - 1];

                PointF New = new PointF((int)(Last.X + r * Math.Cos(fiToRad)), (int)(Last.Y - r * Math.Sin(fiToRad)));

                if (PolygonVertexes.Count() > 2 && !TestConvex(ref New))
                {
                    break;
                }

                PolygonVertexes.Add(New);
            }

            isUpdate = true;
        }
        private void QminUpDown_ValueChanged(object sender, EventArgs e)
        {
            int NewValue = (int)QminUpDown.Value;
            Qmin = NewValue > 0 ? NewValue : 1;
            QminUpDown.Value = Qmin;
        }

        private void QmaxUpDown_ValueChanged(object sender, EventArgs e)
        {
            int NewValue = (int)QmaxUpDown.Value % 361;
            if (NewValue > Qmin)
                Qmax = NewValue;
            QmaxUpDown.Value = Qmax;
        }

        private void RminUpDown_ValueChanged(object sender, EventArgs e)
        {
            int NewValue = (int)RminUpDown.Value % 700;
            Rmin = NewValue > 0 ? NewValue : 1;
            RminUpDown.Value = Rmin;
        }

        private void RmaxUpDown_ValueChanged(object sender, EventArgs e)
        {
            int NewValue = (int)RmaxUpDown.Value;
            if (NewValue > Rmin)
                Rmax = NewValue;
            RmaxUpDown.Value = Rmax;
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
                scale += scaleDelta;
                isUpdate = true;
            }


        }

        private bool is_Convex()
        {
            int curDirection = 0;
            int n = PolygonVertexes.Count();
            for (int i = 0; i < n; i++)
            {
                PointF P0 = PolygonVertexes[i];
                PointF P1 = PolygonVertexes[(i + 1) % n];
                PointF P2 = PolygonVertexes[(i + 2) % n];
                int pos = SideVectorPoint(ref P0, ref P1, ref P2);

                if (pos == 0) continue;

                if (curDirection == 0)
                {
                    curDirection = pos;
                    continue;
                }

                if ((curDirection > 0 && pos > 0) || (curDirection < 0 && pos < 0))
                    continue;

                return false;
            }
            return true;
        }

        private void ConvexTest_Click(object sender, EventArgs e)
        {
            if (PolygonVertexes.Count() < 3)
                return;

            if (is_Convex())
                TestConvexRes.BackColor = Color.Green;
            else
                TestConvexRes.BackColor = Color.Red;
        }
    }
}
