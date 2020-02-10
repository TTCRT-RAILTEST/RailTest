using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailTest.Frames
{
    /// <summary>
    /// Представляет точку канала.
    /// </summary>
    internal struct ChannelPoint
    {
        /// <summary>
        /// Поле для хранения индекса точки.
        /// </summary>
        private int _Index;

        /// <summary>
        /// Поле для хранения значения точки.
        /// </summary>
        private double _Value;

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <param name="index">
        /// Индекс точки.
        /// </param>
        /// <param name="value">
        /// Значение точки.
        /// </param>
        public ChannelPoint(int index, double value)
        {
            _Index = index;
            _Value = value;
        }

        /// <summary>
        /// Возвращает или задаёт индекс точки.
        /// </summary>
        public int Index
        {
            get
            {
                return _Index;
            }
            set
            {
                _Index = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт значение точки.
        /// </summary>
        public double Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }
    }
}
