using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointInArbitraryPolygon
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
        double scaleStep = 0.2;

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

        private bool TestPointInPolugon()
        {
            int k = 0; // кол-во пересечений луча с ребрами 

            for(int i = 0 ; i < PolygonVertexes.Count(); i++) // цикл по всем ребрам
            {
                PointF A = PolygonVertexes[i];
                PointF B = PolygonVertexes[(i+1) % PolygonVertexes.Count()];

                if (A.Y == B.Y) continue; // если ребро вертикальное то его не рассматриваем

                // не учитываем если пересечение достигается в нижней точке ребра
                float miny = A.Y < B.Y ? B.Y : A.Y;
                if (TestPoint.Y == miny) continue;

                // ищем позицию точки пересечения ребре и вертикального луча из тестовой точки вправо
                float t = ((TestPoint.Y - B.Y) / (A.Y - B.Y));

                if (t < 0 || t > 1) continue; // если точка пересечения не лежит на реьре а на его продолжении то пропускаем

                float CX = (A.X - B.X) * t + B.X;
                if (CX < TestPoint.X) continue; // если точка пересечения левее тестовой точки, то она не принадлежит лучу

                k++; // засчитываем пересечение
            }

            if (k % 2 == 0) return false; // четное число пересечений => тестовая точка лежит мне полигона
            return true; // тестовая точка внутри
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
                if (GrabPointIndex >= 0 ) PolygonVertexes[GrabPointIndex] = e.Location;
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
                        for(int i=0; i < PolygonVertexes.Count(); i++)
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

            for(int i = 0; i < pointCount; i++)
            {
                PointF newPoint = new PointF(rnd.Next(0,800),rnd.Next(0,600));
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
                double scaleDelta = scaleStep * e.Delta;

                for (int i = 0; i < PolygonVertexes.Count(); i++)
                {
                    // перемещаем фигуру в начало координат (из глобальных в локальную)
                    PointF transform = new PointF(PolygonVertexes[i].X - CenterPolygon.X, PolygonVertexes[i].Y - CenterPolygon.Y);

                    // масшатбирование
                    transform.X *= (float)(scaleDelta);
                    transform.Y *= (float)(scaleDelta);

                    // в глобальную
                    PolygonVertexes[i] = new PointF(transform.X + CenterPolygon.X, transform.Y + CenterPolygon.Y);
                }
                scale = scale + scaleDelta;
                isUpdate = true;
            }

            
        }
    }
}
