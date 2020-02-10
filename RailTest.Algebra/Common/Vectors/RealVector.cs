using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RailTest.Algebra
{
    /// <summary>
    /// Представляет вектор с действительными значениями.
    /// </summary>
    public unsafe sealed class RealVector : Vector
    {
        /// <summary>
        /// Поле для хранения указателя на область памяти, в которой расположены элементы вектора.
        /// </summary>
        private double* _Items;

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public RealVector() :
            this(0)
        {

        }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="length">
        /// Длина.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// В параметре <paramref name="length"/> передано отрицательное значение.
        /// </exception>
        /// <exception cref="OutOfMemoryException">
        /// Недостаточно памяти для выполнения запроса.
        /// </exception>
        public RealVector(int length) :
            base(sizeof(double), length)
        {
            
        }

        /// <summary>
        /// Возвращает или задаёт значение по указанному индексу.
        /// </summary>
        /// <param name="index">
        /// Индекс значения.
        /// </param>
        /// <returns>
        /// Значение.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// В параметре <paramref name="index"/> передано отрицательное значение.
        /// - или -
        /// В параметре <paramref name="index"/> передано означение, большее или равное <see cref="Vector.Length"/>.
        /// - или -
        /// Передано нечисловое значение.
        /// - или -
        /// Передано бесконечное значение.
        /// </exception>
        public double this[int index]
        {
            get
            {
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException("index", "Передано отрицательное значение.");
                }
                else if (index >= Length)
                {
                    throw new ArgumentOutOfRangeException("index", "Передано значение, большее или равное длине.");
                }
                return _Items[index];
            }
            set
            {
                if (index < 0)
                {
                    throw new ArgumentOutOfRangeException("index", "Передано отрицательное значение.");
                }
                else if (index >= Length)
                {
                    throw new ArgumentOutOfRangeException("index", "Передано значение, большее или равное длине.");
                }
                if (double.IsNaN(value))
                {
                    throw new ArgumentOutOfRangeException("value", "Передано нечисловое значение.");
                }
                if (double.IsInfinity(value))
                {
                    throw new ArgumentOutOfRangeException("value", "Передано бесконечное значение.");
                }
                _Items[index] = value;
            }
        }

        /// <summary>
        /// Возвращает среднее значение элементов.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Длина <see cref="Vector.Length"/> равна нулю.
        /// </exception>
        public double Average
        {
            get
            {
                int length = Length;
                if (length == 0)
                {
                    throw new InvalidOperationException("Произошла попытка определить среднее значение нулевого количества элементов.");
                }
                double average = 0;
                for (int i = 0; i != length; ++i)
                {
                    average += _Items[i];
                }
                return average / length;
            }
        }

        /// <summary>
        /// Возвращает минимальное значение.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Длина <see cref="Vector.Length"/> равна нулю.
        /// </exception>
        public double Min
        {
            get
            {
                int length = Length;
                if (length == 0)
                {
                    throw new InvalidOperationException("Произошла попытка определить среднее значение нулевого количества элементов.");
                }
                double min = _Items[0];
                for (int i = 0; i != length; ++i)
                {
                    if (min > _Items[0])
                    {
                        min = _Items[0];
                    }
                }
                return min;
            }
        }

        /// <summary>
        /// Возвращает максимальное значение.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Длина <see cref="Vector.Length"/> равна нулю.
        /// </exception>
        public double Max
        {
            get
            {
                int length = Length;
                if (length == 0)
                {
                    throw new InvalidOperationException("Произошла попытка определить среднее значение нулевого количества элементов.");
                }
                double max = _Items[0];
                for (int i = 0; i != length; ++i)
                {
                    if (max < _Items[0])
                    {
                        max = _Items[0];
                    }
                }
                return max;
            }
        }


        ///// <summary>
        ///// Возвращает индекс минимального значения.
        ///// </summary>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если <see cref="LongDimension"/> равно нулю.
        ///// </exception>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека создала исключение.
        ///// </exception>
        //public ulong LongIndexMinimum
        //{
        //    get
        //    {
        //        if (LongDimension == 0)
        //        {
        //            throw new InvalidOperationException("Нельзя определить минимальное значение вектора нулевой размерности.");
        //        }
        //        return Import.RealVector_IndexMinimum(Handle);
        //    }
        //}

        ///// <summary>
        ///// Возвращает индекс максимального значения.
        ///// </summary>
        ///// <exception cref="OverflowException">
        ///// Происходит в случае, если результат больше <see cref="int.MaxValue"/>.
        ///// </exception>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если <see cref="LongDimension"/> равно нулю.
        ///// </exception>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека создала исключение.
        ///// </exception>
        //public int IndexMaximum
        //{
        //    get
        //    {
        //        ulong index = LongIndexMaximum;
        //        if (index > int.MaxValue)
        //        {
        //            throw new OverflowException("Результат не может уместиться в 32-битном числе.");
        //        }
        //        return (int)index;
        //    }
        //}

        ///// <summary>
        ///// Возвращает индекс максимального значения.
        ///// </summary>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если <see cref="LongDimension"/> равно нулю.
        ///// </exception>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека создала исключение.
        ///// </exception>
        //public ulong LongIndexMaximum
        //{
        //    get
        //    {
        //        if (Dimension == 0)
        //        {
        //            throw new InvalidOperationException("Нельзя определить минимальное значение вектора нулевой размерности.");
        //        }
        //        return Import.RealVector_IndexMaximum(Handle);
        //    }
        //}

        ///// <summary>
        ///// Возвращает СКО.
        ///// </summary>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека создала исключение.
        ///// </exception>
        //public double StandardDeviation
        //{
        //    get
        //    {
        //        return Import.RealVector_StandardDeviation(Handle);
        //    }
        //}

        ///// <summary>
        ///// Возвращает минимально вероятное значение.
        ///// </summary>
        ///// <param name="probability">
        ///// Вероятность.
        ///// </param>
        ///// <param name="type">
        ///// Значение, определяющее тип закона распределения.
        ///// </param>
        ///// <returns>
        ///// Минимально вероятное значение.
        ///// </returns>
        ///// <exception cref="ArgumentOutOfRangeException">
        ///// Происходит в случае, если значение <paramref name="probability"/> меньше или равно нулю
        ///// - или -
        ///// значение <paramref name="probability"/> больше или равно единице.
        ///// </exception>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека создала исключение.
        ///// </exception>
        //public double GetMinimumProbable(double probability, ProbabilityType type)
        //{
        //    if (probability <= 0 || probability >= 1)
        //    {
        //        throw new ArgumentOutOfRangeException("probability", "Вероятность должны быть больше нуля и меньше единицы.");
        //    }
        //    return Import.RealVector_MinimumProbable(Handle, probability, type);
        //}

        ///// <summary>
        ///// Возвращает минимально вероятное значение по теоретическому квантилю.
        ///// </summary>
        ///// <param name="probability">
        ///// Вероятность.
        ///// </param>
        ///// <returns>
        ///// Минимально вероятное значение по теоретическому квантилю.
        ///// </returns>
        ///// <exception cref="ArgumentOutOfRangeException">
        ///// Происходит в случае, если значение <paramref name="probability"/> меньше или равно нулю
        ///// - или -
        ///// значение <paramref name="probability"/> больше или равно единице.
        ///// </exception>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека создала исключение.
        ///// </exception>
        //public double GetStandardMinimumProbable(double probability)
        //{
        //    return GetMinimumProbable(probability, ProbabilityType.Standard);
        //}

        ///// <summary>
        ///// Возвращает минимально вероятное значение по эмпирическому квантилю.
        ///// </summary>
        ///// <param name="probability">
        ///// Вероятность.
        ///// </param>
        ///// <returns>
        ///// Минимально вероятное значение по эмпирическому квантилю.
        ///// </returns>
        ///// <exception cref="ArgumentOutOfRangeException">
        ///// Происходит в случае, если значение <paramref name="probability"/> меньше или равно нулю
        ///// - или -
        ///// значение <paramref name="probability"/> больше или равно единице.
        ///// </exception>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека создала исключение.
        ///// </exception>
        //public double GetEmpiricalMinimumProbable(double probability)
        //{
        //    return GetMinimumProbable(probability, ProbabilityType.Empirical);
        //}

        ///// <summary>
        ///// Возвращает максимально вероятное значение.
        ///// </summary>
        ///// <param name="probability">
        ///// Вероятность.
        ///// </param>
        ///// <param name="type">
        ///// Значение, определяющее тип закона распределения.
        ///// </param>
        ///// <returns>
        ///// Максимально вероятное значение.
        ///// </returns>
        ///// <exception cref="ArgumentOutOfRangeException">
        ///// Происходит в случае, если значение <paramref name="probability"/> меньше или равно нулю
        ///// - или -
        ///// значение <paramref name="probability"/> больше или равно единице.
        ///// </exception>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека создала исключение.
        ///// </exception>
        //public double GetMaximumProbable(double probability, ProbabilityType type)
        //{
        //    if (probability <= 0 || probability >= 1)
        //    {
        //        throw new ArgumentOutOfRangeException("probability", "Вероятность должны быть больше нуля и меньше единицы.");
        //    }
        //    return Import.RealVector_MaximumProbable(Handle, probability, type);
        //}

        ///// <summary>
        ///// Возвращает максимально вероятное значение по теоретическому квантилю.
        ///// </summary>
        ///// <param name="probability">
        ///// Вероятность.
        ///// </param>
        ///// <returns>
        ///// Максимально вероятное значение по теоретическому квантилю.
        ///// </returns>
        ///// <exception cref="ArgumentOutOfRangeException">
        ///// Происходит в случае, если значение <paramref name="probability"/> меньше или равно нулю
        ///// - или -
        ///// значение <paramref name="probability"/> больше или равно единице.
        ///// </exception>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека создала исключение.
        ///// </exception>
        //public double GetStandardMaximumProbable(double probability)
        //{
        //    return GetMaximumProbable(probability, ProbabilityType.Standard);
        //}

        ///// <summary>
        ///// Возвращает максимально вероятное значение по эмпирическому квантилю.
        ///// </summary>
        ///// <param name="probability">
        ///// Вероятность.
        ///// </param>
        ///// <returns>
        ///// Максимально вероятное значение по эмпирическому квантилю.
        ///// </returns>
        ///// <exception cref="ArgumentOutOfRangeException">
        ///// Происходит в случае, если значение <paramref name="probability"/> меньше или равно нулю
        ///// - или -
        ///// значение <paramref name="probability"/> больше или равно единице.
        ///// </exception>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека создала исключение.
        ///// </exception>
        //public double GetEmpiricalMaximumProbable(double probability)
        //{
        //    return GetMaximumProbable(probability, ProbabilityType.Empirical);
        //}

        ///// <summary>
        ///// Выполняет нормализацию по правилу трёх сигм.
        ///// </summary>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека выдала исключение.
        ///// </exception>
        //public void ThreeSigmaNormalization()
        //{
        //    Import.RealVector_ThreeSigmaNormalization(Handle);
        //}

        /// <summary>
        /// Масштабирует значения всех элементов вектора.
        /// </summary>
        /// <param name="factor">
        /// Масштабный множитель.
        /// </param>
        public void Scale(double factor)
        {
            int length = Length;
            for (int i = 0; i != length; ++i)
            {
                _Items[i] *= factor;
            }
        }

        /// <summary>
        /// Смещает значения всех элементов вектора.
        /// </summary>
        /// <param name="offset">
        /// Смещение.
        /// </param>
        public void Move(double offset)
        {
            int length = Length;
            for (int i = 0; i != length; ++i)
            {
                _Items[i] += offset;
            }
        }

        /// <summary>
        /// Заполняет всех элементов вектора заданным значением.
        /// </summary>
        /// <param name="value">
        /// Значение, которым заполняется вектор.
        /// </param>
        public void Fill(double value)
        {
            int length = Length;
            for (int i = 0; i != length; ++i)
            {
                _Items[i] = value;
            }
        }

        /// <summary>
        /// Устанавливает все элементы вектора в нулевое значение.
        /// </summary>
        public void Zero()
        {
            int length = Length;
            if (length > 0)
            {
                Memory.Zero(Pointer, length * (long)sizeof(double));
            }
        }

        ///// <summary>
        ///// Выполняет циклический сдвиг.
        ///// </summary>
        ///// <param name="offset">
        ///// Смещение.
        ///// </param>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека выдала исключение.
        ///// </exception>
        //public void CyclicShift(int offset)
        //{
        //    if (offset >= 0)
        //    {
        //        CyclicShift((ulong)offset);
        //    }
        //    else
        //    {
        //        if (LongDimension > long.MaxValue)
        //        {
        //            CyclicShift(LongDimension - (ulong)(-offset));
        //        }
        //        else
        //        {
        //            long longDimension = (long)LongDimension;
        //            long longOffset = offset % longDimension;
        //            if (longOffset < 0)
        //            {
        //                longOffset += longDimension;
        //            }
        //            CyclicShift((ulong)longOffset);
        //        }
        //    }
        //}

        ///// <summary>
        ///// Определяет сдвиг относительно вектора-шаблона.
        ///// </summary>
        ///// <param name="pattern">
        ///// Вектор-шаблон.
        ///// </param>
        ///// <returns>
        ///// Сдвиг относительно вектора-шаблона.
        ///// </returns>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека выдала исключение.
        ///// </exception>
        //public int Shift(RealVector pattern)
        //{
        //    ulong result = LongShift(pattern);
        //    if (result > int.MaxValue)
        //    {
        //        throw new OverflowException("Результат не может уместиться в 32-битном числе.");
        //    }
        //    return (int)result;
        //}

        ///// <summary>
        ///// Инвертирует вектор.
        ///// </summary>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека выдала исключение.
        ///// </exception>
        //public void Invert()
        //{
        //    Import.RealVector_Invert(Handle);
        //}

        ///// <summary>
        ///// Возвращает подвектор.
        ///// </summary>
        ///// <param name="index">
        ///// Индекс, с которого начинается подвектор.
        ///// </param>
        ///// <param name="dimension">
        ///// Размерность подвектора.
        ///// </param>
        ///// <returns>
        ///// Подвектор.
        ///// </returns>
        ///// <exception cref="ArgumentOutOfRangeException">
        ///// Происходит в случае, если сумма значений параметров <paramref name="index"/>
        ///// и <paramref name="dimension"/> больше свойства <see cref="LongDimension"/>.
        ///// </exception>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека выдала исключение.
        ///// </exception>
        //public RealVector GetSubVector(ulong index, ulong dimension)
        //{
        //    if (index + dimension > LongDimension)
        //    {
        //        throw new ArgumentOutOfRangeException("index + dimension", "Произошла попытка получить подвектор, который не умещается в векторе.");
        //    }
        //    return new RealVector(Import.RealVector_SubVector(Handle, index, dimension));
        //}

        ///// <summary>
        ///// Возвращает подвектор.
        ///// </summary>
        ///// <param name="index">
        ///// Индекс, с которого начинается подвектор.
        ///// </param>
        ///// <param name="dimension">
        ///// Размерность подвектора.
        ///// </param>
        ///// <returns>
        ///// Подвектор.
        ///// </returns>
        ///// <exception cref="ArgumentOutOfRangeException">
        ///// Происходит в случае, если значение параметра <paramref name="index"/> меньше нуля
        ///// - или -
        ///// значение параметра <paramref name="dimension"/> меньше нуля
        ///// - или -
        ///// сумма значений параметров <paramref name="index"/> и <paramref name="dimension"/> больше свойства <see cref="LongDimension"/>.
        ///// </exception>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека выдала исключение.
        ///// </exception>
        //public RealVector GetSubVector(int index, int dimension)
        //{
        //    if (index < 0)
        //    {
        //        throw new ArgumentOutOfRangeException("index", "Произошла попытка получить подвектор отрицательного индекса.");
        //    }
        //    if (dimension < 0)
        //    {
        //        throw new ArgumentOutOfRangeException("dimension", "Произошла попытка получить подвектор отрицательной размерности.");
        //    }
        //    return GetSubVector((ulong)index, (ulong)dimension);
        //}

        ///// <summary>
        ///// Выполняет преобразование вектора.
        ///// </summary>
        ///// <param name="target">
        ///// Результат преобразования.
        ///// </param>
        ///// <param name="source">
        ///// Исходный вектор.
        ///// </param>
        ///// <param name="matrix">
        ///// Матрица преобразования.
        ///// </param>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека выдала исключение.
        ///// </exception>
        //public static void Transform(RealVector target, RealVector source, RealMatrix matrix)
        //{
        //    if (matrix.Rows != target.Dimension || matrix.Columns != source.Dimension)
        //    {
        //        throw new ArgumentOutOfRangeException("matrix", "Матрица должна иметь подходящий размер.");
        //    }
        //    Import.RealVector_Transform(target.Handle, source.Handle, matrix.Handle);
        //}

        ///// <summary>
        ///// Создаёт копию вектора.
        ///// </summary>
        ///// <returns>
        ///// Копия вектора.
        ///// </returns>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека выдала исключение.
        ///// </exception>
        //public RealVector Clone()
        //{
        //    return GetSubVector(0, LongDimension);
        //}

        ///// <summary>
        ///// Выполняет свёртку двух векторов.
        ///// </summary>
        ///// <param name="result">
        ///// Результат операции.
        ///// </param>
        ///// <param name="left">
        ///// Левый операнд.
        ///// </param>
        ///// <param name="right">
        ///// Правый операнд.
        ///// </param>
        ///// <exception cref="ArgumentException">
        ///// Происходит в случае, если размерности векторов не совпадают.
        ///// </exception>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека выдала исключение.
        ///// </exception>
        //public static void Convolution(RealVector result, RealVector left, RealVector right)
        //{
        //    if (left.Dimension != result.Dimension)
        //    {
        //        throw new ArgumentException("left", "Размерности векторов не совпадают.");
        //    }
        //    if (right.Dimension != result.Dimension)
        //    {
        //        throw new ArgumentException("right", "Размерности векторов не совпадают.");
        //    }
        //    Import.RealVector_Convolution(result.Handle, left.Handle, right.Handle);
        //}





        ////
        //// Сводка:
        ////     Определяет, входит ли элемент в коллекцию System.Collections.Generic.List`1.
        ////
        //// Параметры:
        ////   item:
        ////     Объект для поиска в System.Collections.Generic.List`1. Для ссылочных типов допускается
        ////     значение null.
        ////
        //// Возврат:
        ////     Значение true, если параметр item найден в коллекции System.Collections.Generic.List`1;
        ////     в противном случае — значение false.
        //public bool Contains(T item);

        ////
        //// Сводка:
        ////     Преобразует элементы текущего списка System.Collections.Generic.List`1 в другой
        ////     тип и возвращает список преобразованных элементов.
        ////
        //// Параметры:
        ////   converter:
        ////     Делегат System.Converter`2, преобразующий каждый элемент из одного типа в другой.
        ////
        //// Параметры типа:
        ////   TOutput:
        ////     Тип элементов массива назначения.
        ////
        //// Возврат:
        ////     Список System.Collections.Generic.List`1 с элементами конечного типа, преобразованными
        ////     из текущего списка System.Collections.Generic.List`1.
        ////
        //// Исключения:
        ////   T:System.ArgumentNullException:
        ////     converter — null.
        //public List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter);

        ////
        //// Сводка:
        ////     Копирует System.Collections.Generic.List`1 целиком в совместимый одномерный массив,
        ////     начиная с указанного индекса конечного массива.
        ////
        //// Параметры:
        ////   array:
        ////     Одномерный массив System.Array, в который копируются элементы из интерфейса System.Collections.Generic.List`1.
        ////     Массив System.Array должен иметь индексацию, начинающуюся с нуля.
        ////
        ////   arrayIndex:
        ////     Отсчитываемый от нуля индекс в массиве array, указывающий начало копирования.
        ////
        //// Исключения:
        ////   T:System.ArgumentNullException:
        ////     array — null.
        ////
        ////   T:System.ArgumentOutOfRangeException:
        ////     Значение параметра arrayIndex меньше 0.
        ////
        ////   T:System.ArgumentException:
        ////     Число элементов в исходной коллекции System.Collections.Generic.List`1 больше
        ////     доступного места от положения, заданного значением параметра arrayIndex, до конца
        ////     массива назначения array.
        //public void CopyTo(T[] array, int arrayIndex);

        ////
        //// Сводка:
        ////     Копирует диапазон элементов из списка System.Collections.Generic.List`1 в совместимый
        ////     одномерный массив, начиная с указанного индекса конечного массива.
        ////
        //// Параметры:
        ////   index:
        ////     Отсчитываемый от нуля индекс исходного списка System.Collections.Generic.List`1,
        ////     с которого начинается копирование.
        ////
        ////   array:
        ////     Одномерный массив System.Array, в который копируются элементы из интерфейса System.Collections.Generic.List`1.
        ////     Массив System.Array должен иметь индексацию, начинающуюся с нуля.
        ////
        ////   arrayIndex:
        ////     Отсчитываемый от нуля индекс в массиве array, указывающий начало копирования.
        ////
        ////   count:
        ////     Число элементов для копирования.
        ////
        //// Исключения:
        ////   T:System.ArgumentNullException:
        ////     array — null.
        ////
        ////   T:System.ArgumentOutOfRangeException:
        ////     Значение параметра index меньше 0. -или- Значение параметра arrayIndex меньше
        ////     0. -или- Значение параметра count меньше 0.
        ////
        ////   T:System.ArgumentException:
        ////     Значение параметра index больше или равно значению System.Collections.Generic.List`1.Count
        ////     исходного списка System.Collections.Generic.List`1. -или- Число элементов от
        ////     index до конца исходного списка System.Collections.Generic.List`1 больше доступного
        ////     места от положения, заданного значением параметра arrayIndex, до конца массива
        ////     назначения array.
        //public void CopyTo(int index, T[] array, int arrayIndex, int count);

        ////
        //// Сводка:
        ////     Копирует весь список System.Collections.Generic.List`1 в совместимый одномерный
        ////     массив, начиная с первого элемента целевого массива.
        ////
        //// Параметры:
        ////   array:
        ////     Одномерный массив System.Array, в который копируются элементы из интерфейса System.Collections.Generic.List`1.
        ////     Массив System.Array должен иметь индексацию, начинающуюся с нуля.
        ////
        //// Исключения:
        ////   T:System.ArgumentNullException:
        ////     array — null.
        ////
        ////   T:System.ArgumentException:
        ////     Число элементов в исходном массиве System.Collections.Generic.List`1 больше числа
        ////     элементов, которые может содержать массив назначения array.
        //public void CopyTo(T[] array);

        ////
        //// Сводка:
        ////     Определяет, содержит ли System.Collections.Generic.List`1 элементы, удовлетворяющие
        ////     условиям указанного предиката.
        ////
        //// Параметры:
        ////   match:
        ////     Делегат System.Predicate`1, определяющий условия поиска элементов.
        ////
        //// Возврат:
        ////     true, если System.Collections.Generic.List`1 содержит один или несколько элементов,
        ////     удовлетворяющих условиям указанного предиката, в противном случае — false.
        ////
        //// Исключения:
        ////   T:System.ArgumentNullException:
        ////     match — null.
        //public bool Exists(Predicate<T> match);

        ////
        //// Сводка:
        ////     Выполняет поиск элемента, удовлетворяющего условиям указанного предиката, и возвращает
        ////     первое найденное вхождение в пределах всего списка System.Collections.Generic.List`1.
        ////
        //// Параметры:
        ////   match:
        ////     Делегат System.Predicate`1, определяющий условия поиска элемента.
        ////
        //// Возврат:
        ////     Первый элемент, удовлетворяющий условиям указанного предиката, если такой элемент
        ////     найден; в противном случае — значение по умолчанию для типа T.
        ////
        //// Исключения:
        ////   T:System.ArgumentNullException:
        ////     match — null.
        //public T Find(Predicate<T> match);

        ////
        //// Сводка:
        ////     Извлекает все элементы, удовлетворяющие условиям указанного предиката.
        ////
        //// Параметры:
        ////   match:
        ////     Делегат System.Predicate`1, определяющий условия поиска элементов.
        ////
        //// Возврат:
        ////     Список System.Collections.Generic.List`1, содержащий все элементы, удовлетворяющие
        ////     условиям указанного предиката, если такие элементы найдены; в противном случае
        ////     — пустой список System.Collections.Generic.List`1.
        ////
        //// Исключения:
        ////   T:System.ArgumentNullException:
        ////     match — null.
        //public List<T> FindAll(Predicate<T> match);

        ////
        //// Сводка:
        ////     Выполняет поиск элемента, удовлетворяющего условиям указанного предиката, и возвращает
        ////     отсчитываемый от нуля индекс первого найденного вхождения в пределах всего списка
        ////     System.Collections.Generic.List`1.
        ////
        //// Параметры:
        ////   match:
        ////     Делегат System.Predicate`1, определяющий условия поиска элемента.
        ////
        //// Возврат:
        ////     Отсчитываемый от нуля индекс первого вхождения элемента, отвечающего условиям
        ////     предиката match, если такой элемент найден. В противном случае значение –1.
        ////
        //// Исключения:
        ////   T:System.ArgumentNullException:
        ////     match — null.
        //public int FindIndex(Predicate<T> match);

        ////
        //// Сводка:
        ////     Выполняет поиск элемента, удовлетворяющего условиям указанного предиката, и возвращает
        ////     отсчитываемый от нуля индекс первого вхождения в диапазоне элементов списка System.Collections.Generic.List`1,
        ////     начиная с заданного индекса и заканчивая последним элементом.
        ////
        //// Параметры:
        ////   startIndex:
        ////     Индекс (с нуля) начальной позиции поиска.
        ////
        ////   match:
        ////     Делегат System.Predicate`1, определяющий условия поиска элемента.
        ////
        //// Возврат:
        ////     Отсчитываемый от нуля индекс первого вхождения элемента, отвечающего условиям
        ////     предиката match, если такой элемент найден. В противном случае значение –1.
        ////
        //// Исключения:
        ////   T:System.ArgumentNullException:
        ////     match — null.
        ////
        ////   T:System.ArgumentOutOfRangeException:
        ////     startIndex находится вне диапазона допустимых индексов для System.Collections.Generic.List`1.
        //public int FindIndex(int startIndex, Predicate<T> match);

        ////
        //// Сводка:
        ////     Выполняет поиск элемента, удовлетворяющего условиям указанного предиката, и возвращает
        ////     отсчитываемый от нуля индекс первого вхождения в диапазоне элементов списка System.Collections.Generic.List`1,
        ////     начинающемся с заданного индекса и содержащем указанное число элементов.
        ////
        //// Параметры:
        ////   startIndex:
        ////     Индекс (с нуля) начальной позиции поиска.
        ////
        ////   count:
        ////     Число элементов в диапазоне, в котором выполняется поиск.
        ////
        ////   match:
        ////     Делегат System.Predicate`1, определяющий условия поиска элемента.
        ////
        //// Возврат:
        ////     Отсчитываемый от нуля индекс первого вхождения элемента, отвечающего условиям
        ////     предиката match, если такой элемент найден. В противном случае значение –1.
        ////
        //// Исключения:
        ////   T:System.ArgumentNullException:
        ////     match — null.
        ////
        ////   T:System.ArgumentOutOfRangeException:
        ////     startIndex находится вне диапазона допустимых индексов для System.Collections.Generic.List`1.
        ////     -или- Значение параметра count меньше 0. -или- startIndex и count не указывают
        ////     допустимый раздел в System.Collections.Generic.List`1.
        //public int FindIndex(int startIndex, int count, Predicate<T> match);

        ////
        //// Сводка:
        ////     Выполняет поиск элемента, удовлетворяющего условиям указанного предиката, и возвращает
        ////     последнее найденное вхождение в пределах всего списка System.Collections.Generic.List`1.
        ////
        //// Параметры:
        ////   match:
        ////     Делегат System.Predicate`1, определяющий условия поиска элемента.
        ////
        //// Возврат:
        ////     Последний элемент, удовлетворяющий условиям указанного предиката, если такой
        ////     элемент найден; в противном случае — значение по умолчанию для типа T.
        ////
        //// Исключения:
        ////   T:System.ArgumentNullException:
        ////     match — null.
        //public T FindLast(Predicate<T> match);

        ////
        //// Сводка:
        ////     Выполняет поиск элемента, удовлетворяющего условиям указанного предиката, и возвращает
        ////     отсчитываемый от нуля индекс последнего найденного вхождения в пределах всего
        ////     списка System.Collections.Generic.List`1.
        ////
        //// Параметры:
        ////   match:
        ////     Делегат System.Predicate`1, определяющий условия поиска элемента.
        ////
        //// Возврат:
        ////     Отсчитываемый от нуля индекс последнего вхождения элемента, удовлетворяющего
        ////     условиям предиката match, если такой элемент найден; в противном случае — значение
        ////     –1.
        ////
        //// Исключения:
        ////   T:System.ArgumentNullException:
        ////     match — null.
        //public int FindLastIndex(Predicate<T> match);

        ////
        //// Сводка:
        ////     Выполняет поиск элемента, удовлетворяющего условиям указанного предиката, и возвращает
        ////     отсчитываемый от нуля индекс последнего вхождения в диапазоне элементов списка
        ////     System.Collections.Generic.List`1, начиная с первого элемента и заканчивая элементом
        ////     с заданным индексом.
        ////
        //// Параметры:
        ////   startIndex:
        ////     Индекс (с нуля) начала диапазона поиска в обратном направлении.
        ////
        ////   match:
        ////     Делегат System.Predicate`1, определяющий условия поиска элемента.
        ////
        //// Возврат:
        ////     Отсчитываемый от нуля индекс последнего вхождения элемента, удовлетворяющего
        ////     условиям предиката match, если такой элемент найден; в противном случае — значение
        ////     –1.
        ////
        //// Исключения:
        ////   T:System.ArgumentNullException:
        ////     match — null.
        ////
        ////   T:System.ArgumentOutOfRangeException:
        ////     startIndex находится вне диапазона допустимых индексов для System.Collections.Generic.List`1.
        //public int FindLastIndex(int startIndex, Predicate<T> match);

        ////
        //// Сводка:
        ////     Выполняет поиск элемента, удовлетворяющего условиям указанного предиката, и возвращает
        ////     отсчитываемый от нуля индекс последнего вхождения в диапазоне элементов списка
        ////     System.Collections.Generic.List`1, содержащем указанное число элементов и заканчивающемся
        ////     элементом с заданным индексом.
        ////
        //// Параметры:
        ////   startIndex:
        ////     Индекс (с нуля) начала диапазона поиска в обратном направлении.
        ////
        ////   count:
        ////     Число элементов в диапазоне, в котором выполняется поиск.
        ////
        ////   match:
        ////     Делегат System.Predicate`1, определяющий условия поиска элемента.
        ////
        //// Возврат:
        ////     Отсчитываемый от нуля индекс последнего вхождения элемента, удовлетворяющего
        ////     условиям предиката match, если такой элемент найден; в противном случае — значение
        ////     –1.
        ////
        //// Исключения:
        ////   T:System.ArgumentNullException:
        ////     match — null.
        ////
        ////   T:System.ArgumentOutOfRangeException:
        ////     startIndex находится вне диапазона допустимых индексов для System.Collections.Generic.List`1.
        ////     -или- Значение параметра count меньше 0. -или- startIndex и count не указывают
        ////     допустимый раздел в System.Collections.Generic.List`1.
        //public int FindLastIndex(int startIndex, int count, Predicate<T> match);

        ////
        //// Сводка:
        ////     Выполняет указанное действие с каждым элементом списка System.Collections.Generic.List`1.
        ////
        //// Параметры:
        ////   action:
        ////     Делегат System.Action`1, выполняемый для каждого элемента списка System.Collections.Generic.List`1.
        ////
        //// Исключения:
        ////   T:System.ArgumentNullException:
        ////     action — null.
        ////
        ////   T:System.InvalidOperationException:
        ////     Элемент в коллекции изменен.
        //public void ForEach(Action<T> action);

        ////
        //// Сводка:
        ////     Выполняет поиск указанного объекта и возвращает отсчитываемый от нуля индекс
        ////     первого вхождения в диапазоне элементов списка System.Collections.Generic.List`1,
        ////     начинающемся с заданного индекса и содержащем указанное число элементов.
        ////
        //// Параметры:
        ////   item:
        ////     Объект для поиска в System.Collections.Generic.List`1. Для ссылочных типов допускается
        ////     значение null.
        ////
        ////   index:
        ////     Индекс (с нуля) начальной позиции поиска. Значение 0 (ноль) действительно в пустом
        ////     списке.
        ////
        ////   count:
        ////     Число элементов в диапазоне, в котором выполняется поиск.
        ////
        //// Возврат:
        ////     Отсчитываемый от нуля индекс первого вхождения item в диапазоне элементов списка
        ////     System.Collections.Generic.List`1, который начинается с позиции index и содержит
        ////     count элементов, если искомый объект найден; в противном случае значение –1.
        ////
        //// Исключения:
        ////   T:System.ArgumentOutOfRangeException:
        ////     index находится вне диапазона допустимых индексов для System.Collections.Generic.List`1.
        ////     -или- Значение параметра count меньше 0. -или- index и count не указывают допустимый
        ////     раздел в System.Collections.Generic.List`1.
        //public int IndexOf(T item, int index, int count);

        ////
        //// Сводка:
        ////     Осуществляет поиск указанного объекта и возвращает отсчитываемый от нуля индекс
        ////     первого вхождения в диапазоне элементов списка System.Collections.Generic.List`1,
        ////     начиная с заданного индекса и до последнего элемента.
        ////
        //// Параметры:
        ////   item:
        ////     Объект для поиска в System.Collections.Generic.List`1. Для ссылочных типов допускается
        ////     значение null.
        ////
        ////   index:
        ////     Индекс (с нуля) начальной позиции поиска. Значение 0 (ноль) действительно в пустом
        ////     списке.
        ////
        //// Возврат:
        ////     Отсчитываемый от нуля индекс первого вхождения элемента item в диапазоне элементов
        ////     списка System.Collections.Generic.List`1, начиная с позиции index и до конца
        ////     списка, если элемент найден; в противном случае значение –1.
        ////
        //// Исключения:
        ////   T:System.ArgumentOutOfRangeException:
        ////     index находится вне диапазона допустимых индексов для System.Collections.Generic.List`1.
        //public int IndexOf(T item, int index);

        ////
        //// Сводка:
        ////     Осуществляет поиск указанного объекта и возвращает отсчитываемый от нуля индекс
        ////     первого вхождения, найденного в пределах всего списка System.Collections.Generic.List`1.
        ////
        //// Параметры:
        ////   item:
        ////     Объект для поиска в System.Collections.Generic.List`1. Для ссылочных типов допускается
        ////     значение null.
        ////
        //// Возврат:
        ////     Индекс (с нуля) первого вхождения параметра item, если оно найдено в коллекции
        ////     System.Collections.Generic.List`1; в противном случае -1.
        //public int IndexOf(T item);

        ////
        //// Сводка:
        ////     Осуществляет поиск указанного объекта и возвращает отсчитываемый от нуля индекс
        ////     последнего вхождения, найденного в пределах всего списка System.Collections.Generic.List`1.
        ////
        //// Параметры:
        ////   item:
        ////     Объект для поиска в System.Collections.Generic.List`1. Для ссылочных типов допускается
        ////     значение null.
        ////
        //// Возврат:
        ////     Отсчитываемый от нуля индекс последнего вхождения item в пределах всего списка
        ////     System.Collections.Generic.List`1, если элемент найден; в противном случае значение
        ////     –1.
        //public int LastIndexOf(T item);

        ////
        //// Сводка:
        ////     Осуществляет поиск указанного объекта и возвращает отсчитываемый от нуля индекс
        ////     последнего вхождения в диапазоне элементов списка System.Collections.Generic.List`1,
        ////     начиная с первого элемента и до позиции с заданным индексом.
        ////
        //// Параметры:
        ////   item:
        ////     Объект для поиска в System.Collections.Generic.List`1. Для ссылочных типов допускается
        ////     значение null.
        ////
        ////   index:
        ////     Индекс (с нуля) начала диапазона поиска в обратном направлении.
        ////
        //// Возврат:
        ////     Отсчитываемый от нуля индекс последнего вхождения элемента item в диапазоне элементов
        ////     списка System.Collections.Generic.List`1, начиная с первого элемента и до позиции
        ////     index, если элемент найден; в противном случае значение -1.
        ////
        //// Исключения:
        ////   T:System.ArgumentOutOfRangeException:
        ////     index находится вне диапазона допустимых индексов для System.Collections.Generic.List`1.
        //public int LastIndexOf(T item, int index);

        ////
        //// Сводка:
        ////     Выполняет поиск указанного объекта и возвращает отсчитываемый от нуля индекс
        ////     последнего вхождения в диапазоне элементов списка System.Collections.Generic.List`1,
        ////     содержащем указанное число элементов и заканчивающемся в позиции с указанным
        ////     индексом.
        ////
        //// Параметры:
        ////   item:
        ////     Объект для поиска в System.Collections.Generic.List`1. Для ссылочных типов допускается
        ////     значение null.
        ////
        ////   index:
        ////     Индекс (с нуля) начала диапазона поиска в обратном направлении.
        ////
        ////   count:
        ////     Число элементов в диапазоне, в котором выполняется поиск.
        ////
        //// Возврат:
        ////     Отсчитываемый от нуля индекс последнего вхождения item в диапазоне элементов
        ////     списка System.Collections.Generic.List`1, состоящем из count элементов и заканчивающемся
        ////     в позиции index, если элемент найден. В противном случае значение –1.
        ////
        //// Исключения:
        ////   T:System.ArgumentOutOfRangeException:
        ////     index находится вне диапазона допустимых индексов для System.Collections.Generic.List`1.
        ////     -или- Значение параметра count меньше 0. -или- index и count не указывают допустимый
        ////     раздел в System.Collections.Generic.List`1.
        //public int LastIndexOf(T item, int index, int count);


        ////
        //// Сводка:
        ////     Изменяет порядок элементов в указанном диапазоне.
        ////
        //// Параметры:
        ////   index:
        ////     Отсчитываемый от нуля индекс начала диапазона, порядок элементов которого требуется
        ////     изменить.
        ////
        ////   count:
        ////     Число элементов в диапазоне, порядок сортировки в котором требуется изменить.
        ////
        //// Исключения:
        ////   T:System.ArgumentOutOfRangeException:
        ////     Значение параметра index меньше 0. -или- Значение параметра count меньше 0.
        ////
        ////   T:System.ArgumentException:
        ////     Параметры index и count не указывают допустимый диапазон элементов в списке System.Collections.Generic.List`1.
        //public void Reverse(int index, int count);

        ////
        //// Сводка:
        ////     Изменяет порядок элементов во всем списке System.Collections.Generic.List`1 на
        ////     обратный.
        //public void Reverse();

        ////
        //// Сводка:
        ////     Сортирует элементы в диапазоне элементов списка System.Collections.Generic.List`1
        ////     с помощью указанной функции сравнения.
        ////
        //// Параметры:
        ////   index:
        ////     Индекс (с нуля) начала диапазона, который требуется отсортировать.
        ////
        ////   count:
        ////     Длина диапазона сортировки.
        ////
        ////   comparer:
        ////     Реализация System.Collections.Generic.IComparer`1, которую следует использовать
        ////     при сравнении элементов, или null, если должна использоваться функция сравнения
        ////     по умолчанию System.Collections.Generic.Comparer`1.Default.
        ////
        //// Исключения:
        ////   T:System.ArgumentOutOfRangeException:
        ////     Значение параметра index меньше 0. -или- Значение параметра count меньше 0.
        ////
        ////   T:System.ArgumentException:
        ////     index и count не указывают допустимый диапазон в System.Collections.Generic.List`1.
        ////     -или- Реализация comparer вызвала ошибку во время сортировки. Например, comparer
        ////     может не возвратить 0 при сравнении элемента с самим собой.
        ////
        ////   T:System.InvalidOperationException:
        ////     comparer является null, и функция сравнения по умолчанию System.Collections.Generic.Comparer`1.Default
        ////     не может найти реализацию универсального интерфейса System.IComparable`1 или
        ////     интерфейса System.IComparable для типа T.
        //public void Sort(int index, int count, IComparer<T> comparer);

        ////
        //// Сводка:
        ////     Сортирует элементы во всем списке System.Collections.Generic.List`1 с использованием
        ////     указанного System.Comparison`1.
        ////
        //// Параметры:
        ////   comparison:
        ////     System.Comparison`1, используемый при сравнении элементов.
        ////
        //// Исключения:
        ////   T:System.ArgumentNullException:
        ////     comparison — null.
        ////
        ////   T:System.ArgumentException:
        ////     Реализация comparison вызвала ошибку во время сортировки. Например, comparison
        ////     может не возвратить 0 при сравнении элемента с самим собой.
        //public void Sort(Comparison<T> comparison);

        
        /// <summary>
        /// Сортирует все элементы вектора в порядке возрастания.
        /// </summary>
        public void Sort()
        {
            void sortCore(double* series, int length, double* temporal)
            {
                if (length <= 1)
                {
                    return;
                }
                int partition = length >> 1;
                sortCore(series, partition, temporal);
                sortCore(series + partition, length - partition, temporal);

                double* second = series + partition;

                int secondLength = length - partition;
                int firstIndex = 0;
                int secondIndex = 0;
                double* range = temporal;

                while (firstIndex != partition && secondIndex != secondLength)
                {
                    if (series[firstIndex] <= second[secondIndex])
                    {
                        *(range++) = series[firstIndex++];
                    }
                    else
                    {
                        *(range++) = second[secondIndex++];
                    }
                }

                if (firstIndex != partition)
                {
                    Memory.Copy(new IntPtr(range), new IntPtr(series + firstIndex), (partition - firstIndex) * sizeof(double));
                }
                else if (secondIndex != secondLength)
                {
                    Memory.Copy(new IntPtr(range), new IntPtr(second + secondIndex), (secondLength - secondIndex) * sizeof(double));
                }
                Memory.Copy(new IntPtr(series), new IntPtr(temporal), (partition + secondLength) * sizeof(double));
            }

            void sortBase(double* series, int length)
            {
                if (length == 0)
                {
                    return;
                }

                double* temporal = (double*)Memory.Alloc(length * sizeof(double));
                try
                {
                    sortCore(series, length, temporal);
                }
                finally
                {
                    Memory.Free(new IntPtr(temporal));
                }
            }

            sortBase(_Items, Length);
        }

        ////
        //// Сводка:
        ////     Сортирует элементы во всем списке System.Collections.Generic.List`1 с помощью
        ////     указанной функции сравнения.
        ////
        //// Параметры:
        ////   comparer:
        ////     Реализация System.Collections.Generic.IComparer`1, которую следует использовать
        ////     при сравнении элементов, или null, если должна использоваться функция сравнения
        ////     по умолчанию System.Collections.Generic.Comparer`1.Default.
        ////
        //// Исключения:
        ////   T:System.InvalidOperationException:
        ////     comparer является null, и функция сравнения по умолчанию System.Collections.Generic.Comparer`1.Default
        ////     не может найти реализацию универсального интерфейса System.IComparable`1 или
        ////     интерфейса System.IComparable для типа T.
        ////
        ////   T:System.ArgumentException:
        ////     Реализация comparer вызвала ошибку во время сортировки. Например, comparer может
        ////     не возвратить 0 при сравнении элемента с самим собой.
        //public void Sort(IComparer<T> comparer);

        /// <summary>
        /// Копирует элементы вектора в новый массив.
        /// </summary>
        /// <returns>
        /// Массив, содержащий копии элементов вектора.
        /// </returns>
        public double[] ToArray()
        {
            int length = Length;
            double[] array = new double[length];
            Marshal.Copy(Pointer, array, 0, length);
            return array;
        }

        ////
        //// Сводка:
        ////     Определяет, все ли элементы списка System.Collections.Generic.List`1 удовлетворяют
        ////     условиям указанного предиката.
        ////
        //// Параметры:
        ////   match:
        ////     Делегат System.Predicate`1, определяющий условия, проверяемые для элементов.
        ////
        //// Возврат:
        ////     true, если каждый элемент списка System.Collections.Generic.List`1 удовлетворяет
        ////     условиям заданного предиката, в противном случае — false. Если в списке нет элементов,
        ////     возвращается true.
        ////
        //// Исключения:
        ////   T:System.ArgumentNullException:
        ////     match — null.
        //public bool TrueForAll(Predicate<T> match);


        /// <summary>
        /// Вызывает событие <see cref="Vector.PointerChanged"/>.
        /// </summary>
        /// <param name="e">
        /// Аргументы, связанные с событием.
        /// </param>
        protected override void OnPointerChanged(EventArgs e)
        {
            _Items = (double*)Pointer.ToPointer();
            base.OnPointerChanged(e);
        }
    }
}
