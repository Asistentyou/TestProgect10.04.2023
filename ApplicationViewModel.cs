using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System;
using System.Linq;

namespace MVVC
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        Blyda selectedPhone;

        IFileService fileService;
        IDialogService dialogService;

        public ObservableCollection<Blyda> Phones { get; set; }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SaveFileDialog() == true)
                          {
                              fileService.Save(dialogService.FilePath, Phones.ToList());
                              dialogService.ShowMessage("Файл сохранен");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }
        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog() == true)
                          {
                              var phones = fileService.Open(dialogService.FilePath);
                              Phones.Clear();
                              foreach (var p in phones)
                                  Phones.Add(p);
                              dialogService.ShowMessage("Файл открыт");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Blyda phone = new Blyda();
                      Phones.Insert(0, phone);
                      SelectedPhone = phone;
                  }));
            }
        }
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      Blyda phone = obj as Blyda;
                      if (phone != null)
                      {
                          Phones.Remove(phone);
                      }
                  },
                 (obj) => Phones.Count > 0));
            }
        }
        private RelayCommand doubleCommand;
        public RelayCommand DoubleCommand
        {
            get
            {
                return doubleCommand ??
                  (doubleCommand = new RelayCommand(obj =>
                  {
                      Blyda phone = obj as Blyda;
                      if (phone != null)
                      {
                          Blyda phoneCopy = new Blyda
                          {
                              Title = phone.Title,
                              Razdel = phone.Razdel,
                              Ingridient = phone.Ingridient,
                              Opicanie = phone.Opicanie,
                              Kalor = phone.Kalor,
                              Price = phone.Price,
                              Photo = phone.Photo

                          };
                          Phones.Insert(0, phoneCopy);
                      }
                  }));
            }
        }
        public Blyda SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }
        public ApplicationViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;

            Phones = new ObservableCollection<Blyda>
            {
                new Blyda {Title="Салат перевертыш", Razdel="Салаты",Ingridient="шампиньон", Opicanie="Очень вкусное",
                    Kalor="350", Price=1000, Photo=@"C:\Users\Дмитрий\Desktop\MVVC\7WCSQCAsrOk.jpg" },
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}