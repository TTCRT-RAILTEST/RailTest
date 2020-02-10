using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailTest.Frames
{
    /// <summary>
    /// Представляет значение, определяющее код измерительного диапазона.
    /// </summary>
    internal enum CatmanCodeOfMeasuringRange
    {
        /// <summary>
        /// Измерительный диапазон: 3 мВ/В.
        /// </summary>
        Range3mV_V = 700,

        /// <summary>
        /// Измерительный диапазон: 12 мВ/В.
        /// </summary>
        Range12mV_V = 701,

        /// <summary>
        /// Измерительный диапазон: 125 мВ/В.
        /// </summary>
        Range125mV_V = 702,

        /// <summary>
        /// Измерительный диапазон: 500 мВ/В.
        /// </summary>
        Range500mV_V = 703,

        /// <summary>
        /// Измерительный диапазон: 0.1 В.
        /// </summary>
        Range0_1V = 710,

        /// <summary>
        /// Измерительный диапазон: 1 В.
        /// </summary>
        Range1V = 711,

        /// <summary>
        /// Измерительный диапазон: 10 В.
        /// </summary>
        Range10V = 712,

        /// <summary>
        /// Измерительный диапазон: 20 мА.
        /// </summary>
        Range20mA = 720,

        /// <summary>
        /// Измерительный диапазон: 200 мА.
        /// </summary>
        Range200mA = 721,

        /// <summary>
        /// Измерительный диапазон: 0.4 кОм.
        /// </summary>
        Range0_4kOhm = 730,

        /// <summary>
        /// Измерительный диапазон: 4 кОм.
        /// </summary>
        Range4kOhm = 731,

        /// <summary>
        /// Измерительный диапазон: 1 МГц.
        /// </summary>
        Range1MHz = 740,

        /// <summary>
        /// Измерительный диапазон: 100 кГц.
        /// </summary>
        Range100kHz = 741,

        /// <summary>
        /// Измерительный диапазон: 10 кГц.
        /// </summary>
        Range10kHz = 742,

        /// <summary>
        /// Измерительный диапазон: 1 кГц.
        /// </summary>
        Range1kHz = 743,

        /// <summary>
        /// Измерительный диапазон: 100 Гц.
        /// </summary>
        Range100Hz = 744,

        /// <summary>
        /// Измерительный диапазон: 10 мс.
        /// </summary>
        Range10ms = 750,

        /// <summary>
        /// Измерительный диапазон: 100 мс.
        /// </summary>
        Range100ms = 751,

        /// <summary>
        /// Измерительный диапазон: 1 с.
        /// </summary>
        Range1s = 752,

        /// <summary>
        /// Измерительный диапазон: 10 с.
        /// </summary>
        Range10s = 753,

        /// <summary>
        /// Измерительный диапазон: 100 с.
        /// </summary>
        Range100s = 754,

        /// <summary>
        /// Счётчик.
        /// </summary>
        RangeCounter = 760,

        /// <summary>
        /// Счётчик 2x.
        /// </summary>
        RangeCounter2x = 761,

        /// <summary>
        /// Измерительный диапазон: 6 мВ.
        /// </summary>
        Range6mV = 771,

        /// <summary>
        /// Измерительный диапазон: 15 мВ.
        /// </summary>
        Range15mV = 772,

        /// <summary>
        /// Измерительный диапазон: 50 мВ.
        /// </summary>
        Range50mV = 773,

        /// <summary>
        /// Измерительный диапазон: 100 мВ.
        /// </summary>
        Range100mV = 774,

        /// <summary>
        /// Измерительный диапазон: 250 мВ.
        /// </summary>
        Range250mV = 775,

        /// <summary>
        /// Измерительный диапазон: 1000 мВ.
        /// </summary>
        Range1000mV = 776,

        /// <summary>
        /// Измерительный диапазон: 2500 мВ.
        /// </summary>
        Range2500mV = 777,
    }
}
