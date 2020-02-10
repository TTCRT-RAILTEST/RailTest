using System;

namespace RailTest.Algebra
{
    /// <summary>
    /// Представляет матрицу с действительными значениями.
    /// </summary>
    public unsafe class RealMatrix : Matrix
    {
        /// <summary>
        /// Поле для хранения указателя на область памяти, в которой расположены элементы вектора.
        /// </summary>
        private readonly double* _Items;

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="rowsCount">
        /// Количество строк.
        /// </param>
        /// <param name="columnsCount">
        /// Количество столбцов.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>В параметре <paramref name="rowsCount"/> передано отрицательное значение.</para>
        /// <para>- или -</para>
        /// <para>В параметре <paramref name="columnsCount"/> передано отрицательное значение.</para>
        /// </exception>
        /// <exception cref="OutOfMemoryException">
        /// Недостаточно памяти для выполнения запроса.
        /// </exception>
        public RealMatrix(int rowsCount, int columnsCount) :
            base(sizeof(double), rowsCount, columnsCount)
        {
            _Items = (double*)Pointer.ToPointer();
        }

        /// <summary>
        /// Возвращает или задаёт значение по указанному индексу.
        /// </summary>
        /// <param name="row">
        /// Отсчитываемый от нуля индекс строки.
        /// </param>
        /// <param name="column">
        /// Отсчитываемый от нуля индекс столбца.
        /// </param>
        /// <returns>
        /// Значение.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>В параметре <paramref name="row"/> передано отрицательное значение.</para>
        /// <para>- или -</para>
        /// <para>В параметре <paramref name="row"/> передано означение, большее или равное <see cref="Matrix.RowsCount"/>.</para>
        /// <para>- или -</para>
        /// <para>В параметре <paramref name="column"/> передано отрицательное значение.</para>
        /// <para>- или -</para>
        /// <para>В параметре <paramref name="column"/> передано означение, большее или равное <see cref="Matrix.ColumnsCount"/>.</para>
        /// <para>- или -</para>
        /// <para>Передано нечисловое значение.</para>
        /// <para>- или -</para>
        /// <para>Передано бесконечное значение.</para>
        /// </exception>
        public double this[int row, int column]
        {
            get
            {
                if (row < 0)
                {
                    throw new ArgumentOutOfRangeException("row", "Передано отрицательное значение.");
                }
                else if (row >= RowsCount)
                {
                    throw new ArgumentOutOfRangeException("row", "Передано значение, большее или равное количеству строк.");
                }
                if (column < 0)
                {
                    throw new ArgumentOutOfRangeException("column", "Передано отрицательное значение.");
                }
                else if (column >= ColumnsCount)
                {
                    throw new ArgumentOutOfRangeException("column", "Передано значение, большее или равное количеству столбцов.");
                }
                return _Items[row + RowsCount * column];
            }
            set
            {
                if (row < 0)
                {
                    throw new ArgumentOutOfRangeException("row", "Передано отрицательное значение.");
                }
                else if (row >= RowsCount)
                {
                    throw new ArgumentOutOfRangeException("row", "Передано значение, большее или равное количеству строк.");
                }
                if (column < 0)
                {
                    throw new ArgumentOutOfRangeException("column", "Передано отрицательное значение.");
                }
                else if (column >= ColumnsCount)
                {
                    throw new ArgumentOutOfRangeException("column", "Передано значение, большее или равное количеству столбцов.");
                }
                if (double.IsNaN(value))
                {
                    throw new ArgumentOutOfRangeException("value", "Передано нечисловое значение.");
                }
                if (double.IsInfinity(value))
                {
                    throw new ArgumentOutOfRangeException("value", "Передано бесконечное значение.");
                }
                _Items[row + RowsCount * column] = value;
            }
        }
    }
}
