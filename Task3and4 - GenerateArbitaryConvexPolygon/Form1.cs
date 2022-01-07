using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateArbitaryConvexPolygon
{
    public partial class Form1 : Form
    {
        int Qmin = 1;
        int Qmax = 360;

        int Rmin = 1;
        int Rmax = 700;

        List<PointF> PolygonVertexes = new List<PointF>();

        bool isUpdate = false;


        Graphics G;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            QminUpDown.Value = 1;
            QmaxUpDown.Value = 180;

            RminUpDown.Value = 1;
            RmaxUpDown.Value = 700;

            G = CreateGraphics();
            timer1.Start();
        }

        private void Draw()
        {
            System.Drawing.SolidBrush PolygonVartexesBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

            System.Drawing.SolidBrush PolygonBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Yellow);
            //Draw  TriangleVertexes
            for (int i = 0; i < PolygonVertexes.Count(); i++)
            {
                G.FillEllipse(PolygonVartexesBrush, PolygonVertexes[i].X - 4, PolygonVertexes[i].Y - 4, 8, 8);
            }

            if (PolygonVertexes.Count() > 2)
            {
                G.FillPolygon(PolygonBrush, PolygonVertexes.ToArray());
            }

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

        private void Clear_Click(object sender, EventArgs e)
        {
            PolygonVertexes.Clear();
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

        private bool is_Convex()
        {
            int curDirection = 0;
            int n = PolygonVertexes.Count();
            for(int i = 0; i < n ; i++)
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
