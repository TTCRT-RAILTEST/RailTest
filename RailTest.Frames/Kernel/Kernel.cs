using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace RailTest.Frames
{
    /// <summary>
    /// Предоставляет механизмы для чтения и записи файлов кадров регистрации.
    /// </summary>
    internal partial class Kernel
    {

        /// <summary>
        /// Загружает данные из файла.
        /// </summary>
        /// <param name="path">
        /// Путь к файлу.
        /// </param>
        /// <param name="readMode">
        /// Значение, определяющее режим чтения файла кадра регистрации.
        /// </param>
        /// <returns>
        /// Данные, загруженные из файла.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Параметр <paramref name="path"/> имеет значение пустой ссылки.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Параметр <paramref name="path"/> является пустой строкой (""),
        /// содержит только пробелы или содержит один или несколько недопустимых знаков.
        /// -или-
        /// <paramref name="path"/> ссылается на устройство,
        /// которое не является файловым, например "con:", "com1:", "lpt1:" и т. д., в среде NTFS.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Параметр path является пустой строкой (""), содержит только пробелы или содержит
        /// один или несколько недопустимых знаков.
        /// </exception>
        /// <exception cref="NotSupportedException">
        /// path ссылается на устройство, которое не является файловым, например "con:", "com1:", "lpt1:" и т. д., в среде, отличной от NTFS.
        /// </exception>
        /// <exception cref="FileNotFoundException">
        /// Невозможно найти файл, например, когда mode содержит FileMode.Truncate или FileMode.Open,
        /// а файл, заданный в path, не существует.Файл должен уже существовать в этих режимах.
        /// </exception>
        /// <exception cref="IOException">
        /// Произошла ошибка ввода-вывода, например, задано FileMode.CreateNew, когда файл,
        /// указанный в path, уже существует. – или –Компьютер работает под управлением операционной
        /// системы Windows 98 или Windows 98 Second Edition, и для параметра share задано
        /// значение FileShare.Delete.– или –Поток закрыт.
        /// </exception>
        /// <exception cref="SecurityException">
        /// У вызывающего объекта отсутствует необходимое разрешение.
        /// </exception>
        /// <exception cref="DirectoryNotFoundException">
        /// Указанный путь недопустим; возможно, он соответствует неподключенному диску.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">
        /// Запрошенный параметр access не разрешен операционной системой для заданного path,
        /// например, когда параметр access равен Write или ReadWrite, а файл или каталог
        /// установлены на доступ только для чтения.
        /// </exception>
        /// <exception cref="PathTooLongException">
        /// Длина указанного пути, имени файла или обоих параметров превышает установленное
        /// в системе максимальное значение.Например, для платформ на основе Windows длина
        /// пути не должна превышать 248 символов, а имена файлов не должны содержать более
        /// 260 символов.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Параметр mode содержит недопустимое значение.
        /// </exception>
        public static Tuple<FrameHeader, ChannelCollection> LoadFrame(string path, FileReadMode readMode)
        {
            FileReader reader = null;
            try
            {
                reader = new FileReader(path);
                long fileSize = reader.FileSize;

                reader.Position = 0;
                if (fileSize >= 350 && reader.ReadUInt64() == 0x42414C54534554UL)
                {
                    return LoadTestLabFrame(path, reader, readMode);
                }

                reader.Position = 0;
                if (fileSize >= 2 && reader.ReadInt16() == 0x1394)
                {
                    return LoadCatmanFrame(path, reader, readMode);
                }
            }
            finally
            {
                reader?.Close();
            }
            throw new InvalidDataException("Произошла попытка загрузить файл неизвестного формата.");
        }

        public static void SaveFrame(string path, StorageFormat format, Frame frame)
        {
            FileWriter writer = null;
            try
            {
                writer = new FileWriter(path);
                switch (format)
                {
                    case StorageFormat.Simple:
                        throw new Exception();
                    case StorageFormat.TestLab:
                        SaveTestLabFrame(frame, writer);
                        break;
                    case StorageFormat.Catman:
                        SaveCatmanFrame(frame, writer);
                        break;
                    case StorageFormat.Mera:
                        throw new Exception();
                    default:
                        throw new ArgumentOutOfRangeException("format", "Произошла попытка сохранить кадр в неизвестном формате.");
                }
            }
            finally
            {
                writer?.Close();
            }
        }
    }
}
