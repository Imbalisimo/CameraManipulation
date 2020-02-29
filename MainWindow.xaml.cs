using SharpGL;
//using SharpGL.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CameraManipulationOpenGL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            // Get the OpenGL object.
            OpenGL gl = args.OpenGL;

            //  Set the clear color.
            gl.ClearColor(0, 0, 0, 0);

            //  Enable the OpenGL depth testing functionality.
            gl.Enable(OpenGL.GL_DEPTH_TEST);
        }

        float rotatePyramid = 0;
        float rquad = 0;
        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            //  Get the OpenGL instance that's been passed to us.
            OpenGL gl = args.OpenGL;

            //  Clear the color and depth buffers.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //  Reset the modelview matrix.
            gl.LoadIdentity();

            //  Move the geometry into a fairly central position.
            gl.Translate(-1.5f, 0.0f, -6.0f);

            //  Draw a pyramid. First, rotate the modelview matrix.
            gl.Rotate(rotatePyramid, 0.0f, 1.0f, 0.0f);

            //  Start drawing triangles.
            gl.Begin(OpenGL.GL_TRIANGLES);

                gl.Color(1.0f, 0.0f, 0.0f);
                gl.Vertex(0.0f, 1.0f, 0.0f);
                gl.Color(0.0f, 1.0f, 0.0f);
                gl.Vertex(-1.0f, -1.0f, 1.0f);
                gl.Color(0.0f, 0.0f, 1.0f);
                gl.Vertex(1.0f, -1.0f, 1.0f);

                gl.Color(1.0f, 0.0f, 0.0f);
                gl.Vertex(0.0f, 1.0f, 0.0f);
                gl.Color(0.0f, 0.0f, 1.0f);
                gl.Vertex(1.0f, -1.0f, 1.0f);
                gl.Color(0.0f, 1.0f, 0.0f);
                gl.Vertex(1.0f, -1.0f, -1.0f);

                gl.Color(1.0f, 0.0f, 0.0f);
                gl.Vertex(0.0f, 1.0f, 0.0f);
                gl.Color(0.0f, 1.0f, 0.0f);
                gl.Vertex(1.0f, -1.0f, -1.0f);
                gl.Color(0.0f, 0.0f, 1.0f);
                gl.Vertex(-1.0f, -1.0f, -1.0f);

                gl.Color(1.0f, 0.0f, 0.0f);
                gl.Vertex(0.0f, 1.0f, 0.0f);
                gl.Color(0.0f, 0.0f, 1.0f);
                gl.Vertex(-1.0f, -1.0f, -1.0f);
                gl.Color(0.0f, 1.0f, 0.0f);
                gl.Vertex(-1.0f, -1.0f, 1.0f);

            gl.End();

            //  Reset the modelview.
            gl.LoadIdentity();

            //  Move into a more central position.
            gl.Translate(1.5f, 0.0f, -7.0f);

            //  Rotate the cube.
            gl.Rotate(rquad, 1.0f, 1.0f, 1.0f);

            //  Provide the cube colors and geometry.
            gl.Begin(OpenGL.GL_QUADS);

                gl.Color(0.0f, 1.0f, 0.0f);
                gl.Vertex(1.0f, 1.0f, -1.0f);
                gl.Vertex(-1.0f, 1.0f, -1.0f);
                gl.Vertex(-1.0f, 1.0f, 1.0f);
                gl.Vertex(1.0f, 1.0f, 1.0f);

                gl.Color(1.0f, 0.5f, 0.0f);
                gl.Vertex(1.0f, -1.0f, 1.0f);
                gl.Vertex(-1.0f, -1.0f, 1.0f);
                gl.Vertex(-1.0f, -1.0f, -1.0f);
                gl.Vertex(1.0f, -1.0f, -1.0f);

                gl.Color(1.0f, 0.0f, 0.0f);
                gl.Vertex(1.0f, 1.0f, 1.0f);
                gl.Vertex(-1.0f, 1.0f, 1.0f);
                gl.Vertex(-1.0f, -1.0f, 1.0f);
                gl.Vertex(1.0f, -1.0f, 1.0f);

                gl.Color(1.0f, 1.0f, 0.0f);
                gl.Vertex(1.0f, -1.0f, -1.0f);
                gl.Vertex(-1.0f, -1.0f, -1.0f);
                gl.Vertex(-1.0f, 1.0f, -1.0f);
                gl.Vertex(1.0f, 1.0f, -1.0f);

                gl.Color(0.0f, 0.0f, 1.0f);
                gl.Vertex(-1.0f, 1.0f, 1.0f);
                gl.Vertex(-1.0f, 1.0f, -1.0f);
                gl.Vertex(-1.0f, -1.0f, -1.0f);
                gl.Vertex(-1.0f, -1.0f, 1.0f);

                gl.Color(1.0f, 0.0f, 1.0f);
                gl.Vertex(1.0f, 1.0f, -1.0f);
                gl.Vertex(1.0f, 1.0f, 1.0f);
                gl.Vertex(1.0f, -1.0f, 1.0f);
                gl.Vertex(1.0f, -1.0f, -1.0f);

            gl.End();

            //  Flush OpenGL.
            gl.Flush();

            //  Rotate the geometry a bit.
            rotatePyramid += 3.0f;
            rquad -= 3.0f;
        }

        private void OpenGLControl_Resized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            // Get the OpenGL instance.
            OpenGL gl = args.OpenGL;

            // Load and clear the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();

            // Perform a perspective transformation
            gl.Perspective(45.0f, (float)gl.RenderContextProvider.Width / (float)gl.RenderContextProvider.Height,
                0.1f, 100.0f);

            //  Use the 'look at' helper function to position and aim the camera.
            //gl.LookAt(-5, 5, -5, 0, 0, 0, 0, 1, 0);

            // Load the modelview.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }
    }
}
