﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RailTest.Algebra.Specialized
{
    /// <summary>
    /// Представляет двумерный вектор.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector2
    {
        /// <summary>
        /// Возвращает вектор, все компоненты которого равны нулю.
        /// </summary>
        /// <example>
        /// <code language="cs">
        /// Vector2D vector = Vector2D.Zero;
        /// </code>
        /// </example>
        public static Vector2 Zero => new Vector2(0, 0);

        /// <summary>
        /// Возвращает вектор (1, 0).
        /// </summary>
        /// <example>
        /// <code language="cs">
        /// Vector2D vector = Vector2D.UnitX;
        /// </code>
        /// </example>
        public static Vector2 UnitX => new Vector2(1, 0);

        /// <summary>
        /// Возвращает вектор (0, 1).
        /// </summary>
        /// <example>
        /// <code language="cs">
        /// Vector2D vector = Vector2D.UnitY;
        /// </code>
        /// </example>
        public static Vector2 UnitY => new Vector2(0, 1);

        /// <summary>
        /// Первая компонента вектора.
        /// </summary>
        public double X;

        /// <summary>
        /// Вторая компонента вектора.
        /// </summary>
        public double Y;

        /// <summary>
        /// Инициализирует новый экземпляр.
        /// </summary>
        /// <param name="x">
        /// Первая компонента вектора.
        /// </param>
        /// <param name="y">
        /// Вторая компонента вектора.
        /// </param>
        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Возвращает длину вектора.
        /// </summary>
        public double Length
        {
            get
            {
                return Math.Sqrt(X * X + Y * Y);
            }
        }

        /// <summary>
        /// Возвращает квадрат длины вектора.
        /// </summary>
        public double LengthSquared
        {
            get
            {
                return X * X + Y * Y;
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
        public static Vector2 Negate(Vector2 value)
        {
            return new Vector2(-value.X, -value.Y);
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
        public static Vector2 Add(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X + right.X, left.Y + right.Y);
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
        public static Vector2 Subtract(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X - right.X, left.Y - right.Y);
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
        public static Vector2 Multiply(double left, Vector2 right)
        {
            return new Vector2(left * right.X, left * right.Y);
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
        public static Vector2 Multiply(Vector2 left, double right)
        {
            return new Vector2(left.X * right, left.Y * right);
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
        public static Vector2 Divide(Vector2 value, double divisor)
        {
            if (divisor == 0)
            {
                throw new ArithmeticException("Делитель равен нулю.");
            }
            double factor = 1 / divisor;
            return new Vector2(value.X * factor, value.Y * factor);
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
        public static double Dot(Vector2 left, Vector2 right)
        {
            return left.X * right.X + left.Y * right.Y;
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
        public static Vector2 Normalize(Vector2 value)
        {
            double factor = value.X * value.X + value.Y * value.Y;
            if (factor == 0)
            {
                throw new ArithmeticException("Вектор равен нулю.");
            }
            factor = 1 / Math.Sqrt(factor);
            return new Vector2(value.X * factor, value.Y * factor);
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
        public static double Distance(Vector2 first, Vector2 second)
        {
            double x = first.X - second.X;
            double y = first.Y - second.Y;
            return Math.Sqrt(x * x + y * y);
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
        public static double DistanceSquared(Vector2 first, Vector2 second)
        {
            double x = first.X - second.X;
            double y = first.Y - second.Y;
            return x * x + y * y;
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
        public static bool operator ==(Vector2 left, Vector2 right)
        {
            return left.X == right.X && left.Y == right.Y;
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
        public static bool operator !=(Vector2 left, Vector2 right)
        {
            return left.X != right.X || left.Y != right.Y;
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
        public static Vector2 operator -(Vector2 value)
        {
            return new Vector2(-value.X, -value.Y);
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
        public static Vector2 operator +(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X + right.X, left.Y + right.Y);
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
        public static Vector2 operator -(Vector2 left, Vector2 right)
        {
            return new Vector2(left.X - right.X, left.Y - right.Y);
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
        public static Vector2 operator *(double left, Vector2 right)
        {
            return new Vector2(left * right.X, left * right.Y);
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
        public static Vector2 operator *(Vector2 left, double right)
        {
            return new Vector2(left.X * right, left.Y * right);
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
        public static Vector2 operator /(Vector2 value, double divisor)
        {
            if (divisor == 0)
            {
                throw new ArithmeticException("Делитель равен нулю.");
            }
            double factor = 1 / divisor;
            return new Vector2(value.X * factor, value.Y * factor);
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
            if (obj is Vector2 other)
            {
                return X == other.X && Y == other.Y;
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
        public bool Equals(Vector2 other)
        {
            return X == other.X && Y == other.Y;
        }

        /// <summary>
        /// Возвращает хэш-код данного экземпляра.
        /// </summary>
        /// <returns>
        /// Хэш-код.
        /// </returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
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
            result.Append(")");
            return result.ToString();
        }
    }
}
