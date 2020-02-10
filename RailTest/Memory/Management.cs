using System;
using System.Runtime.InteropServices;

namespace RailTest.Memory
{
    /// <summary>
    /// Предоставляет механизмы для работы с памятью.
    /// </summary>
    /// <example>
    /// В следующем примере показано использование методов класса <see cref="Management"/>:
    /// <code language="cs">
    /// IntPtr first = <see cref="Management"/>.Alloc(1024);              // Выделение блока памяти размером 1024 байта.
    /// IntPtr second = <see cref="Management"/>.Alloc(4096);             // Выделение блока памяти размером 4096 байт.
    /// <see cref="Management"/>.Fill(first, 512, 100);                   // Заполнение блока памяти значением 100.
    /// <see cref="Management"/>.Move(first + 256, first, 512);           // Копирование данных.
    /// <see cref="Management"/>.Zero(second, 2048);                      // Заполнение блока нулевым значением.
    /// <see cref="Management"/>.Copy(second + 1024, first + 512, 256);   // Копирование данных.
    /// <see cref="Management"/>.Free(first);                             // Освобождение блока памяти.
    /// <see cref="Management"/>.Free(second);                            // Освобождение блока памяти.
    /// </code>
    /// </example>
    public unsafe static class Management
    {
        /// <summary>
        /// Выделяет область памяти.
        /// </summary>
        /// <param name="size">
        /// Размер области памяти, которую необходимо выделить.
        /// </param>
        /// <returns>
        /// Указатель на выделенную область памяти.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// В параметре <paramref name="size"/> передано отрицательное значение.
        /// </exception>
        /// <exception cref="OutOfMemoryException">
        /// Недостаточно памяти для выполнения запроса.
        /// </exception>
        public static IntPtr Alloc(long size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("size", "Передано отрицательное значение.");
            }
            else if (size == 0)
            {
                return IntPtr.Zero;
            }
            else
            {
                IntPtr pointer = Marshal.AllocHGlobal((IntPtr)size);
                Zero(pointer, size);
                return pointer;
            }
        }

        /// <summary>
        /// Освобождает область памяти.
        /// </summary>
        /// <param name="target">
        /// Область памяти, которую необходимо освободить.
        /// </param>
        public static void Free(IntPtr target)
        {
            if (target != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(target);
            }
        }

        /// <summary>
        /// Выполняет копирование содержимого исходного блока памяти в целевой блок памяти.
        /// </summary>
        /// <param name="target">
        /// Указатель на целевой блок памяти, в который необходимо выполнить копирование.
        /// </param>
        /// <param name="source">
        /// Указатель на исходный блок памяти, из которого необходимо выполнить копирование.
        /// </param>
        /// <param name="size">
        /// Размер копируемых данных в байтах.
        /// </param>
        /// <remarks>
        /// Метод <see cref="Copy"/> работает быстрее, чем метод <see cref="Move"/>,
        /// но для корректной работы метод <see cref="Copy"/> требует,
        /// чтобы исходный блок памяти <paramref name="source"/> не перекрывал целевой блок памяти <paramref name="target"/>.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// В параметре <paramref name="size"/> передано отрицательное значение.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Не удалось выполнить копирование блоков памяти.
        /// </exception>
        public unsafe static void Copy(IntPtr target, IntPtr source, long size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("size", "Передано отрицательное значение.");
            }
            try
            {
                Core.Import.RtlCopyMemory(target.ToPointer(), source.ToPointer(), (ulong)size);
            }
            catch
            {
                throw new InvalidOperationException("Не удалось выполнить копирование блоков памяти.");
            }
        }

        /// <summary>
        /// Выполняет копирование содержимого исходного блока памяти в целевой блок памяти.
        /// </summary>
        /// <param name="target">
        /// Указатель на целевой блок памяти, в который необходимо выполнить копирование.
        /// </param>
        /// <param name="source">
        /// Указатель на исходный блок памяти, из которого необходимо выполнить копирование.
        /// </param>
        /// <param name="size">
        /// Размер копируемых данных в байтах.
        /// </param>
        /// <remarks>
        /// Допускается перекрытие блоков памяти <paramref name="target"/> и <paramref name="source"/>.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// В параметре <paramref name="size"/> передано отрицательное значение.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Не удалось выполнить копирование блоков памяти.
        /// </exception>
        public unsafe static void Move(IntPtr target, IntPtr source, long size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("size", "Передано отрицательное значение.");
            }
            try
            {
                Core.Import.RtlMoveMemory(target.ToPointer(), source.ToPointer(), (ulong)size);
            }
            catch
            {
                throw new InvalidOperationException("Не удалось выполнить копирование блоков памяти.");
            }
        }

        /// <summary>
        /// Заполняет область памяти указанным значением.
        /// </summary>
        /// <param name="target">
        /// Указатель на блок памяти, который необходимо заполнить.
        /// </param>
        /// <param name="size">
        /// Размер заполняемого блока памяти в байтах.
        /// </param>
        /// <param name="fill">
        /// Значение, которым заполняется каждый байт в блоке памяти.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// В параметре <paramref name="size"/> передано отрицательное значение.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Не удалось выполнить заполнение блоков памяти.
        /// </exception>
        public unsafe static void Fill(IntPtr target, long size, int fill)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("size", "Передано отрицательное значение.");
            }
            try
            {
                Core.Import.RtlFillMemory(target.ToPointer(), (ulong)size, fill);
            }
            catch
            {
                throw new InvalidOperationException("Не удалось выполнить заполнение блоков памяти.");
            }
        }

        /// <summary>
        /// Заполняет область памяти нулевым значением.
        /// </summary>
        /// <param name="target">
        /// Указатель на блок памяти, который необходимо заполнить.
        /// </param>
        /// <param name="size">
        /// Размер заполняемого блока памяти в байтах.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// В параметре <paramref name="size"/> передано отрицательное значение.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Не удалось выполнить заполнение блоков памяти.
        /// </exception>
        public unsafe static void Zero(IntPtr target, long size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("size", "Передано отрицательное значение.");
            }
            try
            {
                Core.Import.RtlZeroMemory(target.ToPointer(), (ulong)size);
            }
            catch
            {
                throw new InvalidOperationException("Не удалось выполнить заполнение блоков памяти..");
            }
        }
    }
}
