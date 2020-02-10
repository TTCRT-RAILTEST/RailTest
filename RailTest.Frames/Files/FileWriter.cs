using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailTest.Frames
{
    /// <summary>
    /// Представляет средство записи файлов регистрации.
    /// </summary>
    internal class FileWriter
    {
        /// <summary>
        /// Поле для хранения потока.
        /// </summary>
        private FileStream _Stream;

        /// <summary>
        /// Поле для хранения средства записи в файл.
        /// </summary>
        private BinaryWriter _Writer;

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="path">
        /// Пусть к файлу.
        /// </param>
        public FileWriter(string path)
        {
            _Stream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            _Writer = new BinaryWriter(_Stream);
        }

        /// <summary>
        /// Получает или задает текущую позицию в файле.
        /// </summary>
        public long Position
        {
            get
            {
                return _Stream.Position;
            }
            set
            {
                _Stream.Position = value;
            }
        }

        public void Write(byte[] buffer, int index, int count)
        {
            _Writer.Write(buffer, index, count);
        }

        public void WriteUInt8(byte value)
        {
            _Writer.Write((byte)value);
        }

        public void WriteInt8(sbyte value)
        {
            _Writer.Write((sbyte)value);
        }

        public void WriteUInt16(ushort value)
        {
            _Writer.Write((ushort)value);
        }

        public void WriteInt16(short value)
        {
            _Writer.Write((short)value);
        }

        public void WriteUInt32(uint value)
        {
            _Writer.Write((uint)value);
        }

        public void WriteInt32(int value)
        {
            _Writer.Write((int)value);
        }

        public void WriteUInt64(ulong value)
        {
            _Writer.Write((ulong)value);
        }

        public void WriteInt64(long value)
        {
            _Writer.Write((long)value);
        }

        public void WriteFloat32(float value)
        {
            _Writer.Write((float)value);
        }

        public void WriteFloat64(double value)
        {
            _Writer.Write((double)value);
        }

        /// <summary>
        /// Закрывает файл.
        /// </summary>
        public void Close()
        {
            _Writer?.Flush();
            _Stream?.Flush();

            _Writer?.Dispose();
            _Writer = null;

            _Stream?.Dispose();
            _Stream = null;
        }
    }
}
