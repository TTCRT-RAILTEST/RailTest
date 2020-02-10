using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailTest.Frames
{
    /// <summary>
    /// Представляет заголовок канала в формате <see cref="StorageFormat.Catman"/>.
    /// </summary>
    internal class CatmanChannelHeader : ChannelHeader
    {
        /// <summary>
        /// Поле для хранения положения канала в базе данных Catman.
        /// </summary>
        private int _LocationInDatabase;

        /// <summary>
        /// Поле для хранения коментария к каналу.
        /// </summary>
        private string _Comment;

        /// <summary>
        /// Поле для хранения формата данных канала.
        /// </summary>
        private CatmanDataFormat _DataFormat;

        /// <summary>
        /// Поле для хранения ширины данных в байтах.
        /// </summary>
        private int _DataWidth;

        /// <summary>
        /// Поле для хранения даты и времени измерения.
        /// </summary>
        private DateTime _Time;

        /// <summary>
        /// Поле для хранения размера дополнительного заголовка канала в байтах.
        /// </summary>
        private int _SizeOfExtendedHeader;

        /// <summary>
        /// Поле для хранения времени начала измерений.
        /// </summary>
        private DateTime _StartTime;

        /// <summary>
        /// Поле для хранения шага времени выборки.
        /// </summary>
        private double _SamplingTimeStep;

        /// <summary>
        /// Поле для хранения кода типа датчика.
        /// </summary>
        private CatmanCodeOfSensorType _CodeOfSensorType;

        /// <summary>
        /// Поле для хранения кода напряжения питания.
        /// </summary>
        private CatmanCodeOfSupplyVoltage _CodeOfSupplyVoltage;

        /// <summary>
        /// Поле для хранения кода характеристик фильтра.
        /// </summary>
        private CatmanCodeOfFilterCharacteristics _CodeOfFilterCharacteristics;

        /// <summary>
        /// Поле для хранения кода частоты фильтра.
        /// </summary>
        private CatmanCodeOfFilterFrequency _CodeOfFilterFrequency;

        /// <summary>
        /// Поле для хранения значения тары.
        /// </summary>
        private double _TareValue;

        /// <summary>
        /// Поле для хранения нулевого значения.
        /// </summary>
        private double _ZeroValue;

        /// <summary>
        /// Поле для хранения кода измерительного диапазона.
        /// </summary>
        private CatmanCodeOfMeasuringRange _CodeOfMeasuringRange;

        /// <summary>
        /// Поле для хранения входных характеристик.
        /// </summary>
        private double[] _InputCharacteristics;

        /// <summary>
        /// Поле для хранения серийного номера усилителя.
        /// </summary>
        private string _AmplifierSerialNumber;

        /// <summary>
        /// Поле для хранения физической единицы измерения.
        /// </summary>
        private string _PhysicalUnit;

        /// <summary>
        /// Поле для хранения исходной единицы измерения.
        /// </summary>
        private string _NativeUnit;

        /// <summary>
        /// Поле для хранения номера слота оборудования.
        /// </summary>
        private int _HardwareSlotNumber;

        /// <summary>
        /// Поле для хранения номера подканала или 0, если одноканальный слот.
        /// </summary>
        private int _HardwareSubSlotNumber;

        /// <summary>
        /// Поле для хранения кода усилителя.
        /// </summary>
        private int _CodeOfAmplifierType;

        /// <summary>
        /// Поле для хранения кода типа соединителя AP.
        /// </summary>
        private int _CodeOfAPConnectorType;

        /// <summary>
        /// Поле для хранения коэффициента заполнения, используемого в измерениях тензодатчиков.
        /// </summary>
        private double _GageFactor;

        /// <summary>
        /// Поле для хранения мостового коэффициента, используемого в измерениях тензодатчиков.
        /// </summary>
        private double _BridgeFactor;

        /// <summary>
        /// Поле для хранения кода измерительного сигнала.
        /// </summary>
        private int _CodeOfMeasurementSignal;

        /// <summary>
        /// Поле для хранения кода входного усилителя.
        /// </summary>
        private int _CodeOfAmplifierInput;

        /// <summary>
        /// Поле для хранения кода фильтра высоких частот.
        /// </summary>
        private int _CodeOfHighpassFilter;

        /// <summary>
        /// Поле для хранения специальной информации, используемой в заголовках файлов онлайн-экспорта.
        /// </summary>
        private int _OnlineImportInfo;

        /// <summary>
        /// Поле для хранения кода типа шкалы.
        /// </summary>
        private int _CodeOfScaleType;

        /// <summary>
        /// Поле для хранения программного нуля (тары) для каналов, имеющих пользовательскую шкалу.
        /// </summary>
        private double _SoftwareZeroValue;

        /// <summary>
        /// Поле для хранения защиты от записи. Если не ноль, то доступ на запись запрещен.
        /// </summary>
        private int _WriteProtected;

        /// <summary>
        /// Поле для хранения данных для выравнивания структуры данных.
        /// </summary>
        private byte[] _Alignment;

        /// <summary>
        /// Поле для хранения номинального диапазона.
        /// </summary>
        private double _NominalRange;

        /// <summary>
        /// Поле для хранения коэффициента компенсации длины кабеля.
        /// </summary>
        private double _CableLengthCompensation;

        /// <summary>
        /// Поле для хранения формата экспортируемых данных.
        /// </summary>
        private int _ExportFormat;

        /// <summary>
        /// Поле для хранения типа канала.
        /// </summary>
        private int _ChannelType;

        /// <summary>
        /// Поле для хранения соединителя на слое системы сбора данных.
        /// </summary>
        private int _EDaqConnectorOnLayer;

        /// <summary>
        /// Поле для хранения слоя системы сбора данных.
        /// </summary>
        private int _EDaqLayer;

        /// <summary>
        /// Поле для хранения типа содержимого.
        /// </summary>
        private int _ContentType;

        /// <summary>
        /// Поле для хранения зарезервированных данных.
        /// </summary>
        private byte[] _Reserved;

        /// <summary>
        /// Поле для хранения режима линеаризации.
        /// </summary>
        private int _LinearisationMode;

        /// <summary>
        /// Поле для хранения типа пользовательского масштаба.
        /// </summary>
        private int _UserScaleType;

        /// <summary>
        /// Поле для хранения количества точек для таблицы пользовательского масштаба.
        /// </summary>
        private int _NumberOfPointsScaleTable;

        /// <summary>
        /// Поле для хранения серии значений таблицы пользовательского масштаба.
        /// Значения зависят от типа масштабирования.
        /// </summary>
        private double[] _PointsScaleTable;

        /// <summary>
        /// Поле для хранения термо-типа.
        /// </summary>
        private int _ThermoType;

        /// <summary>
        /// Поле для хранения формулы.
        /// </summary>
        private string _Formula;

        /// <summary>
        /// Поле для хранения информации о сенсоре.
        /// </summary>
        private CatmanSensorInfo _SensorInfo;

        /// <summary>
        /// Поле для хранения формата строки.
        /// </summary>
        private string _FormatString;

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public CatmanChannelHeader() : base(StorageFormat.Catman)
        {
            _LocationInDatabase = 0;
            _Comment = "";
            _DataFormat = CatmanDataFormat.DoubleNumeric;
            _DataWidth = 8;
            _Time = DateTime.Now;
            _SizeOfExtendedHeader = 148;
            _StartTime = DateTime.Now;
            _SamplingTimeStep = 0;
            _CodeOfSensorType = CatmanCodeOfSensorType.StrainGageFullBridge120Ohms;
            _CodeOfSupplyVoltage = CatmanCodeOfSupplyVoltage.Voltage2_5;
            _CodeOfFilterCharacteristics = CatmanCodeOfFilterCharacteristics.NoFilter;
            _CodeOfFilterFrequency = CatmanCodeOfFilterFrequency.FrequencyNone;
            _TareValue = 0;
            _ZeroValue = 0;
            _CodeOfMeasuringRange = CatmanCodeOfMeasuringRange.Range1000mV;
            _InputCharacteristics = new double[4];
            _InputCharacteristics[0] = 0;
            _InputCharacteristics[1] = 0;
            _InputCharacteristics[2] = 1;
            _InputCharacteristics[3] = 1;
            _AmplifierSerialNumber = "";
            _PhysicalUnit = "";
            _NativeUnit = "";
            _HardwareSlotNumber = 0;
            _HardwareSubSlotNumber = 0;
            _CodeOfAmplifierType = 0;
            _CodeOfAPConnectorType = 0;
            _GageFactor = 0;
            _BridgeFactor = 0;
            _CodeOfMeasurementSignal = 0;
            _CodeOfAmplifierInput = 0;
            _CodeOfHighpassFilter = 0;
            _OnlineImportInfo = 0;
            _CodeOfScaleType = 0;
            _SoftwareZeroValue = 0;
            _WriteProtected = 0;
            _Alignment = new byte[3];
            _Alignment[0] = 0;
            _Alignment[1] = 0;
            _Alignment[2] = 0;
            _NominalRange = 0;
            _CableLengthCompensation = 0;
            _ExportFormat = 0;
            _ChannelType = 0;
            _EDaqConnectorOnLayer = 0;
            _EDaqLayer = 0;
            _ContentType = 0;
            _Reserved = new byte[3];
            _Reserved[0] = 0;
            _Reserved[1] = 0;
            _Reserved[2] = 0;
            _LinearisationMode = 0;
            _UserScaleType = 0;
            _NumberOfPointsScaleTable = 4;
            _PointsScaleTable = new double[4];
            _PointsScaleTable[0] = 0;
            _PointsScaleTable[1] = 0;
            _PointsScaleTable[2] = 1;
            _PointsScaleTable[3] = 1;
            _ThermoType = 0;
            _Formula = "";
            _SensorInfo = new CatmanSensorInfo();
            _FormatString = "0.0000";
        }

        /// <summary>
        /// Возвращает или задаёт положение канала в базе данных Catman.
        /// </summary>
        public int LocationInDatabase
        {
            get
            {
                return _LocationInDatabase;
            }
            set
            {
                _LocationInDatabase = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт коментарий к каналу.
        /// </summary>
        public string Comment
        {
            get
            {
                return _Comment;
            }
            set
            {
                _Comment = value ?? "";
            }
        }

        /// <summary>
        /// Возвращает или задаёт формат данных канала.
        /// </summary>
        public CatmanDataFormat DataFormat
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
        /// Возвращает или задаёт ширину данных в байтах.
        /// </summary>
        public int DataWidth
        {
            get
            {
                return _DataWidth;
            }
            set
            {
                _DataWidth = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт дату и время измерения.
        /// </summary>
        public DateTime Time
        {
            get
            {
                return _Time;
            }
            set
            {
                _Time = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт размер дополнительного заголовка канала в байтах.
        /// </summary>
        public int SizeOfExtendedHeader
        {
            get
            {
                return _SizeOfExtendedHeader;
            }
            set
            {
                _SizeOfExtendedHeader = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт время начала измерений.
        /// </summary>
        public DateTime StartTime
        {
            get
            {
                return _StartTime;
            }
            set
            {
                _StartTime = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт шаг времени выборки.
        /// </summary>
        public double SamplingTimeStep
        {
            get
            {
                return _SamplingTimeStep;
            }
            set
            {
                Sampling = 1000 / value;
                _SamplingTimeStep = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт код типа датчика.
        /// </summary>
        public CatmanCodeOfSensorType CodeOfSensorType
        {
            get
            {
                return _CodeOfSensorType;
            }
            set
            {
                _CodeOfSensorType = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт код напряжения питания.
        /// </summary>
        public CatmanCodeOfSupplyVoltage CodeOfSupplyVoltage
        {
            get
            {
                return _CodeOfSupplyVoltage;
            }
            set
            {
                _CodeOfSupplyVoltage = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт код характеристик фильтра.
        /// </summary>
        public CatmanCodeOfFilterCharacteristics CodeOfFilterCharacteristics
        {
            get
            {
                return _CodeOfFilterCharacteristics;
            }
            set
            {
                _CodeOfFilterCharacteristics = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт код частоты фильтра.
        /// </summary>
        public CatmanCodeOfFilterFrequency CodeOfFilterFrequency
        {
            get
            {
                return _CodeOfFilterFrequency;
            }
            set
            {
                _CodeOfFilterFrequency = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт значение тары.
        /// </summary>
        public double TareValue
        {
            get
            {
                return _TareValue;
            }
            set
            {
                _TareValue = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт нулевое значение.
        /// </summary>
        public double ZeroValue
        {
            get
            {
                return _ZeroValue;
            }
            set
            {
                _ZeroValue = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт код измерительного диапазона.
        /// </summary>
        public CatmanCodeOfMeasuringRange CodeOfMeasuringRange
        {
            get
            {
                return _CodeOfMeasuringRange;
            }
            set
            {
                _CodeOfMeasuringRange = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт входные характеристики.
        /// </summary>
        public double[] InputCharacteristics
        {
            get
            {
                return _InputCharacteristics;
            }
            set
            {
                _InputCharacteristics = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт серийный номер усилителя.
        /// </summary>
        public string AmplifierSerialNumber
        {
            get
            {
                return _AmplifierSerialNumber;
            }
            set
            {
                _AmplifierSerialNumber = value ?? "";
            }
        }

        /// <summary>
        /// Возвращает или задаёт физическую единицу измерения.
        /// </summary>
        public string PhysicalUnit
        {
            get
            {
                return _PhysicalUnit;
            }
            set
            {
                _PhysicalUnit = value ?? "";
            }
        }

        /// <summary>
        /// Возвращает или задаёт исходную единицу измерения.
        /// </summary>
        public string NativeUnit
        {
            get
            {
                return _NativeUnit;
            }
            set
            {
                _NativeUnit = value ?? "";
            }
        }

        /// <summary>
        /// Возвращает или задаёт номер слота оборудования.
        /// </summary>
        public int HardwareSlotNumber
        {
            get
            {
                return _HardwareSlotNumber;
            }
            set
            {
                _HardwareSlotNumber = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт номер подканала.
        /// </summary>
        public int HardwareSubSlotNumber
        {
            get
            {
                return _HardwareSubSlotNumber;
            }
            set
            {
                _HardwareSubSlotNumber = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт код усилителя.
        /// </summary>
        public int CodeOfAmplifierType
        {
            get
            {
                return _CodeOfAmplifierType;
            }
            set
            {
                _CodeOfAmplifierType = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт код типа соединителя AP.
        /// </summary>
        public int CodeOfAPConnectorType
        {
            get
            {
                return _CodeOfAPConnectorType;
            }
            set
            {
                _CodeOfAPConnectorType = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт коэффициент заполнения, используемый в измерениях тензодатчиков.
        /// </summary>
        public double GageFactor
        {
            get
            {
                return _GageFactor;
            }
            set
            {
                _GageFactor = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт мостовой коэффициент, используемый в измерениях тензодатчиков.
        /// </summary>
        public double BridgeFactor
        {
            get
            {
                return _BridgeFactor;
            }
            set
            {
                _BridgeFactor = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт код измерительного сигнала.
        /// </summary>
        public int CodeOfMeasurementSignal
        {
            get
            {
                return _CodeOfMeasurementSignal;
            }
            set
            {
                _CodeOfMeasurementSignal = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт код входного усилителя.
        /// </summary>
        public int CodeOfAmplifierInput
        {
            get
            {
                return _CodeOfAmplifierInput;
            }
            set
            {
                _CodeOfAmplifierInput = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт код фильтра высоких частот.
        /// </summary>
        public int CodeOfHighpassFilter
        {
            get
            {
                return _CodeOfHighpassFilter;
            }
            set
            {
                _CodeOfHighpassFilter = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт специальную информацию, используемую в заголовках файлов онлайн-экспорта.
        /// </summary>
        public int OnlineImportInfo
        {
            get
            {
                return _OnlineImportInfo;
            }
            set
            {
                _OnlineImportInfo = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт код типа шкалы.
        /// </summary>
        public int CodeOfScaleType
        {
            get
            {
                return _CodeOfScaleType;
            }
            set
            {
                _CodeOfScaleType = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт программный нуль (тару) для каналов, имеющих пользовательскую шкалу.
        /// </summary>
        public double SoftwareZeroValue
        {
            get
            {
                return _SoftwareZeroValue;
            }
            set
            {
                _SoftwareZeroValue = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт защиту от записи. Если не ноль, то доступ на запись запрещен.
        /// </summary>
        public int WriteProtected
        {
            get
            {
                return _WriteProtected;
            }
            set
            {
                _WriteProtected = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт данные для выравнивания структуры данных.
        /// </summary>
        public byte[] Alignment
        {
            get
            {
                return _Alignment;
            }
            set
            {
                _Alignment = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт номинальный диапазон.
        /// </summary>
        public double NominalRange
        {
            get
            {
                return _NominalRange;
            }
            set
            {
                _NominalRange = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт коэффициент компенсации длины кабеля.
        /// </summary>
        public double CableLengthCompensation
        {
            get
            {
                return _CableLengthCompensation;
            }
            set
            {
                _CableLengthCompensation = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт формат экспортируемых данных.
        /// </summary>
        public int ExportFormat
        {
            get
            {
                return _ExportFormat;
            }
            set
            {
                _ExportFormat = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт тип канала.
        /// </summary>
        public int ChannelType
        {
            get
            {
                return _ChannelType;
            }
            set
            {
                _ChannelType = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт соединитель на слое системы сбора данных.
        /// </summary>
        public int EDaqConnectorOnLayer
        {
            get
            {
                return _EDaqConnectorOnLayer;
            }
            set
            {
                _EDaqConnectorOnLayer = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт слой системы сбора данных.
        /// </summary>
        public int EDaqLayer
        {
            get
            {
                return _EDaqLayer;
            }
            set
            {
                _EDaqLayer = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт тип содержимого.
        /// </summary>
        public int ContentType
        {
            get
            {
                return _ContentType;
            }
            set
            {
                _ContentType = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт зарезервированные данные.
        /// </summary>
        public byte[] Reserved
        {
            get
            {
                return _Reserved;
            }
            set
            {
                _Reserved = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт режим линеаризации.
        /// </summary>
        public int LinearisationMode
        {
            get
            {
                return _LinearisationMode;
            }
            set
            {
                _LinearisationMode = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт тип пользовательского масштаба.
        /// </summary>
        public int UserScaleType
        {
            get
            {
                return _UserScaleType;
            }
            set
            {
                _UserScaleType = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт количество точек для таблицы пользовательского масштаба.
        /// </summary>
        public int NumberOfPointsScaleTable
        {
            get
            {
                return _NumberOfPointsScaleTable;
            }
            set
            {
                _NumberOfPointsScaleTable = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт серию значений таблицы пользовательского масштаба.
        /// Значения зависят от типа масштабирования.
        /// </summary>
        public double[] PointsScaleTable
        {
            get
            {
                return _PointsScaleTable;
            }
            set
            {
                _PointsScaleTable = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт термо-тип.
        /// </summary>
        public int ThermoType
        {
            get
            {
                return _ThermoType;
            }
            set
            {
                _ThermoType = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт формулу.
        /// </summary>
        public string Formula
        {
            get
            {
                return _Formula;
            }
            set
            {
                _Formula = value ?? "";
            }
        }

        /// <summary>
        /// Возвращает или задаёт информацию о сенсоре.
        /// </summary>
        public CatmanSensorInfo SensorInfo
        {
            get
            {
                return _SensorInfo;
            }
            set
            {
                _SensorInfo = value ?? new CatmanSensorInfo();
            }
        }

        /// <summary>
        /// Возвращает формат строки.
        /// </summary>
        public string FormatString
        {
            get
            {
                return _FormatString;
            }
            set
            {
                _FormatString = value ?? "";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public double MinValueFactor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double MaxValueFactor { get; set; }


        /// <summary>
        /// Создаёт копию объекта.
        /// </summary>
        /// <returns>
        /// Копия объекта.
        /// </returns>
        internal override ChannelHeader Clone()
        {
            CatmanChannelHeader header = new CatmanChannelHeader();
            header.Name = Name;
            header.Unit = Unit;
            header.Sampling = Sampling;
            header.Cutoff = Cutoff;

            header.LocationInDatabase = LocationInDatabase;
            header.Comment = Comment;
            header.DataFormat = DataFormat;
            header.DataWidth = DataWidth;
            header.Time = Time;
            header.SizeOfExtendedHeader = SizeOfExtendedHeader;
            header.StartTime = StartTime;
            header.SamplingTimeStep = SamplingTimeStep;
            header.CodeOfSensorType = CodeOfSensorType;
            header.CodeOfSupplyVoltage = CodeOfSupplyVoltage;
            header.CodeOfFilterCharacteristics = CodeOfFilterCharacteristics;
            header.CodeOfFilterFrequency = CodeOfFilterFrequency;
            header.TareValue = TareValue;
            header.ZeroValue = ZeroValue;
            header.CodeOfMeasuringRange = CodeOfMeasuringRange;
            header.AmplifierSerialNumber = AmplifierSerialNumber;
            header.PhysicalUnit = PhysicalUnit;
            header.NativeUnit = NativeUnit;
            header.HardwareSlotNumber = HardwareSlotNumber;
            header.HardwareSubSlotNumber = HardwareSubSlotNumber;
            header.CodeOfAmplifierType = CodeOfAmplifierType;
            header.CodeOfAPConnectorType = CodeOfAPConnectorType;
            header.GageFactor = GageFactor;
            header.BridgeFactor = BridgeFactor;
            header.CodeOfMeasurementSignal = CodeOfMeasurementSignal;
            header.CodeOfAmplifierInput = CodeOfAmplifierInput;
            header.CodeOfHighpassFilter = CodeOfHighpassFilter;
            header.OnlineImportInfo = OnlineImportInfo;
            header.CodeOfScaleType = CodeOfScaleType;
            header.SoftwareZeroValue = SoftwareZeroValue;
            header.WriteProtected = WriteProtected;
            header.NominalRange = NominalRange;
            header.CableLengthCompensation = CableLengthCompensation;
            header.ExportFormat = ExportFormat;
            header.ChannelType = ChannelType;
            header.EDaqConnectorOnLayer = EDaqConnectorOnLayer;
            header.EDaqLayer = EDaqLayer;
            header.ContentType = ContentType;
            header.LinearisationMode = LinearisationMode;
            header.UserScaleType = UserScaleType;
            header.NumberOfPointsScaleTable = NumberOfPointsScaleTable;
            header.ThermoType = ThermoType;
            header.Formula = Formula;
            header.FormatString = FormatString;
            header.MinValueFactor = MinValueFactor;
            header.MaxValueFactor = MaxValueFactor;

            if (InputCharacteristics != null)
            {
                header.InputCharacteristics = new double[InputCharacteristics.Length];
                for (int i = 0; i != InputCharacteristics.Length; ++i)
                {
                    header.InputCharacteristics[i] = InputCharacteristics[i];
                }
            }

            if (Alignment != null)
            {
                header.Alignment = new byte[Alignment.Length];
                for (int i = 0; i != Alignment.Length; ++i)
                {
                    header.Alignment[i] = Alignment[i];
                }
            }

            if (Reserved != null)
            {
                header.Reserved = new byte[Reserved.Length];
                for (int i = 0; i != Reserved.Length; ++i)
                {
                    header.Reserved[i] = Reserved[i];
                }
            }

            if (PointsScaleTable != null)
            {
                header.PointsScaleTable = new double[PointsScaleTable.Length];
                for (int i = 0; i != PointsScaleTable.Length; ++i)
                {
                    header.PointsScaleTable[i] = PointsScaleTable[i];
                }
            }

            header.SensorInfo = new CatmanSensorInfo();

            header.SensorInfo.InUse = SensorInfo.InUse;
            header.SensorInfo.Description = SensorInfo.Description;
            header.SensorInfo.Tid = SensorInfo.Tid;

            return header;
        }
        
        /// <summary>
        /// Вызывает событие <see cref="ChannelHeader.SamplingChanged"/>.
        /// </summary>
        /// <param name="e">
        /// Аргументы, связанные с событием.
        /// </param>
        protected override void OnSamplingChanged(EventArgs e)
        {
            SamplingTimeStep = 1000 / Sampling;
            base.OnSamplingChanged(e);
        }
    }
}


/*

namespace RailTest.Frames
{
    public class CatmanChannelHeader 
    {



        /// <summary>
        /// Создает новый объект, являющийся копией текущего экземпляра.
        /// </summary>
        /// <returns>
        /// Новый объект, являющийся копией этого экземпляра.
        /// </returns>
        public override ChannelHeader Clone()
        {
            throw TemporaryException;
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
        public override ChannelHeader Convert(StorageFormat format)
        {
            throw TemporaryException;
        }

        /// <summary>
        /// Возвращает размер в байтах.
        /// </summary>
        internal override int SizeInBytes
        {
            get
            {
                throw TemporaryException;
            }
        }

        /// <summary>
        /// Возвращает размер данных канала в байтах.
        /// </summary>
        /// <param name="length">
        /// Длина канала.
        /// </param>
        /// <returns>
        /// Размер данных канала в байтах.
        /// </returns>
        internal override int GetDataSizeInBytes(int length)
        {
            throw TemporaryException;
        }
    }
}

     
     */
