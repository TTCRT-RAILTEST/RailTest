namespace RailTest.Frames
{
    /// <summary>
    /// Значение, определяющее формат канала.
    /// </summary>
    internal enum TestLabDataFormat
    {
        /// <summary>
        /// Беззнаковое целое число размером 8 бит.
        /// </summary>
        UInt8 = 0x1,

        /// <summary>
        /// Беззнаковое целое число размером 16 бит.
        /// </summary>
        UInt16 = 0x2,

        /// <summary>
        /// Беззнаковое целое число размером 32 бита.
        /// </summary>
        UInt32 = 0x3,

        /// <summary>
        /// Знаковое целое число размером 8 бит.
        /// </summary>
        Int8 = 0x11,

        /// <summary>
        /// Знаковое целое число размером 16 бит.
        /// </summary>
        Int16 = 0x12,

        /// <summary>
        /// Знаковое целое число размером 32 бита.
        /// </summary>
        Int32 = 0x13,

        /// <summary>
        /// Число с плавающей точкой размером 32 бита.
        /// </summary>
        Float32 = 0x4,

        /// <summary>
        /// Число с плавающей точкой размером 64 бита.
        /// </summary>
        Float64 = 0x8
    }
}