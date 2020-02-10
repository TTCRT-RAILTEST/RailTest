using System;

namespace RailTest.Algebra
{
    /// <summary>
    /// Представляет базовый класс для всех матриц.
    /// </summary>
    public abstract class Matrix : Ancestor, IDisposable
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="itemSize">
        /// Размер одного элемента.
        /// </param>
        /// <param name="rowsCount">
        /// Количество строк.
        /// </param>
        /// <param name="columnsCount">
        /// Количество столбцов.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>В параметре <paramref name="itemSize"/> передано отрицательное или равное нулю значение.</para>
        /// <para>- или -</para>
        /// <para>В параметре <paramref name="rowsCount"/> передано отрицательное значение.</para>
        /// <para>- или -</para>
        /// <para>В параметре <paramref name="columnsCount"/> передано отрицательное значение.</para>
        /// </exception>
        /// <exception cref="OutOfMemoryException">
        /// Недостаточно памяти для выполнения запроса.
        /// </exception>
        public Matrix(int itemSize, int rowsCount, int columnsCount)
        {
            if (itemSize <= 0)
            {
                throw new ArgumentOutOfRangeException("itemSize", "Передано отрицательное или равное нулю значение.");
            }
            if (rowsCount < 0)
            {
                throw new ArgumentOutOfRangeException("rowsCount", "Передано отрицательное значение.");
            }
            if (columnsCount < 0)
            {
                throw new ArgumentOutOfRangeException("columnsCount", "Передано отрицательное значение.");
            }
            RowsCount = rowsCount;
            ColumnsCount = columnsCount;
            Pointer = Memory.Alloc(rowsCount * ((long)columnsCount) * itemSize);
        }

        /// <summary>
        /// Разрушает объект.
        /// </summary>
        ~Matrix()
        {
            if (Pointer != IntPtr.Zero)
            {
                Memory.Free(Pointer);
                Pointer = IntPtr.Zero;
                RowsCount = 0;
                ColumnsCount = 0;
            }
        }

        /// <summary>
        /// Выполняет определяемые приложением задачи, связанные с удалением,
        /// высвобождением или сбросом неуправляемых ресурсов.
        /// </summary>
        public void Dispose()
        {
            if (Pointer != IntPtr.Zero)
            {
                Memory.Free(Pointer);
                Pointer = IntPtr.Zero;
                RowsCount = 0;
                ColumnsCount = 0;
            }
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Возвращает указатель на область памяти, содержащую данные.
        /// </summary>
        public IntPtr Pointer { get; private set; }

        /// <summary>
        /// Возвращает количество строк.
        /// </summary>
        public int RowsCount { get; private set; }

        /// <summary>
        /// Возвращает количество столбцов.
        /// </summary>
        public int ColumnsCount { get; private set; }
    }
}
