using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;

namespace CameraManipulationOpenGL
{
    public static class Cam
    {
        public static Matrix3D Position = Matrix3D.Identity;

        public static void Move(Vector3D direction, Vector3D rotation)
        {
            Matrix3D matrix = Matrix3D.Identity;

            // translation
            if (direction.X != 0)
                matrix = Matrix3D.Multiply(matrix, MoveRight(direction.X));

            if (direction.Y != 0)
                matrix = Matrix3D.Multiply(matrix, MoveForwards(direction.Y));

            // rotation
            if (rotation.X != 0)
                matrix = Matrix3D.Multiply(matrix, Pitch(rotation.X));

            if (rotation.Y != 0)
                matrix = Matrix3D.Multiply(matrix, Jaw(rotation.Y));

            if (rotation.Z != 0)
                matrix = Matrix3D.Multiply(matrix, Roll(rotation.Z));

            OnMoving(matrix);
            Position.Append(matrix);
        }

        private static Matrix3D MoveRight(double velocity)
        {
            return new Matrix3D(    1   , 0, 0, 0,
                                    0   , 1, 0, 0,
                                    0   , 0, 1, 0,
                                velocity, 0, 0, 1);
        }

        private static Matrix3D MoveForwards(double velocity)
        {
            return new Matrix3D(1, 0,    0    , 0,
                                0, 1,    0    , 0,
                                0, 0,    1    , 0,
                                0, 0, velocity, 1);
        }

        private static Matrix3D Pitch(double angle)
        {
            return new Matrix3D(1,      0          ,        0       , 0,
                                0,  Math.Cos(angle), Math.Sin(angle), 0,
                                0, -Math.Sin(angle), Math.Cos(angle), 0,
                                0,      0          ,        0       , 1);
            //angle *= 10;
            //Matrix3D matrix = Matrix3D.Identity;
            //matrix.Rotate(new Quaternion(Position.Transform(new Vector3D(1, 0, 0)), angle));
            //return matrix;
        }

        private static Matrix3D Jaw(double angle)
        {
            //return new Matrix3D(Math.Cos(angle), 0, -Math.Sin(angle), 0,
            //                            0      , 1,         0       , 0,
            //                    Math.Sin(angle), 0,  Math.Cos(angle), 0,
            //                            0      , 0,         0       , 1);
            angle *= 10;
            Matrix3D matrix = Matrix3D.Identity;
            matrix.Rotate(new Quaternion(Position.Transform(new Vector3D(0, 1, 0)), angle));
            return matrix;
        }

        private static Matrix3D Roll(double angle)
        {
            return new Matrix3D( Math.Cos(angle), Math.Sin(angle), 0, 0,
                                -Math.Sin(angle), Math.Cos(angle), 0, 0,
                                        0       ,       0        , 1, 0,
                                        0       ,       0        , 0, 1);
            //angle *= 10;
            //Matrix3D matrix = Matrix3D.Identity;
            //matrix.Rotate(new Quaternion(Position.Transform(new Vector3D(0, 0, 1)), angle));
            //return matrix;
        }

        public static void Reset()
        {
            Position.Invert();
            OnMoving(Position);
            Position = Matrix3D.Identity;
        }

        public delegate void Moving(Matrix3D newMatrix);
        public static event Moving OnMoving;
    }
}
