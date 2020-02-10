using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RailTest.Algebra.Specialized
{
    /// <summary>
    /// Представляет трёхмерный вектор.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector3
    {
        /// <summary>
        /// Возвращает вектор, все компоненты которого равны нулю.
        /// </summary>
        public static Vector3 Zero => new Vector3(0, 0, 0);

        /// <summary>
        /// Возвращает вектор (1, 0, 0).
        /// </summary>
        public static Vector3 UnitX => new Vector3(1, 0, 0);

        /// <summary>
        /// Возвращает вектор (0, 1, 0).
        /// </summary>
        public static Vector3 UnitY => new Vector3(0, 1, 0);

        /// <summary>
        /// Возвращает вектор (0, 0, 1).
        /// </summary>
        public static Vector3 UnitZ => new Vector3(0, 0, 1);

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
        /// Инициализирует новый экземпляр.
        /// </summary>
        /// <param name="value">
        /// Вектор, содержащий первую и вторую компоненты.
        /// </param>
        /// <param name="z">
        /// Третья компонента вектора.
        /// </param>
        public Vector3(Vector2 value, double z)
        {
            X = value.X;
            Y = value.Y;
            Z = z;
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
        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Возвращает длину вектора.
        /// </summary>
        public double Length
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y + Z * Z);
            }
        }

        /// <summary>
        /// Возвращает квадрат длины вектора.
        /// </summary>
        public double LengthSquared
        {
            get
            {
                return X * X + Y * Y + Z * Z;
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
        public static Vector3 Negate(Vector3 value)
        {
            return new Vector3(-value.X, -value.Y, -value.Z);
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
        public static Vector3 Add(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
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
        public static Vector3 Subtract(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
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
        public static Vector3 Multiply(double left, Vector3 right)
        {
            return new Vector3(left * right.X, left * right.Y, left * right.Z);
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
        public static Vector3 Multiply(Vector3 left, double right)
        {
            return new Vector3(left.X * right, left.Y * right, left.Z * right);
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
        public static Vector3 Divide(Vector3 value, double divisor)
        {
            if (divisor == 0)
            {
                throw new ArithmeticException("Делитель равен нулю.");
            }
            double factor = 1 / divisor;
            return new Vector3(value.X * factor, value.Y * factor, value.Z * factor);
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
        public static double Dot(Vector3 left, Vector3 right)
        {
            return left.X * right.X + left.Y * right.Y + left.Z * right.Z;
        }

        /// <summary>
        /// Вычисляет векторное произведение двух векторов.
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
        public static Vector3 Cross(Vector3 left, Vector3 right)
        {
            return new Vector3(
                left.Y * right.Z - left.Z * right.Y,
                left.Z * right.X - left.X * right.Z,
                left.X * right.Y - left.Y * right.X);
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
        public static Vector3 Normalize(Vector3 value)
        {
            double factor = value.X * value.X + value.Y * value.Y + value.Z * value.Z;
            if (factor == 0)
            {
                throw new ArithmeticException("Вектор равен нулю.");
            }
            factor = 1 / Math.Sqrt(factor);
            return new Vector3(value.X * factor, value.Y * factor, value.Z * factor);
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
        public static double Distance(Vector3 first, Vector3 second)
        {
            double x = first.X - second.X;
            double y = first.Y - second.Y;
            double z = first.Z - second.Z;
            return Math.Sqrt(x * x + y * y + z * z);
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
        public static double DistanceSquared(Vector3 first, Vector3 second)
        {
            double x = first.X - second.X;
            double y = first.Y - second.Y;
            double z = first.Z - second.Z;
            return x * x + y * y + z * z;
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
        public static bool operator ==(Vector3 left, Vector3 right)
        {
            return left.X == right.X && left.Y == right.Y && left.Z == right.Z;
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
        public static bool operator !=(Vector3 left, Vector3 right)
        {
            return left.X != right.X || left.Y != right.Y || left.Z != right.Z;
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
        public static Vector3 operator -(Vector3 value)
        {
            return new Vector3(-value.X, -value.Y, -value.Z);
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
        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
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
        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
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
        public static Vector3 operator *(double left, Vector3 right)
        {
            return new Vector3(left * right.X, left * right.Y, left * right.Z);
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
        public static Vector3 operator *(Vector3 left, double right)
        {
            return new Vector3(left.X * right, left.Y * right, left.Z * right);
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
        public static Vector3 operator /(Vector3 value, double divisor)
        {
            if (divisor == 0)
            {
                throw new ArithmeticException("Делитель равен нулю.");
            }
            double factor = 1 / divisor;
            return new Vector3(value.X * factor, value.Y * factor, value.Z * factor);
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
            if (obj is Vector3 other)
            {
                return X == other.X && Y == other.Y && Z == other.Z;
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
        public bool Equals(Vector3 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        /// <summary>
        /// Возвращает хэш-код данного экземпляра.
        /// </summary>
        /// <returns>
        /// Хэш-код.
        /// </returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
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
            result.Append(")");
            return result.ToString();
        }
    }
}
