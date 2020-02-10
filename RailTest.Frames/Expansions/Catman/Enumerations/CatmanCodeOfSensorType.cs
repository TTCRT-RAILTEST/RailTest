using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailTest.Frames
{
    /// <summary>
    /// Представляет значение, определяющее код типа датчика.
    /// </summary>
    internal enum CatmanCodeOfSensorType
    {
        /// <summary>
        /// Тензометрический датчик/индуктивный полный мост (только для Spider8).
        /// </summary>
        StrainGageInductiveFullBridge = 350,

        /// <summary>
        /// Тензометрический датчик/индуктивный полумост (только для Spider8).
        /// </summary>
        StrainGageInductiveHalfBridge = 351,

        /// <summary>
        /// Четвертьмост (только для Spider8).
        /// </summary>
        QuarterBridge = 352,

        /// <summary>
        /// Полный тензометрический мост.
        /// </summary>
        StrainGageFullBridge = 353,

        /// <summary>
        /// Тензометрический полумост.
        /// </summary>
        StrainGageHalfBridge = 354,

        /// <summary>
        /// Тензометрический четвертьмост.
        /// </summary>
        StrainGageQuarterBridge = 355,

        /// <summary>
        /// Индуктивнй полный мост.
        /// </summary>
        InductiveFullBridge = 356,

        /// <summary>
        /// Индуктивнй полумост.
        /// </summary>
        InductiveHalfBridge = 357,

        /// <summary>
        /// Полный мост (ML10, низкий диапазон).
        /// </summary>
        FullBridgeLowRange = 358,

        /// <summary>
        /// Полумост (ML10, низкий диапазон).
        /// </summary>
        HalfBridgeLowRange = 359,

        /// <summary>
        /// Полный мост (ML10, высокий диапазон).
        /// </summary>
        FullBridgeHighRange = 360,

        /// <summary>
        /// Полумост (ML10, высокий диапазон).
        /// </summary>
        HalfBridgeHighRange = 361,

        /// <summary>
        /// Тензометрический полный мост 120 Ом (AP14).
        /// </summary>
        StrainGageFullBridge120Ohms = 362,

        /// <summary>
        /// Тензометрический полный мост 350 Ом (AP14).
        /// </summary>
        StrainGageFullBridge350Ohms = 363,

        /// <summary>
        /// Тензометрический полный мост 700 Ом (AP14).
        /// </summary>
        StrainGageFullBridge700Ohms = 364,

        /// <summary>
        /// Тензометрический полумост 120 Ом (AP14).
        /// </summary>
        StrainGageHalfBridge120Ohms = 365,

        /// <summary>
        /// Тензометрический полумост 350 Ом (AP14).
        /// </summary>
        StrainGageHalfBridge350Ohms = 366,

        /// <summary>
        /// Тензометрический полумост 700 Ом (AP14).
        /// </summary>
        StrainGageHalfBridge700Ohms = 367,

        /// <summary>
        /// Тензометрический четвертьмост 120 Ом 4-проводной (AP14, AP814).
        /// </summary>
        StrainGageQuarterBridge120Ohms4Wire = 368,

        /// <summary>
        /// Тензометрический четвертьмост 350 Ом 4-проводной (AP14, AP814).
        /// </summary>
        StrainGageQuarterBridge350Ohms4Wire = 369,

        /// <summary>
        /// Тензометрический четвертьмост 700 Ом 4-проводной (AP14, AP814).
        /// </summary>
        StrainGageQuarterBridge700Ohms4Wire = 370,

        /// <summary>
        /// Тензометрический четвертьмост 120 Ом 3-проводной (AP14, AP814).
        /// </summary>
        StrainGageQuarterBridge120Ohms3Wire = 371,

        /// <summary>
        /// Тензометрический четвертьмост 350 Ом 3-проводной (AP14, AP814).
        /// </summary>
        StrainGageQuarterBridge350Ohms3Wire = 372,

        /// <summary>
        /// Тензометрический четвертьмост 700 Ом 3-проводной (AP14, AP814).
        /// </summary>
        StrainGageQuarterBridge700Ohms3Wire = 373,

        /// <summary>
        /// Тензометрический четвертьмост 1000 Ом 3-проводной (AP814 опционально).
        /// </summary>
        StrainGageQuarterBridge1000Ohms3Wire = 374,

        /// <summary>
        /// Тензометрический четвертьмост 3-проводной, пользовательский специальный резистор (AP814 опционально).
        /// </summary>
        StrainGageQuarterBridge3WireUserSpecificResistor = 375,

        /// <summary>
        /// Тензометрический четвертьмост 1000 Ом 4-проводной (AP815 опционально).
        /// </summary>
        StrainGageQuarterBridge1000Ohms4wire = 376,

        /// <summary>
        /// Тензометрический четвертьмост 4-проводной, пользовательский специальный резистор (AP815 опционально).
        /// </summary>
        StrainGageQuarterBridge4WireUserSpecificResistor = 377,

        /// <summary>
        /// Индуктивный датчик линейных перемещений.
        /// </summary>
        LVDT = 380,

        /// <summary>
        /// Потенциометр (AP836).
        /// </summary>
        Potentiometer = 385,

        /// <summary>
        /// Напряжение постоянного тока (только для Spider8).
        /// </summary>
        DCVolt = 420,

        /// <summary>
        /// Сила постоянного тока (только для Spider8).
        /// </summary>
        DCAmpere = 421,

        /// <summary>
        /// Постоянный ток 75 мВ.
        /// </summary>
        DC75mV = 425,

        /// <summary>
        /// Постоянный ток 10 В.
        /// </summary>
        DC10V = 426,

        /// <summary>
        /// Постоянный ток 20 мА.
        /// </summary>
        DC20mA = 427,

        /// <summary>
        /// Термопара типа J.
        /// </summary>
        ThermocoupleTypeJ = 450,

        /// <summary>
        /// Термопара типа K.
        /// </summary>
        ThermocoupleTypeK = 451,

        /// <summary>
        /// Термопара типа T.
        /// </summary>
        ThermocoupleTypeT = 452,

        /// <summary>
        /// Термопара типа S.
        /// </summary>
        ThermocoupleTypeS = 453,

        /// <summary>
        /// Термопара типа B (только для Spider8).
        /// </summary>
        ThermocoupleTypeB = 454,

        /// <summary>
        /// Термопара типа E (только для Spider8).
        /// </summary>
        ThermocoupleTypeE = 455,

        /// <summary>
        /// Термопара типа R (только для Spider8).
        /// </summary>
        ThermocoupleTypeR = 456,

        /// <summary>
        /// Термопара типа N (только для ML801).
        /// </summary>
        ThermocoupleTypeN = 457,

        /// <summary>
        /// Термопара типа I.
        /// </summary>
        ThermocoupleTypeI = 510,

        /// <summary>
        /// Резистор 500 Ом.
        /// </summary>
        Resistor500Ohms = 476,

        /// <summary>
        /// Резистор 5000 Ом.
        /// </summary>
        Resistor5000Ohms = 477,

        /// <summary>
        /// Резистор 2500 Ом.
        /// </summary>
        Resistor2500Ohms = 478,

        /// <summary>
        /// Резистор 50 Ом.
        /// </summary>
        Resistor50Ohms = 479,

        /// <summary>
        /// Потенциометр Pt10.
        /// </summary>
        Pt10 = 500,

        /// <summary>
        /// Потенциометр Pt100.
        /// </summary>
        Pt100 = 501,

        /// <summary>
        /// Потенциометр Pt500.
        /// </summary>
        Pt500 = 502,

        /// <summary>
        /// Потенциометр Pt1000.
        /// </summary>
        Pt1000 = 503,

        /// <summary>
        /// Частота (только для Spider8).
        /// </summary>
        Frequency = 520,

        /// <summary>
        /// Двухфазный 1x (только для Spider8).
        /// </summary>
        TwoPhases1x = 522,

        /// <summary>
        /// Двухфазный 2x (только для Spider8).
        /// </summary>
        TwoPhases2x = 523,

        /// <summary>
        /// Счетчик (только для Spider8).
        /// </summary>
        Counter = 525,

        /// <summary>
        /// Счетчик x 1000 (только для ML60B).
        /// </summary>
        Counter1000 = 526,

        /// <summary>
        /// Широтно-импульсная модуляция (только для ML460).
        /// </summary>
        PulseWidthModulation = 527,

        /// <summary>
        /// Частота 1 кГц.
        /// </summary>
        Frequency1kHz = 536,

        /// <summary>
        /// Частота 2 кГц.
        /// </summary>
        Frequency2kHz = 530,

        /// <summary>
        /// Частота 10 кГц.
        /// </summary>
        Frequency10kHz = 535,

        /// <summary>
        /// Частота 20 кГц.
        /// </summary>
        Frequency20kHz = 531,

        /// <summary>
        /// Частота 100 кГц.
        /// </summary>
        Frequency100kHz = 534,

        /// <summary>
        /// Частота 200 кГц.
        /// </summary>
        Frequency200kHz = 532,

        /// <summary>
        /// Частота 500 кГц (только для ML460).
        /// </summary>
        Frequency500kHz = 538,

        /// <summary>
        /// Частота 1 МГц.
        /// </summary>
        Frequency1MHz = 533,

        /// <summary>
        /// Частота 2 МГц.
        /// </summary>
        Frequency2MHz = 537,

        /// <summary>
        /// Акселерометр 0.1 В (AP18).
        /// </summary>
        Deltatron0_1V = 550,

        /// <summary>
        /// Акселерометр 1 В (AP18).
        /// </summary>
        Deltatron1V = 551,

        /// <summary>
        /// Акселерометр 10 В (AP18).
        /// </summary>
        Deltatron10V = 552,

        /// <summary>
        /// 0.1 nC (AP08).
        /// </summary>
        NC0_1 = 570,

        /// <summary>
        /// 1 nC (AP08).
        /// </summary>
        NC1 = 571,

        /// <summary>
        /// 10 nC (AP08).
        /// </summary>
        NC10 = 572,

        /// <summary>
        /// 100 nC (AP08).
        /// </summary>
        NC100 = 573
    }
}
