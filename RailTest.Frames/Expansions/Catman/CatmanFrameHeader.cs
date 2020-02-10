using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailTest.Frames
{
    /// <summary>
    /// Представляет заголовок кадра в формате <see cref="StorageFormat.Catman"/>.
    /// </summary>
    internal class CatmanFrameHeader : FrameHeader
    {
        private string _Comment;
        private string[] _Reserve = new string[32];
        private int _MaximumChannelLength;

        /// <summary>
        /// 
        /// </summary>
        public string Comment { get { return _Comment; } set { _Comment = value; } }

        /// <summary>
        /// 
        /// </summary>
        public string[] Reserve { get { return _Reserve; } set { _Reserve = value; } }

        /// <summary>
        /// 
        /// </summary>
        public int MaximumChannelLength { get { return _MaximumChannelLength; } set { _MaximumChannelLength = value; } }

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public CatmanFrameHeader() :
            base(StorageFormat.Catman)
        {
            _Comment = "";
            for (int i = 0; i != 32; ++i)
            {
                _Reserve[i] = "";
            }
            _MaximumChannelLength = 0;
        }

        /// <summary>
        /// Создаёт копию объекта.
        /// </summary>
        /// <returns>
        /// Копия объекта.
        /// </returns>
        internal override FrameHeader Clone()
        {
            CatmanFrameHeader duplicate = new CatmanFrameHeader();
            duplicate.Comment = Comment;
            for (int i = 0; i != 32; ++i)
            {
                duplicate.Reserve[i] = Reserve[i];
            }
            duplicate.MaximumChannelLength = MaximumChannelLength;
            return duplicate;
        }
    }
}