using System;

namespace RailTest.Frames
{
    /// <summary>
    /// Представляет заголовок канала в формате <see cref="StorageFormat.TestLab"/>.
    /// </summary>
    internal class TestLabChannelHeader : ChannelHeader
    {
        /// <summary>
        /// Поле для хранения описания канала.
        /// </summary>
        private string _Description;

        /// <summary>
        /// Поле для хранения смещения значений канала.
        /// </summary>
        private double _Offset;

        /// <summary>
        /// Поле для хранения масштаба значений канала.
        /// </summary>
        private double _Scale;

        /// <summary>
        /// Поле для хранения типа канала.
        /// </summary>
        private TestLabChannelType _Type;

        /// <summary>
        /// Поле для хранения формата данных канала.
        /// </summary>
        private TestLabDataFormat _DataFormat;

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public TestLabChannelHeader() : base(StorageFormat.TestLab)
        {
            _Description = "";
            _Offset = 0;
            _Scale = 1;
            _Type = TestLabChannelType.Normal;
            _DataFormat = TestLabDataFormat.Float64;
        }

        /// <summary>
        /// Возвращает или задаёт описание канала.
        /// </summary>
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value ?? "";
            }
        }

        /// <summary>
        /// Возвращает или задаёт смещение значений канала.
        /// </summary>
        public double Offset
        {
            get
            {
                return _Offset;
            }
            set
            {
                _Offset = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт масштаб значений канала.
        /// </summary>
        public double Scale
        {
            get
            {
                return _Scale;
            }
            set
            {
                _Scale = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт тип канала.
        /// </summary>
        public TestLabChannelType Type
        {
            get
            {
                return _Type;
            }
            set
            {
                _Type = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт формат данных канала.
        /// </summary>
        public TestLabDataFormat DataFormat
        {
            get
            {
                return _DataFormat;
            }
            set
            {
                _DataFormat = value;
            }
        }

        /// <summary>
        /// Создает новый объект, являющийся копией текущего экземпляра.
        /// </summary>
        /// <returns>
        /// Новый объект, являющийся копией этого экземпляра.
        /// </returns>
        internal override ChannelHeader Clone()
        {
            TestLabChannelHeader duplicate = new TestLabChannelHeader();
            duplicate.Name = Name;
            duplicate.Sampling = Sampling;
            duplicate.Unit = Unit;
            duplicate.Cutoff = Cutoff;

            duplicate._Description = _Description;
            duplicate._Offset = _Offset;
            duplicate._Scale = _Scale;
            duplicate._Type = _Type;
            duplicate._DataFormat = _DataFormat;
            return duplicate;
        }

        /// <summary>
        /// Возвращает заголовок канала в другом формате.
        /// </summary>
        /// <param name="format">
        /// Формат заголовка канала, в который необходимо преобразовать текущий объект.
        /// </param>
        /// <returns>
        /// Преобразованный объект.
        /// </returns>
        internal override ChannelHeader Convert(StorageFormat format)
        {
            switch (format)
            {
                case StorageFormat.TestLab:
                    return Clone();
                case StorageFormat.Catman:
                    {
                        CatmanChannelHeader header = new CatmanChannelHeader();
                        header.Sampling = Sampling;
                        header.Cutoff = Cutoff;
                        return header;
                    }
                default:
                    throw new Exception();
            }
        }
        
        /// <summary>
        /// Выполняет проверку и нормализацию значения типа <see cref="TestLabChannelType"/>.
        /// </summary>
        /// <param name="value">
        /// Исходное значение.
        /// </param>
        /// <returns>
        /// Нормализованное значение.
        /// </returns>
        internal static TestLabChannelType Validation(TestLabChannelType value)
        {
            switch (value)
            {
                case TestLabChannelType.Normal:
                    return TestLabChannelType.Normal;
                case TestLabChannelType.Service:
                    return TestLabChannelType.Service;
                default:
                    throw new InvalidOperationException("Тип канала не поддерживается.");
            }
        }

        /// <summary>
        /// Выполняет проверку и нормализацию значения типа <see cref="TestLabDataFormat"/>.
        /// </summary>
        /// <param name="value">
        /// Исходное значение.
        /// </param>
        /// <returns>
        /// Нормализованное значение.
        /// </returns>
        internal static TestLabDataFormat Validation(TestLabDataFormat value)
        {
            switch (value)
            {
                case TestLabDataFormat.UInt8:
                    return TestLabDataFormat.UInt8;
                case TestLabDataFormat.UInt16:
                    return TestLabDataFormat.UInt16;
                case TestLabDataFormat.UInt32:
                    return TestLabDataFormat.UInt32;
                case TestLabDataFormat.Int8:
                    return TestLabDataFormat.Int8;
                case TestLabDataFormat.Int16:
                    return TestLabDataFormat.Int16;
                case TestLabDataFormat.Int32:
                    return TestLabDataFormat.Int32;
                case TestLabDataFormat.Float32:
                    return TestLabDataFormat.Float32;
                case (TestLabDataFormat)((int)TestLabDataFormat.Float32 | 0x10):
                    return TestLabDataFormat.Float32;
                case TestLabDataFormat.Float64:
                    return TestLabDataFormat.Float64;
                case (TestLabDataFormat)((int)TestLabDataFormat.Float64 | 0x10):
                    return TestLabDataFormat.Float64;
                default:
                    throw new InvalidOperationException("Формат данных не поддерживается.");
            }
        }

        /// <summary>
        /// Возвращает размер элемента массива данных канала в байтах.
        /// </summary>
        /// <param name="format">
        /// Формат данных.
        /// </param>
        /// <returns>
        /// Размер элемента массива данных канала в байтах.
        /// </returns>
        internal static int GetItemSize(TestLabDataFormat format)
        {
            switch (format)
            {
                case TestLabDataFormat.UInt8:
                    return 1;
                case TestLabDataFormat.UInt16:
                    return 2;
                case TestLabDataFormat.UInt32:
                    return 4;
                case TestLabDataFormat.Int8:
                    return 1;
                case TestLabDataFormat.Int16:
                    return 2;
                case TestLabDataFormat.Int32:
                    return 4;
                case TestLabDataFormat.Float32:
                    return 4;
                case TestLabDataFormat.Float64:
                    return 8;
                default:
                    throw new InvalidOperationException("Формат данных не поддерживается.");
            }
        }
    }
}