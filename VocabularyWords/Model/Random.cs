using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace VocabularyWords.Model
{
    /// <summary>
    /// Выбор случайного слова
    /// </summary>
    class Random
    {
        /// <summary>
        /// передача выбранного слова 
        /// </summary>
        /// <param name="word"></param>
        public delegate void Write(KeyValuePair<string, int> word);

        Reader _reader;
        System.Random r = new System.Random();
        Timer _timer;

        /// <summary>
        /// запуск таймера для выбора случайного слова
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="write"></param>
        public Random(Reader reader, Write write)
        {
            if (reader.Vocabilaries != null)
            {
                _reader = reader;
                _timer = new Timer(new TimerCallback(b => write(reader.Vocabilaries.ElementAt(r.Next(reader.Vocabilaries.Count)))), 0, 0, 1000);
            }
        }

        /// <summary>
        /// остановка таймера
        /// </summary>
        public void Stop()
        {
            _reader = null;
            _timer.Dispose();
        }
    }
}
