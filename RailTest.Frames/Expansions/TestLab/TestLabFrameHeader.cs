using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailTest.Frames
{
    /// <summary>
    /// Представляет заголовок кадра в формате <see cref="StorageFormat.TestLab"/>.
    /// </summary>
    internal class TestLabFrameHeader : FrameHeader
    {
        /// <summary>
        /// Поле для хранения название испытаний.
        /// </summary>
        private string _Title;

        /// <summary>
        /// Поле для хранения названия типа испытаний.
        /// </summary>
        private string _Character;

        /// <summary>
        /// Поле для хранения названия места проведения испытаний.
        /// </summary>
        private string _Region;

        /// <summary>
        /// Поле для хранения времени проведения испытаний.
        /// </summary>
        private DateTime _Time;

        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        public TestLabFrameHeader() : base(StorageFormat.TestLab)
        {
            _Title = "";
            _Character = "";
            _Region = "";
            _Time = DateTime.Now;
        }

        /// <summary>
        /// Возвращает или задаёт название испытаний.
        /// </summary>
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value ?? "";
            }
        }

        /// <summary>
        /// Возвращает или задаёт название типа испытаний.
        /// </summary>
        public string Character
        {
            get
            {
                return _Character;
            }
            set
            {
                _Character = value ?? "";
            }
        }

        /// <summary>
        /// Возвращает или задаёт название места проведения испытаний.
        /// </summary>
        public string Region
        {
            get
            {
                return _Region;
            }
            set
            {
                _Region = value ?? "";
            }
        }

        /// <summary>
        /// Возвращает или задаёт время проведения испытаний.
        /// </summary>
        public DateTime Time
        {
            get
            {
                return _Time;
            }
            set
            {
                _Time = value;
            }
        }

        /// <summary>
        /// Создаёт копию объекта.
        /// </summary>
        /// <returns>
        /// Копия объекта.
        /// </returns>
        internal override FrameHeader Clone()
        {
            TestLabFrameHeader duplicate = new TestLabFrameHeader();
            duplicate.Title = Title;
            duplicate.Character = Character;
            duplicate.Region = Region;
            duplicate.Time = Time;
            return duplicate;
        }
    }
}
