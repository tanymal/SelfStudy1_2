using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace self_study_1_2_ds
{
    public partial class Form1 : Form
    {
        private Dictionary<int, Point> vertexPositions = new Dictionary<int, Point>();
        private List<(int, int)> edges = new List<(int, int)>();

        public Form1()
        {
            InitializeComponent();
            InitializeGraph();
        }

        private void InitializeGraph()
        {
            AddVertex(1, new Point(50, 100));
            AddVertex(2, new Point(150, 50));
            AddVertex(3, new Point(250, 50));
            AddVertex(4, new Point(350, 100));
            AddVertex(5, new Point(250, 150));
            AddVertex(6, new Point(150, 150));

            //Граф 1
            //AddEdge(1, 3);
            //AddEdge(1, 5);
            //AddEdge(2, 4);
            //AddEdge(2, 5);
            //AddEdge(3, 4);
            //AddEdge(4, 6);
            //AddEdge(5, 6);

            //Граф 2
            //AddEdge(1, 2);
            //AddEdge(1, 3);
            //AddEdge(1, 4);
            //AddEdge(1, 5);
            //AddEdge(1, 6);
            //AddEdge(2, 4);
            //AddEdge(2, 5);
            //AddEdge(3, 6);
            //AddEdge(4, 5);
            //AddEdge(4, 6);
            //AddEdge(5, 6);

            //Граф 3
            AddVertex(7, new Point(50, 200));
            AddVertex(8, new Point(350, 200));

            AddEdge(1, 2);
            AddEdge(1, 5);
            AddEdge(1, 8);

            AddEdge(2, 3);
            AddEdge(2, 4);
            AddEdge(2, 8);

            AddEdge(4, 5);
            AddEdge(4, 8);
            AddEdge(5, 6);

            AddEdge(6, 7);
            AddEdge(6, 8);
            AddEdge(7, 8);
        }

        private void AddVertex(int vertex, Point position)
        {
            vertexPositions[vertex] = position;
        }

        private void AddEdge(int startVertex, int endVertex)
        {
            edges.Add((startVertex, endVertex));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (var vertex in vertexPositions)
            {
                e.Graphics.FillEllipse(Brushes.Yellow, vertex.Value.X - 10, vertex.Value.Y - 10, 20, 20);
                e.Graphics.DrawString(vertex.Key.ToString(), Font, Brushes.Black, vertex.Value.X - 5, vertex.Value.Y - 5);
            }

            foreach (var edge in edges)
            {
                Point startPoint = vertexPositions[edge.Item1];
                Point endPoint = vertexPositions[edge.Item2];
                e.Graphics.DrawLine(Pens.Red, startPoint, endPoint);
            }
        }
    }
}
