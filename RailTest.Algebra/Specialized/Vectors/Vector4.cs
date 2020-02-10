using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RailTest.Algebra.Specialized
{
    /// <summary>
    /// Представляет четырёхмерный вектор.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector4
    {
        /// <summary>
        /// Возвращает вектор, все компоненты которого равны нулю.
        /// </summary>
        public static Vector4 Zero => new Vector4(0, 0, 0, 0);

        /// <summary>
        /// Возвращает вектор (1, 0, 0, 0).
        /// </summary>
        public static Vector4 UnitX => new Vector4(1, 0, 0, 0);

        /// <summary>
        /// Возвращает вектор (0, 1, 0, 0).
        /// </summary>
        public static Vector4 UnitY => new Vector4(0, 1, 0, 0);

        /// <summary>
        /// Возвращает вектор (0, 0, 1, 0).
        /// </summary>
        public static Vector4 UnitZ => new Vector4(0, 0, 1, 0);

        /// <summary>
        /// Возвращает вектор (0, 0, 0, 1).
        /// </summary>
        public static Vector4 UnitW => new Vector4(0, 0, 0, 1);

        /// <summary>
        /// Первая компонента вектора.
        /// </summary>
        public double X;

        /// <summary>
        /// Вторая компонента вектора.
        /// </summary>
        public double Y;

        /// <summary>
        /// Третья компонента вектора.
        /// </summary>
        public double Z;

        /// <summary>
        /// Четвёртая компонента вектора.
        /// </summary>
        public double W;

        /// <summary>
        /// Инициализирует новый экземпляр.
        /// </summary>
        /// <param name="value">
        /// Вектор, содержащий первую, вторую и трерью компоненты.
        /// </param>
        /// <param name="w">
        /// Четвёртая компонента вектора.
        /// </param>
        public Vector4(Vector3 value, double w)
        {
            X = value.X;
            Y = value.Y;
            Z = value.Z;
            W = w;
        }

        /// <summary>
        /// Инициализирует новый экземпляр.
        /// </summary>
        /// <param name="value">
        /// Вектор, содержащий первую и вторую компоненты.
        /// </param>
        /// <param name="z">
        /// Третья компонента вектора.
        /// </param>
        /// <param name="w">
        /// Четвёртая компонента вектора.
        /// </param>
        public Vector4(Vector2 value, double z, double w)
        {
            X = value.X;
            Y = value.Y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Инициализирует новый экземпляр.
        /// </summary>
        /// <param name="x">
        /// Первая компонента вектора.
        /// </param>
        /// <param name="y">
        /// Вторая компонента вектора.
        /// </param>
        /// <param name="z">
        /// Третья компонента вектора.
        /// </param>
        /// <param name="w">
        /// Четвёртая компонента вектора.
        /// </param>
        public Vector4(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        /// <summary>
        /// Возвращает длину вектора.
        /// </summary>
        public double Length
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y + Z * Z + W * W);
            }
        }

        /// <summary>
        /// Возвращает квадрат длины вектора.
        /// </summary>
        public double LengthSquared
        {
            get
            {
                return X * X + Y * Y + Z * Z + W * W;
            }
        }

        /// <summary>
        /// Возвращает противоположный вектор.
        /// </summary>
        /// <param name="value">
        /// Исходный вектор.
        /// </param>
        /// <returns>
        /// Противоположный вектор.
        /// </returns>
        public static Vector4 Negate(Vector4 value)
        {
            return new Vector4(-value.X, -value.Y, -value.Z, -value.W);
        }

        /// <summary>
        /// Выполняет операцию сложения двух векторов.
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
        public static Vector4 Add(Vector4 left, Vector4 right)
        {
            return new Vector4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
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
        public static Vector4 Subtract(Vector4 left, Vector4 right)
        {
            return new Vector4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
        }

        /// <summary>
        /// Выполняет операцию умножения скаляра на вектор.
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
        public static Vector4 Multiply(double left, Vector4 right)
        {
            return new Vector4(left * right.X, left * right.Y, left * right.Z, left * right.W);
        }

        /// <summary>
        /// Выполняет операцию умножения вектора на скаляр.
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
        public static Vector4 Multiply(Vector4 left, double right)
        {
            return new Vector4(left.X * right, left.Y * right, left.Z * right, left.W * right);
        }

        /// <summary>
        /// Делит заданный вектор на указанное скалярное значение.
        /// </summary>
        /// <param name="value">
        /// Вектор.
        /// </param>
        /// <param name="divisor">
        /// Скалярное значение.
        /// </param>
        /// <returns>
        /// Вектор, полученный в результате деления.
        /// </returns>
        /// <exception cref="ArithmeticException">
        /// В параметре <paramref name="divisor"/> передано отрицательное значение.
        /// </exception>
        public static Vector4 Divide(Vector4 value, double divisor)
        {
            if (divisor == 0)
            {
                throw new ArithmeticException("Делитель равен нулю.");
            }
            double factor = 1 / divisor;
            return new Vector4(value.X * factor, value.Y * factor, value.Z * factor, value.W * factor);
        }

        /// <summary>
        /// Выполняет операцию скалярного произведения.
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
        public static double Dot(Vector4 left, Vector4 right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W;
        }

        /// <summary>
        /// Возвращает вектор с тем же направлением, что и заданный вектор, но с длиной равной единице.
        /// </summary>
        /// <param name="value">
        /// Нормализуемый вектор.
        /// </param>
        /// <returns>
        /// Нормализованный вектор.
        /// </returns>
        /// <exception cref="ArithmeticException">
        /// В параметре <paramref name="value"/> передан вектор равный нулю.
        /// </exception>
        public static Vector4 Normalize(Vector4 value)
        {
            double factor = value.X * value.X + value.Y * value.Y + value.Z * value.Z;
            if (factor == 0)
            {
                throw new ArithmeticException("Вектор равен нулю.");
            }
            factor = 1 / Math.Sqrt(factor);
            return new Vector4(value.X * factor, value.Y * factor, value.Z * factor, value.W * factor);
        }

        /// <summary>
        /// Вычисляет евклидово расстояние между двумя заданными точками.
        /// </summary>
        /// <param name="first">
        /// Радиус-вектор первой точки.
        /// </param>
        /// <param name="second">
        /// Радиус-вектор второй точки.
        /// </param>
        /// <returns>
        /// Расстояние между точками.
        /// </returns>
        public static double Distance(Vector4 first, Vector4 second)
        {
            double x = first.X - second.X;
            double y = first.Y - second.Y;
            double z = first.Z - second.Z;
            double w = first.W - second.W;
            return Math.Sqrt(x * x + y * y + z * z + w * w);
        }

        /// <summary>
        /// Возвращает квадрат евклидова расстояния между двумя заданными точками.
        /// </summary>
        /// <param name="first">
        /// Радиус-вектор первой точки.
        /// </param>
        /// <param name="second">
        /// Радиус-вектор второй точки.
        /// </param>
        /// <returns>
        /// Квадрат расстояния между точками.
        /// </returns>
        public static double DistanceSquared(Vector4 first, Vector4 second)
        {
            double x = first.X - second.X;
            double y = first.Y - second.Y;
            double z = first.Z - second.Z;
            double w = first.W - second.W;
            return x * x + y * y + z * z + w * w;
        }

        /// <summary>
        /// Выполняет операцию проверки на равенство двух векторов.
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
        public static bool operator ==(Vector4 left, Vector4 right)
        {
            return left.X == right.X && left.Y == right.Y && left.Z == right.Z && left.W == right.W;
        }

        /// <summary>
        /// Выполняет операцию проверки на неравенство двух векторов.
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
        public static bool operator !=(Vector4 left, Vector4 right)
        {
            return left.X != right.X || left.Y != right.Y || left.Z != right.Z || left.W != right.W;
        }

        /// <summary>
        /// Возвращает противоположный вектор.
        /// </summary>
        /// <param name="value">
        /// Исходный вектор.
        /// </param>
        /// <returns>
        /// Противоположный вектор.
        /// </returns>
        public static Vector4 operator -(Vector4 value)
        {
            return new Vector4(-value.X, -value.Y, -value.Z, -value.W);
        }

        /// <summary>
        /// Выполняет операцию сложения двух векторов.
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
        public static Vector4 operator +(Vector4 left, Vector4 right)
        {
            return new Vector4(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W);
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
        public static Vector4 operator -(Vector4 left, Vector4 right)
        {
            return new Vector4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
        }

        /// <summary>
        /// Выполняет операцию умножения скаляра на вектор.
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
        public static Vector4 operator *(double left, Vector4 right)
        {
            return new Vector4(left * right.X, left * right.Y, left * right.Z, left * right.W);
        }

        /// <summary>
        /// Выполняет операцию умножения вектора на скаляр.
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
        public static Vector4 operator *(Vector4 left, double right)
        {
            return new Vector4(left.X * right, left.Y * right, left.Z * right, left.W * right);
        }

        /// <summary>
        /// Делит заданный вектор на указанное скалярное значение.
        /// </summary>
        /// <param name="value">
        /// Вектор.
        /// </param>
        /// <param name="divisor">
        /// Скалярное значение.
        /// </param>
        /// <returns>
        /// Вектор, полученный в результате деления.
        /// </returns>
        /// <exception cref="ArithmeticException">
        /// В параметре <paramref name="divisor"/> передано значение, равное нулю.
        /// </exception>
        public static Vector4 operator /(Vector4 value, double divisor)
        {
            if (divisor == 0)
            {
                throw new ArithmeticException("Делитель равен нулю.");
            }
            double factor = 1 / divisor;
            return new Vector4(value.X * factor, value.Y * factor, value.Z * factor, value.W * factor);
        }

        /// <summary>
        /// Возвращает значение, указывающее, равен ли данный экземпляр указанному объекту.
        /// </summary>
        /// <param name="obj">
        /// Объект для сравнения с текущим экземпляром.
        /// </param>
        /// <returns>
        /// Значение true, если <paramref name="obj"/> равен текущему экземпляру;
        /// в противном случае - значение false.
        /// Если в параметре <paramref name="obj"/> передана пустая ссылка, метод возвращает false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector4 other)
            {
                return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
            }
            return false;
        }

        /// <summary>
        /// Возвращает значение, указывающее, равен ли данный экземпляр другому вектору.
        /// </summary>
        /// <param name="other">
        /// Другой вектор.
        /// </param>
        /// <returns>
        /// Значение true, если два вектора равны; в противном случае - значение false.
        /// </returns>
        public bool Equals(Vector4 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
        }

        /// <summary>
        /// Возвращает хэш-код данного экземпляра.
        /// </summary>
        /// <returns>
        /// Хэш-код.
        /// </returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode() ^ W.GetHashCode();
        }

        /// <summary>
        /// Возвращает строковое представление текущего экземпляра.
        /// </summary>
        /// <returns>
        /// Строковое представление текущего экземпляра.
        /// </returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder("(");
            result.Append(X);
            result.Append(", ");
            result.Append(Y);
            result.Append(", ");
            result.Append(Z);
            result.Append(", ");
            result.Append(W);
            result.Append(")");
            return result.ToString();
        }
    }
}
