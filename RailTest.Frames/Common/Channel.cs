using RailTest.Algebra;
using System;
using System.Numerics;

namespace RailTest.Frames
{
    /// <summary>
    /// Представляет канал кадра регистрации.
    /// </summary>
    public class Channel : Ancestor
    {
        /// <summary>
        /// Поле для хранения вектора данных.
        /// </summary>
        private RealVector _Vector;

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="name">
        /// Имя канала.
        /// </param>
        /// <param name="unit">
        /// Единица измерения.
        /// </param>
        /// <param name="sampling">
        /// Частота дискретизации.
        /// </param>
        /// <param name="cutoff">
        /// Частота среза фильтра.
        /// </param>
        /// <param name="length">
        /// Длина массива данных.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Происходит в случае, если значение параметра <paramref name="sampling"/> меньше нуля
        /// - или -
        /// значение параметра <paramref name="length"/> меньше нуля.
        /// </exception>
        /// <exception cref="OutOfMemoryException">
        /// Происходит в случае, если недостаточно памяти для выполнения запроса.
        /// </exception>
        public Channel(string name, string unit, double sampling, double cutoff, int length)
        {
            Header = new ChannelHeader(name, unit, sampling, cutoff);

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", "Произошла попытка создать канал отрицательной длины.");
            }
            _Vector = new RealVector(length);
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="header">
        /// Заголовок канала.
        /// </param>
        /// <param name="vector">
        /// Вектор данных.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Происходит в случае, если в параметре <paramref name="header"/> была передана пустая ссылка
        /// - или -
        /// если в параметре <paramref name="vector"/> была передана пустая ссылка.
        /// </exception>
        internal Channel(ChannelHeader header, RealVector vector)
        {
            Header = header ?? throw new ArgumentNullException("header", "Передана пустая ссылка.");
            _Vector = vector ?? throw new ArgumentNullException("vector", "Передана пустая ссылка.");
        }

        /// <summary>
        /// Возвращает заголовок канала.
        /// </summary>
        public ChannelHeader Header { get; }

        /// <summary>
        /// Возвращает или задаёт вектор данных.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        /// Происходит в случае, если в новом значении параметра была передана пустая ссылка.
        /// </exception>
        public RealVector Vector
        {
            get
            {
                return _Vector;
            }
            set
            {
                _Vector = value ?? throw new ArgumentNullException("value", "Передана пустая ссылка.");
            }
        }

        /// <summary>
        /// Возвращает формат кадра.
        /// </summary>
        public StorageFormat Format
        {
            get
            {
                return Header.Format;
            }
        }

        /// <summary>
        /// Возвращает или задаёт имя канала.
        /// </summary>
        public string Name
        {
            get
            {
                return Header.Name;
            }
            set
            {
                Header.Name = value ?? "";
            }
        }

        /// <summary>
        /// Возвращает или задаёт единицу измерения.
        /// </summary>
        public string Unit
        {
            get
            {
                return Header.Unit;
            }
            set
            {
                Header.Unit = value ?? "";
            }
        }

