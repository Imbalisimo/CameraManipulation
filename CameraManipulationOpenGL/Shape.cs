using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;

namespace CameraManipulationOpenGL
{
    abstract class Shape
    {
        protected Dictionary<string, Point3D> points;
        protected Dictionary<string, Point3D> originalPoints;

        protected List<Color> colors;

        private int _currentColorIndex;
        public int CurrentColorIndex
        {
            get => _currentColorIndex;
            set { _currentColorIndex = (value + colors.Count) % colors.Count; }
        }

        protected Shape()
        {
            Cam.OnMoving += Trasform;

            colors = new List<Color>();
            foreach (string ColorName in Enum.GetNames(typeof(KnownColor)))
            {
                colors.Add(Color.FromName(ColorName));
            }
            CurrentColorIndex = 0;
        }

        public void Trasform(Matrix3D matrix)
        {
            List<string> keys = new List<string>();
            foreach(string key in points.Keys)
            {
                keys.Add(key);
            }
            foreach(string key in keys)
            {
                points[key] = matrix.Transform(points[key]);
            }
        }

        public void MovePoint(string point, Point3D position)
        {
            points[point] = Cam.Position.Transform(position);
        }

        public abstract void Draw(OpenGL gl);

        protected void Vertex(OpenGL gl, Point3D vertex)
        {
            gl.Vertex(vertex.X, vertex.Y, vertex.Z);
        }

        protected void BindCurrentPositionAsOrigin()
        {
            originalPoints = new Dictionary<string, Point3D>();
            foreach(KeyValuePair<string, Point3D> pair in points)
            {
                originalPoints[pair.Key] = pair.Value;
            }
        }

        protected void ReturnToOriginPosition()
        {
            foreach (KeyValuePair<string, Point3D> pair in originalPoints)
            {
                points[pair.Key] = pair.Value;
            }
        }

        protected void GlColor(OpenGL gl)
        {
            gl.Color(
                colors[CurrentColorIndex].R,
                colors[CurrentColorIndex].G,
                colors[CurrentColorIndex].B);
        }
    }
}
