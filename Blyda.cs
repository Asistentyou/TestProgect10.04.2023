using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MVVC
{
    class Blyda : INotifyPropertyChanged
    {
        private string title;
        private string razdel;
        private string ingridient;
        private string opicanie;
        private string kalor;
        private int price;
        private string photo;

        public Blyda()
        {

        }
        public Blyda(string title, string razdel, string ingridient, string opicanie, string kalor, int price, string photo)
        {
            this.title = title;
            this.razdel = razdel;
            this.ingridient = ingridient;
            this.opicanie =  opicanie;
            this.kalor = kalor;
            this.price = price;
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Razdel
        {
            get { return razdel; }
            set
            {
                razdel = value;
                OnPropertyChanged("Razdel");
            }
        }
        public string Ingridient
        {
            get { return ingridient; }
            set
            {
                ingridient = value;
                OnPropertyChanged("Ingridient");
            }
        }
        public string Opicanie
        {
            get { return opicanie; }
            set
            {
                opicanie = value;
                OnPropertyChanged("Opicanie");
            }
        }
        public string Kalor
        {
            get { return kalor; }
            set
            {
                kalor = value;
                OnPropertyChanged("Kalor");
            }
        }
        public int Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        public string Photo
        {
            get { return photo; }
            set
            {
                photo = value;
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