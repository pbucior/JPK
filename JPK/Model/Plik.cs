using System.ComponentModel;

namespace JPK
{
    public class Plik : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _status { get; set; }
        private bool _czyPolaczony { get; set; }
        private string _nazwa { get; set; }
        private string _idPliku { get; set; }

        public bool Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        public bool CzyPolaczony
        {
            get { return _czyPolaczony; }
            set
            {
                _czyPolaczony = value;
                OnPropertyChanged("CzyPolaczony");
            }
        }

        public string Nazwa
        {
            get { return _nazwa; }
            set
            {
                _nazwa = value;
                OnPropertyChanged("Nazwa");
            }
        }

        public string IdPliku
        {
            get { return _idPliku; }
            set
            {
                _idPliku = value;
                OnPropertyChanged("IdPliku");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
    }
}
