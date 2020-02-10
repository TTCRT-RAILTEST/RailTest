using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailTest.Frames
{
    /// <summary>
    /// Представляет знечение, определяющее код частоты фильтра.
    /// </summary>
    internal enum CatmanCodeOfFilterFrequency
    {
        /// <summary>
        /// Частота фильтра 0.01 Гц.
        /// </summary>
        Frequency0_01Hz = 901,

        /// <summary>
        /// Частота фильтра 0.012 Гц.
        /// </summary>
        Frequency0_012Hz = 902,

        /// <summary>
        /// Частота фильтра 0.015 Гц.
        /// </summary>
        Frequency0_015Hz = 903,

        /// <summary>
        /// Частота фильтра 0.02 Гц.
        /// </summary>
        Frequency0_02Hz = 904,

        /// <summary>
        /// Частота фильтра 0.025 Гц.
        /// </summary>
        Frequency0_025Hz = 905,

        /// <summary>
        /// Частота фильтра 0.03 Гц.
        /// </summary>
        Frequency0_03Hz = 906,

        /// <summary>
        /// Частота фильтра 0.04 Гц.
        /// </summary>
        Frequency0_04Hz = 907,

        /// <summary>
        /// Частота фильтра 0.05 Гц.
        /// </summary>
        Frequency0_05Hz = 908,

        /// <summary>
        /// Частота фильтра 0.06 Гц.
        /// </summary>
        Frequency0_06Hz = 909,

        /// <summary>
        /// Частота фильтра 0.07 Гц.
        /// </summary>
        Frequency0_07Hz = 910,

        /// <summary>
        /// Частота фильтра 0.075 Гц.
        /// </summary>
        Frequency0_075Hz = 911,

        /// <summary>
        /// Частота фильтра 0.08 Гц.
        /// </summary>
        Frequency0_08Hz = 912,

        /// <summary>
        /// Частота фильтра 0.09 Гц.
        /// </summary>
        Frequency0_09Hz = 913,

        /// <summary>
        /// Частота фильтра 0.1 Гц.
        /// </summary>
        Frequency0_1Hz = 914,

        /// <summary>
        /// Частота фильтра 0.12 Гц.
        /// </summary>
        Frequency0_12Hz = 915,

        /// <summary>
        /// Частота фильтра 0.15 Гц.
        /// </summary>
        Frequency0_15Hz = 916,

        /// <summary>
        /// Частота фильтра 0.2 Гц.
        /// </summary>
        Frequency0_2Hz = 917,

        /// <summary>
        /// Частота фильтра 0.25 Гц.
        /// </summary>
        Frequency0_25Hz = 918,

        /// <summary>
        /// Частота фильтра 0.3 Гц.
        /// </summary>
        Frequency0_3Hz = 919,

        /// <summary>
        /// Частота фильтра 0.4 Гц.
        /// </summary>
        Frequency0_4Hz = 920,

        /// <summary>
        /// Частота фильтра 0.5 Гц.
        /// </summary>
        Frequency0_5Hz = 921,

        /// <summary>
        /// Частота фильтра 0.6 Гц.
        /// </summary>
        Frequency0_6Hz = 922,

        /// <summary>
        /// Частота фильтра 0.7 Гц.
        /// </summary>
        Frequency0_7Hz = 923,

        /// <summary>
        /// Частота фильтра 0.75 Гц.
        /// </summary>
        Frequency0_75Hz = 924,

        /// <summary>
        /// Частота фильтра 0.8 Гц.
        /// </summary>
        Frequency0_8Hz = 925,

        /// <summary>
        /// Частота фильтра 0.9 Гц.
        /// </summary>
        Frequency0_9Hz = 926,

        /// <summary>
        /// Частота фильтра 1 Гц.
        /// </summary>
        Frequency1Hz = 927,

        /// <summary>
        /// Частота фильтра 1.2 Гц.
        /// </summary>
        Frequency1_2Hz = 928,

        /// <summary>
        /// Частота фильтра 1.25 Гц.
        /// </summary>
        Frequency1_25Hz = 929,

        /// <summary>
        /// Частота фильтра 1.5 Гц.
        /// </summary>
        Frequency1_5Hz = 930,

        /// <summary>
        /// Частота фильтра 2 Гц.
        /// </summary>
        Frequency2Hz = 931,

        /// <summary>
        /// Частота фильтра 2.5 Гц.
        /// </summary>
        Frequency2_5Hz = 932,

        /// <summary>
        /// Частота фильтра 3 Гц.
        /// </summary>
        Frequency3Hz = 933,

        /// <summary>
        /// Частота фильтра 4 Гц.
        /// </summary>
        Frequency4Hz = 934,

        /// <summary>
        /// Частота фильтра 5 Гц.
        /// </summary>
        Frequency5Hz = 935,

        /// <summary>
        /// Частота фильтра 6 Гц.
        /// </summary>
        Frequency6Hz = 936,

        /// <summary>
        /// Частота фильтра 7 Гц.
        /// </summary>
        Frequency7Hz = 937,

        /// <summary>
        /// Частота фильтра 7.5 Гц.
        /// </summary>
        Frequency7_5Hz = 938,

        /// <summary>
        /// Частота фильтра 8 Гц.
        /// </summary>
        Frequency8Hz = 939,

        /// <summary>
        /// Частота фильтра 9 Гц.
        /// </summary>
        Frequency9Hz = 940,

        /// <summary>
        /// Частота фильтра 10 Гц.
        /// </summary>
        Frequency10Hz = 941,

        /// <summary>
        /// Частота фильтра 12 Гц.
        /// </summary>
        Frequency12Hz = 942,

        /// <summary>
        /// Частота фильтра 15 Гц.
        /// </summary>
        Frequency15Hz = 943,

        /// <summary>
        /// Частота фильтра 17.5 Гц.
        /// </summary>
        Frequency17_5Hz = 944,

        /// <summary>
        /// Частота фильтра 20 Гц.
        /// </summary>
        Frequency20Hz = 945,

        /// <summary>
        /// Частота фильтра 25 Гц.
        /// </summary>
        Frequency25Hz = 946,

        /// <summary>
        /// Частота фильтра 30 Гц.
        /// </summary>
        Frequency30Hz = 947,

        /// <summary>
        /// Частота фильтра 40 Гц.
        /// </summary>
        Frequency40Hz = 948,

        /// <summary>
        /// Частота фильтра 50 Гц.
        /// </summary>
        Frequency50Hz = 949,

        /// <summary>
        /// Частота фильтра 60 Гц.
        /// </summary>
        Frequency60Hz = 950,

        /// <summary>
        /// Частота фильтра 70 Гц.
        /// </summary>
        Frequency70Hz = 951,

        /// <summary>
        /// Частота фильтра 75 Гц.
        /// </summary>
        Frequency75Hz = 952,

        /// <summary>
        /// Частота фильтра 80 Гц.
        /// </summary>
        Frequency80Hz = 953,

        /// <summary>
        /// Частота фильтра 90 Гц.
        /// </summary>
        Frequency90Hz = 954,

        /// <summary>
        /// Частота фильтра 100 Гц.
        /// </summary>
        Frequency100Hz = 955,

        /// <summary>
        /// Частота фильтра 120 Гц.
        /// </summary>
        Frequency120Hz = 956,

        /// <summary>
        /// Частота фильтра 150 Гц.
        /// </summary>
        Frequency150Hz = 957,

        /// <summary>
        /// Частота фильтра 200 Гц.
        /// </summary>
        Frequency200Hz = 958,

        /// <summary>
        /// Частота фильтра 250 Гц.
        /// </summary>
        Frequency250Hz = 959,

        /// <summary>
        /// Частота фильтра 300 Гц.
        /// </summary>
        Frequency300Hz = 960,

        /// <summary>
        /// Частота фильтра 400 Гц.
        /// </summary>
        Frequency400Hz = 961,

        /// <summary>
        /// Частота фильтра 500 Гц.
        /// </summary>
        Frequency500Hz = 962,

        /// <summary>
        /// Частота фильтра 550 Гц.
        /// </summary>
        Frequency550Hz = 963,

        /// <summary>
        /// Частота фильтра 600 Гц.
        /// </summary>
        Frequency600Hz = 964,

        /// <summary>
        /// Частота фильтра 700 Гц.
        /// </summary>
        Frequency700Hz = 965,

        /// <summary>
        /// Частота фильтра 750 Гц.
        /// </summary>
        Frequency750Hz = 966,

        /// <summary>
        /// Частота фильтра 800 Гц.
        /// </summary>
        Frequency800Hz = 967,

        /// <summary>
        /// Частота фильтра 900 Гц.
        /// </summary>
        Frequency900Hz = 968,

        /// <summary>
        /// Частота фильтра 1 кГц.
        /// </summary>
        Frequency1kHz = 969,

        /// <summary>
        /// Частота фильтра 1.1 кГц.
        /// </summary>
        Frequency1_1kHz = 970,

        /// <summary>
        /// Частота фильтра 1.2 кГц.
        /// </summary>
        Frequency1_2kHz = 971,

        /// <summary>
        /// Частота фильтра 1.5 кГц.
        /// </summary>
        Frequency1_5kHz = 972,

        /// <summary>
        /// Частота фильтра 2 кГц.
        /// </summary>
        Frequency2kHz = 973,

        /// <summary>
        /// Частота фильтра 2.4 кГц.
        /// </summary>
        Frequency2_4kHz = 974,

        /// <summary>
        /// Частота фильтра 2.5 кГц.
        /// </summary>
        Frequency2_5kHz = 975,

        /// <summary>
        /// Частота фильтра 3 кГц.
        /// </summary>
        Frequency3kHz = 976,

        /// <summary>
        /// Частота фильтра 4 кГц.
        /// </summary>
        Frequency4kHz = 977,

        /// <summary>
        /// Частота фильтра 5 кГц.
        /// </summary>
        Frequency5kHz = 978,

        /// <summary>
        /// Частота фильтра 6 кГц.
        /// </summary>
        Frequency6kHz = 979,

        /// <summary>
        /// Частота фильтра 7 кГц.
        /// </summary>
        Frequency7kHz = 980,

        /// <summary>
        /// Частота фильтра 7.5 кГц.
        /// </summary>
        Frequency7_5kHz = 981,

        /// <summary>
        /// Частота фильтра 8 кГц.
        /// </summary>
        Frequency8kHz = 982,

        /// <summary>
        /// Частота фильтра 9 кГц.
        /// </summary>
        Frequency9kHz = 983,

        /// <summary>
        /// Частота фильтра 10 кГц.
        /// </summary>
        Frequency10kHz = 1100,

        /// <summary>
        /// Частота фильтра 50 кГц.
        /// </summary>
        Frequency50kHz = 1140,

        /// <summary>
        /// Частота фильтра 100 кГц.
        /// </summary>
        Frequency100kHz = 1150,

        /// <summary>
        /// Без фильтра.
        /// </summary>
        FrequencyNone = 1199
    }
}
