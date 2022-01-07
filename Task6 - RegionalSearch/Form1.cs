using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task6___RegionalSearch
{
    public partial class Form1 : Form
    {
        enum Mode
        {
            None = 0,
            EnterPoints,
            EnterRegion,
        }

        Mode CurrentMode = Mode.None;

        int MinPolygonVertexCount = 3;
        int MaxPolygonVertexCount = 21;

        List<PointF> Points = new List<PointF>();


        class cell
        {
            public PointF point;
            public int count;

            public cell()
            {
                this.count = 0;
                point = new PointF();
            }
        }

        cell[,] Table;
        List<int> CoordX = new List<int>();
        List<int> CoordY = new List<int>();

        Point[] Region = new Point[2];
        int RegionPointCounter = 0;

        bool isRegionEntered = false;

        bool isPointEdit = false;

        int GrabPointIndex = -3;

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

        private void formTable()
        {
            Table = new cell[Points.Count() + 1, Points.Count() + 1];
            CoordX.Clear();
            CoordY.Clear();
            foreach(PointF coord in Points)
            {
                CoordX.Add((int)coord.X);
                CoordY.Add((int)coord.Y);
            }
            CoordX.Sort();
            CoordY.Sort();

            for(int i=0;i< Points.Count() + 1; i++)
            {
                for(int j=0;j< Points.Count() + 1; j++)
                {
                    int X = i == Points.Count() ? -1 : CoordX[i];
                    int Y = j == Points.Count() ? -1 : CoordY[j];
                    Table[i, j] = new cell();
                    Table[i, j].point = new PointF(X,Y);
                    int c = 0;
                    for(int n=0;n< Points.Count();n++)
                    {
                        bool left = X == -1 ? true : Points[n].X < Table[i, j].point.X;
                        bool up = Y == -1 ? true : Points[n].Y < Table[i, j].point.Y;
                        if (left && up )
                            c++;
                    }
                    Table[i, j].count = c;
                }
            }

        }

        private int Q(Point p)
        {

            int li = 0;
            int ri = Points.Count() + 1;

            int lj = 0;
            int rj = Points.Count() + 1;

            while (ri != li)
            {
                int mid =(li + ri) / 2;
                if (mid == Points.Count())
                {
                    ri = mid;
                    continue;
                }

                if (CoordX[mid] < p.X)
                    li = mid + 1;
                else
                    ri = mid;
            }
            // 1 2 3
            // 0 1 2 3
            // 0.5    1.5
            // .0---1---2---3
            //  0   1   2 
            while (rj != lj)
            {
                int mid = (lj + rj) / 2;
                if (mid == Points.Count())
                {
                    rj = mid;
                    continue;
                }

                if (CoordY[mid] < p.Y)
                    lj = mid + 1;
                else
                    rj = mid;
            }
            /*for (;i< Points.Count();i++)
            {
                if (CoordX[i] > p.X)
                    break;
            }

            int j = 0;

            for(;j< Points.Count();j++)
            {
                if (CoordY[j] > p.Y) 
                    break;
            }*/

            return Table[li, lj].count;
        }

        private void CountPointsInRegion()
        {
            int Qlu = Q(Region[0]);
            int Qld = Q(new Point(Region[0].X, Region[1].Y));
            int Qrd = Q(Region[1]);
            int Qru = Q(new Point(Region[1].X, Region[0].Y));
            int N = Qrd - Qru - Qld + Qlu;
            //int N = Q(Region[1]) + Q(Region[0]) - Q(new Point(Region[0].X, Region[1].Y)) - Q(new Point(Region[1].X, Region[0].Y));
            PointsInRegion.Text = Convert.ToString(N);
        }

        private void Draw()
        {
            System.Drawing.Pen RegionPen = new System.Drawing.Pen(Color.Gray);


            System.Drawing.SolidBrush PointInBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
            System.Drawing.SolidBrush PointOutBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            System.Drawing.SolidBrush PointBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

            for (int i = 0; i < RegionPointCounter; i++)
            {
                G.DrawRectangle(RegionPen, Region[i].X - 4, Region[i].Y - 4,8,8 );
            }

            if (isRegionEntered)
            {
                G.DrawRectangle(RegionPen,new Rectangle( Region[0].X, Region[0].Y, Region[1].X - Region[0].X, Region[1].Y - Region[0].Y));
                CountPointsInRegion();
            }

            for (int i = 0; i < Points.Count(); i++)
            {
                G.FillEllipse(PointBrush, Points[i].X - 4, Points[i].Y - 4, 8, 8);
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

        private void ModeRegion_CheckedChanged(object sender, EventArgs e)
        {
            CurrentMode = Mode.EnterRegion;
        }

        private void ModePoints_CheckedChanged(object sender, EventArgs e)
        {
            CurrentMode = Mode.EnterPoints;
        }

        private void ModePoint_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPointEdit)
            {
                if (GrabPointIndex >= 0) Points[GrabPointIndex] = e.Location;
                else Region[-GrabPointIndex - 1] = e.Location;
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
                    case Mode.EnterPoints:
                        Points.Add(new PointF(e.Location.X, e.Location.Y));
                        formTable();
                        isUpdate = true;
                        break;
                    case Mode.EnterRegion:
                        if (!isRegionEntered)
                        {
                            Region[RegionPointCounter] = e.Location;
                            RegionPointCounter++;
                            isRegionEntered = RegionPointCounter == 2;
                        }

                        isUpdate = true;
                        break;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {

                switch (CurrentMode)
                {
                    case Mode.EnterPoints:
                        for (int i = 0; i < Points.Count(); i++)
                        {
                            if (TryGrabPoint(Points[i], e.Location))
                            {
                                GrabPointIndex = i;
                                isPointEdit = true;
                                return;
                            }
                        }
                        break;

                    case Mode.EnterRegion:
                        for(int i=0;i< RegionPointCounter; i++)
                        {
                            if (TryGrabPoint(Region[i], e.Location))
                            {
                                GrabPointIndex = -i -1;
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
                GrabPointIndex = -3;
                isPointEdit = false;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            isRegionEntered = false;
            Points.Clear();
            PointsInRegion.Text = "NONE";
            GrabPointIndex = -3;
            isPointEdit = false;
            RegionPointCounter = 0;
            isUpdate = true;
        }

        private void ArbitraryPolygon_Click(object sender, EventArgs e)
        {

        }

        /*private void MaxVCUpDown_ValueChanged(object sender, EventArgs e)
        {
            int NewValue = (int)MaxVCUpDown.Value;
            if (NewValue > MinPolygonVertexCount)
                MaxPolygonVertexCount = NewValue;
        }

        private void MinVCUpDown_ValueChanged(object sender, EventArgs e)
        {
            int NewValue = (int)MinVCUpDown.Value;
            MinPolygonVertexCount = NewValue > 2 ? NewValue : 3;
        }*/

    }
}