        /// <summary>
        /// Возвращает или задаёт частоту дискретизации.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Происходит в случае, если новое значение параметра меньше нуля.
        /// </exception>
        public double Sampling
        {
            get
            {
                return Header.Sampling;
            }
            set
            {
                Header.Sampling = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт частоту среза фильтра.
        /// </summary>
        public double Cutoff
        {
            get
            {
                return Header.Cutoff;
            }
            set
            {
                Header.Cutoff = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт длину массива данных.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Происходит в случае, если новое значение параметра отрицательное.
        /// </exception>
        /// <exception cref="OutOfMemoryException">
        /// Происходит в случае, если недостаточно памяти для выполнения запроса.
        /// </exception>
        public int Length
        {
            get
            {
                return Vector.Length;
            }
            set
            {
                Vector.Length = value;
            }
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
        /// Происходит в случае, если значение параметра <paramref name="index"/> меньше нуля
        /// - или -
        /// больше значения <see cref="Length"/>.
        /// </exception>
        public double this[int index]
        {
            get
            {
                return Vector[index];
            }
            set
            {
                Vector[index] = value;
            }
        }

        /// <summary>
        /// Возвращает значение, в указанное время.
        /// </summary>
        /// <param name="time">
        /// Время.
        /// </param>
        /// <returns>
        /// Значение.
        /// </returns>
        internal double AtTimeSafe(double time)
        {
            int index = (int)(time * Sampling);
            if (index < 0)
            {
                index = 0;
            }
            if (index >= Length)
            {
                index = Length - 1;
            }
            return this[index];
        }

        /// <summary>
        /// Возвращает среднее значение канала.
        /// </summary>
        public double Average
        {
            get
            {
                return Vector.Average;
            }
        }

        /// <summary>
        /// Возвращает максимальное значение канала.
        /// </summary>
        public double Max
        {
            get
            {
                return Vector.Max;
            }
        }

        /// <summary>
        /// Возвращает минимальное значение канала.
        /// </summary>
        public double Min
        {
            get
            {
                return Vector.Min;
            }
        }

        /// <summary>
        /// Возвращает первую точку, в которой найдено максимальное значение канала.
        /// </summary>
        internal ChannelPoint MaximumPoint
        {
            get
            {
                int index = 0;
                double value = this[0];
                for (int i = 0; i != Length; ++i)
                {
                    if (value < this[i])
                    {
                        value = this[i];
                        index = i;
                    }
                }
                return new ChannelPoint(index, value);
            }
        }

        /// <summary>
        /// Возвращает первую точку, в которой найдено минимальное значение канала.
        /// </summary>
        internal ChannelPoint MinimumPoint
        {
            get
            {
                int index = 0;
                double value = this[0];
                for (int i = 0; i != Length; ++i)
                {
                    if (value > this[i])
                    {
                        value = this[i];
                        index = i;
                    }
                }
                return new ChannelPoint(index, value);
            }
        }

        ///// <summary>
        ///// Возвращает стандартное отклонение.
        ///// </summary>
        //public double StandardDeviation
        //{
        //    get
        //    {
        //        return Vector.StandardDeviation;
        //    }
        //}

        ///// <summary>
        ///// Возвращает максимально вероятное значение выборки по теоретическому квантилю.
        ///// </summary>
        ///// <param name="probability">
        ///// Вероятность.
        ///// </param>
        ///// <returns>
        ///// Максимально вероятное значение.
        ///// </returns>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека выдала исключение.
        ///// </exception>
        //public double GetStandardMaximumProbable(double probability)
        //{
        //    return Vector.GetStandardMaximumProbable(probability);
        //}

        ///// <summary>
        ///// Возвращает минимально вероятное значение выборки по теоретическому квантилю.
        ///// </summary>
        ///// <param name="probability">
        ///// Вероятность.
        ///// </param>
        ///// <returns>
        ///// Максимально вероятное значение.
        ///// </returns>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека выдала исключение.
        ///// </exception>
        //public double GetStandardMinimumProbable(double probability)
        //{
        //    return Vector.GetStandardMinimumProbable(probability);
        //}

        ///// <summary>
        ///// Возвращает максимально вероятное значение выборки по эмпирическому квантилю.
        ///// </summary>
        ///// <param name="probability">
        ///// Вероятность.
        ///// </param>
        ///// <returns>
        ///// Максимально вероятное значение.
        ///// </returns>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека выдала исключение.
        ///// </exception>
        //public double GetEmpiricalMaximumProbable(double probability)
        //{
        //    return Vector.GetEmpiricalMaximumProbable(probability);
        //}

        ///// <summary>
        ///// Возвращает минимально вероятное значение выборки по эмпирическому квантилю.
        ///// </summary>
        ///// <param name="probability">
        ///// Вероятность.
        ///// </param>
        ///// <returns>
        ///// Максимально вероятное значение.
        ///// </returns>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека выдала исключение.
        ///// </exception>
        //public double GetEmpiricalMinimumProbable(double probability)
        //{
        //    return Vector.GetEmpiricalMinimumProbable(probability);
        //}

        ///// <summary>
        ///// Выполняет нормализацию по правилу трёх сигм.
        ///// </summary>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека выдала исключение.
        ///// </exception>
        //public void ThreeSigmaNormalization()
        //{
        //    Vector.ThreeSigmaNormalization();
        //}

        /// <summary>
        /// Масштабирует значения.
        /// </summary>
        /// <param name="factor">
        /// Масштабный множитель.
        /// </param>
        public void Scale(double factor)
        {
            Vector.Scale(factor);
        }

        /// <summary>
        /// Смещает значения.
        /// </summary>
        /// <param name="offset">
        /// Смещение.
        /// </param>
        public void Move(double offset)
        {
            Vector.Move(offset);
        }

        ///// <summary>
        ///// Выполняет циклический сдвиг.
        ///// </summary>
        ///// <param name="offset">
        ///// Смещение.
        ///// </param>
        //public void CyclicShift(int offset)
        //{
        //    Vector.CyclicShift(offset);
        //}

        ///// <summary>
        ///// Инвертирует канал.
        ///// </summary>
        //public void Invert()
        //{
        //    Vector.Invert();
        //}

        /// <summary>
        /// Смещает значения канала так, чтобы среднее значение
        /// за первые <paramref name="startTime"/> секунд было равно нулю.
        /// </summary>
        /// <param name="startTime">
        /// Время в секундах.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// В параметре <paramref name="startTime"/> передано отрицательное значение.
        /// </exception>
        unsafe internal void SetZeroAtStart(double startTime)
        {
            if (startTime < 0)
            {
                throw new ArgumentOutOfRangeException("startTime", "Время для оценки смещения не может быть отрицательным.");
            }
            lock (SyncRoot)
            {
                if (Length != 0)
                {
                    int count = 1 + (int)(startTime * Sampling);
                    if (count > Length)
                    {
                        count = Length;
                    }
                    double* pointer = (double*)Vector.Pointer;
                    double mean = 0;
                    for (int i = 0; i != count; ++i)
                    {
                        mean += pointer[i];
                    }
                    mean /= count;
                    Vector.Move(-mean);
                }
            }
        }

        /// <summary>
        /// Представляет преобразователь амплитуд.
        /// </summary>
        /// <param name="frequency">
        /// Частота.
        /// </param>
        /// <param name="amplitude">
        /// Амплитуда.
        /// </param>
        /// <returns>
        /// Преобразованная амплитуда.
        /// </returns>
        internal delegate Complex AmplitudeReformer(double frequency, Complex amplitude);

        ///// <summary>
        ///// Выполняет фильтрацию с помощью преобразования Фурье.
        ///// </summary>
        ///// <param name="reformer">
        ///// Преобразователь амплитуд.
        ///// </param>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека выдала исключение.
        ///// </exception>
        //unsafe public void FourierFiltering(AmplitudeReformer reformer)
        //{
        //    FrequencyReformer coreReformer =
        //        (double frequency, Complex* amplitude) =>
        //        {
        //            *amplitude = reformer(frequency, *amplitude);
        //        };
        //    try
        //    {
        //        Import.RealSeries_FourierFilteringReformer(_Vector.Pointer, (ulong)Length, Sampling, coreReformer);
        //    }
        //    catch (Exception)
        //    {
        //        throw NativeException.InvalidOperationException;
        //    }
        //}

        ///// <summary>
        ///// Выполняет фильтрацию с помощью преобразования Фурье.
        ///// </summary>
        ///// <param name="lowerFrequency">
        ///// Нижняя частота.
        ///// </param>
        ///// <param name="highFrequency">
        ///// Верхняя частота.
        ///// </param>
        ///// <param name="isInversion">
        ///// Значение, определяющее требуется ли выполнить инверсию частот:
        ///// false - после фильтрации остаются частоты большие или равные <paramref name="lowerFrequency"/>,
        /////         но меньшие или равные <paramref name="highFrequency"/>
        ///// - или -
        ///// true -  после фильтрации остаются частоты меньшие <paramref name="lowerFrequency"/> или
        /////         большие <paramref name="highFrequency"/>.
        ///// </param>
        //unsafe public void FF(double lowerFrequency, double highFrequency, bool isInversion = false)
        //{
        //    int count = (int)Math.Pow(2, (int)Math.Ceiling(Math.Log(Length) / Math.Log(2)));
        //    count = count << 8;
        //    double* source = null;
        //    Complex* target = null;
        //    try
        //    {
        //        source = (double*)Service.Memory.VirtualAlloc<double>(count);
        //        target = (Complex*)Service.Memory.VirtualAlloc<Complex>(count);
        //        Service.Memory.Copy<double>(source, Vector.Pointer, Length);
        //        Application.Compute.FFT(source, target, count);

        //        if ((lowerFrequency <= 0.0 && isInversion) ||
        //                (lowerFrequency > 0.0 && !isInversion))
        //        {
        //            target[0].Real = 0;
        //            target[0].Imaginary = 0;
        //        }

        //        //double stepFrequency = Sampling / count;
        //        //for (int i = 1; i <= count >> 1; ++i)
        //        //{
        //        //    double frequency = stepFrequency * i;
        //        //    if (((frequency < lowerFrequency || highFrequency < frequency) && isInversion) ||
        //        //        ((lowerFrequency <= frequency || frequency <= highFrequency) && !isInversion))
        //        //    {
        //        //        target[i].Real = 0;
        //        //        target[i].Imaginary = 0;

        //        //        target[count - i].Real = 0;
        //        //        target[count - i].Imaginary = 0;
        //        //    }
        //        //}


        //        Application.Compute.IFFT(target, source, count);
        //        Service.Memory.Copy<double>(Vector.Pointer, source, Length);
        //    }
        //    finally
        //    {
        //        Service.Memory.VirtualFree(source);
        //        Service.Memory.VirtualFree(target);
        //    }
        //    Scale(1 / (double)count); ;
        //}

        ///// <summary>
        ///// Выполняет фильтрацию с помощью преобразования Фурье.
        ///// </summary>
        ///// <param name="lowerFrequency">
        ///// Нижняя частота.
        ///// </param>
        ///// <param name="highFrequency">
        ///// Верхняя частота.
        ///// </param>
        ///// <param name="isInversion">
        ///// Значение, определяющее требуется ли выполнить инверсию частот:
        ///// false - после фильтрации остаются частоты большие или равные <paramref name="lowerFrequency"/>,
        /////         но меньшие или равные <paramref name="highFrequency"/>
        ///// - или -
        ///// true -  после фильтрации остаются частоты меньшие <paramref name="lowerFrequency"/> или
        /////         большие <paramref name="highFrequency"/>.
        ///// </param>
        //unsafe public void FourierFiltering(double lowerFrequency, double highFrequency, bool isInversion = false)
        //{
        //    try
        //    {
        //        Import.RealSeries_FourierFiltering(_Vector.Pointer, (ulong)Length, Sampling,
        //            lowerFrequency, highFrequency, isInversion);
        //    }
        //    catch (Exception)
        //    {
        //        throw NativeException.InvalidOperationException;
        //    }
        //}

        ///// <summary>
        ///// Вычисляет скользящее среднее.
        ///// </summary>
        ///// <param name="weights">
        ///// Массив, содержащий весовые коэффициенты для скользящего среднего.
        ///// </param>
        ///// <param name="weightsOffset">
        ///// Смещение в массиве <paramref name="weights"/>,
        ///// соответствующее центральному весовому коэффициенту.
        ///// </param>
        ///// <exception cref="ArgumentNullException">
        ///// Происходит в случае, если в параметре <paramref name="weights"/> передана пустая ссылка.
        ///// </exception>
        ///// <exception cref="ArgumentOutOfRangeException">
        ///// Происходит в случае, если в параметре <paramref name="weightsOffset"/> передано отрицательное значение
        ///// - или -
        ///// <paramref name="weightsOffset"/> >= <paramref name="weights.Length"/>.
        ///// </exception>
        ///// <exception cref="InvalidOperationException">
        ///// Происходит в случае, если неуправляемая библиотека выдала исключение.
        ///// </exception>
        //unsafe public void MovingAverage(double[] weights, int weightsOffset = 0)
        //{
        //    Mathematics.Series.MovingAverage(Vector.Pointer, Length, weights, weightsOffset);
        //}

        ///// <summary>
        ///// Изменяет частоту дискретизации.
        ///// </summary>
        ///// <param name="sampling">
        ///// Новая частота дискретизации.
        ///// </param>
        //public void Resampling(double sampling)
        //{
        //    int length = (int)Math.Floor(Length * sampling / Sampling);
        //    Resampling(sampling, length);
        //}

        ///// <summary>
        ///// Изменяет частоту дискретизации.
        ///// </summary>
        ///// <param name="sampling">
        ///// Новая частота дискретизации.
        ///// </param>
        ///// <param name="length">
        ///// Новая длина канала.
        ///// </param>
        //unsafe public void Resampling(double sampling, int length)
        //{
        //    RealVector vector = new RealVector(length);
        //    double* source = _Vector.Pointer;
        //    double* destination = vector.Pointer;

        //    for (int i = 0; i != length; ++i)
        //    {
        //        double time = i / sampling;
        //        int beginSourceIndex = (int)(Math.Floor(time * Sampling));
        //        if (beginSourceIndex < 0)
        //        {
        //            beginSourceIndex = 0;
        //        }
        //        if (beginSourceIndex > Length - 1)
        //        {
        //            beginSourceIndex = Length - 1;
        //        }
        //        destination[i] = source[beginSourceIndex];
        //    }
        //    _Vector = vector;
        //    Sampling = sampling;
        //}
        
        ///// <summary>
        ///// Определяет сдвиг относительно канала-шаблона.
        ///// </summary>
        ///// <param name="pattern">
        ///// Канал-шаблон.
        ///// </param>
        ///// <returns>
        ///// Сдвиг относительно канала-шаблона.
        ///// </returns>
        //public int GetShift(Channel pattern)
        //{
        //    return Vector.Shift(pattern.Vector);
        //}

        ///// <summary>
        ///// Возвращает подканал.
        ///// </summary>
        ///// <param name="index">
        ///// Индекс, с которого начинается подканал.
        ///// </param>
        ///// <param name="length">
        ///// Длина подканала.
        ///// </param>
        ///// <returns>
        ///// Подканал.
        ///// </returns>
        ///// <exception cref="ArgumentOutOfRangeException">
        ///// Происходит в случае, если значение параметра <paramref name="index"/> меньше нуля
        ///// - или -
        ///// значение параметра <paramref name="length"/> меньше нуля
        ///// - или -
        ///// сумма значений параметров <paramref name="index"/> и <paramref name="length"/> больше свойства <see cref="Length"/>.
        ///// </exception>
        //public Channel GetSubChannel(int index, int length)
        //{
        //    if (index < 0)
        //    {
        //        throw new ArgumentOutOfRangeException("index", "Произошла попытка получить подканал отрицательного индекса.");
        //    }
        //    if (length < 0)
        //    {
        //        throw new ArgumentOutOfRangeException("length", "Произошла попытка получить подканал отрицательной длины.");
        //    }
        //    if (index + length > Length)
        //    {
        //        throw new ArgumentOutOfRangeException("index + length", "Произошла попытка получить подканал, который не умещается в канале.");
        //    }
        //    RealVector subVector = Vector.GetSubVector(index, length);
        //    return new Channel(Header.Clone(), subVector);
        //}

        ///// <summary>
        ///// Создаёт копию канала.
        ///// </summary>
        ///// <returns>
        ///// Копия канала.
        ///// </returns>
        //public Channel Clone()
        //{
        //    return new Channel(Header.Clone(), Vector.Clone());
        //}
    }
}
