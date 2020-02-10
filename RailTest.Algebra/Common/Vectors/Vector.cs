using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailTest.Algebra
{
    /// <summary>
    /// Базовый класс для всех объектов, реализующих вектор.
    /// </summary>
    public abstract class Vector : Ancestor, IDisposable
    {
        /// <summary>
        /// Происходит при изменении свойства <see cref="Pointer"/>.
        /// </summary>
        public event EventHandler PointerChanged;

        /// <summary>
        /// Происходит при изменении свойства <see cref="Length"/>.
        /// </summary>
        public event EventHandler LengthChanged;

        /// <summary>
        /// Поле для хранения размера одного элемента.
        /// </summary>
        private readonly int _ItemSize;

        /// <summary>
        /// Поле для хранения длины вектора.
        /// </summary>
        private int _Length;

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="itemSize">
        /// Размер одного элемента.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// В параметре <paramref name="itemSize"/> передано отрицательное или равное нулю значение.
        /// </exception>
        public Vector(int itemSize) :
                    this(itemSize, 0)
        {

        }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="itemSize">
        /// Размер одного элемента.
        /// </param>
        /// <param name="length">
        /// Длина.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <para>В параметре <paramref name="itemSize"/> передано отрицательное или равное нулю значение.</para>
        /// <para>- или -</para>
        /// <para>В параметре <paramref name="length"/> передано отрицательное значение.</para>
        /// </exception>
        /// <exception cref="OutOfMemoryException">
        /// Недостаточно памяти для выполнения запроса.
        /// </exception>
        public Vector(int itemSize, int length)
        {
            if (itemSize <= 0)
            {
                throw new ArgumentOutOfRangeException("itemSize", "Передано отрицательное или равное нулю значение.");
            }
            _ItemSize = itemSize;
            _Length = 0;
            Pointer = IntPtr.Zero;
            Length = length;
        }

        /// <summary>
        /// Разрушает объект.
        /// </summary>
        ~Vector()
        {
            if (Pointer != IntPtr.Zero)
            {
                Memory.Free(Pointer);
                Pointer = IntPtr.Zero;
                _Length = 0;
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
                _Length = 0;
            }
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Возвращает или задаёт длину вектора.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Передано отрицательное значение.
        /// </exception>
        /// <exception cref="OutOfMemoryException">
        /// Недостаточно памяти для выполнения запроса.
        /// </exception>
        public int Length
        {
            get
            {
                return _Length;
            }
            set
            {
                if (_Length != value)
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException("length", "Передано отрицательное значение.");
                    }

                    IntPtr pointer = IntPtr.Zero;
                    if (value > 0)
                    {
                        pointer = Memory.Alloc(value * (long)_ItemSize);
                    }

                    int copyLength = Math.Min(_Length, value);
                    if (copyLength > 0)
                    {
                        Memory.Copy(pointer, Pointer, copyLength * (long)_ItemSize);
                    }

                    if (Pointer != IntPtr.Zero)
                    {
                        Memory.Free(Pointer);
                    }

                    Pointer = pointer;
                    _Length = value;
                    OnPointerChanged(EventArgs.Empty);
                    OnLengthChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает указатель на область памяти, содержащую данные.
        /// </summary>
        public IntPtr Pointer { get; private set; }

        /// <summary>
        /// Вызывает событие <see cref="PointerChanged"/>.
        /// </summary>
        /// <param name="e">
        /// Аргументы, связанные с событием.
        /// </param>
        protected virtual void OnPointerChanged(EventArgs e)
        {
            PointerChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Вызывает событие <see cref="LengthChanged"/>.
        /// </summary>
        /// <param name="e">
        /// Аргументы, связанные с событием.
        /// </param>
        protected virtual void OnLengthChanged(EventArgs e)
        {
            LengthChanged?.Invoke(this, e);
        }
    }
}
