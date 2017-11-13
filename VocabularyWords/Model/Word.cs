namespace VocabularyWords.Model
{
    class Wordmodel
    {
        public Wordmodel(string word, int count)
        {
            _word = word;
            _count = count;
        }

        private string _word;
        public string Word
        {
            get { return _word; }
        }

        private int _count;
        public int Count
        {
            get { return _count; }
        }
    }
}
