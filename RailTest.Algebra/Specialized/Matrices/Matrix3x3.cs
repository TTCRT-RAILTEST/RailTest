using RailTest.Algebra.Specialized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RailTest.Algebra.Specialized
{
    /// <summary>
    /// Представляет матрицу 3x3.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Matrix3x3
    {
        /// <summary>
        /// Матрица, соответствующая тождественному преобразованию.
        /// </summary>
        public readonly static Matrix3x3 Identity = new Matrix3x3(1, 0, 0, 0, 1, 0, 0, 0, 1);

        /// <summary>
        /// Первый элемент первой строки.
        /// </summary>
        public double M11;

        /// <summary>
        /// Первый элемент второй строки.
        /// </summary>
        public double M21;

        /// <summary>
        /// Первый элемент третьей строки.
        /// </summary>
        public double M31;

        /// <summary>
        /// Второй элемент первой строки.
        /// </summary>
        public double M12;

        /// <summary>
        /// Второй элемент второй строки.
        /// </summary>
        public double M22;

        /// <summary>
        /// Второй элемент третьей строки.
        /// </summary>
        public double M32;

        /// <summary>
        /// Третий элемент первой строки.
        /// </summary>
        public double M13;

        /// <summary>
        /// Третий элемент второй строки.
        /// </summary>
        public double M23;

        /// <summary>
        /// Третий элемент третьей строки.
        /// </summary>
        public double M33;

        /// <summary>
        /// Инициализирует новый экземпляр.
        /// </summary>
        /// <param name="m11">Первый элемент первой строки.</param>
        /// <param name="m12">Второй элемент первой строки.</param>
        /// <param name="m13">Третий элемент первой строки.</param>
        /// <param name="m21">Первый элемент второй строки.</param>
        /// <param name="m22">Второй элемент второй строки.</param>
        /// <param name="m23">Третий элемент второй строки.</param>
        /// <param name="m31">Первый элемент третьей строки.</param>
        /// <param name="m32">Второй элемент третьей строки.</param>
        /// <param name="m33">Третий элемент третьей строки.</param>
        public Matrix3x3(
            double m11, double m12, double m13,
            double m21, double m22, double m23,
            double m31, double m32, double m33)
        {
            M11 = m11; M12 = m12; M13 = m13;
            M21 = m21; M22 = m22; M23 = m23;
            M31 = m31; M32 = m32; M33 = m33;
        }

        /// <summary>
        /// Возвращает матрицу масштабирования.
        /// </summary>
        /// <param name="matrix">
        /// Матрица масштабирования.
        /// </param>
        /// <param name="xFactor">
        /// Масштабный множитель вдоль оси абсцисс.
        /// </param>
        /// <param name="yFactor">
        /// Масштабный множитель вдоль оси ординат.
        /// </param>
        /// <param name="zFactor">
        /// Масштабный множитель вдоль оси аппликат.
        /// </param>
        public static void Scaling(out Matrix3x3 matrix, double xFactor, double yFactor, double zFactor)
        {
            matrix.M11 = xFactor; matrix.M12 = 0; matrix.M13 = 0;
            matrix.M21 = 0; matrix.M22 = yFactor; matrix.M23 = 0;
            matrix.M31 = 0; matrix.M32 = 0; matrix.M33 = zFactor;
        }

        /// <summary>
        /// Умножает матрицу на матрицу масштабирования слева.
        /// </summary>
        /// <param name="matrix">
        /// Матрица, которую необходимо преобразовать.
        /// </param>
        /// <param name="xFactor">
        /// Масштабный множитель вдоль оси абсцисс.
        /// </param>
        /// <param name="yFactor">
        /// Масштабный множитель вдоль оси ординат.
        /// </param>
        /// <param name="zFactor">
        /// Масштабный множитель вдоль оси аппликат.
        /// </param>
        public static void ScaleDirect(ref Matrix3x3 matrix, double xFactor, double yFactor, double zFactor)
        {
            matrix.M11 = xFactor * matrix.M11;
            matrix.M12 = xFactor * matrix.M12;
            matrix.M13 = xFactor * matrix.M13;
            matrix.M21 = yFactor * matrix.M21;
            matrix.M22 = yFactor * matrix.M22;
            matrix.M23 = yFactor * matrix.M23;
            matrix.M31 = zFactor * matrix.M31;
            matrix.M32 = zFactor * matrix.M32;
            matrix.M33 = zFactor * matrix.M33;
        }

        /// <summary>
        /// Возвращает матрицу поворота вокруг оси абсцисс.
        /// </summary>
        /// <param name="matrix">
        /// Матрица поворота вокруг оси абсцисс.
        /// </param>
        /// <param name="angle">
        /// Угол поворота вокруг оси абсцисс.
        /// </param>
        public static void RotationX(out Matrix3x3 matrix, double angle)
        {
            double c = Math.Cos(angle);
            double s = Math.Sin(angle);
            matrix.M11 = 1; matrix.M12 = 0; matrix.M13 = 0;
            matrix.M21 = 0; matrix.M22 = c; matrix.M23 = -s;
            matrix.M31 = 0; matrix.M32 = s; matrix.M33 = c;
        }

        /// <summary>
        /// Умножает матрицу на матрицу вращения вокруг оси абсцисс слева.
        /// </summary>
        /// <param name="matrix">
        /// Матрица, которую необходимо преобразовать.
        /// </param>
        /// <param name="angle">
        /// Угол поворота вокруг оси абсцисс.
        /// </param>
        public static void RotateXDirect(ref Matrix3x3 matrix, double angle)
        {
            double temp;
            double c = Math.Cos(angle);
            double s = Math.Sin(angle);

            temp = matrix.M21;
            matrix.M21 = c * temp - s * matrix.M31;
            matrix.M31 = s * temp + c * matrix.M31;

            temp = matrix.M22;
            matrix.M22 = c * temp - s * matrix.M32;
            matrix.M32 = s * temp + c * matrix.M32;

            temp = matrix.M23;
            matrix.M23 = c * temp - s * matrix.M33;
            matrix.M33 = s * temp + c * matrix.M33;
        }

        /// <summary>
        /// Возвращает матрицу поворота вокруг оси ординат.
        /// </summary>
        /// <param name="matrix">
        /// Матрица поворота вокруг оси ординат.
        /// </param>
        /// <param name="angle">
        /// Угол поворота вокруг оси ординат.
        /// </param>
        public static void RotationY(out Matrix3x3 matrix, double angle)
        {
            double c = Math.Cos(angle);
            double s = Math.Sin(angle);
            matrix.M11 = c; matrix.M12 = 0; matrix.M13 = s;
            matrix.M21 = 0; matrix.M22 = 1; matrix.M23 = 0;
            matrix.M31 = -s; matrix.M32 = 0; matrix.M33 = c;
        }

        /// <summary>
        /// Умножает матрицу на матрицу вращения вокруг оси ординат слева.
        /// </summary>
        /// <param name="matrix">
        /// Матрица, которую необходимо преобразовать.
        /// </param>
        /// <param name="angle">
        /// Угол поворота вокруг оси ординат.
        /// </param>
        public static void RotateYDirect(ref Matrix3x3 matrix, double angle)
        {
            double temp;
            double c = Math.Cos(angle);
            double s = Math.Sin(angle);

            temp = matrix.M11;
            matrix.M11 = c * temp + s * matrix.M31;
            matrix.M31 = c * matrix.M31 - s * temp;

            temp = matrix.M12;
            matrix.M12 = c * temp + s * matrix.M32;
            matrix.M32 = c * matrix.M32 - s * temp;

            temp = matrix.M13;
            matrix.M13 = c * temp + s * matrix.M33;
            matrix.M33 = c * matrix.M33 - s * temp;
        }

        /// <summary>
        /// Возвращает матрицу поворота вокруг оси аппликат.
        /// </summary>
        /// <param name="matrix">
        /// Матрица поворота вокруг оси аппликат.
        /// </param>
        /// <param name="angle">
        /// Угол поворота вокруг оси аппликат.
        /// </param>
        public static void RotationZ(out Matrix3x3 matrix, double angle)
        {
            double c = Math.Cos(angle);
            double s = Math.Sin(angle);
            matrix.M11 = c; matrix.M12 = -s; matrix.M13 = 0;
            matrix.M21 = s; matrix.M22 = c; matrix.M23 = 0;
            matrix.M31 = 0; matrix.M32 = 0; matrix.M33 = 1;
        }

        /// <summary>
        /// Умножает матрицу на матрицу вращения вокруг оси аппликат слева.
        /// </summary>
        /// <param name="matrix">
        /// Матрица, которую необходимо преобразовать.
        /// </param>
        /// <param name="angle">
        /// Угол поворота вокруг оси аппликат.
        /// </param>
        public static void RotateZDirect(ref Matrix3x3 matrix, double angle)
        {
            double temp;
            double c = Math.Cos(angle);
            double s = Math.Sin(angle);

            temp = matrix.M11;
            matrix.M11 = c * temp - s * matrix.M21;
            matrix.M21 = s * temp + c * matrix.M21;

            temp = matrix.M12;
            matrix.M12 = c * temp - s * matrix.M22;
            matrix.M22 = s * temp + c * matrix.M22;

            temp = matrix.M13;
            matrix.M13 = c * temp - s * matrix.M23;
            matrix.M23 = s * temp + c * matrix.M23;
        }


        /// <summary>
        /// Возвращает матрицу поворота вокруг произвольной оси.
        /// </summary>
        /// <param name="axis">
        /// Единичкая ось вращения.
        /// </param>
        /// <param name="matrix">
        /// Матрица поворота.
        /// </param>
        /// <param name="angle">
        /// Угол поворота.
        /// </param>
        public static void RotationAxis(out Matrix3x3 matrix, Vector3 axis, double angle)
        {
            double x = axis.X;
            double y = axis.Y;
            double z = axis.Z;
            double c = Math.Cos(angle);
            double s = Math.Sin(angle);
            matrix.M11 = c + (1 - c) * x * x;
            matrix.M12 = (1 - c) * x * y - s * z;
            matrix.M13 = (1 - c) * x * z + s * y;
            matrix.M21 = (1 - c) * y * x + s *z;
            matrix.M22 = c + (1 - c) * y * y;
            matrix.M23 = (1 - c) * y * z - s * x;
            matrix.M31 = (1 - c) * z *x - s * y;
            matrix.M32 = (1 - c) * z * y + s * x;
            matrix.M33 = c + (1 - c) * z * z;
        }


        /// <summary>
        /// Выполняет операцию умножения матриц.
        /// </summary>
        /// <param name="result">
        /// Результат операции.
        /// </param>
        /// <param name="left">
        /// Левый аргумент.
        /// </param>
        /// <param name="right">
        /// Правый аргумент.
        /// </param>
        public static void Multiply(out Matrix3x3 result, ref Matrix3x3 left, Matrix3x3 right)
        {
            double row1, row2, row3;

            row1 = left.M11; row2 = left.M12; row3 = left.M13;
            result.M11 = row1 * right.M11 + row2 * right.M21 + row3 * right.M31;
            result.M12 = row1 * right.M12 + row2 * right.M22 + row3 * right.M32;
            result.M13 = row1 * right.M13 + row2 * right.M23 + row3 * right.M33;

            row1 = left.M21; row2 = left.M22; row3 = left.M23;
            result.M21 = row1 * right.M11 + row2 * right.M21 + row3 * right.M31;
            result.M22 = row1 * right.M12 + row2 * right.M22 + row3 * right.M32;
            result.M23 = row1 * right.M13 + row2 * right.M23 + row3 * right.M33;

            row1 = left.M31; row2 = left.M32; row3 = left.M33;
            result.M31 = row1 * right.M11 + row2 * right.M21 + row3 * right.M31;
            result.M32 = row1 * right.M12 + row2 * right.M22 + row3 * right.M32;
            result.M33 = row1 * right.M13 + row2 * right.M23 + row3 * right.M33;
        }

        /// <summary>
        /// Выполняет преобразование вектора.
        /// </summary>
        /// <param name="vector">
        /// Преобразуемый вектор.
        /// </param>
        public void Transform(ref Vector3 vector)
        {
            double x = vector.X;
            double y = vector.Y;
            double z = vector.Z;

            vector.X = M11 * x + M12 * y + M13 * z;
            vector.Y = M21 * x + M22 * y + M23 * z;
            vector.Z = M31 * x + M32 * y + M33 * z;
        }


        /// <summary>
        /// Выполняет преобразование вектора.
        /// </summary>
        /// <param name="vector">
        /// Преобразуемый вектор.
        /// </param>
        public void TransposedTransform(ref Vector3 vector)
        {
            double x = vector.X;
            double y = vector.Y;
            double z = vector.Z;

            vector.X = M11 * x + M21 * y + M31 * z;
            vector.Y = M12 * x + M22 * y + M32 * z;
            vector.Z = M13 * x + M23 * y + M33 * z;
        }
    }
}
