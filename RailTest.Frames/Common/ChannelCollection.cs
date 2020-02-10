using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailTest.Frames
{
    /// <summary>
    /// Представляет коллекцию каналов.
    /// </summary>
    public class ChannelCollection : Ancestor, IEnumerable<Channel>
    {
        private readonly List<Channel> _Items;

        internal ChannelCollection()
        {
            _Items = new List<Channel>();
        }

        /// <summary>
        /// Добавляет канал в конец коллекции.
        /// </summary>
        /// <param name="channel">
        /// Канал, который добавляется в конец коллекции.
        /// </param>
        public void Add(Channel channel)
        {
            _Items.Add(channel);
        }

        /// <summary>
        /// Добавляет каналы в конец коллекции.
        /// </summary>
        /// <param name="collection">
        /// Коллекция добавляемых каналов.
        /// </param>
        public void AddRange(IEnumerable<Channel> collection)
        {
            foreach (Channel channel in collection)
            {
                Add(channel);
            }
        }

        /// <summary>
        /// Удаляет канал из коллекции.
        /// </summary>
        /// <param name="channel">
        /// Канал, удаляемый из коллекции.
        /// </param>
        public void Remove(Channel channel)
        {
            _Items.Remove(channel);
        }

        /// <summary>
        /// Удаляет все каналы из коллекции.
        /// </summary>
        public void Clear()
        {
            _Items.Clear();
        }

        /// <summary>
        /// Возвращает количество каналов.
        /// </summary>
        public int Count => _Items.Count;

        /// <summary>
        /// Возвращает канал с указанным индексом.
        /// </summary>
        /// <param name="index">
        /// Индекс канала.
        /// </param>
        /// <returns>
        /// Канал с указанным индексом.
        /// </returns>
        public Channel this[int index]
        {
            get
            {
                return _Items[index];
            }
        }

        /// <summary>
        /// Проверяет, содержится ли канал с указанным именем в коллеции.
        /// </summary>
        /// <param name="name">
        /// Имя канала.
        /// </param>
        /// <returns>
        /// Результат проверки.
        /// </returns>
        public bool Contains(string name)
        {
            foreach (Channel channel in this)
            {
                if (channel.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Возвращает перечислитель коллекции.
        /// </summary>
        /// <returns>
        /// Перечислитель коллекции.
        /// </returns>
        public IEnumerator<Channel> GetEnumerator()
        {
            return ((IEnumerable<Channel>)_Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Channel>)_Items).GetEnumerator();
        }

        /// <summary>
        /// Возвращает перый канал с указанным именем.
        /// </summary>
        /// <param name="name">
        /// Имя канала.
        /// </param>
        /// <returns>
        /// Первый канал с указанным именем.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Коллекция не содержит ни одного канала с указанным именем.
        /// </exception>
        public Channel this[string name]
        {
            get
            {
                foreach (Channel channel in this)
                {
                    if (channel.Name == name)
                    {
                        return channel;
                    }
                }
                throw new ArgumentOutOfRangeException("name", "Коллекция не содержит канал с указанным именем.");
            }
        }
    }
}
