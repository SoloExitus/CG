using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task10___11___Convex_hull
{
    public partial class Form1 : Form
    {
        Graphics G;

        List<PointF> Points = new List<PointF>();
        List<PointF> Shell = new List<PointF>();

        bool isUpdate = false;

        bool isPointEdit = false;

        int GrabPointIndex = -1;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            G = CreateGraphics();
            timer1.Start();
        }

        private void Draw()
        {
            System.Drawing.SolidBrush PointsBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

            System.Drawing.SolidBrush PolygonBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Yellow);


            //if (Shell.Count()>0)
            //{
            //    G.FillPolygon(PolygonBrush, Shell.ToArray());
            //}

            for (int i = 0; i < Points.Count(); i++)
            {
                G.FillEllipse(PointsBrush, Points[i].X - 4, Points[i].Y - 4, 8, 8);
            }

            for (int i = 0; i < Shell.Count(); i++)
            {
                G.FillEllipse(PolygonBrush, Shell[i].X - 4, Shell[i].Y - 4, 8, 8);
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

        private bool TryGrabPoint(PointF vertex, PointF location)
        {
            double dist = Math.Sqrt(Math.Pow(location.X - vertex.X, 2) + Math.Pow(location.Y - vertex.Y, 2));
            if (dist < 4.0)
            {
                return true;
            }
            return false;
        }

        private void ModePoint_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPointEdit)
            {
                if (GrabPointIndex >= 0) Points[GrabPointIndex] = e.Location;
                isUpdate = true;
            }
        }

        private void ModePoint_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Points.Add(new PointF(e.Location.X, e.Location.Y));
                isUpdate = true;
            }
            else if (e.Button == MouseButtons.Right)
            {

                for (int i = 0; i < Points.Count(); i++)
                {
                    if (TryGrabPoint(Points[i], e.Location))
                    {
                        GrabPointIndex = i;
                        isPointEdit = true;
                        return;
                    }
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
            Points.Clear();
            GrabPointIndex = -1;
            isPointEdit = false;
            Shell.Clear();
            isUpdate = true;
        }

        private float SideVectorPoint(PointF A,PointF B, PointF P)
        {
            PointF VecU = new PointF(B.X - A.X, B.Y - A.Y);
            PointF VecV = new PointF(P.X - A.X, P.Y - A.Y);

            return (VecU.X * VecV.Y - VecU.Y * VecV.X);
        }

        private bool TestPointInTriangle(PointF A,PointF B,PointF C,PointF T)
        {
            
            
                float first = SideVectorPoint(A, B, T);
                float second = SideVectorPoint(B, C, T);
                float third = SideVectorPoint(C, A, T);

                if ((first >= 0 && second >= 0 && third >= 0) || (first <= 0 && second <= 0 && third <= 0))
                {
                    return true;
                }

            return false;
        }

        private void Simple_Click(object sender, EventArgs e)
        {
            Shell.Clear();
            int N = Points.Count();
            if (N < 2) return;

            for (int t = 0; t < N; t++)
            {
                bool isShellPoint = true;
                for (int i = 0; i < N; i++)
                {
                    if (i == t) 
                        continue;

                    for (int j = 0; j < N; j++)
                    {
                        if (j == t || j==i) 
                            continue;

                        for (int k = 0; k < N; k++)
                        {
                            if (k == t || k==i || k==j) 
                                continue;
                            
                            if (TestPointInTriangle(Points[i], Points[j], Points[k], Points[t]))
                            {
                                isShellPoint = false;
                                break;
                            }
                        }
                        if (!isShellPoint) 
                            break;

                    }
                    if (!isShellPoint)
                        break;
                }
                if (isShellPoint) 
                    Shell.Add(Points[t]);

            }

            isUpdate = true;
        }

        private float squareDist(PointF A, PointF B)
        {
            return (B.X - A.X) * (B.X - A.X) + (B.Y - A.Y) * (B.Y - A.Y);
        }

        private void Ray_Click(object sender, EventArgs e)
        {
            Shell.Clear();
            int N = Points.Count();
            if (N < 2) return;

            int f = 0;
            for(int i = 1; i < N; i++)
            {
                if (Points[i].Y < Points[f].Y || ((Points[i].Y == Points[f].Y) && (Points[i].X < Points[f].X)))
                {
                    f = i;
                } 
            }
            Shell.Add(Points[f]);
            int tf = f;
            while(true)
            {
                int s = -1;
                for (s = 0; s < N; s++)
                {
                    bool isShellPoint = true;

                    if (s == tf) 
                        continue;

                    for(int j = 0; j < N; j++)
                    {
                        if (j == tf || j == s)
                            continue;
                        float r = SideVectorPoint(Points[tf], Points[s], Points[j]);
                        if (r>0 || (r==0 &&(squareDist(Points[tf], Points[j]) > squareDist(Points[tf], Points[s]))))
                        {
                            isShellPoint = false;
                            break;
                        }

                    }
                    if (isShellPoint)
                    {
                        break;
                    }
                }
                if (f == s)
                {
                    break;
                }
                Shell.Add(Points[s]);
                tf = s;
            }

            isUpdate = true;
        }

        private void iterative_Click(object sender, EventArgs e)
        {
            Shell.Clear();
            int N = Points.Count();

            if (N < 2) 
                return;

            isUpdate = true;
        }

        class PointFP
        {
            public float x = 0;
            public float y = 0;
            public float angle = 0;

            public PointFP()
            {
            }

            public PointFP(PointF point, PointF center)
            {
                x = point.X;
                y = point.Y;
                angle = (float)Math.Atan2(point.Y - center.Y, point.X - center.X);
            }

            public PointFP(PointF p)
            {
                x = p.X;
                y = p.Y;
                angle = (float)Math.Atan2(p.Y, p.X);
            }

            public PointFP(float _x,float _y)
            {
                x = _x;
                y = _y;
                angle = (float)Math.Atan2(y, x);
            }

            public PointF ToPointF()
            {
                return new PointF(x, y);
            }
        }

        class PolarAngle : IComparer<PointFP>
        {
            public int Compare(PointFP f, PointFP s)
            {
                return f.angle.CompareTo(s.angle);
            }
        }

        private void Graham_Click(object sender, EventArgs e)
        {
            Shell.Clear();
            int N = Points.Count();

            if (N < 2) 
                return;

            int f = 0;
            for (int i = 1; i < N; i++)
            {
                if (Points[i].Y < Points[f].Y || ((Points[i].Y == Points[f].Y) && (Points[i].X < Points[f].X)))
                {
                    f = i;
                }
            }

            List<PointFP> order = new List<PointFP>();
            Points.ForEach((item)=>
                {
                        order.Add(new PointFP(item, Points[f]));
                }
            );

            order.Sort(new PolarAngle());

            System.Drawing.SolidBrush y = new System.Drawing.SolidBrush(System.Drawing.Color.Yellow);
            System.Drawing.SolidBrush g = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
            System.Drawing.SolidBrush re = new System.Drawing.SolidBrush(System.Drawing.Color.Red);

            int tN = N;
            for(int i = 1; i < tN; i++)
            {
                
                float r = SideVectorPoint(order[i - 1].ToPointF(), order[i].ToPointF(), order[(i + 1) % tN].ToPointF());
                if (r <= 0)
                {
                    
                    order.Remove(order[i]);
                    i-=2;
                    tN--;
                }
                

            }

            order.ForEach(item =>
                {
                    Shell.Add(item.ToPointF());
                }
            );

            isUpdate = true;
        }
    }
}
