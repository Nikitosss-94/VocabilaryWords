using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyWords.ViewModel
{
    class WordViewModel : INotifyPropertyChanged
    {
        public WordViewModel(string word, int count)
        {
            _word = word;
            _count = count.ToString();
        }

        private string _word;
        public string Word
        {
            get { return _word; }
        }

        private string _count;

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public string Count
        {
            get { return _count; }
        }
    }
}
