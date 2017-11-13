namespace VocabularyWords.Model
{
    class Wordmodel
    {
        public Wordmodel(string word, long count)
        {
            Word = word;
            Count = count;
        }
        
        public string Word { get; }
        
        public long Count { get; }
    }
}
