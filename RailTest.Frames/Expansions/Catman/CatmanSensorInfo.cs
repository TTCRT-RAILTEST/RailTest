namespace RailTest.Frames
{
    /// <summary>
    /// Представляет информацию о сенсоре.
    /// </summary>
    internal class CatmanSensorInfo
    {
        /// <summary>
        /// Поле для хранения значения, определяющего учитываются ли свойства датчика в процессе инициализации.
        /// </summary>
        private bool _InUse;

        /// <summary>
        /// Поле для хранения описания.
        /// </summary>
        private string _Description;

        /// <summary>
        /// Поле для хранения идентификатора.
        /// </summary>
        private string _Tid;

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public CatmanSensorInfo() :
            this(false, "", "")
        {

        }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="inUse">
        /// Значение, определяющее учитываются ли свойства датчика в процессе инициализации.
        /// </param>
        /// <param name="description">
        /// Описание.
        /// </param>
        /// <param name="tid">
        /// Идентификатор.
        /// </param>
        public CatmanSensorInfo(bool inUse, string description, string tid)
        {
            _InUse = inUse;
            _Description = description ?? "";
            _Tid = tid ?? "";
        }

        /// <summary>
        /// Возвращает или задаёт значение, определяющее учитываются ли свойства датчика в процессе инициализации.
        /// </summary>
        public bool InUse
        {
            get
            {
                return _InUse;
            }
            set
            {
                _InUse = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт описание.
        /// </summary>
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт идентификатор.
        /// </summary>
        public string Tid
        {
            get
            {
                return _Tid;
            }
            set
            {
                _Tid = value;
            }
        }
    }
}