using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailTest.Frames
{
    /// <summary>
    /// Значение, определяющее формат данных канала.
    /// </summary>
    internal enum CatmanDataFormat
    {
        /// <summary>
        /// Числовой формат с плавающей точкой двойной точности.
        /// </summary>
        DoubleNumeric = 0,

        /// <summary>
        /// Формат текстовых данных.
        /// </summary>
        String = 1,

        /// <summary>
        /// Формат бинарного объекта.
        /// </summary>
        BinaryObject = 2,

        /// <summary>
        /// Числовой формат с плавающей точкой одинарной точности.
        /// </summary>
        SingleNumeric = 4
    }
}
