using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailTest.Frames
{
    /// <summary>
    /// Представляет средство чтения файлов регистрации.
    /// </summary>
    internal class FileReader : Ancestor
    {
        /// <summary>
        /// Поле для хранения потока.
        /// </summary>
        private FileStream _Stream;

        /// <summary>
        /// Поле для хранения средства чтения файла.
        /// </summary>
        private BinaryReader _Reader;

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="path">
        /// Пусть к файлу.
        /// </param>
        public FileReader(string path)
        {
            _Stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            _Reader = new BinaryReader(_Stream);
        }

        /// <summary>
        /// Возвращает размер файла в байтах.
        /// </summary>
        public long FileSize
        {
            get
            {
                return _Stream.Length;
            }
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
        
        /// <summary>
        /// Считывает указанное количество байтов из потока, начиная с заданной точки в массиве байтов.
        /// </summary>
        /// <param name="buffer">
        /// Буфер, в который необходимо считать данные.
        /// </param>
        /// <param name="index">
        /// Стартовая точка в буфере, начиная с которой считываемые данные записываются в буфер.
        /// </param>
        /// <param name="count">
        /// Количество байтов, чтение которых необходимо выполнить.
        /// </param>
        /// <returns>
        /// Количество считанных байтов.
        /// </returns>
        public int Read(byte[] buffer, int index, int count)
        {
            return _Reader.Read(buffer, index, count);
        }

        /// <summary>
        /// Считывает указанное количество байтов из текущего потока в массив байтов и перемещает
        /// текущую позицию на это количество байтов.
        /// </summary>
        /// <param name="count">
        /// Количество байтов, чтение которых необходимо выполнить.
        /// </param>
        /// <returns>
        /// Массив байтов, в котором содержатся данные, считанные из базового потока.
        /// </returns>
        public byte[] ReadBytes(int count)
        {
            return _Reader.ReadBytes(count);
        }
        
        /// <summary>
        /// Считывает из текущего потока значение типа <see cref="byte"/>.
        /// </summary>
        /// <returns>
        /// Значение типа <see cref="byte"/>.
        /// </returns>
        public byte ReadUInt8()
        {
            return _Reader.ReadByte();
        }

        /// <summary>
        /// Считывает из текущего потока значение типа <see cref="sbyte"/>.
        /// </summary>
        /// <returns>
        /// Значение типа <see cref="sbyte"/>.
        /// </returns>
        public sbyte ReadInt8()
        {
            return _Reader.ReadSByte();
        }

        /// <summary>
        /// Считывает из текущего потока значение типа <see cref="ushort"/>.
        /// </summary>
        /// <returns>
        /// Значение типа <see cref="ushort"/>.
        /// </returns>
        public ushort ReadUInt16()
        {
            return _Reader.ReadUInt16();
        }

        /// <summary>
        /// Считывает из текущего потока значение типа <see cref="short"/>.
        /// </summary>
        /// <returns>
        /// Значение типа <see cref="short"/>.
        /// </returns>
        public short ReadInt16()
        {
            return _Reader.ReadInt16();
        }

        /// <summary>
        /// Считывает из текущего потока значение типа <see cref="uint"/>.
        /// </summary>
        /// <returns>
        /// Значение типа <see cref="uint"/>.
        /// </returns>
        public uint ReadUInt32()
        {
            return _Reader.ReadUInt32();
        }

        /// <summary>
        /// Считывает из текущего потока значение типа <see cref="int"/>.
        /// </summary>
        /// <returns>
        /// Значение типа <see cref="int"/>.
        /// </returns>
        public int ReadInt32()
        {
            return _Reader.ReadInt32();
        }

        /// <summary>
        /// Считывает из текущего потока значение типа <see cref="ulong"/>.
        /// </summary>
        /// <returns>
        /// Значение типа <see cref="ulong"/>.
        /// </returns>
        public ulong ReadUInt64()
        {
            return _Reader.ReadUInt64();
        }

        /// <summary>
        /// Считывает из текущего потока значение типа <see cref="long"/>.
        /// </summary>
        /// <returns>
        /// Значение типа <see cref="long"/>.
        /// </returns>
        public long ReadInt64()
        {
            return _Reader.ReadInt64();
        }

        /// <summary>
        /// Считывает из текущего потока значение типа <see cref="float"/>.
        /// </summary>
        /// <returns>
        /// Значение типа <see cref="float"/>.
        /// </returns>
        public float ReadFloat32()
        {
            return _Reader.ReadSingle();
        }

        /// <summary>
        /// Считывает из текущего потока значение типа <see cref="double"/>.
        /// </summary>
        /// <returns>
        /// Значение типа <see cref="double"/>.
        /// </returns>
        public double ReadFloat64()
        {
            return _Reader.ReadDouble();
        }

        /// <summary>
        /// Иеняет порядок байтов в последовательности на обратный.
        /// </summary>
        /// <param name="buffer">
        /// Буффер, содержащий байты.
        /// </param>
        private void ReverseBytes(byte[] buffer)
        {
            byte temportal = 0;
            int length = buffer.Length;
            int halfLength = buffer.Length >> 1;
            for (int i = 0; i != halfLength; ++i)
            {
                temportal = buffer[i];
                buffer[i] = buffer[length - i - 1];
                buffer[length - i - 1] = temportal;
            }
        }

        /// <summary>
        /// Считывает из текущего потока значение типа <see cref="ushort"/>.
        /// </summary>
        /// <returns>
        /// Значение типа <see cref="ushort"/>.
        /// </returns>
        public ushort ReadUInt16(bool isBigEndian)
        {
            if (isBigEndian)
            {
                byte[] buffer = new byte[2];
                Read(buffer, 0, 2);
                ReverseBytes(buffer);
                return BitConverter.ToUInt16(buffer, 0);
            }
            else
            {
                return ReadUInt16();
            }
        }

        /// <summary>
        /// Считывает из текущего потока значение типа <see cref="short"/>.
        /// </summary>
        /// <returns>
        /// Значение типа <see cref="short"/>.
        /// </returns>
        public short ReadInt16(bool isBigEndian)
        {
            if (isBigEndian)
            {
                byte[] buffer = new byte[2];
                Read(buffer, 0, 2);
                ReverseBytes(buffer);
                return BitConverter.ToInt16(buffer, 0);
            }
            else
            {
                return ReadInt16();
            }
        }

        /// <summary>
        /// Считывает из текущего потока значение типа <see cref="uint"/>.
        /// </summary>
        /// <returns>
        /// Значение типа <see cref="uint"/>.
        /// </returns>
        public uint ReadUInt32(bool isBigEndian)
        {
            if (isBigEndian)
            {
                byte[] buffer = new byte[4];
                Read(buffer, 0, 4);
                ReverseBytes(buffer);
                return BitConverter.ToUInt32(buffer, 0);
            }
            else
            {
                return ReadUInt32();
            }
        }

        /// <summary>
        /// Считывает из текущего потока значение типа <see cref="int"/>.
        /// </summary>
        /// <returns>
        /// Значение типа <see cref="int"/>.
        /// </returns>
        public int ReadInt32(bool isBigEndian)
        {
            if (isBigEndian)
            {
                byte[] buffer = new byte[4];
                Read(buffer, 0, 4);
                ReverseBytes(buffer);
                return BitConverter.ToInt32(buffer, 0);
            }
            else
            {
                return ReadInt32();
            }
        }

        /// <summary>
        /// Считывает из текущего потока значение типа <see cref="ulong"/>.
        /// </summary>
        /// <returns>
        /// Значение типа <see cref="ulong"/>.
        /// </returns>
        public ulong ReadUInt64(bool isBigEndian)
        {
            if (isBigEndian)
            {
                byte[] buffer = new byte[8];
                Read(buffer, 0, 8);
                ReverseBytes(buffer);
                return BitConverter.ToUInt64(buffer, 0);
            }
            else
            {
                return ReadUInt64();
            }
        }

        /// <summary>
        /// Считывает из текущего потока значение типа <see cref="long"/>.
        /// </summary>
        /// <returns>
        /// Значение типа <see cref="long"/>.
        /// </returns>
        public long ReadInt64(bool isBigEndian)
        {
            if (isBigEndian)
            {
                byte[] buffer = new byte[8];
                Read(buffer, 0, 8);
                ReverseBytes(buffer);
                return BitConverter.ToInt64(buffer, 0);
            }
            else
            {
                return ReadInt64();
            }
        }

        /// <summary>
        /// Считывает из текущего потока значение типа <see cref="float"/>.
        /// </summary>
        /// <returns>
        /// Значение типа <see cref="float"/>.
        /// </returns>
        public float ReadFloat32(bool isBigEndian)
        {
            if (isBigEndian)
            {
                byte[] buffer = new byte[4];
                Read(buffer, 0, 4);
                ReverseBytes(buffer);
                return BitConverter.ToSingle(buffer, 0);
            }
            else
            {
                return ReadFloat32();
            }
        }

        /// <summary>
        /// Считывает из текущего потока значение типа <see cref="double"/>.
        /// </summary>
        /// <returns>
        /// Значение типа <see cref="double"/>.
        /// </returns>
        public double ReadFloat64(bool isBigEndian)
        {
            if (isBigEndian)
            {
                byte[] buffer = new byte[8];
                Read(buffer, 0, 8);
                ReverseBytes(buffer);
                return BitConverter.ToDouble(buffer, 0);
            }
            else
            {
                return ReadFloat64();
            }
        }





        /// <summary>
        /// Закрывает файл.
        /// </summary>
        public void Close()
        {
            _Reader?.Dispose();
            _Reader = null;
            _Stream?.Dispose();
            _Stream = null;
        }
    }
}
