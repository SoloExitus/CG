using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateArbitaryNonConvexPolygon
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

        private void Clear_Click(object sender, EventArgs e)
        {
            PolygonVertexes.Clear();
            isUpdate = true;
        }

        private void Ganerate_Click(object sender, EventArgs e)
        {
            PolygonVertexes.Clear();
            Random rnd = new Random();
            int fi = 0;

            PointF T = new PointF(this.ClientRectangle.Width /2, this.ClientRectangle.Height /2);

            while (fi < 360)
            {
                int r = rnd.Next(Rmin, Rmax);

                double fiToRad = fi * Math.PI / 180;

                PointF P = new PointF((int)(T.X + r * Math.Cos(fiToRad)), (int)(T.Y - r * Math.Sin(fiToRad)));

                PolygonVertexes.Add(P);

                fi += rnd.Next(Qmin, Qmax);
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
    }
}
