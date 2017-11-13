using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using VocabularyWords.Command;
using VocabularyWords.Model;

namespace VocabularyWords.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {

        public Model.Random Random { get; set; }

        #region Binding

        public ObservableCollection<WordViewModel> Words { get; private set; }

        private string _path;
        public string Path
        {
            get { return _path; }
            set
            {
                _path = value;
                OnPropertyChanged("Path");                
            }
        }

        #endregion

        #region Command

        private Command.AppCommand _selectDir;
        public Command.AppCommand SelectDir
        {
            get
            {
                return _selectDir ??
                    (_selectDir = new Command.AppCommand(() =>
                    {
                        var dialog = new FolderBrowserDialog();
                        Path = dialog.ShowDialog() == DialogResult.OK ? dialog.SelectedPath : Path;
                    }));
            }
        }

        private Command.AppCommand _start;
        public Command.AppCommand Start
        {
            get
            {
                return _start ??
                    (_start = new Command.AppCommand(() => 
                    {
                        Random = new Model.Random(new Reader(Path, ShowMessage), AddWords);
                    }));
            }
        }

        private Command.AppCommand _clear;
        public Command.AppCommand Clear
        {
            get
            {
                return _clear ??
                    (_clear = new Command.AppCommand(() =>
                    {
                        Random.Stop();                  
                        Words.Clear();
                        Guardian.Clear();
                    }));
            }
        }

        #endregion

        private void ShowMessage(string error)
        {
            MessageBox.Show(error);
        }

        private void AddWords(KeyValuePair<string, int> word)
        {
            System.Windows.Application.Current.Dispatcher.BeginInvoke((Action)delegate
            {
                Words.Add(Guardian.Push(word.Key, word.Value));
            });
        }

        public MainWindowViewModel()
        {
            Words = new ObservableCollection<WordViewModel>();
        }
    }
}
