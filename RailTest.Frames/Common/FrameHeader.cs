using System;

namespace RailTest.Frames
{
    /// <summary>
    /// Представляет базовый класс для всех заголовков кадров.
    /// </summary>
    public class FrameHeader : Ancestor
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public FrameHeader() : this(StorageFormat.Simple)
        {

        }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="format">
        /// Формат кадра.
        /// </param>
        internal FrameHeader(StorageFormat format)
        {
            Format = format;
        }

        /// <summary>
        /// Возвращает формат кадра.
        /// </summary>
        public StorageFormat Format { get; }

        /// <summary>
        /// Создаёт копию объекта.
        /// </summary>
        /// <returns>
        /// Копия объекта.
        /// </returns>
        internal virtual FrameHeader Clone()
        {
            if (Format != StorageFormat.Simple)
            {
                throw new NotSupportedException("При попытке создать копию заголовка канала не была найдена функция, реализующая копирование.");
            }
            return new FrameHeader();
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
        internal virtual FrameHeader Convert(StorageFormat format)
        {
            if (format == Format)
            {
                return Clone();
            }
            switch (format)
            {
                case StorageFormat.Simple:
                    return new FrameHeader();
                case StorageFormat.TestLab:
                    return new TestLabFrameHeader();
                case StorageFormat.Catman:
                    return new CatmanFrameHeader();
                case StorageFormat.Mera:
                    throw new Exception();
                default:
                    throw new ArgumentOutOfRangeException("format", "Произошла попытка преобразовать заголовок кадра в неизвестный формат.");
            }
        }
    }
}
