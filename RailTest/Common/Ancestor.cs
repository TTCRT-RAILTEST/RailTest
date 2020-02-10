namespace RailTest
{
    /// <summary>
    /// Представляет базовый класс для всех объектов пространства имён <see cref="RailTest"/>.
    /// </summary>
    /// <example>
    /// В следующем примере показано использование класса <see cref="Ancestor"/> в качестве родителя:
    /// <code language="cs">
    /// class SampleClass : Ancestor
    /// {
    ///     //  Тело класса.
    /// }
    /// </code>
    /// </example>
    /// <remarks>
    /// Класс <see cref="Ancestor"/> предоставляет базовые механизмы,
    /// которые необходимы для всех классов пространства имён <see cref="RailTest"/>.
    /// При реализации новых классов в  пространстве имён <see cref="RailTest"/>
    /// необходимо всегда, когда это возможно, использовать в качестве родителя этот класс или одного из потомков этого класса.
    /// </remarks>
    public class Ancestor
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса.
        /// </summary>
        /// <example>
        /// В следующем примере показано использование конструктора класса <see cref="Ancestor"/>:
        /// <code language="cs">
        /// Ancestor ancestor = new Ancestor();
        /// </code>
        /// </example>
        public Ancestor()
        {

        }

        /// <summary>
        /// Возвращает объект, который используется для синхронизации доступа.
        /// </summary>
        /// <example>
        /// В следующем примере показано использование объекта, который используется для синхронизации доступа:
        /// <code language="cs">
        /// Ancestor ancestor;
        /// lock (ancestor.SyncRoot)
        /// {
        ///     //  Работа с критическими объектами.
        /// }
        /// </code>
        /// </example>
        public object SyncRoot => this;
    }
}
