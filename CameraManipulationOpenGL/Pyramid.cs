using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;

namespace CameraManipulationOpenGL
{
    class Pyramid : Shape
    {
        //          A
        //         /|\
        //        / | \
        //       /  |  \
        //      / _/C\_ \
        //     /_/     \_\
        //    B-_       _-D
        //       \_   _/
        //         \E/

        public Pyramid() : base()
        {
            points = new Dictionary<string, Point3D>();

            points["A"] = new Point3D(-2.0f, 1.0f, -7.0f);
            points["B"] = new Point3D(-3.0f, -1.0f, -6.0f);
            points["C"] = new Point3D(-1.0f, -1.0f, -6.0f);
            points["D"] = new Point3D(-1.0f, -1.0f, -8.0f);
            points["E"] = new Point3D(-3.0f, -1.0f, -8.0f);

            BindCurrentPositionAsOrigin();
        }

        public override void Draw(OpenGL gl)
        {
            //  Start drawing triangles.
            gl.Begin(OpenGL.GL_TRIANGLES);
            {
                GlColor(gl);
                //gl.Color(1.0f, 0.0f, 0.0f);
                Vertex(gl, points["A"]);
                //gl.Color(0.0f, 1.0f, 0.0f);
                Vertex(gl, points["B"]);
                //gl.Color(0.0f, 0.0f, 1.0f);
                Vertex(gl, points["C"]);

                //gl.Color(1.0f, 0.0f, 0.0f);
                Vertex(gl, points["A"]);
                //gl.Color(0.0f, 0.0f, 1.0f);
                Vertex(gl, points["C"]);
                //gl.Color(0.0f, 1.0f, 0.0f);
                Vertex(gl, points["D"]);

                //gl.Color(1.0f, 0.0f, 0.0f);
                Vertex(gl, points["A"]);
                //gl.Color(0.0f, 1.0f, 0.0f);
                Vertex(gl, points["D"]);
                //gl.Color(0.0f, 0.0f, 1.0f);
                Vertex(gl, points["E"]);

                //gl.Color(1.0f, 0.0f, 0.0f);
                Vertex(gl, points["A"]);
                //gl.Color(0.0f, 0.0f, 1.0f);
                Vertex(gl, points["E"]);
                //gl.Color(0.0f, 1.0f, 0.0f);
                Vertex(gl, points["B"]);
            }
            gl.End();
        }
    }
}
