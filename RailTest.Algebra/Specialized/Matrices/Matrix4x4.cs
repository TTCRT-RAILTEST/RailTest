using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RailTest.Algebra.Specialized
{
    /// <summary>
    /// Представляет матрицу размера 4 x 4.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Matrix4x4
    {
        /// <summary>
        /// Возвращает единичну матриц.
        /// </summary>
        public static Matrix4x4 Identity => new Matrix4x4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);

        /// <summary>
        /// Компонента матрицы, расположенная в первой строке в первом столбце.
        /// </summary>
        public double M11;

        /// <summary>
        /// Компонента матрицы, расположенная во второй строке в первом столбце.
        /// </summary>
        public double M21;

        /// <summary>
        /// Компонента матрицы, расположенная в тертьей строке в первом столбце.
        /// </summary>
        public double M31;

        /// <summary>
        /// Компонента матрицы, расположенная в четвёртой строке в первом столбце.
        /// </summary>
        public double M41;

        /// <summary>
        /// Компонента матрицы, расположенная в первой строке во втором столбце.
        /// </summary>
        public double M12;

        /// <summary>
        /// Компонента матрицы, расположенная во второй строке во втором столбце.
        /// </summary>
        public double M22;

        /// <summary>
        /// Компонента матрицы, расположенная в тертьей строке во втором столбце.
        /// </summary>
        public double M32;

        /// <summary>
        /// Компонента матрицы, расположенная в четвёртой строке во втором столбце.
        /// </summary>
        public double M42;

        /// <summary>
        /// Компонента матрицы, расположенная в первой строке в третьем столбце.
        /// </summary>
        public double M13;

        /// <summary>
        /// Компонента матрицы, расположенная во второй строке в третьем столбце.
        /// </summary>
        public double M23;

        /// <summary>
        /// Компонента матрицы, расположенная в тертьей строке в третьем столбце.
        /// </summary>
        public double M33;

        /// <summary>
        /// Компонента матрицы, расположенная в четвёртой строке в третьем столбце.
        /// </summary>
        public double M43;

        /// <summary>
        /// Компонента матрицы, расположенная в первой строке в четвёртом столбце.
        /// </summary>
        public double M14;

        /// <summary>
        /// Компонента матрицы, расположенная во второй строке в четвёртом столбце.
        /// </summary>
        public double M24;

        /// <summary>
        /// Компонента матрицы, расположенная в тертьей строке в четвёртом столбце.
        /// </summary>
        public double M34;

        /// <summary>
        /// Компонента матрицы, расположенная в четвёртой строке в четвёртом столбце.
        /// </summary>
        public double M44;

        /// <summary>
        /// Инициализирует новый экземпляр.
        /// </summary>
        /// <param name="m11">Компонента матрицы, расположенная в первой строке в первом столбце.</param>
        /// <param name="m12">Компонента матрицы, расположенная в первой строке во втором столбце.</param>
        /// <param name="m13">Компонента матрицы, расположенная в первой строке в третьем столбце.</param>
        /// <param name="m14">Компонента матрицы, расположенная в первой строке в четвёртом столбце.</param>
        /// <param name="m21">Компонента матрицы, расположенная во второй строке в первом столбце.</param>
        /// <param name="m22">Компонента матрицы, расположенная во второй строке во втором столбце.</param>
        /// <param name="m23">Компонента матрицы, расположенная во второй строке в третьем столбце.</param>
        /// <param name="m24">Компонента матрицы, расположенная во второй строке в четвёртом столбце.</param>
        /// <param name="m31">Компонента матрицы, расположенная в тертьей строке в первом столбце.</param>
        /// <param name="m32">Компонента матрицы, расположенная в тертьей строке во втором столбце.</param>
        /// <param name="m33">Компонента матрицы, расположенная в тертьей строке в третьем столбце.</param>
        /// <param name="m34">Компонента матрицы, расположенная в тертьей строке в четвёртом столбце.</param>
        /// <param name="m41">Компонента матрицы, расположенная в четвёртой строке в первом столбце.</param>
        /// <param name="m42">Компонента матрицы, расположенная в четвёртой строке во втором столбце.</param>
        /// <param name="m43">Компонента матрицы, расположенная в четвёртой строке в третьем столбце.</param>
        /// <param name="m44">Компонента матрицы, расположенная в четвёртой строке в четвёртом столбце.</param>
        public Matrix4x4(
            double m11, double m12, double m13, double m14,
            double m21, double m22, double m23, double m24,
            double m31, double m32, double m33, double m34,
            double m41, double m42, double m43, double m44)
        {
            M11 = m11; M12 = m12; M13 = m13; M14 = m14;
            M21 = m21; M22 = m22; M23 = m23; M24 = m24;
            M31 = m31; M32 = m32; M33 = m33; M34 = m34;
            M41 = m41; M42 = m42; M43 = m43; M44 = m44;
        }

        /// <summary>
        /// Возвращает значение, определяющее, является ли текущая матрица единичной.
        /// </summary>
        public bool IsIdentity
        {
            get
            {
                return
                    M11 == 1 && M12 == 0 && M13 == 0 && M14 == 0 &&
                    M21 == 0 && M22 == 1 && M23 == 0 && M24 == 0 &&
                    M31 == 0 && M32 == 0 && M33 == 1 && M34 == 0 &&
                    M41 == 0 && M42 == 0 && M43 == 0 && M44 == 1;
            }
        }

        /// <summary>
        /// Возвращает или задает вектор трансляции данной матрицы.
        /// </summary>
        public Vector3 Translation
        {
            get
            {
                return new Vector3(M14, M24, M34);
            }
            set
            {
                M14 = value.X;
                M24 = value.Y;
                M34 = value.Z;
            }
        }

        /// <summary>
        /// Возвращает определитель матрицы.
        /// </summary>
        public double Determinant
        {
            get
            {
                return ToFloat().GetDeterminant();
            }
        }

        /// <summary>
        /// Выполняет операцию сложения двух матриц.
        /// </summary>
        /// <param name="left">
        /// Левый операнд.
        /// </param>
        /// <param name="right">
        /// Правый операнд.
        /// </param>
        /// <returns>
        /// Результат операции.
        /// </returns>
        public static Matrix4x4 Add(Matrix4x4 left, Matrix4x4 right)
        {
            return new Matrix4x4(
                left.M11 + right.M11, left.M12 + right.M12, left.M13 + right.M13, left.M14 + right.M14,
                left.M21 + right.M21, left.M22 + right.M22, left.M23 + right.M23, left.M24 + right.M24,
                left.M31 + right.M31, left.M32 + right.M32, left.M33 + right.M33, left.M34 + right.M34,
                left.M41 + right.M41, left.M42 + right.M42, left.M43 + right.M43, left.M44 + right.M44);
        }

        /// <summary>
        /// Выполняет операцию вычитания.
        /// </summary>
        /// <param name="left">
        /// Левый операнд.
        /// </param>
        /// <param name="right">
        /// Правый операнд.
        /// </param>
        /// <returns>
        /// Результат операции.
        /// </returns>
        public static Matrix4x4 Subtract(Matrix4x4 left, Matrix4x4 right)
        {
            return new Matrix4x4(
                left.M11 - right.M11, left.M12 - right.M12, left.M13 - right.M13, left.M14 - right.M14,
                left.M21 - right.M21, left.M22 - right.M22, left.M23 - right.M23, left.M24 - right.M24,
                left.M31 - right.M31, left.M32 - right.M32, left.M33 - right.M33, left.M34 - right.M34,
                left.M41 - right.M41, left.M42 - right.M42, left.M43 - right.M43, left.M44 - right.M44);
        }

        /// <summary>
        /// Инициализирует новый экземпляр.
        /// </summary>
        /// <param name="rotation">
        /// Матрица вращения.
        /// </param>
        /// <param name="bias">
        /// Вектор смещения.
        /// </param>
        public Matrix4x4(Matrix3x3 rotation, Vector3 bias) :
            this(
                rotation.M11, rotation.M12, rotation.M13, bias.X,
                rotation.M21, rotation.M22, rotation.M23, bias.Y,
                rotation.M31, rotation.M32, rotation.M33, bias.Z,
                0, 0, 0, 1)
        {

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
        public static void Scaling(out Matrix4x4 matrix, double xFactor, double yFactor, double zFactor)
        {
            matrix.M11 = xFactor; matrix.M12 = 0; matrix.M13 = 0; matrix.M14 = 0;
            matrix.M21 = 0; matrix.M22 = yFactor; matrix.M23 = 0; matrix.M24 = 0;
            matrix.M31 = 0; matrix.M32 = 0; matrix.M33 = zFactor; matrix.M34 = 0;
            matrix.M41 = 0; matrix.M42 = 0; matrix.M43 = 0; matrix.M44 = 1;
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
        public static void ScaleDirect(ref Matrix4x4 matrix, double xFactor, double yFactor, double zFactor)
        {
            matrix.M11 = xFactor * matrix.M11;
            matrix.M12 = xFactor * matrix.M12;
            matrix.M13 = xFactor * matrix.M13;
            matrix.M14 = xFactor * matrix.M14;
            matrix.M21 = yFactor * matrix.M21;
            matrix.M22 = yFactor * matrix.M22;
            matrix.M23 = yFactor * matrix.M23;
            matrix.M24 = yFactor * matrix.M24;
            matrix.M31 = zFactor * matrix.M31;
            matrix.M32 = zFactor * matrix.M32;
            matrix.M33 = zFactor * matrix.M33;
            matrix.M34 = zFactor * matrix.M34;
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
        public static void RotationX(out Matrix4x4 matrix, double angle)
        {
            double c = Math.Cos(angle);
            double s = Math.Sin(angle);
            matrix.M11 = 1; matrix.M12 = 0; matrix.M13 = 0; matrix.M14 = 0;
            matrix.M21 = 0; matrix.M22 = c; matrix.M23 = -s; matrix.M24 = 0;
            matrix.M31 = 0; matrix.M32 = s; matrix.M33 = c; matrix.M34 = 0;
            matrix.M41 = 0; matrix.M42 = 0; matrix.M43 = 0; matrix.M44 = 1;
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
        public static void RotateXDirect(ref Matrix4x4 matrix, double angle)
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

            temp = matrix.M24;
            matrix.M24 = c * temp - s * matrix.M34;
            matrix.M34 = s * temp + c * matrix.M34;
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
        public static void RotationY(out Matrix4x4 matrix, double angle)
        {
            double c = Math.Cos(angle);
            double s = Math.Sin(angle);
            matrix.M11 = c; matrix.M12 = 0; matrix.M13 = s; matrix.M14 = 0;
            matrix.M21 = 0; matrix.M22 = 1; matrix.M23 = 0; matrix.M24 = 0;
            matrix.M31 = -s; matrix.M32 = 0; matrix.M33 = c; matrix.M34 = 0;
            matrix.M41 = 0; matrix.M42 = 0; matrix.M43 = 0; matrix.M44 = 1;
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
        public static void RotateYDirect(ref Matrix4x4 matrix, double angle)
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

            temp = matrix.M14;
            matrix.M14 = c * temp + s * matrix.M34;
            matrix.M34 = c * matrix.M34 - s * temp;
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
        public static void RotationZ(out Matrix4x4 matrix, double angle)
        {
            double c = Math.Cos(angle);
            double s = Math.Sin(angle);
            matrix.M11 = c; matrix.M12 = -s; matrix.M13 = 0; matrix.M14 = 0;
            matrix.M21 = s; matrix.M22 = c; matrix.M23 = 0; matrix.M24 = 0;
            matrix.M31 = 0; matrix.M32 = 0; matrix.M33 = 1; matrix.M34 = 0;
            matrix.M41 = 0; matrix.M42 = 0; matrix.M43 = 0; matrix.M44 = 1;
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
        public static void RotateZDirect(ref Matrix4x4 matrix, double angle)
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

            temp = matrix.M14;
            matrix.M14 = c * temp - s * matrix.M24;
            matrix.M24 = s * temp + c * matrix.M24;
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
        public static void Multiply(out Matrix4x4 result, ref Matrix4x4 left, Matrix4x4 right)
        {
            double row1, row2, row3, row4;

            row1 = left.M11; row2 = left.M12; row3 = left.M13; row4 = left.M14;
            result.M11 = row1 * right.M11 + row2 * right.M21 + row3 * right.M31 + row4 * right.M41;
            result.M12 = row1 * right.M12 + row2 * right.M22 + row3 * right.M32 + row4 * right.M42;
            result.M13 = row1 * right.M13 + row2 * right.M23 + row3 * right.M33 + row4 * right.M43;
            result.M14 = row1 * right.M14 + row2 * right.M24 + row3 * right.M34 + row4 * right.M44;

            row1 = left.M21; row2 = left.M22; row3 = left.M23; row4 = left.M24;
            result.M21 = row1 * right.M11 + row2 * right.M21 + row3 * right.M31 + row4 * right.M41;
            result.M22 = row1 * right.M12 + row2 * right.M22 + row3 * right.M32 + row4 * right.M42;
            result.M23 = row1 * right.M13 + row2 * right.M23 + row3 * right.M33 + row4 * right.M43;
            result.M24 = row1 * right.M14 + row2 * right.M24 + row3 * right.M34 + row4 * right.M44;

            row1 = left.M31; row2 = left.M32; row3 = left.M33; row4 = left.M34;
            result.M31 = row1 * right.M11 + row2 * right.M21 + row3 * right.M31 + row4 * right.M41;
            result.M32 = row1 * right.M12 + row2 * right.M22 + row3 * right.M32 + row4 * right.M42;
            result.M33 = row1 * right.M13 + row2 * right.M23 + row3 * right.M33 + row4 * right.M43;
            result.M34 = row1 * right.M14 + row2 * right.M24 + row3 * right.M34 + row4 * right.M44;

            row1 = left.M41; row2 = left.M42; row3 = left.M43; row4 = left.M44;
            result.M41 = row1 * right.M11 + row2 * right.M21 + row3 * right.M31 + row4 * right.M41;
            result.M42 = row1 * right.M12 + row2 * right.M22 + row3 * right.M32 + row4 * right.M42;
            result.M43 = row1 * right.M13 + row2 * right.M23 + row3 * right.M33 + row4 * right.M43;
            result.M44 = row1 * right.M14 + row2 * right.M24 + row3 * right.M34 + row4 * right.M44;
        }



        ////
        //// Сводка:
        ////     Создает сферический элемент с объявлением, который вращается вокруг заданной
        ////     позиции объекта.
        ////
        //// Параметры:
        ////   objectPosition:
        ////     Позиция объекта, вокруг которой будет вращаться элемент с объявлением.
        ////
        ////   cameraPosition:
        ////     Положение камеры.
        ////
        ////   cameraUpVector:
        ////     Вектор перемещения камеры вверх.
        ////
        ////   cameraForwardVector:
        ////     Вектор перемещения камеры вперед.
        ////
        //// Возврат:
        ////     Созданный элемент с объявлением.
        //public static Matrix4x4 CreateBillboard(Vector3 objectPosition, Vector3 cameraPosition, Vector3 cameraUpVector, Vector3 cameraForwardVector);

        //// Сводка:
        ////     Создает цилиндрический элемент с объявлением, который вращается вокруг заданной
        ////     оси.
        ////
        //// Параметры:
        ////   objectPosition:
        ////     Позиция объекта, вокруг которой будет вращаться элемент с объявлением.
        ////
        ////   cameraPosition:
        ////     Положение камеры.
        ////
        ////   rotateAxis:
        ////     Ось, вокруг которой будет вращаться элемент с объявлением.
        ////
        ////   cameraForwardVector:
        ////     Вектор перемещения камеры вперед.
        ////
        ////   objectForwardVector:
        ////     Вектор перемещения объекта вперед.
        ////
        //// Возврат:
        ////     Матрица элемента с объявлением.
        //public static Matrix4x4 CreateConstrainedBillboard(Vector3 objectPosition, Vector3 cameraPosition, Vector3 rotateAxis, Vector3 cameraForwardVector, Vector3 objectForwardVector);

        //// Сводка:
        ////     Создает матрицу, которая вращается вокруг произвольного вектора.
        ////
        //// Параметры:
        ////   axis:
        ////     Ось вращения.
        ////
        ////   angle:
        ////     Угол поворота вокруг axis (в радианах).
        ////
        //// Возврат:
        ////     Матрица поворота.
        //public static Matrix4x4 CreateFromAxisAngle(Vector3 axis, float angle);

        ////
        //// Сводка:
        ////     Создает матрицу поворота на основе заданного значения поворота кватерниона.
        ////
        //// Параметры:
        ////   quaternion:
        ////     Исходный кватернион.
        ////
        //// Возврат:
        ////     Матрица поворота.
        //public static Matrix4x4 CreateFromQuaternion(Quaternion quaternion);

        ////
        //// Сводка:
        ////     Создает матрицу поворота на основе заданного значения нутации, прецессии и собственного
        ////     вращения.
        ////
        //// Параметры:
        ////   yaw:
        ////     Угол поворота вокруг оси Y (в радианах).
        ////
        ////   pitch:
        ////     Угол поворота вокруг оси X (в радианах).
        ////
        ////   roll:
        ////     Угол поворота вокруг оси Z (в радианах).
        ////
        //// Возврат:
        ////     Матрица поворота.
        //public static Matrix4x4 CreateFromYawPitchRoll(float yaw, float pitch, float roll);

        //// Сводка:
        ////     Создает матрицу просмотра.
        ////
        //// Параметры:
        ////   cameraPosition:
        ////     Положение камеры.
        ////
        ////   cameraTarget:
        ////     Целевой объект, на который указывает камера.
        ////
        ////   cameraUpVector:
        ////     Направление "вверх" с точки зрения камеры.
        ////
        //// Возврат:
        ////     Матрица просмотра.
        //public static Matrix4x4 CreateLookAt(Vector3 cameraPosition, Vector3 cameraTarget, Vector3 cameraUpVector);

        //// Сводка:
        ////     Создает матрицу ортогональной перспективы на основе данных размеров отображаемого
        ////     объема.
        ////
        //// Параметры:
        ////   width:
        ////     Ширина отображаемого объема.
        ////
        ////   height:
        ////     Высота отображаемого объема.
        ////
        ////   zNearPlane:
        ////     Минимальное значение по оси Z отображаемого объема.
        ////
        ////   zFarPlane:
        ////     Максимальное значение по оси Z отображаемого объема.
        ////
        //// Возврат:
        ////     Матрица ортогональной проекции.
        //public static Matrix4x4 CreateOrthographic(float width, float height, float zNearPlane, float zFarPlane);

        //// Сводка:
        ////     Создает настраиваемую матрицу ортогональной проекции.
        ////
        //// Параметры:
        ////   left:
        ////     Минимальное значение по оси X отображаемого объема.
        ////
        ////   right:
        ////     Максимальное значение по оси X отображаемого объема.
        ////
        ////   bottom:
        ////     Минимальное значение по оси Y отображаемого объема.
        ////
        ////   top:
        ////     Максимальное значение по оси Y отображаемого объема.
        ////
        ////   zNearPlane:
        ////     Минимальное значение по оси Z отображаемого объема.
        ////
        ////   zFarPlane:
        ////     Максимальное значение по оси Z отображаемого объема.
        ////
        //// Возврат:
        ////     Матрица ортогональной проекции.
        //public static Matrix4x4 CreateOrthographicOffCenter(float left, float right, float bottom, float top, float zNearPlane, float zFarPlane);

        //// Сводка:
        ////     Создает матрицу перспективы на основе данных размеров отображаемого объема.
        ////
        //// Параметры:
        ////   width:
        ////     Ширина отображаемого объема в ближней плоскости просмотра.
        ////
        ////   height:
        ////     Высота отображаемого объема в ближней плоскости просмотра.
        ////
        ////   nearPlaneDistance:
        ////     Расстояние до ближней плоскости просмотра.
        ////
        ////   farPlaneDistance:
        ////     Расстояние до дальней плоскости просмотра.
        ////
        //// Возврат:
        ////     Матрица перспективы.
        ////
        //// Исключения:
        ////   T:System.ArgumentOutOfRangeException:
        ////     Значение nearPlaneDistance меньше или равно нулю. -или- Значение farPlaneDistance
        ////     меньше или равно нулю. -или- Значение nearPlaneDistance больше или равно farPlaneDistance.
        //public static Matrix4x4 CreatePerspective(float width, float height, float nearPlaneDistance, float farPlaneDistance);

        //// Сводка:
        ////     Создает матрицу перспективы на основе поля зрения, пропорций и расстояния до
        ////     ближней и дальней плоскости просмотра.
        ////
        //// Параметры:
        ////   fieldOfView:
        ////     Поле зрения в направлении Y в радианах.
        ////
        ////   aspectRatio:
        ////     Пропорции, определенные как ширина зрительного пространства, деленная на высоту.
        ////
        ////   nearPlaneDistance:
        ////     Расстояние до ближней плоскости просмотра.
        ////
        ////   farPlaneDistance:
        ////     Расстояние до дальней плоскости просмотра.
        ////
        //// Возврат:
        ////     Матрица перспективы.
        ////
        //// Исключения:
        ////   T:System.ArgumentOutOfRangeException:
        ////     Значение fieldOfView меньше или равно нулю. -или- Значение fieldOfView больше
        ////     или равно System.Math.PI. Значение nearPlaneDistance меньше или равно нулю. -или-
        ////     Значение farPlaneDistance меньше или равно нулю. -или- Значение nearPlaneDistance
        ////     больше или равно farPlaneDistance.
        //public static Matrix4x4 CreatePerspectiveFieldOfView(float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance);

        //// Сводка:
        ////     Создает настраиваемую матрицу перспективы.
        ////
        //// Параметры:
        ////   left:
        ////     Минимальное значение по оси X отображаемого объема в ближней плоскости просмотра.
        ////
        ////   right:
        ////     Максимальное значение по оси X отображаемого объема в ближней плоскости просмотра.
        ////
        ////   bottom:
        ////     Минимальное значение по оси Y отображаемого объема в ближней плоскости просмотра.
        ////
        ////   top:
        ////     Максимальное значение по оси Y отображаемого объема в ближней плоскости просмотра.
        ////
        ////   nearPlaneDistance:
        ////     Расстояние до ближней плоскости просмотра.
        ////
        ////   farPlaneDistance:
        ////     Расстояние до дальней плоскости просмотра.
        ////
        //// Возврат:
        ////     Матрица перспективы.
        ////
        //// Исключения:
        ////   T:System.ArgumentOutOfRangeException:
        ////     Значение nearPlaneDistance меньше или равно нулю. -или- Значение farPlaneDistance
        ////     меньше или равно нулю. -или- Значение nearPlaneDistance больше или равно farPlaneDistance.
        //public static Matrix4x4 CreatePerspectiveOffCenter(float left, float right, float bottom, float top, float nearPlaneDistance, float farPlaneDistance);

        //// Сводка:
        ////     Создает матрицу, отражающую систему координат для указанной плоскости.
        ////
        //// Параметры:
        ////   value:
        ////     Плоскость, для которой будет создано отражение.
        ////
        //// Возврат:
        ////     Новая матрица, выражающая отражение.
        //public static Matrix4x4 CreateReflection(Plane value);

        //// Сводка:
        ////     Создает матрицу для поворота точек вокруг оси X относительно центральной точки.
        ////
        //// Параметры:
        ////   radians:
        ////     Значение поворота вокруг оси X (в радианах).
        ////
        ////   centerPoint:
        ////     Центральная точка.
        ////
        //// Возврат:
        ////     Матрица поворота.
        //public static Matrix4x4 CreateRotationX(float radians, Vector3 centerPoint);

        //// Сводка:
        ////     Создает матрицу для поворота точек вокруг оси X.
        ////
        //// Параметры:
        ////   radians:
        ////     Значение поворота вокруг оси X (в радианах).
        ////
        //// Возврат:
        ////     Матрица поворота.
        //public static Matrix4x4 CreateRotationX(float radians);

        //// Сводка:
        ////     Значение поворота вокруг оси Y относительно центральной точки (в радианах).
        ////
        //// Параметры:
        ////   radians:
        ////     Значение поворота вокруг оси Y (в радианах).
        ////
        ////   centerPoint:
        ////     Центральная точка.
        ////
        //// Возврат:
        ////     Матрица поворота.
        //public static Matrix4x4 CreateRotationY(float radians, Vector3 centerPoint);

        //// Сводка:
        ////     Создает матрицу для поворота точек вокруг оси Y.
        ////
        //// Параметры:
        ////   radians:
        ////     Значение поворота вокруг оси Y (в радианах).
        ////
        //// Возврат:
        ////     Матрица поворота.
        //public static Matrix4x4 CreateRotationY(float radians);

        //// Сводка:
        ////     Создает матрицу для поворота точек вокруг оси Z.
        ////
        //// Параметры:
        ////   radians:
        ////     Значение поворота вокруг оси Z (в радианах).
        ////
        //// Возврат:
        ////     Матрица поворота.
        //public static Matrix4x4 CreateRotationZ(float radians);

        //// Сводка:
        ////     Создает матрицу для поворота точек вокруг оси Z относительно центральной точки.
        ////
        //// Параметры:
        ////   radians:
        ////     Значение поворота вокруг оси Z (в радианах).
        ////
        ////   centerPoint:
        ////     Центральная точка.
        ////
        //// Возврат:
        ////     Матрица поворота.
        //public static Matrix4x4 CreateRotationZ(float radians, Vector3 centerPoint);

        //// Сводка:
        ////     Создает матрицу равномерного масштабирования, выполняющую равномерное масштабирование
        ////     по каждой оси, с центральной точкой.
        ////
        //// Параметры:
        ////   scale:
        ////     Коэффициент равномерного масштабирования.
        ////
        ////   centerPoint:
        ////     Центральная точка.
        ////
        //// Возврат:
        ////     Матрица масштабирования.
        //public static Matrix4x4 CreateScale(float scale, Vector3 centerPoint);

        //// Сводка:
        ////     Создает матрицу равномерного масштабирования, выполняющую равномерное масштабирование
        ////     по каждой оси.
        ////
        //// Параметры:
        ////   scale:
        ////     Коэффициент равномерного масштабирования.
        ////
        //// Возврат:
        ////     Матрица масштабирования.
        //public static Matrix4x4 CreateScale(float scale);

        //// Сводка:
        ////     Создает матрицу масштабирования на основе заданных координат X, Y и Z.
        ////
        //// Параметры:
        ////   xScale:
        ////     Значение для масштабирования по оси X.
        ////
        ////   yScale:
        ////     Значение для масштабирования по оси Y.
        ////
        ////   zScale:
        ////     Значение для масштабирования по оси Z.
        ////
        //// Возврат:
        ////     Матрица масштабирования.
        //public static Matrix4x4 CreateScale(float xScale, float yScale, float zScale);

        //// Сводка:
        ////     Создает матрицу масштабирования с центральной точкой.
        ////
        //// Параметры:
        ////   scales:
        ////     Вектор, который содержит значение масштабирования по каждой оси.
        ////
        ////   centerPoint:
        ////     Центральная точка.
        ////
        //// Возврат:
        ////     Матрица масштабирования.
        //public static Matrix4x4 CreateScale(Vector3 scales, Vector3 centerPoint);

        //// Сводка:
        ////     Создает матрицу масштабирования на основе заданного масштаба вектора.
        ////
        //// Параметры:
        ////   scales:
        ////     Используемый масштаб.
        ////
        //// Возврат:
        ////     Матрица масштабирования.
        //public static Matrix4x4 CreateScale(Vector3 scales);

        //// Сводка:
        ////     Создает матрицу масштабирования со смещением на заданную центральную точку.
        ////
        //// Параметры:
        ////   xScale:
        ////     Значение для масштабирования по оси X.
        ////
        ////   yScale:
        ////     Значение для масштабирования по оси Y.
        ////
        ////   zScale:
        ////     Значение для масштабирования по оси Z.
        ////
        ////   centerPoint:
        ////     Центральная точка.
        ////
        //// Возврат:
        ////     Матрица масштабирования.
        //public static Matrix4x4 CreateScale(float xScale, float yScale, float zScale, Vector3 centerPoint);

        //// Сводка:
        ////     Создает матрицу, которая создает проекцию геометрической фигуры на указанной
        ////     плоскости подобно отбрасыванию тени от указанного источника света.
        ////
        //// Параметры:
        ////   lightDirection:
        ////     Направление, из которого поступает свет, отбрасывающий тень.
        ////
        ////   plane:
        ////     Плоскость, на которой новая матрица должна создать проекцию геометрической фигуры,
        ////     подобную отбрасыванию тени.
        ////
        //// Возврат:
        ////     Новая матрица, которую можно использовать для создания проекции геометрической
        ////     фигуры на указанной плоскости из заданного направления.
        //public static Matrix4x4 CreateShadow(Vector3 lightDirection, Plane plane);

        ///// <summary>
        ///// Создает матрицу трансляции на основе заданных компонент.
        ///// </summary>
        ///// <param name="x">
        ///// Первая компонента вектора трансляции.
        ///// </param>
        ///// <param name="y">
        ///// Вторая компонента вектора трансляции.
        ///// </param>
        ///// <param name="z">
        ///// Третья компонента вектора трансляции.
        ///// </param>
        ///// <returns>
        ///// Матрица трансляции.
        ///// </returns>
        //public static Matrix4x4 CreateTranslation(double x, double y, double z)
        //{
        //    return new Matrix4x4(
        //        1, 0, 0, x,
        //        0, 1, 0, y,
        //        0, 0, 1, z,
        //        0, 0, 0, 1);
        //}

        ///// <summary>
        ///// Создает матрицу трансляции на основе заданного трехмерного вектора.
        ///// </summary>
        ///// <param name="translation">
        ///// Вектор трансляции.
        ///// </param>
        ///// <returns>
        ///// Матрица трансляции.
        ///// </returns>
        //public static Matrix4x4 CreateTranslation(Vector3 translation)
        //{
        //    return new Matrix4x4(
        //        1, 0, 0, translation.X,
        //        0, 1, 0, translation.Y,
        //        0, 0, 1, translation.Z,
        //        0, 0, 0, 1);
        //}


        ////
        //// Сводка:
        ////     Создает мировую матрицу с заданными параметрами.
        ////
        //// Параметры:
        ////   position:
        ////     Позиция объекта.
        ////
        ////   forward:
        ////     Направление вперед объекта.
        ////
        ////   up:
        ////     Направление вверх объекта. Его значение обычно равно [0, 1, 0].
        ////
        //// Возврат:
        ////     Мировая матрица.
        //public static Matrix4x4 CreateWorld(Vector3 position, Vector3 forward, Vector3 up);
        ////
        //// Сводка:
        ////     Пытается извлечь координаты масштаба, трансляции и поворота на основе данной
        ////     матрицы масштабирования, поворота или трансляции. Возвращаемое значение указывает,
        ////     успешно ли выполнена операция.
        ////
        //// Параметры:
        ////   matrix:
        ////     Исходная матрица.
        ////
        ////   scale:
        ////     В качестве возвращаемого значения этот метод содержит координату масштабирования
        ////     матрицы преобразования, если операция выполнена успешно.
        ////
        ////   rotation:
        ////     В качестве возвращаемого значения этот метод содержит координату поворота матрицы
        ////     преобразования, если операция выполнена успешно.
        ////
        ////   translation:
        ////     В качестве возвращаемого значения этот метод содержит координату трансляции матрицы
        ////     трансляции, если операция выполнена успешно.
        ////
        //// Возврат:
        ////     Значение true, если объект matrix успешно разложен; в противном случае — значение
        ////     false.
        //public static bool Decompose(Matrix4x4 matrix, out Vector3 scale, out Quaternion rotation, out Vector3 translation);
        ////
        //// Сводка:
        ////     Инвертирует заданную матрицу. Возвращаемое значение указывает, успешно ли выполнена
        ////     операция.
        ////
        //// Параметры:
        ////   matrix:
        ////     Инвертируемая матрица.
        ////
        ////   result:
        ////     В качестве возвращаемого значения этот метод содержит инвертированную матрицу,
        ////     если операция выполнена успешно.
        ////
        //// Возврат:
        ////     Значение true, если параметр matrix успешно преобразован; в противном случае
        ////     — значение false.
        //public static bool Invert(Matrix4x4 matrix, out Matrix4x4 result);
        ////
        //// Сводка:
        ////     Выполняет линейную интерполяцию из одной матрицы во вторую матрицу на основе
        ////     значения, указывающего взвешивание второй матрицы.
        ////
        //// Параметры:
        ////   matrix1:
        ////     Первая матрица.
        ////
        ////   matrix2:
        ////     Вторая матрица.
        ////
        ////   amount:
        ////     Относительное взвешивание матрицы matrix2.
        ////
        //// Возврат:
        ////     Интерполированная матрица.
        //public static Matrix4x4 Lerp(Matrix4x4 matrix1, Matrix4x4 matrix2, float amount);
        ////
        //// Сводка:
        ////     Возвращает матрицу, получаемую в результате масштабирования всех элементов заданной
        ////     матрицы на скалярный множитель.
        ////
        //// Параметры:
        ////   value1:
        ////     Масштабируемая матрица.
        ////
        ////   value2:
        ////     Используемое значение масштабирования.
        ////
        //// Возврат:
        ////     Масштабированная матрица.
        //public static Matrix4x4 Multiply(Matrix4x4 value1, float value2);
        ////
        //// Сводка:
        ////     Возвращает матрицу, полученную в результате перемножения двух матриц.
        ////
        //// Параметры:
        ////   value1:
        ////     Первая матрица.
        ////
        ////   value2:
        ////     Вторая матрица.
        ////
        //// Возврат:
        ////     Матрица произведения.
        //public static Matrix4x4 Multiply(Matrix4x4 value1, Matrix4x4 value2);
        ////
        //// Сводка:
        ////     Преобразует заданную матрицу в отрицательную, умножая все ее значения на "-1".
        ////
        //// Параметры:
        ////   value:
        ////     Матрица, преобразуемая в отрицательную.
        ////
        //// Возврат:
        ////     Матрица, преобразованная в отрицательную.
        //public static Matrix4x4 Negate(Matrix4x4 value);
        ////
        //// Сводка:
        ////     Преобразует заданную матрицу, применяя указанный поворот кватерниона.
        ////
        //// Параметры:
        ////   value:
        ////     Преобразуемая матрица.
        ////
        ////   rotation:
        ////     Применяемый поворот.
        ////
        //// Возврат:
        ////     Преобразованная матрица.
        //public static Matrix4x4 Transform(Matrix4x4 value, Quaternion rotation);
        ////
        //// Сводка:
        ////     Переставляет строки и столбцы матрицы.
        ////
        //// Параметры:
        ////   matrix:
        ////     Преобразуемая матрица.
        ////
        //// Возврат:
        ////     Преобразованная матрица.
        //public static Matrix4x4 Transpose(Matrix4x4 matrix);
        ////
        //// Сводка:
        ////     Возвращает значение, указывающее, равен ли данный экземпляр другой матрице 4x4.
        ////
        //// Параметры:
        ////   other:
        ////     Другая матрица.
        ////
        //// Возврат:
        ////     Значение true, если две матрицы равны; в противном случае — значение false.
        //public bool Equals(Matrix4x4 other);
        ////
        //// Сводка:
        ////     Возвращает значение, указывающее, равен ли данный экземпляр указанному объекту.
        ////
        //// Параметры:
        ////   obj:
        ////     Объект для сравнения с текущим экземпляром.
        ////
        //// Возврат:
        ////     Значение true, если объект obj равен текущему экземпляру; в противном случае
        ////     — значение false. Если значением параметра obj является null, метод возвращает
        ////     false.
        //public override bool Equals(object obj);
        ////
        //// Сводка:
        ////     Возвращает хэш-код данного экземпляра.
        ////
        //// Возврат:
        ////     Хэш-код.
        //public override int GetHashCode();
        ////
        //// Сводка:
        ////     Возвращает строку, представляющую данную матрицу.
        ////
        //// Возврат:
        ////     Строковое представление данной матрицы.
        //public override string ToString();

        ////
        //// Сводка:
        ////     Складывает каждый элемент в одной матрице с соответствующим элементом во второй
        ////     матрице.
        ////
        //// Параметры:
        ////   value1:
        ////     Первая матрица.
        ////
        ////   value2:
        ////     Вторая матрица.
        ////
        //// Возврат:
        ////     Матрица, содержащая суммарные значения.
        //public static Matrix4x4 operator +(Matrix4x4 value1, Matrix4x4 value2);
        ////
        //// Сводка:
        ////     Преобразует заданную матрицу в отрицательную, умножая все ее значения на "-1".
        ////
        //// Параметры:
        ////   value:
        ////     Матрица, преобразуемая в отрицательную.
        ////
        //// Возврат:
        ////     Матрица, преобразованная в отрицательную.
        //public static Matrix4x4 operator -(Matrix4x4 value);
        ////
        //// Сводка:
        ////     Вычитает каждый элемент во второй матрице из соответствующего элемента в первой
        ////     матрице.
        ////
        //// Параметры:
        ////   value1:
        ////     Первая матрица.
        ////
        ////   value2:
        ////     Вторая матрица.
        ////
        //// Возврат:
        ////     Матрица, содержащая значения, которые являются результатом вычитания каждого
        ////     элемента в value2 из соответствующего элемента в value1.
        //public static Matrix4x4 operator -(Matrix4x4 value1, Matrix4x4 value2);
        ////
        //// Сводка:
        ////     Возвращает матрицу, полученную в результате перемножения двух матриц.
        ////
        //// Параметры:
        ////   value1:
        ////     Первая матрица.
        ////
        ////   value2:
        ////     Вторая матрица.
        ////
        //// Возврат:
        ////     Матрица произведения.
        //public static Matrix4x4 operator *(Matrix4x4 value1, Matrix4x4 value2);
        ////
        //// Сводка:
        ////     Возвращает матрицу, получаемую в результате масштабирования всех элементов заданной
        ////     матрицы на скалярный множитель.
        ////
        //// Параметры:
        ////   value1:
        ////     Масштабируемая матрица.
        ////
        ////   value2:
        ////     Используемое значение масштабирования.
        ////
        //// Возврат:
        ////     Масштабированная матрица.
        //public static Matrix4x4 operator *(Matrix4x4 value1, float value2);

        ////
        //// Сводка:
        ////     Возвращает значение, указывающее на равенство заданных матриц.
        ////
        //// Параметры:
        ////   value1:
        ////     Первая матрица для сравнения.
        ////
        ////   value2:
        ////     Вторая матрица для сравнения.
        ////
        //// Возврат:
        ////     Значение true, если value1 и value2 равны; в противном случае — значение false.
        //public static bool operator ==(Matrix4x4 value1, Matrix4x4 value2);

        ////
        //// Сводка:
        ////     Возвращает значение, указывающее на неравенство заданных матриц.
        ////
        //// Параметры:
        ////   value1:
        ////     Первая матрица для сравнения.
        ////
        ////   value2:
        ////     Вторая матрица для сравнения.
        ////
        //// Возврат:
        ////     Значение true, если value1 и value2 не равны друг другу; в противном случае —
        ////     значение false.
        //public static bool operator !=(Matrix4x4 value1, Matrix4x4 value2);



        private System.Numerics.Matrix4x4 ToFloat()
        {
            return new System.Numerics.Matrix4x4(
                (float)M11, (float)M12, (float)M13, (float)M14,
                (float)M21, (float)M22, (float)M23, (float)M24,
                (float)M31, (float)M32, (float)M33, (float)M34,
                (float)M41, (float)M42, (float)M43, (float)M44);
        }
    }
}
