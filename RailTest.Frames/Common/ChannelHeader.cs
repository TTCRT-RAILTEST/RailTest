using System;

namespace RailTest.Frames
{
    /// <summary>
    /// Представляет заголовок канала.
    /// </summary>
    public class ChannelHeader
    {
        /// <summary>
        /// Происходит при изменении свойства <see cref="Sampling"/>.
        /// </summary>
        public event EventHandler SamplingChanged;

        /// <summary>
        /// Поле для хранения имени канала.
        /// </summary>
        private string _Name;

        /// <summary>
        /// Поле для хранения единицы измерения.
        /// </summary>
        private string _Unit;

        /// <summary>
        /// Поле для хранения частоты дискретизации.
        /// </summary>
        private double _Sampling;

        /// <summary>
        /// Поле для хранения частоты среза фильтра.
        /// </summary>
        private double _Cutoff;

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public ChannelHeader() : this(StorageFormat.Simple)
        {

        }

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
        /// <exception cref="ArgumentOutOfRangeException">
        /// Происходит в случае, если значение параметра <paramref name="sampling"/> меньше нуля.
        /// </exception>
        internal ChannelHeader(string name, string unit, double sampling, double cutoff) :
            this(StorageFormat.Simple, name, unit, sampling, cutoff)
        {

        }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="format">
        /// Формат кадра.
        /// </param>
        internal ChannelHeader(StorageFormat format) : this(format, "", "", 0, 0)
        {
            
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="format">
        /// Формат кадра.
        /// </param>
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
        /// <exception cref="ArgumentOutOfRangeException">
        /// Происходит в случае, если значение параметра <paramref name="sampling"/> меньше нуля.
        /// </exception>
        internal ChannelHeader(StorageFormat format, string name, string unit, double sampling, double cutoff)
        {
            Format = format;
            _Name = name;
            _Unit = unit;
            if (sampling < 0)
            {
                throw new ArgumentOutOfRangeException("sampling", "Произошла попытка задать отрицательную частоту дискретизации.");
            }
            _Sampling = sampling;
            _Cutoff = cutoff;
        }

        /// <summary>
        /// Возвращает формат кадра.
        /// </summary>
        public StorageFormat Format { get; }

        /// <summary>
        /// Возвращает или задаёт имя канала.
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value ?? "";
            }
        }

        /// <summary>
        /// Возвращает или задаёт единицу измерения.
        /// </summary>
        public string Unit
        {
            get
            {
                return _Unit;
            }
            set
            {
                _Unit = value ?? "";
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
                return _Sampling;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Произошла попытка задать отрицательную частоту дискретизации.");
                }
                if (_Sampling != value)
                {
                    _Sampling = value;
                    OnSamplingChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает или задаёт частоту среза фильтра.
        /// </summary>
        public double Cutoff
        {
            get
            {
                return _Cutoff;
            }
            set
            {
                _Cutoff = value;
            }
        }

        /// <summary>
        /// Создаёт копию объекта.
        /// </summary>
        /// <returns>
        /// Копия объекта.
        /// </returns>
        internal virtual ChannelHeader Clone()
        {
            if (Format != StorageFormat.Simple)
            {
                throw new NotSupportedException("При попытке создать копию заголовка канала не была найдена функция, реализующая копирование.");
            }
            return new ChannelHeader(Name, Unit, Sampling, Cutoff);
        }

        /// <summary>
        /// Возвращает заголовок кадра в другом формате.
        /// </summary>
        /// <param name="format">
        /// Формат заголовка канала, в который необходимо преобразовать текущий объект.
        /// </param>
        /// <returns>
        /// Преобразованный объект.
        /// </returns>
        internal virtual ChannelHeader Convert(StorageFormat format)
        {
            if (format == Format)
            {
                return Clone();
            }
            switch (format)
            {
                case StorageFormat.Simple:
                    return new ChannelHeader(Name, Unit, Sampling, Cutoff);
                case StorageFormat.TestLab:
                    {
                        TestLabChannelHeader header = new TestLabChannelHeader();
                        header.Name = Name;
                        header.Unit = Unit;
                        header.Sampling = Sampling;
                        header.Cutoff = Cutoff;
                        return header;
                    }
                case StorageFormat.Catman:
                    {
                        CatmanChannelHeader header = new CatmanChannelHeader();
                        header.Name = Name;
                        header.Unit = Unit;
                        header.Sampling = Sampling;
                        header.Cutoff = Cutoff;
                        return header;
                    }
                case StorageFormat.Mera:
                    throw new Exception();
                default:
                    throw new ArgumentOutOfRangeException("format", "Произошла попытка преобразовать заголовок канала в неизвестный формат.");
            }
        }
        
        /// <summary>
        /// Вызывает событие <see cref="SamplingChanged"/>.
        /// </summary>
        /// <param name="e">
        /// Аргументы, связанные с событием.
        /// </param>
        protected virtual void OnSamplingChanged(EventArgs e)
        {
            SamplingChanged?.Invoke(this, e);
        }
    }
}
