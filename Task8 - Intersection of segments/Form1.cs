using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task8___Intersection_of_segments
{
    public partial class Form1 : Form
    {
        enum Mode
        {
            None = 0,
            FirstSegment,
            SecondSegment,
        }

        Mode CurrentMode = Mode.None;

        PointF[] FirstSegment = new PointF[2];
        PointF[] SecondSegment = new PointF[2];

        int curFirstI = 0;
        int curSecondI = 0;

        int FirstIndex = 0;
        int SecondIndex = 0;

        bool isFirstSegmentEntered = false;
        bool isSecondSegmentEntered = false;

        bool isPointEdit = false;

        int GrabPointIndex = -1;

        bool isUpdate = false;


        Graphics G;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CurrentMode = Mode.None;

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

        private void Draw()
        {
            System.Drawing.SolidBrush FirstSegmentBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
            System.Drawing.SolidBrush SecondSegmentBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);

            for (int i = 0; i < FirstIndex; i++)
            {
                G.FillEllipse(FirstSegmentBrush, FirstSegment[i].X - 3, FirstSegment[i].Y - 3, 6, 6);
            }

            if (isFirstSegmentEntered)
            {
                G.DrawLine(new Pen(Color.DarkGreen, 2), FirstSegment[0], FirstSegment[1]);
            }

            for (int i = 0; i < SecondIndex; i++)
            {
                G.FillEllipse(SecondSegmentBrush, SecondSegment[i].X - 3, SecondSegment[i].Y - 3, 6, 6);
            }

            if (isSecondSegmentEntered)
            {
                G.DrawLine(new Pen(Color.OrangeRed, 2), SecondSegment[0], SecondSegment[1]);
            }
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

        private void ModeFirstSegment_CheckedChanged(object sender, EventArgs e)
        {
            CurrentMode = Mode.FirstSegment;
        }

        private void ModeSecondSegment_CheckedChanged(object sender, EventArgs e)
        {
            CurrentMode = Mode.SecondSegment;
        }

        private void ModePoint_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPointEdit)
            {
                if (GrabPointIndex <2)
                {
                    FirstSegment[GrabPointIndex] = e.Location;
                }
                else
                {
                    SecondSegment[GrabPointIndex-2] = e.Location;
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
                    case Mode.FirstSegment:
                        FirstSegment[curFirstI] = new PointF(e.Location.X, e.Location.Y);
                        FirstIndex = isFirstSegmentEntered ? FirstIndex : FirstIndex + 1;
                        isFirstSegmentEntered = FirstIndex == 2;
                        curFirstI = ++curFirstI % 2;
                        isUpdate = true;
                        break;
                    case Mode.SecondSegment:
                        SecondSegment[curSecondI] = new PointF(e.Location.X, e.Location.Y);
                        SecondIndex = isSecondSegmentEntered ? SecondIndex : SecondIndex + 1;
                        isSecondSegmentEntered = SecondIndex == 2;
                        curSecondI = ++curSecondI % 2;
                        isUpdate = true;
                        break;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {

                switch (CurrentMode)
                {
                    case Mode.FirstSegment:
                        for (int i = 0; i < 2; i++)
                        {
                            if (TryGrabPoint(FirstSegment[i], e.Location))
                            {
                                GrabPointIndex = i;
                                isPointEdit = true;
                                return;
                            }
                        }
                        break;
                    case Mode.SecondSegment:
                        for (int i = 0; i < 2; i++)
                        {
                            if (TryGrabPoint(SecondSegment[i], e.Location))
                            {
                                GrabPointIndex = i+2;
                                isPointEdit = true;
                                return;
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
                GrabPointIndex = -1;
                isPointEdit = false;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            isFirstSegmentEntered = false;
            curFirstI = 0;
            FirstIndex = 0;
            isSecondSegmentEntered = false;
            curFirstI = 0;
            SecondIndex = 0;

            GrabPointIndex = -1;
            isPointEdit = false;

            TestConvexRes.BackColor = Color.Gray;

            isUpdate = true;
        }

        private int SideVectorPoint(ref PointF A, ref PointF B, ref PointF P)
        {
            PointF VecU = new PointF(B.X - A.X, B.Y - A.Y);
            PointF VecV = new PointF(P.X - A.X, P.Y - A.Y);

            return (int)(VecU.X * VecV.Y - VecU.Y * VecV.X);
        }

        private bool between(double a, double b, double c)
        {
            return Math.Min(a, b) <= c && c >= Math.Max(a, b);
        }

        private bool isIntersection()
        {
            double det = (FirstSegment[1].X - FirstSegment[0].X) * (SecondSegment[0].Y - SecondSegment[1].Y) -
                (FirstSegment[1].Y - FirstSegment[0].Y) * (SecondSegment[0].X - SecondSegment[1].X);

            if (det == 0.0)
            {
                double firstK = (FirstSegment[0].Y - FirstSegment[1].Y) / (FirstSegment[0].X - FirstSegment[1].X);
                double firstB = FirstSegment[1].Y - firstK * FirstSegment[1].X;
                double secondK = (SecondSegment[0].Y - SecondSegment[1].Y) / (SecondSegment[0].X - SecondSegment[1].X);
                double secondB = SecondSegment[1].Y - secondK * SecondSegment[1].X;

                if (firstB == secondB)
                {
                    // проверяем проекцию точек на ОХ
                    return between(FirstSegment[0].X, FirstSegment[1].X, SecondSegment[0].X) ||
                        between(FirstSegment[0].X, FirstSegment[1].X, SecondSegment[1].X) ||
                        between(SecondSegment[0].X, SecondSegment[1].X, FirstSegment[0].X) ||
                        between(SecondSegment[0].X, SecondSegment[1].X, FirstSegment[1].X);
                }

                return false;
            }

            double det1 = (SecondSegment[0].X - FirstSegment[0].X) * (SecondSegment[0].Y - SecondSegment[1].Y) -
                (SecondSegment[0].Y - FirstSegment[0].Y) * (SecondSegment[0].X - SecondSegment[1].X);

            double det2 = (FirstSegment[1].X - FirstSegment[0].X) * (SecondSegment[0].Y - FirstSegment[0].Y) -
                (FirstSegment[1].Y - FirstSegment[0].Y) * (SecondSegment[0].X - FirstSegment[0].X);

            double t = det1 / det;
            double r = det2 / det;

            if ((0 <= t) && (t <= 1) && (0 <= r) && (r <= 1)) return true;
            return false;
        }

        private void InteseсtionTest_Click(object sender, EventArgs e)
        {
            if (!isFirstSegmentEntered && !isSecondSegmentEntered)
                return;

            if (isIntersection())
                TestConvexRes.BackColor = Color.Green;
            else
                TestConvexRes.BackColor = Color.Red;
        }
    }
}
