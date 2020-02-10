using System;

namespace RailTest.Frames
{
    /// <summary>
    /// Представляет кадр регистрации.
    /// </summary>
    public class Frame : Ancestor
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public Frame() : this(new FrameHeader())
        {

        }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="path">
        /// Путь к файлу.
        /// </param>
        public Frame(string path) : this(path, FileReadMode.DisableCheckExceedingFileSize)
        {

        }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="path">
        /// Путь к файлу.
        /// </param>
        /// <param name="readMode">
        /// Значение, определяющее режим чтения файла кадра регистрации.
        /// </param>
        internal Frame(string path, FileReadMode readMode)
        {
            Tuple<FrameHeader, ChannelCollection> tuple = Kernel.LoadFrame(path, readMode);
            Header = tuple.Item1;
            Channels = tuple.Item2;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="header">
        /// Заголовок кадра.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Происходит в случае, если в параметре <paramref name="header"/> была передана пустая ссылка.
        /// </exception>
        internal Frame(FrameHeader header)
        {
            Header = header ?? throw new ArgumentNullException("header", "Передана пустая ссылка.");
            Channels = new ChannelCollection();
        }

        /// <summary>
        /// Возвращает заголовок кадра.
        /// </summary>
        public FrameHeader Header { get; }

        /// <summary>
        /// Возвращает коллекцию каналов.
        /// </summary>
        public ChannelCollection Channels { get; }

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
        /// Сохраняет кадр в файл.
        /// </summary>
        /// <param name="path">
        /// Путь к файлу.
        /// </param>
        public void Save(string path)
        {
            Save(path, Format);
        }

        /// <summary>
        /// Сохраняет кадр в файл.
        /// </summary>
        /// <param name="path">
        /// Путь к файлу.
        /// </param>
        /// <param name="format">
        /// Формат хранения элементов кадра регистрации.
        /// </param>
        public void Save(string path, StorageFormat format)
        {
            Kernel.SaveFrame(path, format, this);
        }
    }
}
