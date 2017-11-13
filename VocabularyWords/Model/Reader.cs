using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyWords.Model
{
    /// <summary>
    /// Объект читающий текстовые файлы
    /// </summary>
    class Reader
    {
        /// <summary>
        /// возникновение ошибки при обращении к каталогу
        /// </summary>
        /// <param name="error"></param>
        public delegate void ShowMessage(string error);

        /// <summary>
        /// Словарь
        /// </summary>
        private ConcurrentDictionary<string, int> _vocabilaries;
        public ConcurrentDictionary<string, int> Vocabilaries { get { return _vocabilaries; } }

        public Reader(string path, ShowMessage message)
        {
            if (Directory.Exists(path))
            {
                string[] filePaths = Directory.GetFiles(path, "*txt");
                if (filePaths.Length > 0)
                {
                    _vocabilaries = new ConcurrentDictionary<string, int>();
                    Parallel.ForEach(filePaths, file =>
                    {
                        using (var read = new StreamReader(file, Encoding.Default))
                            while (!read.EndOfStream)
                            {
                                var separators = new char[] { ' ', '.', ',', '!', '?', '»', '«' };
                                var words = read.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                                Parallel.ForEach(words, word => _vocabilaries.AddOrUpdate(word, 1, (key, oldValue) => oldValue + 1));
                            }
                    });                    
                }
                else
                    message("Каталог пуст, выберите другой каталог");
            }
            else
                message("Каталог не существует, выберите другой каталог");
        }
        
    }
}
