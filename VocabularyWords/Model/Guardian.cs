using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VocabularyWords.ViewModel;

namespace VocabularyWords.Model
{
    /// <summary>
    /// Хранитель коллекции
    /// </summary>
    internal static class Guardian
    {
        static Stack<WordViewModel> _words = new Stack<WordViewModel>();

        /// <summary>
        /// Возвращает коллекцию слов
        /// </summary>
        /// <returns></returns>
        internal static List<WordViewModel> GetWords() =>
            _words.ToList();

        /// <summary>
        /// Добавляет слово в хранилище
        /// </summary>
        /// <param name="word">Элементарная частица</param>
        internal static WordViewModel Push(string word, int count)
        {
            _words.Push(Factory.CreateWord(word, count));
            return _words.Peek();
        }

        /// <summary>
        /// очищает хранилище
        /// </summary>
        internal static void Clear()
        {
            _words.Clear();
        }


        static class Factory
        {
            internal static WordViewModel CreateWord(string word, int count)
            {
                return new WordViewModel(word, count);
            }
        }
    }
}
