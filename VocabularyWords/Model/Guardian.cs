using System.Collections.Generic;
using System.Linq;

namespace VocabularyWords.Model
{
    /// <summary>
    /// Хранитель коллекции
    /// </summary>
    internal static class Guardian
    {
        static Stack<Wordmodel> _words = new Stack<Wordmodel>();

        /// <summary>
        /// Возвращает коллекцию слов
        /// </summary>
        /// <returns></returns>
        internal static List<Wordmodel> GetWords() =>
            _words.ToList();

        /// <summary>
        /// Добавляет слово в хранилище
        /// </summary>
        /// <param name="word">Элементарная частица</param>
        internal static Wordmodel Push(string word, int count)
        {
            _words.Push(Factory.CreateWord(word, count));
            return _words.Peek();
        }

        /// <summary>
        /// очищает хранилище
        /// </summary>
        internal static void Clear() =>
            _words.Clear();


        static class Factory
        {
            internal static Wordmodel CreateWord(string word, int count) =>
                new Wordmodel(word, count);
        }
    }
}
