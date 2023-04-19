using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MVVC
{
    class BlydaViewModel : INotifyPropertyChanged
    {
        private Blyda blyda;
        public BlydaViewModel(Blyda p)
        {
            blyda = p;
        }
        public string Title
        {
            get { return blyda.Title; }
            set
            {
                blyda.Title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Razdel
        {
            get { return blyda.Razdel; }
            set
            {
                blyda.Razdel = value;
                OnPropertyChanged("Razdel");
            }
        }
        public string Ingridient
        {
            get { return blyda.Ingridient; }
            set
            {
                blyda.Ingridient = value;
                OnPropertyChanged("Ingridient");
            }
        }
        public string Opicanie
        {
            get { return blyda.Opicanie; }
            set
            {
                blyda.Opicanie = value;
                OnPropertyChanged("Opicanie");
            }
        }
        public string Kalor
        {
            get { return blyda.Kalor; }
            set
            {
                blyda.Kalor = value;
                OnPropertyChanged("Kalor");
            }
        }
        public int Price
        {
            get { return blyda.Price; }
            set
            {
                blyda.Price = value;
                OnPropertyChanged("Price");
            }
        }
        public string Photo
        {
            get { return blyda.Photo; }
            set
            {
                blyda.Photo = value;
                OnPropertyChanged("Photo");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}