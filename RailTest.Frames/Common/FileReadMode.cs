using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailTest.Frames
{
    /// <summary>
    /// Представляет значение, определяющее режим чтения файла кадра регистрации.
    /// </summary>
    [Flags]
    internal enum FileReadMode
    {
        /// <summary>
        /// Режим чтения по умолчанию.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Отключить проверку превышения размера файла.
        /// </summary>
        DisableCheckExceedingFileSize = 1,
    }
}
