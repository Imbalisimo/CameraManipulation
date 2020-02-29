using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;

namespace CameraManipulationOpenGL
{
    class Cube : Shape
    {
        //       B-----------C 
        //      /|          /|
        //     / |         / |
        //    A-----------D  |
        //    |  |        |  |
        //    |  |        |  |
        //    |  F--------|--G
        //    | /         | /
        //    |/          |/
        //    E-----------H


        public Cube() : base()
        {
            points = new Dictionary<string, Point3D>();

            points["A"] = new Point3D(3.0f, 1.0f, -8.0f);
            points["B"] = new Point3D(1.0f, 1.0f, -8.0f);
            points["C"] = new Point3D(1.0f, 1.0f, -6.0f);
            points["D"] = new Point3D(3.0f, 1.0f, -6.0f);
            points["E"] = new Point3D(3.0f, -1.0f, -6.0f);
            points["F"] = new Point3D(1.0f, -1.0f, -6.0f);
            points["G"] = new Point3D(1.0f, -1.0f, -8.0f);
            points["H"] = new Point3D(3.0f, -1.0f, -8.0f);

            BindCurrentPositionAsOrigin();
        }

        public override void Draw(OpenGL gl)
        {
            //  Provide the cube colors and geometry.
            gl.Begin(OpenGL.GL_QUADS);
            {
                //gl.Color(0.0f, 1.0f, 0.0f);
                GlColor(gl);
                Vertex(gl, points["A"]);
                Vertex(gl, points["B"]);
                Vertex(gl, points["C"]);
                Vertex(gl, points["D"]);

                //gl.Color(1.0f, 0.5f, 0.0f);
                Vertex(gl, points["E"]);
                Vertex(gl, points["F"]);
                Vertex(gl, points["G"]);
                Vertex(gl, points["H"]);

                //gl.Color(1.0f, 0.0f, 0.0f);
                Vertex(gl, points["D"]);
                Vertex(gl, points["C"]);
                Vertex(gl, points["F"]);
                Vertex(gl, points["E"]);

                //gl.Color(1.0f, 1.0f, 0.0f);
                Vertex(gl, points["H"]);
                Vertex(gl, points["G"]);
                Vertex(gl, points["B"]);
                Vertex(gl, points["A"]);

                //gl.Color(0.0f, 0.0f, 1.0f);
                Vertex(gl, points["C"]);
                Vertex(gl, points["B"]);
                Vertex(gl, points["G"]);
                Vertex(gl, points["F"]);

                //gl.Color(1.0f, 0.0f, 1.0f);
                Vertex(gl, points["A"]);
                Vertex(gl, points["D"]);
                Vertex(gl, points["E"]);
                Vertex(gl, points["H"]);
            }
            gl.End();
        }
    }
}
